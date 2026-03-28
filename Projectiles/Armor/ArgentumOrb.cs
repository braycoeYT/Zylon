using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;

namespace Zylon.Projectiles.Armor
{
	public class ArgentumOrb : ModProjectile
	{
        public override void SetStaticDefaults() {
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 25;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.minion = false;
			Projectile.minionSlots = 0f;
			Projectile.extraUpdates = 1;
		}
        public override bool MinionContactDamage() {
            return false;
        }
        int Timer;
		int minionID;
		int targetNum;
		int animTimer;
		int attackCounter;
		int soundCooldown;
		bool init;
		float pointer;
		Player own;
		public override void PostAI() {
			Projectile.netUpdate = true;
			if (!init) { 
				init = true;
				animTimer = (int)(Main.GameUpdateCount%720);
				attackCounter = (int)Projectile.ai[0]; //This just exists to offset attack patterns.
				return;
			}

			animTimer++;
			minionID = (int)Projectile.ai[0];
			own = Main.player[Projectile.owner];
			ZylonPlayer p = own.GetModPlayer<ZylonPlayer>();

			if (own.dead || !own.active)
				Projectile.active = false;
			if (p.argentumSetBonus)
				Projectile.timeLeft = 2;

			Projectile.Center = own.Center - new Vector2(0, 64).RotatedBy(MathHelper.ToRadians((animTimer%720)+(360*minionID/4)));

			float distanceFromTarget = 1000f;
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
						bool closeThroughWall = between < 500f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
							targetNum = npc.whoAmI;
						}
					}
				}
			}
			Projectile.friendly = foundTarget;
			if (foundTarget) {
				pointer = Projectile.DirectionTo(targetCenter).ToRotation();

				Timer++;
				if (p.argentumType == 0) { //Melee effects - swing swords at enemies
					if (Timer % 25 == 0) {
						attackCounter++;
						if (attackCounter % 4 == 0) SoundEngine.PlaySound(SoundID.Item1, Projectile.Center); //Is this annoying?
						if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<ArgentumOrb_MeleeSword>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.whoAmI, targetNum, attackCounter);
					}
				}
				else if (p.argentumType == 1) { //Ranged effects - fires various weapons
					if (Timer % 80 == minionID*20) {
						attackCounter++;
						int type = ModContent.ProjectileType<ArgentumOrb_RangedArrow>();
						switch (minionID) {
							case 0:
								SoundEngine.PlaySound(SoundID.Item5, Projectile.Center);
								break;
							case 1:
								SoundEngine.PlaySound(SoundID.Item11, Projectile.Center);
								type = ModContent.ProjectileType<ArgentumOrb_RangedBullet>();
								break;
							case 2:
								SoundEngine.PlaySound(SoundID.Item17, Projectile.Center);
								type = ModContent.ProjectileType<ArgentumOrb_RangedDart>();
								break;
							case 3:
								SoundEngine.PlaySound(SoundID.Item11, Projectile.Center);
								type = ModContent.ProjectileType<ArgentumOrb_RangedRocket>();
								break;
						}
						Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 13f;
						if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projDir, type, (int)(Projectile.damage*0.75f), Projectile.knockBack, Projectile.owner);
					}
				}
				else if (p.argentumType == 2) {
					soundCooldown--;
					if (Timer % 28 == minionID*7 && Main.myPlayer == Projectile.owner) {
						if (distanceFromTarget < 250) {
							if (soundCooldown < 1) {
								SoundEngine.PlaySound(new SoundStyle("Zylon/Sounds/Items/ArgentumOrbSFX").WithPitchOffset(Main.rand.NextFloat(1f)).WithVolumeScale(0.25f), Projectile.position);
								soundCooldown = 90;
							}
							Projectile.NewProjectile(Projectile.GetSource_FromThis(), targetCenter, Vector2.Zero, ModContent.ProjectileType<ArgentumOrb_MagicAttack>(), Projectile.damage/4, 0f, Projectile.owner, Projectile.whoAmI);
						}
						else if (distanceFromTarget < 400 && Timer % 56 == minionID*14) {
							if (soundCooldown < 1) {
								SoundEngine.PlaySound(new SoundStyle("Zylon/Sounds/Items/ArgentumOrbSFX").WithPitchOffset(Main.rand.NextFloat(1f)).WithVolumeScale(0.25f), Projectile.position);
								soundCooldown = 90;
							}
							Projectile.NewProjectile(Projectile.GetSource_FromThis(), targetCenter, Vector2.Zero, ModContent.ProjectileType<ArgentumOrb_MagicAttack>(), Projectile.damage/5, 0f, Projectile.owner, Projectile.whoAmI);
						}
					}
				}
				else if (p.argentumType == 3) {
					soundCooldown--;
					if (Timer % 20 == 0) {
						attackCounter++;
						if (Timer % 80 == minionID*20) SoundEngine.PlaySound(new SoundStyle("Zylon/Sounds/Items/ArgentumOrbSFX").WithPitchOffset(Main.rand.NextFloat(1f)).WithVolumeScale(0.25f), Projectile.position);

						float babyRot = MathHelper.ToRadians(animTimer*1.5f);
						Vector2 pos = new Vector2(0, 30).RotatedBy(babyRot+MathHelper.ToRadians(attackCounter%4*90));

						Vector2 projDir = Vector2.Normalize(targetCenter - (Projectile.Center + pos)) * 4f;
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + pos, projDir, ModContent.ProjectileType<ArgentumOrb_SummonLaser>(), (int)(Projectile.damage*0.3f), Projectile.knockBack, Projectile.owner, targetNum);
					}
				}
				/*if (Timer % 120 == 0) { //Old AI
					SoundEngine.PlaySound(new SoundStyle("Zylon/Sounds/Items/ArgentumOrbSFX").WithPitchOffset(Main.rand.NextFloat(3f)).WithVolumeScale(0.35f), Projectile.position);
					Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 4f;
					if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projDir, ModContent.ProjectileType<ArgentumOrb_Laser>(), Projectile.damage, Projectile.knockBack, Projectile.owner, targetNum);
				}*/
			}
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin;
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

			ZylonPlayer p = own.GetModPlayer<ZylonPlayer>();
			if (p.argentumType == 1 && Projectile.friendly) {
				Texture2D cannonTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Armor/ArgentumOrb_RangedCannon");

				Vector2 cannonScale = new Vector2(1f, 1f);
				int temp = Timer % 80;
				if (temp > 70) temp = 80-temp;

				int dist = Math.Abs(temp - minionID*20);

				if (dist <= 10) { //Animation effect on the cannon
					cannonScale = new Vector2(1f, 0.5f + 0.05f*dist);
				}

				Vector2 cannonPos = drawPos + new Vector2(0f, -2f + -22f*cannonScale.Y).RotatedBy(pointer + MathHelper.PiOver2);

				//if (temp == minionID*20) cannonScale = new Vector2(1f, 0.5f);

				Main.spriteBatch.Draw(cannonTexture, cannonPos, null, color, pointer + MathHelper.PiOver2, new Vector2(8, 11), cannonScale, SpriteEffects.None, 0f);
			}
			else if (p.argentumType == 2 && Projectile.friendly) {
				Texture2D spinTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Armor/ArgentumOrb_MagicOverlay");
				float spinRot = MathHelper.ToRadians(animTimer*5);

				Main.spriteBatch.Draw(spinTexture, drawPos, null, color, spinRot, new Vector2(36, 36), 1f, SpriteEffects.None, 0f);
			}
			else if (p.argentumType == 3) {
				Texture2D babyTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Armor/ArgentumOrb_SummonBaby");
				float babyRot = MathHelper.ToRadians(animTimer*1.5f);

				for (int i = 0; i < 4; i++) Main.spriteBatch.Draw(babyTexture, drawPos + new Vector2(0, 30).RotatedBy(babyRot+MathHelper.ToRadians(i*90)), null, color, 0f, new Vector2(10, 10), 1f, SpriteEffects.None, 0f);
			}

            return false;
        }
    }   
}