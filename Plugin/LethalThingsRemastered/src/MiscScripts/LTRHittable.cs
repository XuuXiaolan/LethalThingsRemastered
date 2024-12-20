using GameNetcodeStuff;
using Unity.Netcode;
using UnityEngine;

namespace LethalThingsRemastered.src.MiscScripts;
public abstract class LTRHittable : NetworkBehaviour
{
	public abstract bool Hit(int force, Vector3 hitDirection, PlayerControllerB? playerWhoHit = null, bool playHitSFX = false, int hitID = -1);
}