using GameNetcodeStuff;
using UnityEngine;

namespace LethalThingsRemastered.src.MiscScripts;
public class ThrowableNoisemaker : NoisemakerProp
{
    public bool throwWithRight = false;
    public bool beingThrown = false;

    public override void ItemInteractLeftRight(bool right)
    {
        base.ItemInteractLeftRight(right);

        if (!IsOwner)
        {
            return;
        }

        if ((throwWithRight && right) || !right)
        {
            playerHeldBy.DiscardHeldObject(placeObject: true, null, GetItemThrowDestination());
        }
    }

    public override void EquipItem()
    {
        EnableItemMeshes(enable: true);
        playerHeldBy.equippedUsableItemQE = true;
        isPocketed = false;
    }

    public override void DiscardItem()
    {
        if (playerHeldBy != null)
        {
            playerHeldBy.equippedUsableItemQE = false;
        }
        base.DiscardItem();
    }

    public override void PocketItem()
    {
        if (base.IsOwner && playerHeldBy != null)
        {
            playerHeldBy.equippedUsableItemQE = false;
        }
        base.PocketItem();
    }

    public override void FallWithCurve()
    {
        float magnitude = (startFallingPosition - targetFloorPosition).magnitude;
        base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(itemProperties.restingRotation.x, base.transform.eulerAngles.y, itemProperties.restingRotation.z), 14f * Time.deltaTime / magnitude);
        base.transform.localPosition = Vector3.Lerp(startFallingPosition, targetFloorPosition, itemFallCurve.Evaluate(fallTime));
        if (magnitude > 5f)
        {
            base.transform.localPosition = Vector3.Lerp(new Vector3(base.transform.localPosition.x, startFallingPosition.y, base.transform.localPosition.z), new Vector3(base.transform.localPosition.x, targetFloorPosition.y, base.transform.localPosition.z), itemVerticalFallCurveNoBounce.Evaluate(fallTime));
        }
        else
        {
            base.transform.localPosition = Vector3.Lerp(new Vector3(base.transform.localPosition.x, startFallingPosition.y, base.transform.localPosition.z), new Vector3(base.transform.localPosition.x, targetFloorPosition.y, base.transform.localPosition.z), itemVerticalFallCurve.Evaluate(fallTime));
        }
        fallTime += Mathf.Abs(Time.deltaTime * 12f / magnitude);
    }


    public override void Update()
    {
        base.Update();
    }

    public Vector3 GetItemThrowDestination()
    {
        Vector3 position = base.transform.position;
        Debug.DrawRay(playerHeldBy.gameplayCamera.transform.position, playerHeldBy.gameplayCamera.transform.forward, Color.yellow, 15f);
        itemThrowRay = new Ray(playerHeldBy.gameplayCamera.transform.position, playerHeldBy.gameplayCamera.transform.forward);
        position = ((!Physics.Raycast(itemThrowRay, out itemHit, 12f, StartOfRound.Instance.collidersAndRoomMaskAndDefault, QueryTriggerInteraction.Ignore)) ? itemThrowRay.GetPoint(10f) : itemThrowRay.GetPoint(itemHit.distance - 0.05f));
        Debug.DrawRay(position, Vector3.down, Color.blue, 15f);
        itemThrowRay = new Ray(position, Vector3.down);
        if (Physics.Raycast(itemThrowRay, out itemHit, 30f, StartOfRound.Instance.collidersAndRoomMaskAndDefault, QueryTriggerInteraction.Ignore))
        {
            return itemHit.point + Vector3.up * 0.05f;
        }
        return itemThrowRay.GetPoint(30f);
    }

    public AnimationCurve itemFallCurve;

    public AnimationCurve itemVerticalFallCurve;

    public AnimationCurve itemVerticalFallCurveNoBounce;

    public RaycastHit itemHit;

    public Ray itemThrowRay;

    private PlayerControllerB playerThrownBy;
}