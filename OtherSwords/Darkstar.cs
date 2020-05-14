using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.OtherSwords
{
	public class Darkstar : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkstar");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.HallowStar;
			projectile.width = 80;
			projectile.height = 80;
			projectile.aiStyle = ProjectileID.HallowStar;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}
		public override void AI()
		{
			projectile.rotation += 1;
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 111);
				dust.noGravity = false;
				dust.scale = 1f;
			}
		}
	}   
}