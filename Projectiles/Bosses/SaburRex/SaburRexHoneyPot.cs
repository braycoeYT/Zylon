using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.SaburRex
{
	public class SaburRexHoneyPot : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 72;
			Projectile.height = 72;
			Projectile.aiStyle = -1;
			//Projectile.hostile = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
		}
		Player target;
		int Timer;
		int Timer2;
		int rand = Main.rand.Next(0, 200); //Random spawn position
        public override void AI() { //ai0 - target, ai1 - boss hp left
			NPC owner = Main.npc[ZylonGlobalNPC.saburBoss];

			if (owner.life < 1 || !owner.active || owner.ai[0] != 3f) { //Despawn to prevent annoyance.
				Projectile.alpha += 17;
				if (Projectile.alpha > 254) Projectile.Kill();
				return;
			}

			Timer++;
			target = Main.player[(int)Projectile.ai[0]];
			if (Timer < 120+(int)(120*Projectile.ai[1])) { //Hover above player ominously
				Projectile.alpha -= 17;
				if (Projectile.alpha < 0) Projectile.alpha = 0;
				float x = 200*(float)Math.Sin(Timer/15f+rand);
				Projectile.Center = target.Center - new Vector2(x, 300);
			}
			else if (Timer2 < 120+(int)(30*Projectile.ai[1])) { //Drop the bees - og 90, 60
				Timer2++;
				if (Timer2 > 30+(int)(15*Projectile.ai[1]) && Timer2 % 2 == 0) {
					if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Vector2(Main.rand.Next(-24, 25), 36), new Vector2(0, 8), ModContent.ProjectileType<SaburRexBee>(), Projectile.damage, Projectile.knockBack);
				}
			}
			else {
				Projectile.alpha += 17;
				if (Projectile.alpha > 254) Projectile.Kill();
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);

			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*(1f-(float)Projectile.alpha/255f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}