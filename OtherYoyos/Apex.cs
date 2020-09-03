using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.OtherYoyos
{
	public class Apex : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 400f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 19.6f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1.25f;
		}
		public float Timer
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}
		public override void AI()
		{
			Timer++;
			if (Timer % 120 == 0)
			{
				if (Main.rand.Next(0, 2) == 0)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), ProjectileID.Bullet, (int)(projectile.damage / 2.5), 0f, Main.myPlayer);
				projectile.velocity.X = 0;
				projectile.velocity.Y = 0;
			}
			if (Main.mouseRight)
				projectile.timeLeft = 0;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 100, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 100, false);
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 153);
				dust.noGravity = true;
				dust.scale = 1.6f;
			}
		}
	}
}