using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.OtherYoyos
{
	public class SnekYoyo : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snek outta Heck");
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 375f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 21.5f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Poisoned, 250, false);
			target.AddBuff(BuffID.Venom, 150, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Poisoned, 250, false);
			target.AddBuff(BuffID.Venom, 150, false);
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 40);
				dust.noGravity = true;
				dust.scale = 1.6f;
			}
		}
	}
}