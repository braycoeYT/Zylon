using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.Scavenger
{
	public class BigZero2 : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 120;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrokenCode>(), Main.rand.Next(3, 7) * 60);
        }
		int Timer;
		int shootTimer;
		float speed;
		float extraRot;
		Vector2 targetVel;
        public override void AI() {
			Timer++;

			Projectile.rotation = MathHelper.TwoPi*Projectile.scale;

			if (Timer <= 15) { //20
				Projectile.scale = Timer/15f;
				

				if (Timer == 1) targetVel = Projectile.Center.DirectionTo(new Vector2(Projectile.ai[0], Projectile.ai[1])); //Main.player[Main.npc[ZylonGlobalNPC.scavengerBoss].target].Center);
			}
			else if (Timer >= 25) { //35
				speed = (Timer-25)/15f;
				if (speed > 1f) speed = 1f;
				Projectile.velocity = targetVel*15f*speed;

				extraRot += MathHelper.TwoPi*0.05f;
			}
			
			if (Projectile.timeLeft < 40) {
				Projectile.scale = (Projectile.timeLeft-20f)/20f;
				if (Projectile.scale < 0f) Projectile.scale = 0f;
				extraRot += MathHelper.TwoPi*0.05f;

				//Projectile.rotation = MathHelper.TwoPi*Projectile.scale;

				if (Projectile.timeLeft < 20) {
					Projectile.velocity = Vector2.Zero;
					Projectile.hostile = false;
					return;
				}
			}
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            //Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Adeneb/AdenebMiniSunChase");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = Color.White * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k]+extraRot, drawOrigin, Projectile.rotation/MathHelper.TwoPi, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, Color.White, Projectile.rotation+extraRot, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
	}   
}