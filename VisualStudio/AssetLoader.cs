namespace AmmoToolsMod;

// Credit to Deadman for the texture loading stuff.
internal class AssetBundleLoader
{
    internal static AssetBundle? LoadBundle(string path)
    {
        AssetBundle? temp;
        MemoryStream? memory;
        Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);

        memory = new MemoryStream((int)stream.Length);
        stream.CopyTo(memory);

        temp = AssetBundle.LoadFromMemory(memory.ToArray());

        memory.Dispose();
        stream.Dispose();

        return temp;
    }
}