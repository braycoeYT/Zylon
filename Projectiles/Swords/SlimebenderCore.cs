using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Swords
{
	public class SlimebenderCore : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 2;
			Projectile.alpha = 255;
		}
        public override void OnSpawn(IEntitySource source) {
            Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.slimebenderDamage = 0;
			p.slimebenderCore = 1;
        }
        int spawnInit = 30;
		int flashTimer;
		float rand = Main.rand.NextFloat(MathHelper.TwoPi);
		bool finalMode;
		float finalModeY;
		int lastKnownCore = 1;
        public override bool PreAI() {
            if (finalMode) {
				Player player = Main.player[Projectile.owner];
				finalModeY -= 1f;
				finalModeY *= 1.07f;
				Projectile.Center = player.Center + new Vector2(0, finalModeY);

				Projectile.rotation += 0.03f;
				rand += 1f/130f;
				if (lastKnownCore == 13) flashTimer++; //Continues animation.
			}
			return !finalMode;
        }
        public override void AI() {
			Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();

			Projectile.Center = player.Center;
			Projectile.rotation += 0.03f;
			rand += 1f/130f;

			//Manage activity
			if (p.slimebenderCore > 0) Projectile.timeLeft = 2;

			if (spawnInit > 0) spawnInit--; //Fade in transition
			if (p.slimebenderCore == 13) flashTimer++; //Flashes to tell the player they are ready.

			if (p.slimebenderCore != 0) lastKnownCore = p.slimebenderCore;
			else {
				if (player.HeldItem.type == ItemType<Items.Swords.Slimebender>() && !player.dead && player.active) { //Checking that the right click was real
					finalMode = true;
					Projectile.timeLeft = 90;
					SoundEngine.PlaySound(SoundID.Item67, player.Center);
				}
			}
		}
        public override void OnKill(int timeLeft) {
			Vector2 newPos = new Vector2(Main.MouseWorld.X, Main.player[Projectile.owner].Center.Y-528);
            if (Projectile.owner == Main.myPlayer && finalMode) Projectile.NewProjectile(Projectile.GetSource_FromThis(), newPos, Vector2.Zero, ProjectileType<SlimebenderRain>(), 200, 4f, Projectile.owner, lastKnownCore);
        }
        public override bool PreDraw(ref Color lightColor) {
			Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Swords/SlimebenderCore_Glow");
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = player.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

			float visibility = 1f-(spawnInit/30f);

			Vector2 spawn = player.Center;
			if (finalMode) spawn = Projectile.Center;
			
			//j = how many projectiles to spawn, k = trail for one projectile
            if (p.slimebenderCore > 0) for (int j = 0; j < p.slimebenderCore; j++) for (int k = 0; k < 15; k++) {
                Vector2 drawPosEffect = spawn - new Vector2(0, 130).RotatedBy(MathHelper.ToRadians(k+(j*27.6923f))+rand) - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) - new Vector2(Projectile.width/2, Projectile.height/2);
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, Color.White*visibility, Projectile.oldRot[k], drawOrigin, Projectile.scale-(0.06f*k), SpriteEffects.None, 0);
            }
			if (finalMode) for (int j = 0; j < lastKnownCore; j++) for (int k = 0; k < 15; k++) {
                Vector2 drawPosEffect = spawn - new Vector2(0, 130).RotatedBy(MathHelper.ToRadians(k+(j*27.6923f))+rand) - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) - new Vector2(Projectile.width/2, Projectile.height/2);
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, Color.White*visibility, Projectile.oldRot[k], drawOrigin, Projectile.scale-(0.06f*k), SpriteEffects.None, 0);
            }

			//Glow effect at max cores
			if (p.slimebenderCore == 13 || lastKnownCore == 13) for (int j = 0; j < 13; j++) for (int k = 0; k < 15; k++) {
				int flashTimerTemp = (flashTimer) % 180;
				if (flashTimerTemp <= 60) {
					float flashValue = (float)Math.Sin(Math.PI/60f*flashTimerTemp + Math.PI*15f)*(float)Math.Sin(Math.PI/60f*flashTimerTemp + Math.PI*15f);
					Vector2 drawPosEffect = spawn - new Vector2(0, 130).RotatedBy(MathHelper.ToRadians(k+(j*27.6923f))+rand) - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) - new Vector2(Projectile.width/2, Projectile.height/2);
					Main.spriteBatch.Draw(glowTexture, drawPosEffect, null, Color.White*(flashValue/6f)*(k/15f)*visibility, Projectile.oldRot[k], drawOrigin, Projectile.scale-(0.06f*k), SpriteEffects.None, 0);
				}
			}

            //Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
	}
}