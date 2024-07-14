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
	public class AdenebSunFourthAttack : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 128;
			Projectile.height = 128;
			Projectile.aiStyle = -1;
			Projectile.hostile = false; //being fair to the players
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			if (Main.getGoodWorld) ihatescale = 2f;
            else ihatescale = 1.5f;
			Projectile.hide = true;
            //Projectile.ai[1] = Main.rand.Next(3);
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(6, 9) * 60);
        }
		int Timer;
        float dist;
        float rot;
        float ihatescale;
        float hpLeft2;
		NPC owner;
        int attackTimer;
        public override bool PreAI() {
            owner = Main.npc[ZylonGlobalNPC.adenebBoss];
            if (owner.ai[0] == 3f) {
                Projectile.timeLeft = 2;
                ihatescale *= 0.99f;
                ihatescale -= 0.01f;
                Projectile.rotation += MathHelper.ToRadians(5);

                if (ihatescale < 0.01f) Projectile.Kill();
            }
            if (!owner.active) Projectile.Kill();
            return owner.ai[0] != 3f;
        }
        public override void AI() {
            Timer++;
            attackTimer++;
			//owner = Main.npc[ZylonGlobalNPC.adenebBoss];
            Player target = Main.player[owner.target];
			Vector2 tarPos = target.Center - new Vector2(600*Projectile.ai[0], 0);
            hpLeft2 = (float)owner.life/(float)(owner.lifeMax/2);

            if (Projectile.ai[0] == -1) {
                //Horizontal managers
                if (Projectile.Center.X < tarPos.X) Projectile.velocity.X += 1;
                else if (Projectile.Center.X > tarPos.X) Projectile.velocity.X -= 1;
                else Projectile.velocity.X *= 0.9f;
                
                if (Projectile.velocity.X > 16) Projectile.velocity.X = 16;
                if (Projectile.velocity.X < -16) Projectile.velocity.X = -16;

                //Vertical managers
                if (Projectile.Center.Y < target.Center.Y && Timer % 2 == 0) Projectile.velocity.Y += 1;
			    else if (Timer % 2 == 0) Projectile.velocity.Y -= 1;
			    if (Projectile.velocity.Y > 10) Projectile.velocity.Y = 10;
			    if (Projectile.velocity.Y < -10) Projectile.velocity.Y = -10;

                if (Projectile.ai[1] == 0) {
                    if (attackTimer > 35 + (15*hpLeft2) && Timer > 45) {
                        attackTimer = 0;
                        if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(-10, 0).RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-20, 20))), ModContent.ProjectileType<AdenebLaser>(), Projectile.damage, 0f);
                    }
                }
                else if (Projectile.ai[1] == 1) {
                    if (attackTimer > 50 + (20*hpLeft2) && Timer > 45 && Timer < 240) {
                        attackTimer = 0;
                        if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(-10, 0), ModContent.ProjectileType<AdenebXBeam>(), Projectile.damage, 0f);
                    }
                }
                else {
                    if (attackTimer > 100 && Timer > 0 && Timer < 301) {
                        attackTimer = 0;
                        if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<AdenebBigSun2>(), Projectile.damage, 0f, -1, 0, Projectile.whoAmI);
                    }
                }
            }
            else {
                //Horizontal managers
                if (Projectile.Center.X > tarPos.X) Projectile.velocity.X -= 1;
                else if (Projectile.Center.X < tarPos.X) Projectile.velocity.X += 1;
                else Projectile.velocity.X *= 0.9f;
                
                if (Projectile.velocity.X > 16) Projectile.velocity.X = 16;
                if (Projectile.velocity.X < -16) Projectile.velocity.X = -16;

                //Vertical managers
                if (Projectile.Center.Y < target.Center.Y && Timer % 2 == 0) Projectile.velocity.Y += 1;
			    else if (Timer % 2 == 0) Projectile.velocity.Y -= 1;
			    if (Projectile.velocity.Y > 10) Projectile.velocity.Y = 10;
			    if (Projectile.velocity.Y < -10) Projectile.velocity.Y = -10;

                if (Projectile.ai[1] == 0) {
                    if (attackTimer > 30 + (15*hpLeft2) && Timer > 45) {
                        attackTimer = 0;
                        if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(10, 0).RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-20, 20))), ModContent.ProjectileType<AdenebLaser>(), Projectile.damage, 0f);
                    }
                }
                else if (Projectile.ai[1] == 1) {
                    if (attackTimer > 50 + (20*hpLeft2) && Timer > 45 && Timer < 240) {
                        attackTimer = 0;
                        if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(10, 0), ModContent.ProjectileType<AdenebXBeam>(), Projectile.damage, 0f);
                    }
                }
                else {
                    if (attackTimer > 100 && Timer > 0 && Timer < 301) {
                        attackTimer = 0;
                        if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<AdenebBigSun2>(), Projectile.damage, 0f, -1, 0, Projectile.whoAmI);
                    }
                }
            }
            if (owner.life == 1 || ihatescale <= 0f)  {
                if (Main.netMode != NetmodeID.MultiplayerClient && Projectile.ai[0] == 1) Projectile.NewProjectile(Projectile.GetSource_FromThis(), owner.Center, Vector2.Zero, ModContent.ProjectileType<AdenebSunShield>(), Projectile.damage, 0f);
                Projectile.Kill();
            }
            if (!(owner.life < 1 || !owner.active)) Projectile.timeLeft = 2; //Active check
            if (Timer > 300) ihatescale -= 0.05f;
			if (Main.getGoodWorld && Timer > 300) ihatescale -= 0.025f;
            /*if (ihatescale <= 0f) {
				if (Main.netMode != NetmodeID.MultiplayerClient && Projectile.ai[0] == 1) Projectile.NewProjectile(Projectile.GetSource_FromThis(), owner.Center, Vector2.Zero, ModContent.ProjectileType<AdenebSunShield>(), Projectile.damage, 0f);
				Projectile.Kill();
			}*/
			Projectile.rotation += MathHelper.ToRadians(5);
        }
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Adeneb/AdenebSunFourthAttack");

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