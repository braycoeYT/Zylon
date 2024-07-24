using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Projectiles.Bosses.SaburRex;

namespace Zylon.Projectiles.Misc
{
	public class WinkofRadiasProj : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 38;
			Projectile.height = 38;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 780;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
		}
		int Timer;
		int rand = 1;
		float projSize = 1f;
        public override void AI() {
			if (Projectile.Center.Y < (Main.rockLayer+Main.maxTilesY-250)*8) { //It just has to reach down from the surface to the caverns. Inspired by my first playthrough of Zylon spawning no surface Hallow. You need surface Hallow to beat the mod.
				Projectile.timeLeft = 251;
			}
			Timer++;
			if (Timer == 1 && Main.rand.NextBool()) rand = -1;
			Projectile.rotation += MathHelper.ToRadians(4*rand);

			if (Timer < 17) Projectile.alpha -= 15;

			if (Projectile.timeLeft < 100) Projectile.scale -= 0.01f;

			if (Projectile.timeLeft < 200) projSize -= 0.005f;

			if (Timer % 3 == 0 && Projectile.alpha < 50) {
				SoundEngine.PlaySound(SoundID.NPCHit5.WithPitchOffset(Main.rand.NextFloat(-1f, 1f)), Projectile.position);
				if (Main.netMode != NetmodeID.MultiplayerClient) for (int i = 0; i < 4; i++) {
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 13*projSize).RotatedBy(MathHelper.ToRadians(i*90)+Timer*rand*3), ProjectileID.HallowSpray, 0, 0, Projectile.owner);
				}
			}
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
		    Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;

		    Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
		    Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Color.White*((255f-Projectile.alpha)/255f);
	
		    for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + new Vector2(19, 19+k*2); //+ drawOrigin
			    Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 1f;
			    Main.spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
		    }
		    Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
	
		    return false;
		}
	}   
}