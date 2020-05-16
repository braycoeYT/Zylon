using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.OtherSlappys
{
	public class ShadowOrb : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Orb");
        }
		public override void SetDefaults()
		{
			projectile.width = 39;
			projectile.height = 39;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 8;
			projectile.timeLeft = 1500;
			projectile.ignoreWater = true;
			projectile.light = 0f;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(10) == 0)
		    target.AddBuff(BuffID.Confused, 240, false);
		}
		
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.Next(10) == 0)
		    target.AddBuff(BuffID.Confused, 240, false);
		}
	}   
}