using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class ElementalGooshot : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Elemental Gooshot");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.ElementalDegeneration>(), 60*Main.rand.Next(5, 11));
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(ModContent.BuffType<Buffs.Debuffs.ElementalDegeneration>(), 60 * Main.rand.Next(5, 11));
			}
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .1f) Item.NewItem(Projectile.GetSource_FromThis(), Projectile.getRect(), ModContent.ItemType<Items.Ammo.ElementalGooshot>());
		}
	}   
}