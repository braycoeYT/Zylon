using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class MoltenSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Molten Seed");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.OnFire, Main.rand.Next(10, 21) * 60, false);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
                if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.OnFire, Main.rand.Next(10, 21) * 60, false);
            }
        }

        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(Projectile.GetSource_FromThis(), Projectile.getRect(), ItemID.Seed);
		}
	}   
}