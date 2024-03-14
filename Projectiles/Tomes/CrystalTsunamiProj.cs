using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Tomes
{
	public class CrystalTsunamiProj : ModProjectile
	{
		public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 3;
        }
		public override void SetDefaults() {
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 45;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.frame = Main.rand.Next(3);
			Projectile.extraUpdates = 1;
		}
		float realScale = Main.rand.NextFloat(0.5f, 1f);
        public override void AI() {
			Projectile.scale = realScale;
            Projectile.rotation += 0.2f*realScale;

			//Spawn light
			Color myColor = Color.Blue;
			if (Projectile.frame == 1) myColor = Color.Purple;
			else if (Projectile.frame == 2) myColor = Color.Pink;
			Lighting.AddLight(Projectile.Center, myColor.ToVector3() * 0.45f);
        }
        public override void OnKill(int timeLeft) {
			float rand = Main.rand.NextFloat(MathHelper.TwoPi);
			if (Projectile.scale > 0.8f) {
				//SoundEngine.PlaySound(SoundID.Shatter.WithVolumeScale(0.5f).WithPitchOffset(Main.rand.NextFloat(-2f, 2f)), Projectile.position);
				if (Main.myPlayer == Projectile.owner) for (int i = 0; i < 5; i++) {
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 13).RotatedBy(rand+MathHelper.ToRadians(i*72)), ModContent.ProjectileType<CrystalTsunamiProj2>(), (int)(Projectile.damage*0.75f), Projectile.knockBack/2, Projectile.owner, Projectile.frame);
                }
            }
			else {
				int dustNum = DustID.BlueTorch;
				if (Projectile.frame == 1) dustNum = DustID.PurpleTorch;
				else if (Projectile.frame == 2) dustNum = DustID.PinkTorch;
				for (int i = 0; i < 5; i++) {
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, dustNum);
					dust.noGravity = true;
					dust.scale = 3f;
					dust.velocity = new Vector2(0, 10).RotatedBy(rand+MathHelper.ToRadians(i*72));
				}
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