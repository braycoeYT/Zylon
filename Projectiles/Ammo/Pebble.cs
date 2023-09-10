using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class Pebble : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Pebble");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (Main.rand.NextFloat() < .15f) target.AddBuff(BuffID.Confused, Main.rand.Next(5, 11) * 60, false);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
                if (Main.rand.NextFloat() < .15f) target.AddBuff(BuffID.Confused, Main.rand.Next(5, 11) * 60, false);
            }
        }

        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.getRect(), ModContent.ItemType<Items.Ammo.Pebble>());
		}
	}   
}