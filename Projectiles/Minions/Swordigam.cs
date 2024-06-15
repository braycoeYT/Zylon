using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Dusts;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions
{
	public class Swordigam : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 2f;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.timeLeft = 9999;
		}
		public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return false;
		}
		bool init;
		float rotRand = Main.rand.NextFloat(0.8f, 1.25f);
		int[] cooldown = new int[30];
		float[] swordArmy = new float[30];
		public override void AI() {
			//Initialize the swords
			if (!init && Projectile.owner == Main.myPlayer) {
				if (Main.rand.NextBool()) rotRand *= -1f;
				for (int i = 0; i < cooldown.Length; i++) {
					cooldown[i] = Main.rand.Next(45);
				}
				init = true;
			}

			Player player = Main.player[Projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.Swordigam>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.Swordigam>()))
			{
				Projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;

			float minionPositionOffsetX = (75 + Projectile.minionPos * 100) * -player.direction;
			idlePosition.X += minionPositionOffsetX;

			//Doesn't work for whatever reason
			//if (Main.player[Projectile.owner].stardustGuardian) minionPositionOffsetX -= player.direction*100;
			
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
			float distanceFromTarget = 650f;
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
			#endregion

			#region Movement

			float speed = 15f;
			float inertia = 30f;

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
				if (distanceToIdlePosition > 700f) {
					speed = 20f;
					inertia = 50f;
				}
				else {
					speed = 15f;
					inertia = 30f;
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
			
			for (int i = 0; i < swordArmy.Length; i++) {
				if (cooldown[i] > 0) cooldown[i]--;
				else {
					if (swordArmy[i] == 0.95f) cooldown[i] = 12; //Don't shoot immediately
					if (swordArmy[i] < 1f) swordArmy[i] += 0.05f;
					//if (swordArmy[i] > 1f) swordArmy[i] = 1f;
				}
				if (swordArmy[i] >= 1f && foundTarget && cooldown[i] <= 0) {
					if (Main.myPlayer == Projectile.owner)
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 20).RotatedBy(MathHelper.ToRadians(i*12)), ProjectileType<SwordigamSword>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
					swordArmy[i] = 0f;
					cooldown[i] = 30+Main.rand.Next(45);
				}
			}

			//Main.NewText(swordArmy[0] + " <--SIZE | COOLDOWN-->" + cooldown[0]);

			#endregion

			#region Animation and visuals
			Projectile.rotation += 0.02f*rotRand;

			#endregion
		}
        /*public override void PostAI() { //Almost works :(
            for (int i = 0; i < swordArmy.Length; i++) {
				if (swordArmy[i].timeLeft < 90 && swordArmy[i].active) swordArmy[i].Center = Projectile.Center;
			}
        }*/
        /*public override void PostAI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustType<AdeniteDust>());
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(0.75f, 1.25f);
			}
        }*/
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D swordTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Minions/SwordigamSword");
			Texture2D swordTextureAlt = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Minions/SwordigamSword_Special");
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

			Vector2 swordOrigin = new Vector2(swordTexture.Width * 0.5f, swordTexture.Height);

			for (int k = 0; k < swordArmy.Length; k++) {
				//if (k == 29) {
				//	if (swordArmy[0] >= 0.5f) swordTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Minions/SwordigamSword_Special");
				//}
				if (swordArmy[k] != 0f) Main.spriteBatch.Draw(swordTexture, drawPos, null, color, MathHelper.ToRadians(k*12)+Projectile.rotation, swordOrigin, swordArmy[k], SpriteEffects.None, 0f);
			}

			if (swordArmy[29] >= 0.5f && swordArmy[0] >= 0.5f) //oh flop not this again
				Main.spriteBatch.Draw(swordTextureAlt, drawPos, null, color, Projectile.rotation, swordOrigin, swordArmy[0], SpriteEffects.None, 0f);

			//Looks bad
            /*for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }*/

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
    }
}