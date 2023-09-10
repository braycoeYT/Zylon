using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Tomes.Carnallite
{
	public class DefenseFlower : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Defense Flower");
		}

		public override void SetDefaults() {
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 1000;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.hide = true;
		}

		readonly float AOERange = 380f;
		readonly float Duration = 600f;
		public override void AI()
        {
			Projectile.ai[0]++;
			if (Projectile.ai[0] >= Duration)
            {
				Projectile.Kill();
            }

			Projectile.rotation += 0.025f;

			if (Main.rand.NextBool(7) == true)
            {
				Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<Dusts.CarnalliteTome.DefenseDust>());
			}

			if (Projectile.ai[0] >= fakescaler_limit && !(Projectile.ai[0] >= (Duration - fakescaler_limit)))
            {
                Buff(Main.player[Main.myPlayer]);
            }


        }
        public override bool? CanHitNPC(NPC target)
        {
            return false;
        }

        public override bool CanHitPvp(Player target)
        {
            return false;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
			overPlayers.Add(index);
        }


        float fakescaler;
		float visualoscillation = 0f;
		readonly float fakescaler_limit = 15f;
		readonly float visualoscillation_rate = 60f;

		// These should pretty much always be the same colors except for the last digit on 2 which controls alpha
		readonly Color AOEColor1 = new Color(255, 207, 195);
		readonly Color AOEColor2 = new Color(255, 207, 195, 155);

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D leaves = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/Carnallite/Leaves");
			Texture2D floralGlow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/Carnallite/DefenseFlowerGlow");

			Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Projectile.GetAlpha(lightColor);

			if (Projectile.ai[0] <= fakescaler_limit)
            {
				fakescaler = MathHelper.SmoothStep(0.1f, 1f, (Projectile.ai[0]/fakescaler_limit));
            } else
            {
				if (Projectile.ai[0] >= Duration - fakescaler_limit)
                {
					fakescaler = MathHelper.SmoothStep(1f, 0.1f, ((Projectile.ai[0] - (Duration - fakescaler_limit)) / fakescaler_limit));
				} else
                {
					fakescaler = 1f;
				}
            }

			float fakescale = fakescaler * Projectile.scale;

			Main.spriteBatch.Draw(floralGlow, drawPos, null, Color.White * 0.5f, Projectile.rotation * 0.3f, drawOrigin, (fakescale * 1.22f) + 0.05f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(leaves, drawPos, null, color, Projectile.rotation * 0.3f, drawOrigin, fakescale * 1.22f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(floralGlow, drawPos, null, Color.White * 0.5f, -Projectile.rotation * 0.3f, drawOrigin, (fakescale * 1.22f) + 0.05f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(leaves, drawPos, null, color, -Projectile.rotation * 0.3f, drawOrigin, fakescale * 1.22f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(floralGlow, drawPos, null, Color.White * 0.5f, Projectile.rotation, drawOrigin, fakescale + 0.05f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, fakescale, SpriteEffects.None, 0f);

			return false;
		}

        public override void PostDraw(Color lightColor)
        {
			Texture2D AOE = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/Carnallite/GlowAOE");
			Texture2D AOERing = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/Carnallite/AOERing");
			Texture2D AOERingGlow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/Carnallite/AOERingGlow");

			Vector2 drawOriginAOE = new Vector2(AOE.Width * 0.5f, AOE.Height * 0.5f);
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Projectile.GetAlpha(lightColor);

			visualoscillation++;

			float oscillationProgress;
			if (visualoscillation <= (visualoscillation_rate * 0.5f))
			{
				oscillationProgress = visualoscillation / (visualoscillation_rate * 0.5f);

			}
			else
			{
				oscillationProgress = ((visualoscillation_rate - visualoscillation) / (visualoscillation_rate * 0.5f));

				if (visualoscillation >= visualoscillation_rate)
				{
					visualoscillation = 0f;
				}
			}

			float fakescale = fakescaler * Projectile.scale;
			float oscillatingAlpha = MathHelper.SmoothStep(0.8f, 1f, oscillationProgress);
			float oscillatingScale = MathHelper.SmoothStep(0.98f, 1.02f, oscillationProgress);
			float oscillatingScale2 = MathHelper.SmoothStep(0.99f, 1f, oscillationProgress);
			float AOEScale = AOERange / (AOE.Height * 0.5f);

			Main.spriteBatch.Draw(AOE, drawPos, null, (AOEColor2 * 0.25f) * oscillatingAlpha, Projectile.rotation * 0.1f, drawOriginAOE, (fakescale * AOEScale) * oscillatingScale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(AOERingGlow, drawPos, null, AOEColor1 * oscillatingAlpha * 0.20f, Projectile.rotation * 0.1f, drawOriginAOE, (((fakescale * AOEScale) * oscillatingScale) - 0.05f) * oscillatingScale2, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(AOERingGlow, drawPos, null, AOEColor1 * oscillatingAlpha * 0.10f, Projectile.rotation * 0.1f, drawOriginAOE, (((fakescale * AOEScale) * oscillatingScale) - 0.1f) * oscillatingScale2, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(AOERing, drawPos, null, color, Projectile.rotation * 0.1f, drawOriginAOE, (fakescale * AOEScale) * oscillatingScale, SpriteEffects.None, 0f);

			return;
        }

		public void Buff(Player player)
        {
			if (Vector2.Distance(Projectile.Center, player.Center) <= AOERange)
			{
				player.AddBuff(ModContent.BuffType<Buffs.FloralFortitude>(), 5, false);
				if (Main.rand.NextBool(5) == true) { 
					Dust.NewDustDirect(player.Center, player.width - Main.rand.Next(0, player.width), player.height - Main.rand.Next(0, player.height), ModContent.DustType<Dusts.CarnalliteTome.DefenseFlowerBuffDust>(), Main.rand.NextFloat(-0.57f, 0.57f), 0f, 0, default, 1f);
				}
			}
			

			return;
        }

    }
}