using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Accessories
{
	public class DiscoCanisterProj : ModProjectile
	{
        public override void SetStaticDefaults() {
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
			Projectile.minionSlots = 0f;
		}
        public override bool MinionContactDamage() {
            return false;
        }
        int Timer;
		int minionID;
		int minionMax;
		int critCount;
		bool init;
		Player own;
		public override void PostAI() {
			Timer++;
			if (Timer < 2) return;

			minionID = (int)Projectile.ai[0];
			own = Main.player[Projectile.owner];
			minionMax = own.ownedProjectileCounts[Type];
			ZylonPlayer p = own.GetModPlayer<ZylonPlayer>();

			if (!init) {
				critCount = p.critCount;
				init = true;
			}

			if (own.dead || !own.active)
				Projectile.active = false;
			if (p.discoCanister)
				Projectile.timeLeft = 2;

			Projectile.Center = own.Center - new Vector2(0, 100).RotatedBy(MathHelper.ToRadians((Main.GameUpdateCount%360)+(360*minionID/minionMax)));

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
			if (critCount < p.critCount) {
				critCount = p.critCount;
				Vector2 projDir;
				if (foundTarget) projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 24f;
				else projDir = new Vector2(0, 24).RotatedByRandom(MathHelper.TwoPi);
				if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projDir, ModContent.ProjectileType<DiscoCanisterProj_Laser>(), 60, 1f, Projectile.owner);
			}
		}
		/*public override void PostAI() {
			for (int i = Main.rand.Next(3); i < 2; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}*/
    }   
}