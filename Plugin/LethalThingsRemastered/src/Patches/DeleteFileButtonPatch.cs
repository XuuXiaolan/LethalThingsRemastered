using LethalThingsRemastered.src.Util;

namespace LethalThingsRemastered.src.Patches;

static class DeleteFileButtonPatch
{

	public static void Init()
    {
        On.DeleteFileButton.DeleteFile += DeleteFileButton_DeleteFile;
    }

    private static void DeleteFileButton_DeleteFile(On.DeleteFileButton.orig_DeleteFile orig, DeleteFileButton self)
    {
        orig(self);
		PersistentDataHandler.TryDelete($"LTRSave{self.fileToDelete}");

    }
}