using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Rare
{
	public class RainbowRose : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Rose");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			aiType = ProjectileID.EnchantedBoomerang;
			projectile.melee = false;
		}
		public float Timer
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}
		public override void AI()
		{
			if (Timer % 20 == 0)
			{
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), 251, projectile.damage, 2, Main.myPlayer);
			}
		}
	}   
}