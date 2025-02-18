using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.InteropServices;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Accessories
{
	public class CoreofMendingProj : ModProjectile
	{
		public sealed override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 2;
		}
        public override void OnSpawn(IEntitySource source) {
            Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
        }
		bool end;
		int endTimer;
        int Timer;
		int displayNum;

		int prevDisplay;
		int displayCooldown;
        public override bool PreAI() {
			Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.coreofMending || end) Projectile.timeLeft = 2;

			Projectile.Center = player.Center - new Vector2(0, 150).RotatedBy(MathHelper.ToRadians(Timer));
			Projectile.rotation += 0.025f;
			Projectile.scale = 1.25f + (float)Math.Sin(Main.GameUpdateCount/20f)/4f;
			Timer++;

			if (displayCooldown > 0) displayCooldown--;

			//Main.NewText(p.coreofMendingCounter + " | " + displayNum + " | " + Timer + " | " + endTimer);

			if (end) {
				endTimer++;
				if (endTimer % 30 == 0) {
					displayNum--;
					Vector2 spawnCenter = Projectile.Center - new Vector2(0, 24).RotatedBy(MathHelper.ToRadians(displayNum*60f)+Projectile.rotation);
					if (displayNum > -1 && Main.myPlayer == Projectile.owner)
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), spawnCenter, Vector2.Zero, ProjectileType<CoreofMendingProj2>(), 0, 0f, Main.myPlayer);
				}
				if (Timer > 1200) { // && endTimer > 600 | Total time must be 20 seconds - to prevent late-game exploits with op weapons
					p.coreofMendingCounter = 0;
					Projectile.active = false;

					for (int i = 0; i < 12; i++) {
					    Dust dust = Dust.NewDustDirect(player.Center, 1, 1, DustID.RedTorch);
					 	dust.noGravity = false;
					    dust.scale = 1f;
						dust.velocity = new Vector2(0, 5).RotatedBy(MathHelper.ToRadians(i*30));
				    }

					SoundEngine.PlaySound(SoundID.MaxMana.WithPitchOffset(0.5f), player.position);
				}
			}
            return !end;
        }
        public override void AI() {
			Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();

			if (p.coreofMendingCounter >= 60) end = true;
			displayNum = p.coreofMendingCounter/10;

			if (displayNum != prevDisplay) {
				prevDisplay = displayNum;
				displayCooldown = 10;
			}
		}
        public override bool PreDraw(ref Color lightColor) {
			Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D proj2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Accessories/CoreofMendingProj2");
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
			Vector2 drawOrigin2 = new Vector2(proj2.Width * 0.5f, proj2.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;
			
			//j = how many projectiles to spawn, k = trail for one projectile
            if (displayNum > 0) for (int j = 0; j < displayNum; j++) {
                Vector2 drawPosEffect = drawPos - new Vector2(0, 24).RotatedBy(MathHelper.ToRadians(j*60f)+Projectile.rotation); //Projectile.Center - new Vector2(0, 24).RotatedBy(MathHelper.ToRadians(j*60f)+Projectile.rotation) - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                
				float annoying = 1f;
				if (displayCooldown > 0 && j+1 >= displayNum) annoying = 1f-displayCooldown/10f;
					
				Main.spriteBatch.Draw(proj2, drawPosEffect, null, Color.White*annoying, Projectile.rotation, drawOrigin2, Projectile.scale, SpriteEffects.None, 0);
            }

			float visibility = Timer/30f;
			if (visibility > 1f) visibility = 1f;

			if (end) visibility = 1f - endTimer/60f;
			if (visibility < 0f) visibility = 0f;

			Main.spriteBatch.Draw(projectileTexture, drawPos, null, Color.White*visibility, Projectile.rotation, drawOrigin, 1f, SpriteEffects.None, 0);

			return false;
        }
	}
}