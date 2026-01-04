namespace AmmoToolsMod;

// Credit to Deadman for the texture loading stuff.


internal class TextureSwap
{
    [HarmonyPatch(typeof(GearItem), nameof(GearItem.Deserialize))]
    private static class SwapGearItemTextures
    {
        private static void Postfix()
        {
            if (Settings.instance.RifleAmmoBoxVariant)
            {
                TextureSwapper.SwapGearItemTexture("GEAR_RifleAmmoBox", "RifleAmmoBox_Old", "GEAR_RifleAmmoBox_Dif", 0);
                TextureSwapper.SwapGearItemTexture("GEAR_RifleAmmoBox", "RifleAmmoBox_LOD0", "GEAR_RifleAmmoBox_Dif", 0);
                TextureSwapper.SwapGearItemTexture("GEAR_RifleAmmoBox", "RifleAmmoBox_LOD1", "GEAR_RifleAmmoBox_Dif", 0);
            }
            if (Settings.instance.RevolverAmmoBoxVariant)
            {
                TextureSwapper.SwapGearItemTexture("GEAR_RevolverAmmoBox", "RifleAmmoBox_Old", "GEAR_RevolverAmmoBox_Dif", 0);
                TextureSwapper.SwapGearItemTexture("GEAR_RevolverAmmoBox", "RifleAmmoBox_LOD0", "GEAR_RevolverAmmoBox_Dif", 0);
                TextureSwapper.SwapGearItemTexture("GEAR_RevolverAmmoBox", "RifleAmmoBox_LOD1", "GEAR_RevolverAmmoBox_Dif", 0);
            }
        }
    }
    internal static string GetTextureNameForGearItem(GearItem gi)
    {
        var textureMapping = new Dictionary<string, string>
            {
                { "GEAR_RevolverAmmoBox", "ico_GearItem__RevolverAmmoBox" },
                { "GEAR_RifleAmmoBox", "ico_GearItem__RifleAmmoBox" },
                { "GEAR_Bullet", "ico_GearItem__44MagnumBullet" },

            };
        if (gi.name == "GEAR_RifleAmmoBox" && !Settings.instance.RifleAmmoBoxVariant)
        {
            return string.Empty;
        }
        if (gi.name == "GEAR_RifleAmmoBox" && !Settings.instance.RifleAmmoBoxVariant)
        {
            return string.Empty;
        }
        if (gi.name == "GEAR_Bullet" && !Settings.instance.RevolverIcon)
        {
            return string.Empty;
        }
        if (textureMapping.TryGetValue(gi.name, out var textureName))
        {
            return textureName;
        }

        return string.Empty;
    }
}