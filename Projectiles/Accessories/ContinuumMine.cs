using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Accessories
{
    public class ContinuumMine : ModProjectile
    {
        public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults() {
            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.aiStyle = -1;
            Projectile.friendly = false; //Only damages enemies at the end of its life.
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 181;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
            if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
            return false;
        }
        public override void AI() {
            Projectile.velocity *= 0.9f;
            if (Projectile.timeLeft == 1) {
                Projectile.width = 88;
                Projectile.height = 88;
                Projectile.friendly = true;
            }
            Projectile.rotation += MathHelper.ToRadians(5);
        }
        public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), lightColor, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			
            Texture2D texture2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Accessories/ContinuumMine_Glow");
            Main.EntitySpriteDraw(texture2, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
            return false;
		}
        public override void OnKill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            for (int i = 0; i < 3; i++) {
				float rand1 = Main.rand.NextFloat(-1.5f, 1.5f);
				float rand2 = Main.rand.NextFloat(-1.5f, 1.5f);
				Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(rand1, rand2), Main.rand.Next(61, 64));
			}
        }
    }
}