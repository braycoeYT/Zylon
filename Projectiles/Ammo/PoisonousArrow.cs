using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class PoisonousArrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Poisonous Arrow");
        }
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 3000;
			Projectile.ignoreWater = true;
			AIType = 1;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
		    target.AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(4, 11));
		}

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(4, 11));
			}
        }

        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(Projectile.GetSource_FromThis(), Projectile.getRect(), ModContent.ItemType<Items.Ammo.PoisonousArrow>());
		}
	}   
}