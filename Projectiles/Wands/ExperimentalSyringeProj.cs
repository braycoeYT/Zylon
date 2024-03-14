using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Wands
{
	public class ExperimentalSyringeProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 255;
			Projectile.frame = Main.rand.Next(4);
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            int buffType = BuffID.Poisoned;
			switch (Projectile.frame) {
				case 1:
					buffType = BuffID.Confused;
					break;
				case 2:
					buffType = ModContent.BuffType<Buffs.Debuffs.Shroomed>();
					break;
				case 3:
					buffType = BuffID.Venom;
					break;
            }
			target.AddBuff(buffType, Main.rand.Next(8, 16)*60);
        }
        int Timer;
        public override void AI() {
			Timer++;
			Projectile.rotation += 0.1f;

			//Dust trail
            if (Timer > 6) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.ExperimentalSyringeDust>());
				dust.noGravity = true;
				dust.scale = 1f;
				dust.frame = new Rectangle(0, Projectile.frame * 16, 16, 16);
			}
        }
        public override void OnKill(int timeLeft) {
			for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.ExperimentalSyringeDust>());
				dust.position += new Vector2(Main.rand.Next(-8, 9), Main.rand.Next(-8, 9));
				dust.noGravity = true;
				dust.scale = 1f;
				dust.frame = new Rectangle(0, Projectile.frame * 16, 16, 16);
            }
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
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