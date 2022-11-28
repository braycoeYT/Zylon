using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Blowpipes
{
	public class SigilofNobodyism : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sigil of Nobodyism");
			Main.projFrames[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 72;
			Projectile.height = 72;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 9999;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Ranged;
			AIType = ProjectileID.Bullet;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.frame = Main.rand.Next(2);
			if (Projectile.frame == 1f)
				Projectile.light = 0.5f;
			Projectile.alpha = 255;
		}
        public override void AI() {
			if (Projectile.alpha > 0 && Projectile.timeLeft > 18) Projectile.alpha -= 3;
			if (Projectile.timeLeft <= 18) Projectile.alpha += 15;
			Projectile.rotation += MathHelper.ToRadians(5);
				float num165 = 8f; //(float)Math.Sqrt((double)(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y));
				if (Projectile.alpha > 150)
					num165 = 0f;
				float num166 = Projectile.localAI[0];
				if (num166 == 0f)
				{
					Projectile.localAI[0] = num165;
					num166 = num165;
				}
				if (Projectile.alpha > 0)
				{
					Projectile.alpha -= 25;
				}
				if (Projectile.alpha < 0)
				{
					Projectile.alpha = 0;
				}
				float num167 = Projectile.position.X;
				float num168 = Projectile.position.Y;
				float num169 = 300f;
				bool flag4 = false;
				int num170 = 0;
				if (Projectile.ai[1] == 0f)
				{
					for (int num171 = 0; num171 < 200; num171++)
					{
						if (Main.npc[num171].CanBeChasedBy(Projectile, false) && (Projectile.ai[1] == 0f || Projectile.ai[1] == (float)(num171 + 1)))
						{
							float num172 = Main.npc[num171].position.X + (float)(Main.npc[num171].width / 2);
							float num173 = Main.npc[num171].position.Y + (float)(Main.npc[num171].height / 2);
							float num174 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num172) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num173);
							if (num174 < num169 && Collision.CanHit(new Vector2(Projectile.position.X + (float)(Projectile.width / 2), Projectile.position.Y + (float)(Projectile.height / 2)), 1, 1, Main.npc[num171].position, Main.npc[num171].width, Main.npc[num171].height))
							{
								num169 = num174;
								num167 = num172;
								num168 = num173;
								flag4 = true;
								num170 = num171;
							}
						}
					}
					if (flag4)
					{
						Projectile.ai[1] = (float)(num170 + 1);
					}
					flag4 = false;
				}
				if (Projectile.ai[1] > 0f)
				{
					int num175 = (int)(Projectile.ai[1] - 1f);
					if (Main.npc[num175].active && Main.npc[num175].CanBeChasedBy(Projectile, true) && !Main.npc[num175].dontTakeDamage)
					{
						float num176 = Main.npc[num175].position.X + (float)(Main.npc[num175].width / 2);
						float num177 = Main.npc[num175].position.Y + (float)(Main.npc[num175].height / 2);
						if (Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num176) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num177) < 1000f)
						{
							flag4 = true;
							num167 = Main.npc[num175].position.X + (float)(Main.npc[num175].width / 2);
							num168 = Main.npc[num175].position.Y + (float)(Main.npc[num175].height / 2);
						}
					}
					else
					{
						Projectile.ai[1] = 0f;
					}
				}
				if (!Projectile.friendly)
				{
					flag4 = false;
				}
				if (flag4)
				{
					float arg_82C0_0 = num166;
					Vector2 vector19 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
					float num178 = num167 - vector19.X;
					float num179 = num168 - vector19.Y;
					float num180 = (float)Math.Sqrt((double)(num178 * num178 + num179 * num179));
					num180 = arg_82C0_0 / num180;
					num178 *= num180;
					num179 *= num180;
					int num181 = 8;
					Projectile.velocity.X = (Projectile.velocity.X * (float)(num181 - 1) + num178) / (float)num181;
					Projectile.velocity.Y = (Projectile.velocity.Y * (float)(num181 - 1) + num179) / (float)num181;
				}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				int type = ModContent.DustType<Dusts.BlackDust>();
				if (Projectile.frame == 1) type = ModContent.DustType<Dusts.WhiteDust>();
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, type);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
	}   
}