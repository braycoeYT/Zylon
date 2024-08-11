using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Boomerangs
{
	public class Mephiles_ShadowStick : ModProjectile
	{
        public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
			Projectile.width = 50;
			Projectile.height = 50;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 150;
			Projectile.scale = 0.75f;
			Projectile.tileCollide = false;
		}
		bool ad;
		NPC main = Main.npc[Main.maxNPCs];
		Player main2 = Main.player[Main.maxPlayers];
		Vector2 safe;
		public override void AI() {
			if (!ad) {
				if (Projectile.ai[2] == 0f) main = Main.npc[(int)Projectile.ai[0]];
				else main2 = Main.player[(int)Projectile.ai[0]];
				Projectile.rotation = Projectile.ai[1];
				if (Projectile.ai[2] == 0f) safe = main.Center - Projectile.Center;
				else safe = main2.Center - Projectile.Center;
				ad = true;
            }
			if (Projectile.ai[2] == 0f) Projectile.Center = main.Center - safe;
			else Projectile.Center = main2.Center - safe;
			if (Projectile.ai[2] == 0f && !main.active) Projectile.Kill();
			if (Projectile.ai[2] == 1f && !main2.active) Projectile.Kill();
		}
		public override void PostAI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame);
				dust.noGravity = true;
				dust.scale = 0.75f;
			}
        }
		public override bool PreDraw(ref Color lightColor) {
            SpriteEffects spriteEffects = SpriteEffects.None;

            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
				Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, spriteEffects, 0);
            }
			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0f);
            return false;
        }
        public override void OnKill(int timeLeft) {
            if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Mephiles_ShadowExplosion>(), (int)(Projectile.damage*0.6f), 0.25f, Projectile.owner);
			SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);
		}
    }   
}