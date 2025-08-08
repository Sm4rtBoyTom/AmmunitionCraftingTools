using AmmoToolsMod;

namespace AmmoToolsMod;

internal static class TextureSwapper
{
    private static readonly AssetBundle? retrotexturesAssetBundle = AssetBundleLoader.LoadBundle("AmmoTools.Assets.ammotoolsassets");
    private static readonly Dictionary<string, Texture2D> textures = LoadTexturesFromAssetBundle();

    private static Dictionary<string, Texture2D> LoadTexturesFromAssetBundle()
    {
        var loadedTextures = new Dictionary<string, Texture2D>();
        if (retrotexturesAssetBundle == null) return loadedTextures;

        foreach (var texture in retrotexturesAssetBundle.LoadAllAssets<Texture2D>())
        {
            loadedTextures[texture.name] = texture;
        }

        return loadedTextures;
    }

    internal static void SwapGearItemTexture(string gearName, string objectName, string textureName, int materialIndex = -1, string materialName = null)
    {

        if (!textures.TryGetValue(textureName, out var newTexture)) return;


        var gearItemPrefab = GearItem.LoadGearItemPrefab(gearName);
        if (gearItemPrefab == null) return;


        Transform child = gearItemPrefab.transform.Find(objectName);
        if (child == null) return;


        MeshRenderer renderer = child.GetComponent<MeshRenderer>();
        if (renderer == null) return;

        Material[] materials = renderer.materials;


        if (materialIndex == -1 && !string.IsNullOrEmpty(materialName))
        {
            materialIndex = FindMaterialIndexByName(materials, materialName);
            if (materialIndex == -1) return;
        }


        if (materialIndex < 0 || materialIndex >= materials.Length) return;


        materials[materialIndex].mainTexture = newTexture;
        renderer.materials = materials;
    }


    private static int FindMaterialIndexByName(Material[] materials, string name)
    {
        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i].name.Contains(name))
                return i;
        }
        return -1;
    }

    [HarmonyPatch(typeof(Utils), nameof(Utils.GetInventoryIconTexture), new Type[] { typeof(GearItem) })]
    private static class GenericIconTextureSwap
    {
        private static bool Prefix(GearItem gi, ref Texture2D __result)
        {
            if (gi == null)
            {
                return true;
            }

            string textureName = TextureSwap.GetTextureNameForGearItem(gi);
            if (string.IsNullOrEmpty(textureName))
            {
                return true;
            }

            var textures = LoadTexturesFromAssetBundle();
            if (textures.Count == 0)
            {
                return true;
            }

            if (textures.TryGetValue(textureName, out Texture2D? newTexture))
            {
                __result = newTexture;
                return false;
            }

            return true;
        }
    }
}