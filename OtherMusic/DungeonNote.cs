using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.OtherMusic
{
	public class DungeonNote : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("A Bonechiller's call");
        }
		public override void SetDefaults()
		{
			projectile.width = 13;
			projectile.height = 27;
			projectile.aiStyle = 21;
			projectile.friendly = true;
			projectile.penetrate = 30;
			projectile.magic = true;
			projectile.timeLeft = 240;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(7) == 0)
		    target.AddBuff(BuffID.Confused, 350, false);
		}
	}   
}