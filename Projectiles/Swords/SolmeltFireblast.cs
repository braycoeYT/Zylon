using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Swords
{
	public class SolmeltFireblast : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 48;
			Projectile.height = 48;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 45;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.extraUpdates = 1;
			Projectile.scale = 0.75f;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 9)*60);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) {
				target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 9)*60);
			}
        }

        public override void AI() {
			Projectile.velocity *= 1.02f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
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
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.myPlayer == Projectile.owner) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SolmeltSlash>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, -1);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SolmeltSlash>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 1);
			}
		}
	}   
}