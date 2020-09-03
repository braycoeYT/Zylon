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
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 16;
			item.useTime = 16;
			item.damage = 15;
			item.width = 34;
			item.height = 90;
			item.knockBack = 1;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 6.1f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = -1;
		}
	}
}