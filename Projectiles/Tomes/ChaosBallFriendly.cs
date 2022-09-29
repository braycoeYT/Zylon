using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Tomes
{
	public class ChaosBallFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Chaos Ball");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.timeLeft = 1200;
		}
		public override void AI() {
			for (int i = 0; i < 2; i++) {
				int dustType = 27;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		float ProjectileRotation = Main.rand.NextFloat(0, 91);
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			float lowestDistance = 999999;
			int playerCount;
			Player target = Main.player[1];
			for (playerCount = 0; playerCount < 255; playerCount++) {
				if (Main.player[playerCount].active) {
					if (Vector2.Distance(Projectile.Center, Main.player[playerCount].Center) < lowestDistance) {
						lowestDistance = Vector2.Distance(Projectile.Center, Main.player[playerCount].Center + new Vector2(0, 6));
						 target = Main.player[playerCount];
					}
				}
			}
			Vector2 vector3 = Vector2.Normalize(target.position - Projectile.Center) * 10;
			Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.position, vector3.RotatedBy((float)((double)(Math.PI / 180) * ProjectileRotation)), ModContent.ProjectileType<ChaosBallShardFriendly>(), (int)(Projectile.damage * 0.75f), (int)(Projectile.knockBack * 0.75f), Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.position, vector3.RotatedBy((float)((double)(Math.PI / 180) * (ProjectileRotation + 120))), ModContent.ProjectileType<ChaosBallShardFriendly>(), (int)(Projectile.damage * 0.75f), (int)(Projectile.knockBack * 0.75f), Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.position, vector3.RotatedBy((float)((double)(Math.PI / 180) * (ProjectileRotation + 240))), ModContent.ProjectileType<ChaosBallShardFriendly>(), (int)(Projectile.damage * 0.75f), (int)(Projectile.knockBack * 0.75f), Main.myPlayer, 0f, 0f);
		}
	}   
}