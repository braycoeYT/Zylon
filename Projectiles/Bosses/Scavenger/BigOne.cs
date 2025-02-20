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
	public class BigOne : ModProjectile
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
			Projectile.timeLeft = 480;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrokenCode>(), Main.rand.Next(3, 7) * 60);
        }
		int Timer;
		float visibility;
        public override void AI() {
			NPC owner = Main.npc[ZylonGlobalNPC.scavengerBoss];
			if (!owner.active || owner.life < 1) Projectile.Kill();

			Timer++;
			if (Timer < 60) {
				Projectile.scale = Timer/20f;
				if (Projectile.scale > 1f) Projectile.scale = 1f;
				Projectile.rotation += MathHelper.ToRadians(16);
			}
			else if (Timer == 60) {
				Projectile.velocity = Vector2.Normalize(Projectile.Center - Main.player[owner.target].Center)*-13f;
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			}
			if (Projectile.timeLeft < 30) {
				visibility = Projectile.timeLeft/30f;
				Projectile.hostile = false;
			}

			//Projectile.velocity.Y += (float)Math.Sin(MathHelper.Pi*Timer/120f)*5f;

			if (Timer % 15 == 14 && Timer > 60 && Main.netMode != NetmodeID.MultiplayerClient) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity*-0.5f, ModContent.ProjectileType<BinaryBlast1x1>(), Projectile.damage*3/4, 0f);
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
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
	}   
}