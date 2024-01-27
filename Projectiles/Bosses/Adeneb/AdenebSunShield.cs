using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Zylon.NPCs;
using System.Collections.Generic;
using System;

namespace Zylon.Projectiles.Bosses.Adeneb
{
	public class AdenebSunShield : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 128;
			Projectile.height = 128;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.hide = true;
		}
		float ihatescale = 0f;
		float hpLeft2;
		bool die;
		bool die2;
		bool init;
		NPC owner;
		int attackTimer;
        int attackInt;
		int attackTimer2;
		bool atkCheck;
        public override void AI() {
			owner = Main.npc[ZylonGlobalNPC.adenebBoss];
			hpLeft2 = (float)owner.life/(float)(owner.lifeMax/2);

			if (!init) {
				if (Projectile.ai[0] == 1f) ihatescale = Main.getGoodWorld ? 1.5f : 1f;
				init = true;
			}
				Projectile.damage = 15; //Plz work and not be stupid
				if (Main.expertMode) Projectile.damage = 25;
				if (Main.masterMode) Projectile.damage = 35;
				//Projectile.damage = (int)(Projectile.damage*(1.2f-(0.2f*hpLeft2)));
            //}

			if (!(owner.life < 1 || !owner.active)) Projectile.timeLeft = 2; //Active check

			//Init scale
			if (!die && !die2) {
				if (ihatescale < 1f || (ihatescale < 1.5f && Main.getGoodWorld)) ihatescale += 0.02f;
				if (ihatescale < 1.5f && Main.getGoodWorld) ihatescale += 0.01f;
			}
			//Pos fix
            if (!die2) Projectile.Center = owner.Center;
			Projectile.rotation += MathHelper.ToRadians(5);

			if (owner.ai[1] == 99) { //Finale
				attackTimer = 0;
				Projectile.velocity = Vector2.Zero;
            }
			else if (owner.ai[1] == 1) { //ShieldSplit
				if (ihatescale < 1.5f || (ihatescale < 2f && Main.getGoodWorld)) ihatescale += 0.01f;
				else {
					if (Main.netMode != NetmodeID.MultiplayerClient) for (int x = 0; x < 2; x++) {
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<AdenebSunShieldSplit>(), Projectile.damage, 0f, -1, x);
                    }
					Projectile.Kill();
                }
            }
			else if (owner.ai[1] == 2 || die) { //SunRayRing
				die = true;
				ihatescale -= 0.04f;
				if (Main.getGoodWorld) ihatescale -= 0.02f;
				if (ihatescale <= 0.5f) {
					Projectile.Kill();
					int m = 21 - (int)(9*hpLeft2);
					if (Main.netMode != NetmodeID.MultiplayerClient) for (int x = 0; x < m; x++) {
						Vector2 tempSpd = new Vector2(0, -5f).RotatedBy(MathHelper.ToRadians(360*x/m));
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, tempSpd, ModContent.ProjectileType<AdenebLaserSpeedUpOG>(), (int)(Projectile.damage*0.8f), 0f);
						if (x == 0) Projectile.NewProjectile(Projectile.GetSource_FromThis(), owner.Center, Vector2.Zero, ModContent.ProjectileType<AdenebSunShield>(), Projectile.damage, 0f);
					}
                }
            }
			else if (owner.ai[1] == 3 || die2) { //MiniSunBarrage
				Projectile.hostile = false; //to be nice
				die2 = true;
				attackTimer++;
				if (attackTimer > 20 && attackInt == 0) {
					attackInt++;
					attackTimer = 0;
                }
				if (attackInt > 0) {
					attackTimer2++;
					if (attackTimer2 > 220) ihatescale -= 0.05f;
					if (Main.getGoodWorld && attackTimer2 > 240) ihatescale -= 0.025f;

					if (ihatescale <= 0f) {
						if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), owner.Center, Vector2.Zero, ModContent.ProjectileType<AdenebSunShield>(), Projectile.damage, 0f);
						Projectile.Kill();
					}
					if (attackTimer >= 12+(10*hpLeft2)) {
						ihatescale -= 0.01f;
						if (Main.getGoodWorld) ihatescale -= 0.005f;
						if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 3).RotatedByRandom(MathHelper.TwoPi), ModContent.ProjectileType<AdenebMiniSunChase>(), (int)(Projectile.damage*0.8f), 0f);
						attackTimer = 0;
                    }
                }

				//Rise about the player
				float c = 1.25f;
				if (Main.getGoodWorld) c = 1.5f;

				Player target = Main.player[owner.target];
				Vector2 tarPos = target.Center - new Vector2(0, 240);

				if (Projectile.Center.Y < tarPos.Y && attackTimer % 5 == 0) Projectile.velocity.Y += c;
				else if (attackTimer % 5 == 0) Projectile.velocity.Y -= c;
				if (Projectile.velocity.Y > 22) Projectile.velocity.Y = 22;
				if (Projectile.velocity.Y < -22) Projectile.velocity.Y = -22;
	
				//Horizontal manager
				if (Projectile.Center.X < tarPos.X && attackTimer % 5 == 0) Projectile.velocity.X += c;
				else if (attackTimer % 5 == 0) Projectile.velocity.X -= c;
				if (Projectile.velocity.X > 20) Projectile.velocity.X = 20;
				if (Projectile.velocity.X < -20) Projectile.velocity.X = -20;
				
				//Faster
				if (Projectile.Center.X < tarPos.X - 600) Projectile.velocity.X += 2;
				if (Projectile.Center.X > tarPos.X + 600) Projectile.velocity.X -= 2;
				//if (Projectile.Center.Y < tarPos.Y - 200) Projectile.velocity.Y += 2;
				if (Projectile.Center.Y > tarPos.Y + 100) Projectile.velocity.Y -= 2;

				if (Math.Abs(Projectile.Center.Y - tarPos.Y) < 120) Projectile.velocity.Y *= 0.85f;
            }
			else if (owner.ai[1] == 5) { //Finale
				if (Main.getGoodWorld) ihatescale += 0.0125f;
				else ihatescale += 0.025f;
				if (ihatescale > 2f) {
					//ihatescale = 2f;
					attackTimer++;
					if (attackTimer >= 120) {
						Projectile.Kill(); //Goodbye friend.
                    }
					else if (attackTimer > 60) {
						Projectile.velocity.Y *= 1.05f;
                    }
					else if (attackTimer == 60) {
						Projectile.velocity.Y = -1f;
                    }
                }
            }
        }
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Adeneb/AdenebSunShield");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, ihatescale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, ihatescale, SpriteEffects.None, 0f);

            return false;
        }
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) {
            behindNPCs.Add(index);
        }
    }   
}