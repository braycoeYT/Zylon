using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Eye
{
	public class GlazedLens : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Glazed Lens");
		}

		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 9999;
			item.value = 2500;
			item.rare = ItemRarityID.Blue;
		}
	}
}