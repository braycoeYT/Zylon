using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Carnallite
{
	public class Shrubweed : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shrubweed");
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 13f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 335f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
		}
		public override void SetDefaults() {
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
		int Timer;
		public override void AI() {
			float distanceFromTarget = 100f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;
			if (!foundTarget) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					float between = Vector2.Distance(npc.Center, projectile.Center);
					bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
					bool inRange = between < distanceFromTarget;
					bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
					bool closeThroughWall = between < 100f;
					if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall) && npc.life > 0 && npc.type != NPCID.TargetDummy) {
						distanceFromTarget = between;
						targetCenter = npc.Center;
						foundTarget = true;
					}
				}
			}
			Vector2 projDir = Vector2.Normalize(targetCenter - projectile.Center) * 10;
			if (foundTarget) {
				Timer++;
				if (Timer % 60 == 0)
				Projectile.NewProjectile(projectile.Center, projDir, mod.ProjectileType("StingerPassive"), projectile.damage, projectile.knockBack, Main.myPlayer);
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, mod.DustType("CarnalliteDust"));
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}
}