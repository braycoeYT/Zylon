using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Zylon.NPCs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Bosses.SaburRex
{
	public class SaburRexSwordActive : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults() {
			Projectile.width = 50;
			Projectile.height = 50;
			Projectile.hostile = true;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (Main.expertMode && owner.ai[0] == 1f && owner.ai[3] == 1f) target.KillMe(PlayerDeathReason.ByCustomReason(target.name + " was sent to the dungeon."), 999, 1); //We are NOT messing around.
        }
		NPC owner;
        public override void AI() {
			owner = Main.npc[ZylonGlobalNPC.saburBoss];
			if (owner.active && owner.life > 0) Projectile.timeLeft = 2;
			Projectile.rotation = owner.ai[2]*owner.direction - MathHelper.PiOver4; //Projectile rot for facing right

			Vector2 posChange = new Vector2(0, -64).RotatedBy(owner.ai[2]);
			if (owner.direction == -1) {
				posChange.X *= -1; //If Sabur is flipped, reflect across Y axis
				
				//Projectile.rotation = owner.ai[2]*-1f - MathHelper.PiOver4; //Projectile rotation fix as well.
			}
			posChange.X *= 0.75f;
			Projectile.Center = owner.Center - new Vector2(8*owner.direction, 0) + posChange; //- new Vector2(8*owner.direction, 0)

			Projectile.spriteDirection = owner.direction;
			Projectile.frame = (int)owner.ai[0];
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = SpriteEffects.None;//Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
    }   
}