using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Minions
{
	public class IcyWisp : ModProjectile
	{
        public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 4;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 26;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.minion = true;
			Projectile.minionSlots = 0.5f;
		}
        public override bool MinionContactDamage() {
            return false;
        }
		int Timer;
		int minionID;
		int minionMax;
		Player own;
		public override void AI() {
			Timer++;
			if (Timer < 2) return;

			minionID = (int)Projectile.ai[0];
			own = Main.player[Projectile.owner];
			minionMax = own.ownedProjectileCounts[Type];

			if (own.dead || !own.active)
				own.ClearBuff(ModContent.BuffType<Buffs.Minions.IcyWisp>());
			if (own.HasBuff(ModContent.BuffType<Buffs.Minions.IcyWisp>()))
				Projectile.timeLeft = 2;

			Projectile.Center = own.Center - new Vector2(0, 50+(minionMax*4)).RotatedBy(MathHelper.ToRadians((Main.GameUpdateCount%360)+(360*minionID/minionMax)));

			float distanceFromTarget = 800f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (own.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[own.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				if (between < 2000f)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget)
			{
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 400f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			Projectile.friendly = foundTarget;
			int temp = (int)(240*minionID/minionMax);
			if (temp < 0) temp = 0;
			if (temp > 239) temp = 239;
			if (((int)(Main.GameUpdateCount % 240) == temp) && foundTarget) {
				Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 5f;
				if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projDir, ModContent.ProjectileType<IcyWispBeam>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
			}

			if (++Projectile.frameCounter >= 4) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
					Projectile.frame = 0;
			}
		}
		public override void PostAI() {
			for (int i = Main.rand.Next(3); i < 2; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
    }   
}