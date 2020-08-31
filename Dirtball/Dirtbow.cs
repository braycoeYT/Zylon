using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Dirtball
{
	public class Dirtbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("It's oozing!");
		}

		public override void SetDefaults() 
		{
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.useStyle = 5;
			item.useAnimation = 16;
			item.useTime = 16;
			item.damage = 15;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1;
			item.shoot = 1;
			item.shootSpeed = 6.1f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = -1;
		}
	}
}