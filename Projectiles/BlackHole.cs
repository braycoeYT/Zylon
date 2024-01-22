using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.Collections.Generic;

namespace Zylon.Projectiles
{
	public class BlackHole : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 160;
			Projectile.height = 160;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 300;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.scale = 0f;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 2;
			Projectile.hide = true;
		}
		public override void AI() {
			//Lighting.AddLight(Projectile.Center, 0.2f, 0.2f, 0.2f);
			Projectile.scale += 0.015f;
			if (Projectile.scale > 1f) Projectile.scale = 1f;
            if (Projectile.timeLeft < 18)
				Projectile.alpha += 15;
        }
        public override void PostAI() {
            base.PostAI();
        }
        public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/BlackHole");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), new Color(255, 255, 255, 255-Projectile.alpha), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) {
            behindNPCs.Add(index);
        }
    }   
}