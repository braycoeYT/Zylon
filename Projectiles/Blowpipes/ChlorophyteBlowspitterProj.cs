using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Blowpipes
{
	public class ChlorophyteBlowspitterProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slimeblast");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.ChlorophyteBullet);
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 1;
			Projectile.ignoreWater = true;
			Projectile.light = 0.2f;
			Projectile.DamageType = DamageClass.Ranged;
			AIType = ProjectileID.ChlorophyteBullet;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
    }   
}