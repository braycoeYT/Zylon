using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class StoryMineral : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Zylonian Mineral Extractor Story");
			Tooltip.SetDefault("'The Zylonian Mineral Extractor (ZME) wasn't originally meant for the mass extraction of minerals from billions of planets.\nIt was originally hidden very deep underground on Zylon's sister planet, Tinmulo.\nThe crystal was about 3 meters tall when it was inside of Tinmulo's crust.\nIt consumed medium size prey such as juvenile cosmic worms.\nAfter the great historic war of the Zylonians and the Tinmulons, the Zylonians began Mass Mineral Extraction (MME).\nThe Zylonians encountered the crystal and mistook it as an ectojewelo and took it away.\nAfter a few of the workers handling the ectojewelo disappeared, the dispatch scientists discovered the crystal.\nThey took it to their research station and discovered its potential for MME.\n Yet the crystal was only up to 0.1% maximum power.\n To enhance it's power, the Zylonians (force)fed it thousands of megatons of crystals and gems.\nIt grew to the bloated size it was today.\nThen the lead mechanic in charge, Toxeye, built it's jail cell, the XYL-900.\nThe bloated beast was forced into the XYL-900, which made it work for the Zylonians' MME and gave it an ever-growing taste for jewels and gems.\nMaybe a gigantic jewel of high value could overload it's processors and make it come to invade Terraria?'");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 1;
			item.rare = 12;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.expert = true;
		}
	}
}