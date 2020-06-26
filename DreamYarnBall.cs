using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class DreamYarnBall : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Cats love it!");
		}

		public override void SetDefaults() 
		{
			item.value = 2000;
			item.shopCustomPrice = 10000;
		}
	}
}