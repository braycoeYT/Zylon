using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Zylomax
{
	public class NuclearGenerator : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'A section of King Slime's nucleus. It generates infinite sticky glowsticks at the cost of mana.'\nZYLOMAX ITEM");
		}

		public override void SetDefaults() 
		{
			item.damage = 0;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 2500;
			item.rare = 11;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 53;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.mana = 10;
			item.holdStyle = 3;
			item.stack = 1;
		}
	}
}