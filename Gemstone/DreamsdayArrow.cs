using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Gemstone
{
	public class DreamsdayArrow : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dreamsday Arrow");
        }
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 39;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 12;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			projectile.light = 0.75f;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(9) == 0)
		    target.AddBuff(BuffID.Frostburn, 350, false);
            if (Main.rand.Next(9) == 0)
		    target.AddBuff(BuffID.Venom, 350, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(9) == 0)
				target.AddBuff(BuffID.Frostburn, 350, false);
			if (Main.rand.Next(9) == 0)
				target.AddBuff(BuffID.Venom, 350, false);
		}
	}   
}