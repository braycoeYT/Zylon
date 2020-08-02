using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.OtherSeeds
{
	public class PinkySeedshot : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pinky Seedshot");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.width = 12;
			projectile.height = 12;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextFloat() < .75f)
				target.AddBuff(BuffID.Slimed, 180, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.NextFloat() < .75f)
				target.AddBuff(BuffID.Slimed, 180, false);
		}
	}   
}