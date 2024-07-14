using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Tomes
{
	public class FahrenheitFlame : ModProjectile
	{
		public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 22;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = -1;
			Projectile.scale = Main.rand.NextFloat(0.75f, 1f);
			Projectile.usesIDStaticNPCImmunity = true;
			Projectile.idStaticNPCHitCooldown = 10;
			Projectile.DamageType = DamageClass.Magic;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 6)*60);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) {
				target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 6)*60);
			}
        }
		float lightAlpha;
        public override void AI() {
			Projectile.ai[0]++;
			if (Projectile.ai[0] % 4 == 0 && Projectile.ai[1] != 1f) Projectile.velocity.Y += 1;
			if (++Projectile.frameCounter >= 3) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 2)
					Projectile.frame = 0;
			}
			int count1 = (int)Main.GameUpdateCount % 15;
			int count2 = (int)Main.GameUpdateCount % 30;
			if (count2 > 14) lightAlpha = 1f - count1/15f;
			else lightAlpha = count1/15f;
        }
        public override void PostAI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				dust.noGravity = true;
				dust.scale = 0.8f;
			}
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			if (oldVelocity.Y < 0) Projectile.velocity.Y = oldVelocity.Y*-1.5f;
			else {
				Projectile.ai[1] = 1f;
				Projectile.velocity = Vector2.Zero;
				Projectile.timeLeft = 120;
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            }
            return false;
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D altTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/FahrenheitFlame_Light");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);

			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(altTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*lightAlpha, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}