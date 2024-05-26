using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Enemies
{
	public class DirtSlimeProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = -1;
			Projectile.tileCollide = false;
		}
		bool launch;
		int rand = Main.rand.Next(2);
		int Timer;
		int Timer2;
		float flashPower;
		bool init;
		Vector2 offset;
        public override void AI() {
			NPC owner = Main.npc[(int)Projectile.ai[0]];
			Projectile.rotation += 0.03f - 0.06f*rand; //Projectile rotation
			Projectile.hostile = launch; //Only damage players if launched
			Projectile.tileCollide = !owner.active || owner.life < 1 || launch;

			if (!init) {
				offset = owner.Center - Projectile.Center;
				init = true;
			}
			if (!Projectile.tileCollide) {
				Projectile.Center = owner.Center + offset;
			}

			//Gravity effect
            Timer++;
			if (Timer % 3 == 0 && Projectile.velocity.Y < 16) Projectile.velocity.Y += 1;

			//Fall to the ground if the slime is dead.
			if (!owner.active || owner.life < 1) return;

			//Launch code - based on X offset
			if (Timer > (int)Projectile.ai[2] && !launch) {
				Timer2++;
				if (Timer2 == 61) {
					launch = true;
					Projectile.velocity = new Vector2(Projectile.ai[1]/3f, -8);
				}
				else Projectile.velocity = Vector2.Zero;

				//Flash animation
				if (Timer2 < 10) flashPower += 0.1f;
				else flashPower -= 0.1f;
			}
			else if (Timer < (int)Projectile.ai[2]) Projectile.velocity = Vector2.Zero;
        }
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Dirt);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Dirt);
				dust.noGravity = true;
				dust.scale = 1.25f;
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D altTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Enemies/DirtSlimeProj_Light");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);

			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), lightColor, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(altTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*flashPower, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}