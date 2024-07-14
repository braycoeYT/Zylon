using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Zylon.NPCs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Bosses.SaburRex
{
	public class SaburRexMartianSaucer : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 210;
			Projectile.height = 94;
			Projectile.aiStyle = -1;
			Projectile.hostile = false; //Contact damage is mean
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
		}
		bool hasAttacked;
		int Timer;
        public override void AI() {

			Timer++;
			//Projectile.hostile = Projectile.alpha < 180;
			NPC owner = Main.npc[ZylonGlobalNPC.saburBoss];
			Player target = Main.player[owner.target];
			float hpLeft = (float)owner.life/(float)owner.lifeMax; //idk if I will use this or not

			if ((!owner.active || owner.life < 1 || owner.ai[0] != 0f) && Timer < 75) {
				Projectile.alpha += 15;
				if (Projectile.alpha > 254) Projectile.Kill();
				return;
			}

			//Alpha control
			if (hasAttacked && Timer > (120)+45) Projectile.alpha += 15;
			else if (Projectile.alpha > 0) Projectile.alpha -= 15;

			if (hasAttacked && Projectile.alpha > 254) Projectile.Kill();

			if (Timer == 1) { //Init
				Projectile.velocity = Projectile.DirectionTo(target.Center).RotatedByRandom(MathHelper.ToRadians(15f))*6f;
				Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
				Projectile.Center -= Projectile.velocity*30;
			}
			else if (Timer < 32) { //30 frames - spin before hit
				Projectile.rotation += MathHelper.ToRadians(12);
				Projectile.velocity *= 0.96f;
			}
			else if (Timer == 32) {
				int tempNum = (120)-32;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 47.75f).RotatedBy(Projectile.rotation), ModContent.ProjectileType<SaburRexMartianSaucerWarning>(), 0, 0f, -1, Projectile.rotation, tempNum);
				Projectile.velocity = Vector2.Zero;
			}
			if (Timer == 120) {
				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 47.75f).RotatedBy(Projectile.rotation), ModContent.ProjectileType<SaburRexMartianSaucerDeathray>(), Projectile.damage, 0f, -1, Projectile.rotation);
				hasAttacked = true;
			}
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*(((float)255f-Projectile.alpha)/255f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
    }   
}