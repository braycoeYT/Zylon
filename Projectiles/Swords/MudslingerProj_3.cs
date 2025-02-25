using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Zylon.Projectiles.Swords
{
	public class MudslingerProj_3 : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Molten Mud");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 40;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 0.5f;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 5));
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 5));
			}
        }

        public override void AI() {
			Projectile.velocity *= 1.02f;
			//Projectile.friendly = Projectile.timeLeft < 105;
			Projectile.rotation += 0.1f;
			Lighting.AddLight(Projectile.Center, 0.25f, 0f, 0f);
		}
		public override void PostAI() {
			int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
			Dust dust = Main.dust[dustIndex];
			dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
			dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
			dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
		}
        public override void OnKill(int timeLeft) {
            for (int i = 0; i < 4; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1.25f + Main.rand.Next(-30, 31) * 0.01f;
			}
        }
        public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}