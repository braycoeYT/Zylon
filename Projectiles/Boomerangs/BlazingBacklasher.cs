using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Boomerangs
{
	public class BlazingBacklasher : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Blazing Backlasher");
        }
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 3;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.MeleeNoSpeed;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Daybreak, 300);
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		int Timer;
		float num31;
		float num32;
		float num38 = 0.25f; //0.25f
		Vector2 vector;
		float num39;
		float num40;
		float num42 = 12f; //18f
		float num43 = 0.6f; //0.4f
		Vector2 vector2; 
		float num44;
		float num45; 
		float num46;
		public override void AI() {
			num31 = Projectile.position.X + (float)(Projectile.width / 2) + Projectile.velocity.X * 100f;
			num32 = Projectile.position.Y + (float)(Projectile.height / 2) + Projectile.velocity.Y * 100f;
			vector = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
			num39 = num31 - vector.X;
			num40 = num32 - vector.Y;
			vector2 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
			num44 = Main.player[Projectile.owner].position.X + (float)(Main.player[Projectile.owner].width / 2) - vector2.X;
			num45 = Main.player[Projectile.owner].position.Y + (float)(Main.player[Projectile.owner].height / 2) - vector2.Y;
			num46 = (float)Math.Sqrt((double)(num44 * num44 + num45 * num45));
			Timer++;
			if (Timer % 20 == 0) 
				ProjectileHelpers.NewNetProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.position + Projectile.velocity * -5, new Vector2(0, 0), ProjectileID.SolarWhipSwordExplosion, Projectile.damage, 0, Projectile.owner);
			else if (Timer > 10) {
				Projectile.width = 32;
				Projectile.height = 32;
			}
			if (Projectile.ai[0] == 0f) {
				if (Projectile.velocity.X < num39)
						{
							Projectile.velocity.X = Projectile.velocity.X + num38;
							if (Projectile.velocity.X < 0f && num39 > 0f)
							{
								Projectile.velocity.X = Projectile.velocity.X + num38 * 2f;
							}
						}
						else if (Projectile.velocity.X > num39)
						{
							Projectile.velocity.X = Projectile.velocity.X - num38;
							if (Projectile.velocity.X > 0f && num39 < 0f)
							{
								Projectile.velocity.X = Projectile.velocity.X - num38 * 2f;
							}
						}
						if (Projectile.velocity.Y < num40)
						{
							Projectile.velocity.Y = Projectile.velocity.Y + num38;
							if (Projectile.velocity.Y < 0f && num40 > 0f)
							{
								Projectile.velocity.Y = Projectile.velocity.Y + num38 * 2f;
							}
						}
						else if (Projectile.velocity.Y > num40)
						{
							Projectile.velocity.Y = Projectile.velocity.Y - num38;
							if (Projectile.velocity.Y > 0f && num40 < 0f)
							{
								Projectile.velocity.Y = Projectile.velocity.Y - num38 * 2f;
							}
						}
			}
			else {
				if (Projectile.type == 383)
					{
						Vector2 vector3 = new Vector2(num44, num45) - Projectile.velocity;
						if (vector3 != Vector2.Zero)
						{
							Vector2 value = vector3;
							value.Normalize();
							Projectile.velocity += value * Math.Min(num43, vector3.Length());
						}
					}
					else
					{
						if (Projectile.velocity.X < num44)
						{
							Projectile.velocity.X = Projectile.velocity.X + num43;
							if (Projectile.velocity.X < 0f && num44 > 0f)
							{
								Projectile.velocity.X = Projectile.velocity.X + num43;
							}
						}
						else if (Projectile.velocity.X > num44)
						{
							Projectile.velocity.X = Projectile.velocity.X - num43;
							if (Projectile.velocity.X > 0f && num44 < 0f)
							{
								Projectile.velocity.X = Projectile.velocity.X - num43;
							}
						}
						if (Projectile.velocity.Y < num45)
						{
							Projectile.velocity.Y = Projectile.velocity.Y + num43;
							if (Projectile.velocity.Y < 0f && num45 > 0f)
							{
								Projectile.velocity.Y = Projectile.velocity.Y + num43;
							}
						}
						else if (Projectile.velocity.Y > num45)
						{
							Projectile.velocity.Y = Projectile.velocity.Y - num43;
							if (Projectile.velocity.Y > 0f && num45 < 0f)
							{
								Projectile.velocity.Y = Projectile.velocity.Y - num43;
							}
						}
					}
			}
		}
	}   
}