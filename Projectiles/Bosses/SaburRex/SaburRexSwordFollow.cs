using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Zylon.NPCs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.Collections.Generic;

namespace Zylon.Projectiles.Bosses.SaburRex
{
	public class SaburRexSwordFollow : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 8;
        }
        public override void SetDefaults() {
			Projectile.width = 54;
			Projectile.height = 54;
			//Projectile.hostile = true;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.hide = true;
		}
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) {
            behindNPCs.Add(index);
		}
        public override void AI() {
			Projectile.netUpdate = true;
			NPC owner = Main.npc[ZylonGlobalNPC.saburBoss];
			if (owner.active && owner.life > 1) Projectile.timeLeft = 2;
			Projectile.position = owner.position - new Vector2(12*owner.direction, 0); //og 18
			Projectile.frame = (int)owner.ai[1];
			Projectile.direction = owner.direction;
			Projectile.rotation = MathHelper.ToRadians(135);
			
			if (owner.direction == -1) Projectile.position += new Vector2(8, 0);
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