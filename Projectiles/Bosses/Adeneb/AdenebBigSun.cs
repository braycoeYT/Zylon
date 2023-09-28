using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Zylon.NPCs;
using System;

namespace Zylon.Projectiles.Bosses.Adeneb
{
	public class AdenebBigSun : ModProjectile
	{
        public override void SetStaticDefaults()
        {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
		}

        public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 80;
			Projectile.height = 80;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 340;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		int s;
		int shootCount;

		const int ChargeUpTime = 100;
        public override void AI() {
			NPC main = Main.npc[ZylonGlobalNPC.adenebBoss];


			Projectile.oldPos[0] = Projectile.Center;
			for (int i = Projectile.oldPos.Length - 1; i > 0; i--)
			{
				Projectile.oldPos[i] = Projectile.oldPos[i - 1];
			}

			Projectile.ai[0]++;
			if (Projectile.ai[0] <= ChargeUpTime) {

				if (main.life < main.lifeMax / 2) { //temp fix for phase transition?
					Projectile.Kill();
                }

				if (Projectile.ai[0] == 1)
					SoundEngine.PlaySound(new SoundStyle($"Zylon/Sounds/Projectiles/FireCharge") { Volume = 0.7f, PitchVariance = 0.0f, MaxInstances = 2, }, Projectile.Center);

				GlobalFakeScale = Projectile.ai[0] * (1f/(float)ChargeUpTime);
				Projectile.Center = main.Center - new Vector2(0, 100).RotatedBy(main.rotation);

				if (Projectile.ai[0] == ChargeUpTime)
				{
					Projectile.velocity = new Vector2(0, -10).RotatedBy(main.rotation);
					s = 8 + (int)(6 * (main.life - main.lifeMax / 2) / (main.lifeMax / 2));
					if (s < 8) s = 8;

					Systems.Camera.CameraController.ScreenshakePoints(30, 1000, Main.player[Main.myPlayer].Center, Projectile.Center, 1.5f);
					SoundEngine.PlaySound(new SoundStyle($"Zylon/Sounds/Projectiles/FireBoom") { Volume = 1.2f, PitchVariance = 0.2f, MaxInstances = 2, }, Projectile.Center);
				}
			} else if (Projectile.ai[0] % s == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
				shootCount++;
				float not = MathHelper.PiOver2 * -1;
				if (shootCount % 2 == 0) not = MathHelper.PiOver2;
				Vector2 oof = Vector2.Normalize(Projectile.velocity) * 0.02f;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, oof.RotatedBy(not), ModContent.ProjectileType<AdenebLaserSpeedUp>(), (int)(Projectile.damage * 0.85f), 0f);
			}

			RingRotation = Projectile.ai[0] * 0.06f;
			SparkleRotation = Projectile.ai[0] * 0.078f;
			ChargeUpScale = 1f - GlobalFakeScale;
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}

		float GlobalFakeScale = 0f;
		float ChargeUpScale = 0f;
		float RingRotation = 0f;
		float SparkleRotation = 0f;
		public override bool PreDraw(ref Color lightColor) {
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D ringTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Adeneb/AdenebBigSun_rings");

			Texture2D sphereGlow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Assets/Bloom/Glow120_120");
			Texture2D lineGlow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Assets/Bloom/GlowSparkle");
			Texture2D starGlow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Assets/Bloom/GlowStar");

			Vector2 drawOrigin = texture.Size() * 0.5f;
			Vector2 ringDrawOrigin = ringTexture.Size() * 0.5f;
			Vector2 glowOrigins = sphereGlow.Size() * 0.5f;

			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Projectile.GetAlpha(Color.White);

			Color glowColor = Projectile.GetAlpha(new Color(255, 186, 64)) * 0.25f;

			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

			if (ChargeUpScale > 0.05)
            {
				Main.EntitySpriteDraw(starGlow, drawPos, null, (glowColor * 2f) * GlobalFakeScale, RingRotation * 2f, glowOrigins, ChargeUpScale * 1.5f, effects, 0);
				Main.EntitySpriteDraw(starGlow, drawPos, null, (glowColor * 2f) * GlobalFakeScale, -RingRotation * 2f, glowOrigins, ChargeUpScale * 2.5f, effects, 0);
			}

			Main.EntitySpriteDraw(lineGlow, drawPos, null, glowColor, SparkleRotation, glowOrigins, GlobalFakeScale * 1.2f, effects, 0);
			Main.EntitySpriteDraw(lineGlow, drawPos, null, glowColor, -SparkleRotation, glowOrigins, GlobalFakeScale * 1.2f, effects, 0);

			Main.EntitySpriteDraw(lineGlow, drawPos, null, glowColor, SparkleRotation * 0.75f, glowOrigins, GlobalFakeScale * 1.4f, effects, 0);
			Main.EntitySpriteDraw(lineGlow, drawPos, null, glowColor, -SparkleRotation * 0.75f, glowOrigins, GlobalFakeScale * 1.4f, effects, 0);

			Main.EntitySpriteDraw(sphereGlow, drawPos, null, glowColor * 1.35f, RingRotation * 0.3f, glowOrigins, (GlobalFakeScale * 1.7f) * new Vector2(1f, Math.Abs((float)Math.Sin(SparkleRotation * 0.6f))), effects, 0);
			Main.EntitySpriteDraw(sphereGlow, drawPos, null, glowColor * 1.35f, RingRotation * 0.3f, glowOrigins, (GlobalFakeScale * 1.8f) * new Vector2(Math.Abs((float)Math.Cos(SparkleRotation * 0.6f)), 1f), effects, 0);

			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
				Color colorAfterEffect = glowColor * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
				Main.spriteBatch.Draw(sphereGlow, drawPosEffect, null, colorAfterEffect, 0f, glowOrigins, GlobalFakeScale - k / (float)Projectile.oldPos.Length / 3, SpriteEffects.None, 0);
			}

			Main.EntitySpriteDraw(texture, drawPos, null, color, 0f, drawOrigin, GlobalFakeScale, effects, 0);
			Main.EntitySpriteDraw(ringTexture, drawPos, null, color, RingRotation, ringDrawOrigin, GlobalFakeScale, effects, 0);

			Main.EntitySpriteDraw(ringTexture, drawPos, null, color, RingRotation * 0.5f, ringDrawOrigin, GlobalFakeScale * new Vector2(1f, Math.Abs((float)Math.Sin(RingRotation * 0.8f))) * 1.2f, effects, 0);
			Main.EntitySpriteDraw(ringTexture, drawPos, null, color, RingRotation * 0.25f, ringDrawOrigin, GlobalFakeScale * new Vector2(Math.Abs((float)Math.Cos(RingRotation * 0.5f)), 1f) * 1.1f, effects, 0);

			Main.EntitySpriteDraw(sphereGlow, drawPos, null, glowColor, 0f, glowOrigins, GlobalFakeScale * 1.5f, effects, 0);

			Main.EntitySpriteDraw(sphereGlow, drawPos, null, glowColor * 0.5f, 0f, glowOrigins, GlobalFakeScale * 2.5f, effects, 0);
			return false;
		}
	}   
}