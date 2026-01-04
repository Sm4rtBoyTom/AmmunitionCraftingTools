using ModSettings;

namespace AmmoToolsMod
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

    [Section("Texture Replacement")]

        [Name("Replace rifle Ammunition box texture")]
        [Description("Changes the texture of rifle ammunition box.")]
        public bool RifleAmmoBoxVariant = false;

        [Name("Replace Revolver ammunition box texture")]
        [Description("Changes the texture of revolver ammunition box.")]
        public bool RevolverAmmoBoxVariant = false;

        [Name("Replace Revolver Bullet Icon texture")]
        [Description("Changes the texture of Revolver Icon.")]
        public bool RevolverIcon = false;

        [Section("Manufactured Arrows")]

        [Name("Sharpenable Arrows")]
        [Description("Manufactured arrows can be sharpened to regain some condition.")]
        public bool sharpenablearrows = false;

        [Section("Mineral Radial Spawn Settings")]

        [Name("Sulfur Chance")]
        [Description("Adjust the chance for Sulfur to spawn in Caves. Default: 2.5%.")]
        [Slider(0f, 10f, 21)]
        public float SulfurChance = 2.5f;

        [Name("Niter Chance")]
        [Description("Adjust the chance for Niter to spawn in Caves. Default: 2.5%.")]
        [Slider(0f, 10f, 21)]
        public float NiterChance = 2.5f;

        /* 
                [Section("Experimental Settings")]

                [Name("Experimental Bullet Spawning")]
                [Description("Enables a different spwaning method for Rifle/Revolver cartrdiges Cartridges spawn with 10%. Spawn chance, but with higher amount of cartridges in the box. (20 Cartridges per box)")]
                public bool ExperimentalSpawning = false;
        */
    }
}


