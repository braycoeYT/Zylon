using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class DiskiteBigSun : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pocket Sun");
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 118;
			Projectile.height = 118;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 340;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		int s;
		int Timer;
		int shootCount;
        public override void AI() {
			NPC main = Main.npc[ZylonGlobalNPC.diskiteBoss];
			Timer++;
			if (Timer < 100) {
				Projectile.scale = Timer*0.01f;
				Projectile.Center = main.Center - new Vector2(0, 100).RotatedBy(main.rotation);
            }
			if (Timer == 100) {
				Projectile.velocity = new Vector2(0, -10).RotatedBy(main.rotation);
				s = 8+(int)(6*(main.life-main.lifeMax/2)/(main.lifeMax/2));
				if (s < 8) s = 8;
            }
			if (Timer > 100 && Timer % s == 0) {
				shootCount++;
				float nut = MathHelper.PiOver2*-1;
				if (shootCount % 2 == 0) nut = MathHelper.PiOver2;
				Vector2 oof = Vector2.Normalize(Projectile.velocity)*4f;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, oof.RotatedBy(nut), ModContent.ProjectileType<DiskiteLaserSpeedUp>(), (int)(Projectile.damage*0.85f), 0f);
            }

			//Animation
			Projectile.rotation += Projectile.scale*0.06f;
            if (++Projectile.frameCounter >= 5) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 2)
					Projectile.frame = 0;
			}
        }
        public override void OnSpawn(IEntitySource source) {
			SoundEngine.PlaySound(SoundID.NPCHit5, Projectile.position);
        }
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
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