namespace AmmoToolsMod;

// Credit to Deadman for the texture loading stuff.
internal static class TextureSwapper
{
    private static readonly AssetBundle? AmmoToolsAssetBundle =
        AssetBundleLoader.LoadBundle("AmmoTools.Assets.ammotoolsassets");

    private static readonly Dictionary<string, Texture2D> textures = LoadTexturesFromAssetBundle();

    private static Dictionary<string, Texture2D> LoadTexturesFromAssetBundle()
    {
        var loadedTextures = new Dictionary<string, Texture2D>();
        if (AmmoToolsAssetBundle == null)
        {
            UnityEngine.Debug.LogWarning("AssetBundle is null!");
            return loadedTextures;
        }

        foreach (var texture in AmmoToolsAssetBundle.LoadAllAssets<Texture2D>())
        {
            loadedTextures[texture.name] = texture;
        }

        return loadedTextures;
    }

    internal static void SwapGearItemTexture(string gearItemName, string gameObjectName, string newTextureName)
    {
        if (!textures.TryGetValue(newTextureName, out var newTexture)) return;

        var gearItemPrefab = GearItem.LoadGearItemPrefab(gearItemName);
        if (gearItemPrefab == null) return;

        foreach (var renderer in gearItemPrefab.GetComponentsInChildren<Renderer>(true))
        {
            if (renderer.gameObject.name == gameObjectName)
            {
                foreach (var material in renderer.materials)
                {
                    material.mainTexture = newTexture;
                }
            }
        }
    }

    [HarmonyPatch(typeof(Utils), nameof(Utils.GetInventoryIconTexture), new Type[] { typeof(GearItem) })]
    private static class GenericIconTextureSwap
    {
        private static bool Prefix(GearItem gi, ref Texture2D __result)
        {
            if (gi == null) return true;

            string textureName = TextureSwap.GetTextureNameForGearItem(gi);
            if (string.IsNullOrEmpty(textureName)) return true;

            if (textures.TryGetValue(textureName, out Texture2D? newTexture))
            {
                __result = newTexture;
                return false; // Skip original method
            }

            return true; // Use original method
        }
    }
}
