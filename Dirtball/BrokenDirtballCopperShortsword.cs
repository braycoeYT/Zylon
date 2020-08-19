using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Dirtball
{
	public class BrokenDirtballCopperShortsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Fall to thine glory of thine ultimate sword!\nShoots many dirt projectiles");
		}

		public override void SetDefaults() 
		{
			item.damage = 11;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 3;
			item.knockBack = 9.5f;
			item.value = 2000;
			item.rare = -1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("CrazyDirtStuff");
			item.shootSpeed = 102f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 1 + Main.rand.Next(3);
			if (numberProjectiles > 1)
			{
				float rotation = MathHelper.ToRadians(5);
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
				return false;
			}
			return true;
		}
	}
}