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
		Projectile[] swordArmy = new Projectile[30];
		public override void AI() {
			//Initialize the swords
			if (!init && Projectile.owner == Main.myPlayer) {
				if (Main.rand.NextBool()) rotRand *= -1f;
				for (int i = 0; i < swordArmy.Length; i++) {
					swordArmy[i] = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ProjectileType<SwordigamSword>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.whoAmI, i, Main.rand.Next(45));
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

			float minionPositionOffsetX = (100 + Projectile.minionPos * 100) * -player.direction;
			idlePosition.X += minionPositionOffsetX;
			
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
			
			if (foundTarget) Projectile.ai[0] = 1f; //Tells projectiles to launch.
			else Projectile.ai[0] = 0f;

			//Check if we need to spawn new projectiles
			if (Projectile.owner == Main.myPlayer) {
				for (int i = 0; i < swordArmy.Length; i++) {
					if (!swordArmy[i].active || swordArmy[i].timeLeft < 1 || (int)swordArmy[i].ai[0] != Projectile.whoAmI)
						swordArmy[i] = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ProjectileType<SwordigamSword>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.whoAmI, i, Main.rand.Next(45));
				}
			}

			/*//For the topmost to animate properly - look cut or uncut
			int ownedNum = -1;
			for (int i = 0; i < Main.maxProjectiles; i++) { //checks for topmost owned sword
				if (Main.projectile[i].type == ProjectileType<SwordigamSword>() && Main.projectile[i].active && (int)Main.projectile[i].ai[0] == Projectile.whoAmI)
					ownedNum = (int)Main.projectile[i].ai[1]; //this is the newest sword
			}
			int checkNum = ownedNum + 1; //Gets the sword to the right of the topmost sword.
			if (checkNum == 30) checkNum = 0; //sword29 will check sword0, not the nonexistant sword30

			//The topmost sword's code will realize that it is the topmost, then check if it needs to switch to the special sprite.
			if (swordArmy[checkNum].active && swordArmy[checkNum].scale > 0.5f && swordArmy[checkNum].velocity.Length() < 0.1f) Projectile.ai[2] = ownedNum; //Switch to special sprite.
			else Projectile.ai[2] = -1f; //Don't switch; the rightmost is fine.*/

			Main.NewText(Main.player[Projectile.owner].ownedProjectileCounts[ProjectileType<SwordigamSword>()]);

			#endregion

			#region Animation and visuals
			Projectile.rotation += 0.02f*rotRand;
			Projectile.ai[1] += 0.02f*rotRand; //Rotates projectiles

			#endregion
		}
        /*public override void PostAI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustType<AdeniteDust>());
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(0.75f, 1.25f);
			}
        }*/
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

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