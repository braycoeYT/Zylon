using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Dirtball
{
	public class DirtyPistol : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Paydirt Pistol");
			Tooltip.SetDefault("Please don't pluck the flower.\nShoots 2 Bullets");
		}

		public override void SetDefaults() 
		{
			item.value = 500;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 17;
			item.useTime = 17;
			item.damage = 6;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1.5f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 30f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = -1;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 2;
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}