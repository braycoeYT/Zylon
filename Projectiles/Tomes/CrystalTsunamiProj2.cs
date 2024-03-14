using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Tomes
{
	public class CrystalTsunamiProj2 : ModProjectile
	{
		public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 3;
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 20;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Magic;
		}
		float realScale = Main.rand.NextFloat(0.75f, 1.25f);
        public override void AI() {
			Projectile.scale = realScale;
            Projectile.rotation += 0.1f*realScale;
			Projectile.frame = (int)Projectile.ai[0];

			//Spawn light
			Color myColor = Color.Blue;
			if (Projectile.frame == 1) myColor = Color.Purple;
			else if (Projectile.frame == 2) myColor = Color.Pink;
			Lighting.AddLight(Projectile.Center, myColor.ToVector3() * 0.2f);
        }
        public override void OnKill(int timeLeft) {
			float rand = Main.rand.NextFloat(MathHelper.TwoPi);
			int dustNum = DustID.BlueTorch;
			if (Projectile.frame == 1) dustNum = DustID.PurpleTorch;
			else if (Projectile.frame == 2) dustNum = DustID.PinkTorch;
			for (int i = 0; i < 5; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, dustNum);
				dust.noGravity = true;
				dust.scale = 2f;
				dust.velocity = new Vector2(0, 10).RotatedBy(rand+MathHelper.ToRadians(i*72));
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