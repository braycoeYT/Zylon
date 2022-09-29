using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Yoyos
{
	public class EarthDay : ModProjectile
	{
		public override void SetStaticDefaults() {
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 320f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12f;
		}
		public override void SetDefaults() {
			Projectile.extraUpdates = 0;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 1f;
		}
		int Timer;
		int Timer2;
        public override void AI() {
			Timer2++;
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
			Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 5f;
			if (foundTarget) {
				Timer++;
				if (Timer % 60 == 0)
					Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, projDir, ModContent.ProjectileType<AcornFriendlyMelee>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
			}
			if (Timer2 % 20 == 0)
				Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Vector2(0, -5), ModContent.ProjectileType<Minions.MushroomSpore>(), Projectile.damage / 2, 1f, Main.myPlayer, 1f);
		}
    }
}