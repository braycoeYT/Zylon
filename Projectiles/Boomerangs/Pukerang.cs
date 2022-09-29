using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class Pukerang : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pukerang");
        }
		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = 3;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
		}
		int Timer;
		public override void AI() {
			// Starting search distance
			float distanceFromTarget = 100f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (!foundTarget) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];

					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = false; //between < 100f;

						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 10f;
			if (foundTarget) {
				Timer++;
				if (Timer % 20 == 0)
				Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, projDir, ModContent.ProjectileType<Projectiles.CursedFlamesMelee>(), Projectile.damage, Projectile.knockBack / 4, Main.myPlayer);
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.CursedInferno, Main.rand.Next(4, 11) * 60);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.CursedInferno, Main.rand.Next(4, 11) * 60);
		}
	}   
}