using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Armor
{
	public class RoyalSlime : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Floating Slime Staff");
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.minion = false;
			Projectile.minionSlots = 0f;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Summon;
		}
		public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return false;
		}
		int Timer;
		float spinSpeed = 0.02f;
		public override void AI() {
			Timer++;
			Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.RoyalSlime>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.RoyalSlime>()))
			{
				Projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Projectile.Center = player.Center - new Vector2(0, 64);
			if (p.metelordExpert) {
				Projectile.Center -= new Vector2(0, 51); //size of metecore + 5 pixels
			}
			#endregion

			#region Find target
			float distanceFromTarget = 900f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
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
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			Projectile.friendly = foundTarget;
			#endregion

            #region Projectile
			Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 1;
			if (Timer % 90 == 0 && foundTarget && Projectile.rotation > 0.3f)
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projDir*14f, ProjectileType<RoyalSlimeProj>(), 20, Projectile.knockBack, Projectile.owner);

			#endregion

            #region Animation and visuals
            if (spinSpeed < 0.03f) spinSpeed = 0.03f;
			if (spinSpeed > 0.5f) spinSpeed = 0.5f;
			if (foundTarget) spinSpeed += 0.01f;
			else spinSpeed -= 0.01f;

			Projectile.rotation += spinSpeed;

			Lighting.AddLight(Projectile.Center, Color.SkyBlue.ToVector3() * 0.4f);
			#endregion
		}
	}
}