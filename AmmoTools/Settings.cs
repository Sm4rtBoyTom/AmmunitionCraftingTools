using ModSettings;

namespace AmmoToolsMod
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

    [Section("Texture Replacement")]

        [Name("Replace Revolver Bullet Texture")]
        [Description("Switches the revolver bullet texture to the removed .44 Magnum Bullet.")]
        public bool RevolverBulletTexture = false;

        [Name("Replace Hunting Rifle Icon Texture")]
        [Description("Changes the icon of hunting rifle.")]
        public bool HuntingRifleIconTexture = false;

        [Name("Replace rifle Ammunition box texture")]
        [Description("Changes the texture of rifle ammunition box.")]
        public bool RifleAmmoBoxVariant = false;

        [Name("Replace Revolver ammunition box texture")]
        [Description("Changes the texture of revolver ammunition box.")]
        public bool RevolverAmmoBoxVariant = false;

        [Name("Replace Revolver Icon texture")]
        [Description("Changes the texture of revolver inventory icon.")]
        public bool RevolverIconTexture = false;

        [Section("Marnufactured Arrows")]

        [Name("Sharpenable Arrows")]
        [Description("Manufactured arrows can be sharpened to regain some condition.")]
        public bool sharpenablearrows = false;


        /* 
                [Section("Experimental Settings")]

                [Name("Experimental Bullet Spawning")]
                [Description("Enables a different spwaning method for Rifle/Revolver cartrdiges Cartridges spawn with 10%. Spawn chance, but with higher amount of cartridges in the box. (20 Cartridges per box)")]
                public bool ExperimentalSpawning = false;
        */
    }
}


