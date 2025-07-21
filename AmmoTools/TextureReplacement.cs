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
                TextureSwapper.SwapGearItemTexture("GEAR_RifleAmmoBox", "RifleAmmoBox_Old", "GEAR_RifleAmmoBox_Dif");
                TextureSwapper.SwapGearItemTexture("GEAR_RifleAmmoBox", "RifleAmmoBox_LOD0", "GEAR_RifleAmmoBox_Dif");
                TextureSwapper.SwapGearItemTexture("GEAR_RifleAmmoBox", "RifleAmmoBox_LOD1", "GEAR_RifleAmmoBox_Dif");
            }
            if (Settings.instance.RevolverAmmoBoxVariant)
            {
                TextureSwapper.SwapGearItemTexture("GEAR_RevolverAmmoBox", "RifleAmmoBox_Old", "GEAR_RevolverAmmoBox_Dif");
                TextureSwapper.SwapGearItemTexture("GEAR_RevolverAmmoBox", "RifleAmmoBox_LOD0", "GEAR_RevolverAmmoBox_Dif");
                TextureSwapper.SwapGearItemTexture("GEAR_RevolverAmmoBox", "RifleAmmoBox_LOD1", "GEAR_RevolverAmmoBox_Dif");
            }
        }
    }
    internal static string GetTextureNameForGearItem(GearItem gi)
    {
        var textureMapping = new Dictionary<string, string>
            {
                { "GEAR_Bullet", "ico_GearItem__44MagnumBullet" },
                { "GEAR_Rifle", "ico_GearItem__RifleHuntingLodge" },
                { "GEAR_Revolver", "ico_GearItem__Revolver_Dif" },
                { "GEAR_RevolverAmmoBox", "ico_GearItem__RevolverAmmoBox" },
                { "GEAR_RifleAmmoBox", "ico_GearItem__RifleAmmoBox" },

            };
        if (gi.name == "GEAR_RifleAmmoBox" && !Settings.instance.RifleAmmoBoxVariant)
        {
            return string.Empty;
        }
        if (gi.name == "GEAR_Bullet" && !Settings.instance.RevolverBulletTexture)
        {
            return string.Empty;
        }
        if (gi.name == "GEAR_Rifle" && !Settings.instance.HuntingRifleIconTexture)
        {
            return string.Empty;
        }
        if (gi.name == "GEAR_RifleAmmoBox" && !Settings.instance.RifleAmmoBoxVariant)
        {
            return string.Empty;
        }
        if (gi.name == "GEAR_Revolver" && !Settings.instance.RevolverIconTexture)
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