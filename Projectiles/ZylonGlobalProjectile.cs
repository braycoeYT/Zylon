using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles
{
	public class ZylonGlobalProjectile : GlobalProjectile
	{
		int damageCooldown;
		public override bool InstancePerEntity => true;
		public override void SetDefaults(Projectile projectile) {
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
				if (projectile.type == ProjectileID.Flare || projectile.type == ProjectileID.BlueFlare)
					projectile.timeLeft = 3600;
			}
		}
        public override bool PreAI(Projectile projectile) {
            Player player = Main.player[projectile.owner];
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.hexNecklace) {
				if (projectile.type == ProjectileID.WandOfSparkingSpark) {
					if (Main.myPlayer == player.whoAmI)
						Projectile.NewProjectile(projectile.GetSource_Death(), projectile.position, projectile.velocity, ProjectileType<Projectiles.Wands.WandofHexingProj>(), projectile.damage, projectile.knockBack, Main.myPlayer);
					projectile.Kill();
                }
				if ((projectile.type >= 121 && projectile.type <= 126) || projectile.type == ProjectileID.AmberBolt || projectile.type == ModContent.ProjectileType<Projectiles.Wands.JadeBolt>()) {
					if (Main.myPlayer == player.whoAmI)
						Projectile.NewProjectile(projectile.GetSource_Death(), projectile.position, projectile.velocity, ProjectileType<Projectiles.Wands.HexOreStaffProj>(), projectile.damage, projectile.knockBack, Main.myPlayer);
					projectile.Kill();
                }
            }
			return true;
        }
        int Timer;
        public override void PostAI(Projectile projectile) {
			Timer++;
			Player player = Main.player[projectile.owner];
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.dirtRegalia && (projectile.minion || projectile.type == ProjectileType<Minions.DirtBlockExp>()) && Timer % 90 == 60) {
				float distanceFromTarget = 160f;
				Vector2 targetCenter = projectile.position;
				bool foundTarget = false;
					
				if (!foundTarget) {
					for (int i = 0; i < Main.maxNPCs; i++) {
						NPC npc = Main.npc[i];

						if (npc.CanBeChasedBy()) {
							float between = Vector2.Distance(npc.Center, projectile.Center);
							bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
							bool inRange = between < distanceFromTarget;
							bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
							bool closeThroughWall = false; //between < 100f;

							if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
								distanceFromTarget = between;
								targetCenter = npc.Center;
								foundTarget = true;
							}
						}
					}
				}
				if (foundTarget) {
					Vector2 projDir = Vector2.Normalize(targetCenter - projectile.Center) * 7f;
					Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, projDir, ProjectileType<Accessories.DirtBallAcc>(), (int)(projectile.damage*0.6f), projectile.knockBack/2, Main.myPlayer);
                }
            }
			if (damageCooldown > 0) { //only use this if you are sure that projectiles inflicted are friendly
				projectile.friendly = false;
				damageCooldown--;
				if (damageCooldown == 0) projectile.friendly = true;
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit) {
            if (target.type == NPCType<NPCs.Bosses.Dirtball.DirtBlock>() && (projectile.penetrate < 0 || projectile.penetrate > 3) && projectile.minion == false && Main.expertMode)
				projectile.penetrate = 3;
			if (target.type == NPCType<NPCs.Bosses.Metelord.MetelordHead>() || target.type == NPCType<NPCs.Bosses.Metelord.MetelordBody>() || target.type == NPCType<NPCs.Bosses.Metelord.MetelordTail>()) {
				if ((projectile.DamageType != DamageClass.Summon && projectile.DamageType != DamageClass.MagicSummonHybrid && projectile.aiStyle != 19) || projectile.type == ProjectileType<Minions.DirtBlockExp>())
					damageCooldown = 30;
            }
        }
    }
}