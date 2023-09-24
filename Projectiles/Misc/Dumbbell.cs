using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Misc
{
	public class Dumbbell : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
		}
        public override void OnSpawn(IEntitySource source) {
            SoundEngine.PlaySound(SoundID.Item34, Projectile.position);
        }
        public override void AI() {
			Projectile.rotation += 0.02f+(0.08f*Projectile.ai[0]);
			Projectile.ai[1]++;
            Projectile.velocity.X *= 0.94f+(0.06f*Projectile.ai[0]);
			if (Projectile.ai[0] != 1 && Projectile.ai[1] % (4+(int)(0*Projectile.ai[0])) == 0) Projectile.velocity.Y += 1f;
        }
		public override void PostAI() {
            if (Main.rand.NextBool() && Projectile.ai[0] == 1f) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch);
				dust.noGravity = true;
				dust.scale = 0.75f;
			}
        }
        public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Projectile.ai[0] == 1f) for (int x = 0; x < 8; x++) {
				Dust dust = Dust.NewDustDirect(Projectile.position - new Vector2(Projectile.width, Projectile.height), Projectile.width*2, Projectile.height*2, DustID.RedTorch);
				dust.noGravity = true;
				dust.scale = 3f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 speed = Projectile.velocity;
			speed.Normalize();
			Texture2D fire = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Misc/Dumbbell_Max");
			Vector2 insertPos2 = sheetInsertPosition - speed*64f;

			if (Projectile.ai[0] == 1f) Main.EntitySpriteDraw(fire, insertPos2, new Rectangle?(new Rectangle(0, spriteSheetOffset, fire.Width, fire.Height)), Color.White, speed.ToRotation()+MathHelper.PiOver2, new Vector2(fire.Width / 2f, fire.Height / 2f), 2.5f, effects, 0);
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), lightColor, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}