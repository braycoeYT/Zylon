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
	public class BigZero : ModProjectile
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
			Projectile.timeLeft = 360;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrokenCode>(), Main.rand.Next(3, 7) * 60);
        }
		int Timer;
		int shootTimer;
        public override void AI() { //ai0 = hpLeft
			Timer++; shootTimer++;
			if (Timer < 20) {
				Projectile.scale = Timer/20f;
				Projectile.rotation = MathHelper.TwoPi*Projectile.scale;
			}
			if (Projectile.timeLeft < 40) {
				Projectile.scale = (Projectile.timeLeft-20f)/20f;
				if (Projectile.scale < 0f) Projectile.scale = 0f;
				Projectile.rotation = MathHelper.TwoPi*Projectile.scale;

				if (Projectile.timeLeft < 20) {
					Projectile.velocity = Vector2.Zero;
					Projectile.hostile = false;
					return;
				}
			}
			NPC owner = Main.npc[ZylonGlobalNPC.scavengerBoss];
			if (!owner.active || owner.life < 1) Projectile.Kill();

			if (owner.ai[0] != 1f && Projectile.timeLeft > 45) Projectile.timeLeft = 45;

			Projectile.velocity = Vector2.Normalize(Projectile.Center - Main.player[owner.target].Center)*(-5f);

			Projectile.velocity.Y += (float)Math.Sin(MathHelper.Pi*Timer/120f)*5f;

			//if (Math.Abs(Main.player[owner.target].Center.X - Projectile.Center.X) > 900) Projectile.velocity = Vector2.Normalize(Projectile.Center - Main.player[owner.target].Center)*-20f;

			float rand = Main.rand.NextFloat(MathHelper.TwoPi);
			if (shootTimer > 110+50*Projectile.ai[0] && Main.netMode != NetmodeID.MultiplayerClient) for (int i = 0; i < 4; i++) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(i*90) + rand), ModContent.ProjectileType<BinaryBlast1x1>(), Projectile.damage*3/4, 0f);
				shootTimer = 0;
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
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.rotation/MathHelper.TwoPi, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
	}   
}