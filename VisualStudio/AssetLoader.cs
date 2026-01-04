namespace AmmoToolsMod;

// Credit to Deadman for the texture loading stuff.
internal class AssetBundleLoader
{
    internal static AssetBundle? LoadBundle(string path)
    {
        using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
        {
            MemoryStream? memory = new((int)stream.Length);
            stream!.CopyTo(memory);

            Il2CppSystem.IO.MemoryStream memoryStream = new Il2CppSystem.IO.MemoryStream(memory.ToArray());

            AssetBundle loadFromMemoryInternal = AssetBundle.LoadFromStream(memoryStream);
            return loadFromMemoryInternal;
        }
    }
}