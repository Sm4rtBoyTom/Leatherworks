namespace Leatherworks
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

        [Section("Spawn Chances")]

        [Name("Treebark spawn chance")]
        [Description("Choose How Often Treebark Should Spawn. Default: 10%")]
        [Slider(1, 25, 25)]
        public int treebarkChance = 10;

        [Section("Leather Yield")]

        [Name("Rabbit leather yield")]
        [Description("Choose How Much Scraped Leather You Get From A Rabbit Pelt. Default: 1")]
        [Slider(1, 5, 5)]
        public int rabbitYield = 1;

        [Name("Deer and wolf leather yield")]
        [Description("Choose How Much Scraped Leather You Get From A Deer Hide and Wolf Pelt. Default: 3")]
        [Slider(1, 5, 5)]
        public int wolfdeerYield = 3;

        [Name("Bear and moose leather yield")]
        [Description("Choose How Much Scraped Leather You Get From A Moose and Bear Hide. Default: 5")]
        [Slider(1, 5, 5)]
        public int moosebearYield = 5;

        [Name("Cougar leather yield")]
        [Description("Choose How Much Scraped Leather You Get From A Cougar Hide. Default: 4")]
        [Slider(1, 5, 5)]
        public int cougarYield = 4;

        [Section("Preferences")]

        [Name("Bark amount for making flour")]
        [Description("Choose How Much Fried Tree Bark Is Needed For Making Flour. Default: 35")]
        [Slider(25, 60, 8)]
        public int flourAmount = 35;

        [Name("Tanning amount to fill a box")]
        [Description("Choose How Much Tanning Is Needed For Filling A Metal Box. Default: 1")]
        [Slider(1, 4, 4)]
        public int tanningAmount = 1;

        [Name("Able to Scrape Fresh Hide?")]
        [Description("Enable The Ability To Scrape Fresh Hide. Default: False")]
        public bool noCured = false;

        [Name("Able to Use Stone To Grind Flour?")]
        [Description("Enable The Ability To Grind Flour Using A Stone. Default: False")]
        public bool noGrind = false;

    }
}
