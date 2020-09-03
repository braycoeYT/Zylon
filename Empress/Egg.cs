using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Empress
{
	public class Egg : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Egg");
			Tooltip.SetDefault("Has a low chance of shooting an egg which venoms enemies");
		}
		public override void SetDefaults() 
		{
			item.value = 500000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 13;
			item.useTime = 13;
			item.damage = 64;
			item.width = 12;
			item.height = 24;
			item.knockBack = 5.1f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.rare = ItemRarityID.Lime;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int ran = Main.rand.Next(1, 10);
			if (ran == 1) type = mod.ProjectileType("Egg");
			return true;
		}
	}
}