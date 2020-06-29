using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Cell
{
	public class DiseasedStar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diseased Star");
		}
		public override void SetDefaults()
		{
			//projectile.CloneDefaults(ProjectileID.Bullet);
			aiType = 1;
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = ProjectileID.FallingStar;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			if (Main.expertMode)
			projectile.damage = 41;
			else
			projectile.damage = 29;
		}
		public override void AI()
		{
			projectile.rotation += 0.01f;
		}
	}
}