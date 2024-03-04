using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Ammo
{
	public class HallowedSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Hallowed Seed");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
			Projectile.penetrate = 3;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (Main.rand.NextBool(2))
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position - new Vector2(0, 400), new Vector2(Main.rand.NextFloat(-1f, 1f), 12), ProjectileID.HallowStar, (int)(Projectile.damage * 0.75f), Projectile.knockBack * 0.5f, Projectile.owner);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
                if (Main.rand.NextBool(2))
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position - new Vector2(0, 400), new Vector2(Main.rand.NextFloat(-1f, 1f), 12), ProjectileID.HallowStar, (int)(Projectile.damage * 0.75f), Projectile.knockBack * 0.5f, Projectile.owner);
            }
        }

        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(Projectile.GetSource_FromThis(), Projectile.getRect(), ModContent.ItemType<Items.Ammo.CorruptSeed>());
		}
	}   
}