using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Ammo
{
	public class DeathweedSprouted : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Deathweed");
        }
		public override void SetDefaults() {
			Projectile.width = 12; //16
			Projectile.height = 16; //36
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 3;
			Projectile.rotation = 0;
		}
        public override void ModifyHitPvp(Player target, ref int damage, ref bool crit) {
            if (target.statLife < target.statLifeMax/2) damage += 3;
			if (target.statLife < target.statLifeMax/4) damage += 2;
			if (target.statLife < target.statLifeMax/8) damage += 2;
			if (target.statLife < target.statLifeMax/16) damage += 1;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection){
			if (target.life < target.lifeMax/2) damage += 3;
			if (target.life < target.lifeMax/4) damage += 2;
			if (target.life < target.lifeMax/8) damage += 2;
			if (target.life < target.lifeMax/16) damage += 1;
        }
	}   
}