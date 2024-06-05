using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.Graphics.Effects;

namespace Zylon.Projectiles.Minions
{
	public class SwordigamSword : ModProjectile
	{
        public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 60;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.scale = 1f;
			Projectile.hide = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
		public override void AI() {
			Projectile.rotation = Projectile.velocity.ToRotation()-MathHelper.PiOver2;
            if (Projectile.timeLeft < 15)
                Projectile.alpha += 17;
		}
        /*public override void PostAI() {
			if (!launch) {
				if (Vector2.Distance(Projectile.Center, owner.Center) > 1)
					Projectile.Center += owner.velocity;
			}
        }*/
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) {
            behindProjectiles.Add(index);
        }
        public override void OnKill(int timeLeft) {
            Projectile.ai[0] = -1f; //Hello DADDY I AM DEAD PLEASE ACKNOWLEDGE MY PASSING
        }
        public override bool PreDraw(ref Color lightColor) {
			Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            
			Color color = Color.White*((255f-Projectile.alpha)/255f);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) - new Vector2(18, 0);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            
			//if ((int)Projectile.ai[1] == 29f && !launch && owner.ai[2] == 1f) Main.spriteBatch.Draw(projText2, drawPos, null, color*0.5f, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
    }   
}