using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles
{
	public class DirtyJarSpecks : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("the insides of a Dirty Jar");
        }
		
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 550;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextFloat() < .5f)
		    target.AddBuff(BuffID.Slow, 60, false);
		    target.AddBuff(BuffID.Stinky, 180, false);
			if (Main.rand.NextFloat() < .01f)
		    target.AddBuff(BuffID.Slimed, 120, false);
		    if (Main.rand.NextFloat() < .2f)
		    target.AddBuff(BuffID.Wet, 120, false);
		}
	}   
}