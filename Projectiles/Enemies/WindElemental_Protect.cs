using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.Projectiles.Enemies
{
	public class WindElemental_Protect : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Wind Elemental");
        }
        public override void SetDefaults() {
            Projectile.width = 70;
			Projectile.height = 66;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 180;
			Projectile.tileCollide = false;
			Projectile.penetrate = 9999;
			Projectile.alpha = 255;
			Projectile.hostile = true;
        }
		NPC main;
        public override void AI() {
			main = Main.npc[(int)Projectile.ai[0]];
			Projectile.Center = main.Center + new Vector2(0, 4);
			Projectile.rotation += 0.15f;
			if (Projectile.timeLeft < 60 && main.life > 1 && main.active == true) {
				Projectile.alpha += 4;
				Projectile.scale += 0.05f;
				Projectile.width = (int)(70*Projectile.scale);
				Projectile.height = (int)(66*Projectile.scale);
            }
			else if (!(main.life > 1 && main.active == true)) {
				Projectile.alpha += 7;
				if (Projectile.alpha > 254) Projectile.active = false;
            }
			else { 
				Projectile.alpha -= 5;
				if (Projectile.alpha < 0) Projectile.alpha = 0;
			}
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*((255f-Projectile.alpha)/255f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
    }
}