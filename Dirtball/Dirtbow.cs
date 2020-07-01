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
			item.value = 20;
			item.useStyle = 5;
			item.useAnimation = 16;
			item.useTime = 16;
			item.damage = 9;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1;
			item.shoot = 1;
			item.shootSpeed = 6.1f;
			item.noMelee = true;
			item.ranged = true;
			item.crit = 1;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
		}
	}
}