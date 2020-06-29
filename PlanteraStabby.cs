using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles
{
	public class PlanteraStabby : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plantera Stabby");
        }
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 5;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            if (Main.rand.Next(5) == 0)
		    target.AddBuff(BuffID.Venom, 350, false);
		}
	}   
}