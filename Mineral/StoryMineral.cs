using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class StoryMineral : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Zylonian Mineral Extractor Story");
			Tooltip.SetDefault("The creature and machine that destroyed billions of planets.\nOriginally a normal size gemimic inside of Tinmulo's crust, the Zylonians fed it countless gems.\nThen they attached it to a mind-controlling machine and gave it a taste for valuable minerals and gems.");
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 0;
			item.rare = 12;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.expert = true;
		}
	}
}