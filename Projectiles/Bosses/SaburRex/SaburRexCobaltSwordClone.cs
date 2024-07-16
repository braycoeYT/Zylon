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
	public class SaburRexCobaltSwordClone : ModProjectile
	{
        public override void SetDefaults() {
			Projectile.width = 45;
			Projectile.height = 45;
			Projectile.hostile = true;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}
        public override bool CanHitPlayer(Player target) {
            return Projectile.alpha < 101;
        }
		Projectile owner;
        public override void AI() {
			owner = Main.projectile[(int)Projectile.ai[0]];
			Projectile.alpha = owner.alpha;
			if (!Main.npc[ZylonGlobalNPC.saburBoss].active || Main.npc[ZylonGlobalNPC.saburBoss].life < 2) Projectile.Kill();
			if (owner.active && owner.type == ModContent.ProjectileType<SaburRexCobaltClone>()) Projectile.timeLeft = 2;

			Projectile.rotation = owner.ai[2] + MathHelper.PiOver4;

			Vector2 posChange = new Vector2(0, -54).RotatedBy(owner.ai[2]+MathHelper.PiOver2);
			posChange.X *= 0.75f;
			Projectile.Center = owner.Center + posChange; //- new Vector2(8*owner.direction, 0)
			//- new Vector2(8*owner.direction, 0)
			Projectile.spriteDirection = owner.direction;
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = SpriteEffects.None;//Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, null, Color.White*(1f-(float)Projectile.alpha/255f), Projectile.rotation, new Vector2(texture.Width / 2f, texture.Height / 2f), Projectile.scale, effects, 0);
			return false;
		}
    }   
}