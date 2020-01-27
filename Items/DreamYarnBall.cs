using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class DreamYarnBall : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Don't start rolling this yarn ball, it lasts forever. But the cats will do it for sure.'");
		}

		public override void SetDefaults() 
		{
			item.value = 2000;
			item.shopCustomPrice = 10000;
		}
	}
}