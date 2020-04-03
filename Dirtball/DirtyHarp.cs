using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Dirtball
{
	public class DirtyHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Play a sour melody at an absurd speed'");
		}

		public override void SetDefaults() 
		{
			item.damage = 7;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 500;
			item.rare = -1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 76;
			item.shootSpeed = 5.5f;
			item.noMelee = true;
			item.mana = 4;
			item.holdStyle = 3;
			item.stack = 1;
		}
	}
}