using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions
{
	public class Goocat : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 9;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 56;
			Projectile.height = 56;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
		}
		public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return false;
		}
		int Timer;
		bool init;
		float greenChance;
		public override void AI() {
			if (!init) {
				Projectile.frame = Main.rand.Next(8);
				if (Main.rand.NextFloat() < 0.005f) Projectile.frame = 8; //shiny!!!
				init = true;

				switch (Projectile.frame) { //Determines chance of green proj instead of orange, not necessary to run for shiny edition
					case 0:
						greenChance = 1f;
						break;
					case 1:
						greenChance = 0f;
						break;
					case 2:
						greenChance = 0.5f;
						break;
					case 3:
						greenChance = 0.5f;
						break;
					case 4:
						greenChance = 0.5f;
						break;
					case 5:
						greenChance = 0.5f;
						break;
					case 6:
						greenChance = 0.25f;
						break;
					case 7:
						greenChance = 0.75f;
						break;
                }
            }

			Player player = Main.player[Projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.Goocat>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.Goocat>()))
			{
				Projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center - new Vector2(Main.rand.Next(-80, 81), 80);

			//float minionPositionOffsetX = (60 + Projectile.minionPos * 40) * -player.direction;
			//idlePosition.X += minionPositionOffsetX;

			idlePosition.Y -= Projectile.minionPos * 40;
			
			Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				Projectile.position = idlePosition;
				Projectile.velocity *= 0.1f;
				Projectile.netUpdate = true;
			}
			float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile other = Main.projectile[i];
				if (i != Projectile.whoAmI && other.active && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < Projectile.width) {
					if (Projectile.position.X < other.position.X) Projectile.velocity.X -= overlapVelocity;
					else Projectile.velocity.X += overlapVelocity;

					if (Projectile.position.Y < other.position.Y) Projectile.velocity.Y -= overlapVelocity;
					else Projectile.velocity.Y += overlapVelocity;
				}
			}
			#endregion

			#region Find target
			float distanceFromTarget = 600f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				if (between < 2000f)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center - new Vector2(Main.rand.Next(-24, 25), 100+npc.height/2+Projectile.minionPos * 40);
					foundTarget = true;
				}
			}
			if (!foundTarget)
			{
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center - new Vector2(0, 100+npc.height/2+Projectile.minionPos * 40), Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position - new Vector2(0, 100+Projectile.minionPos * 40), npc.width, npc.height);
						bool closeThroughWall = between < 300f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center - new Vector2(Main.rand.Next(-24, 25), 100+npc.height/2+Projectile.minionPos * 40);
							foundTarget = true;
						}
					}
				}
			}
			Projectile.friendly = foundTarget;
			#endregion

			#region Movement

			float speed = 16f;
			float inertia = 8f;

			if (foundTarget)
			{
				if (distanceFromTarget > 40f) {
					Vector2 direction = targetCenter - Projectile.Center;
					direction.Normalize();
					direction *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			else {
				if (distanceToIdlePosition > 600f) {
					speed = 45f;
					inertia = 56f;
				}
				else {
					speed = 34f;
					inertia = 34f;
				}
				if (distanceToIdlePosition > 20f) {
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (Projectile.velocity == Vector2.Zero) {
					Projectile.velocity.X = -0.15f;
					Projectile.velocity.Y = -0.05f;
				}
			}
			#endregion

			#region Projectile
			if (foundTarget && Vector2.Distance(targetCenter, Projectile.Center) < 400) {
				Timer++;
				if (Timer % 12 == 0) {
					int helpInt = 1;
					if (Projectile.frame == 8) helpInt = 2;
					else if (Main.rand.NextFloat() <= greenChance) helpInt = 0;
					ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 8), ProjectileType<GoocatBarf>(), Projectile.damage, Projectile.knockBack, Projectile.owner, helpInt);
				}
			}

			#endregion

			#region Animation and visuals
			//Projectile.rotation = 0f;
			Projectile.spriteDirection = Projectile.direction;
			if (Projectile.frame == 8) Lighting.AddLight(Projectile.Center, Color.Gold.ToVector3() * 0.5f);
			#endregion
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustID;
				if (Projectile.frame == 8) dustID = DustID.GoldCoin;
				else {
					if (Main.rand.NextFloat() <= greenChance) dustID = DustType<Dusts.ElemDustGreen>();
					else dustID = DustType<Dusts.ElemDustOrange>();
                }
				int dustIndex = Dust.NewDust(Projectile.position + new Vector2(6, 12), Projectile.width-12, Projectile.height, dustID);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-150, 151) * 0.01f;
				dust.velocity.Y = Main.rand.NextFloat(6, 9);
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}