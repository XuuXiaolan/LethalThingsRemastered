namespace LethalThingsRemastered.src.Util.Extensions;
static class ObjectExtensions
{
	public static string ToStringWithDefault(this object it, string defaultString = "null")
	{
		return it.ToString().OrIfEmpty(defaultString);
	} 
}