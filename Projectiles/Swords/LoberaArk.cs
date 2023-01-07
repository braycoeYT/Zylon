using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Swords
{
	public class LoberaArk : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lobera");
			Main.projFrames[Projectile.type] = 28;
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Arkhalis);
			AIType = ProjectileID.Arkhalis;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer % 5 == 0)
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), new Vector2(Main.MouseWorld.X + Main.rand.Next(-160, 161), Main.player[Projectile.owner].position.Y - 400), new Vector2(0, 20), ModContent.ProjectileType<LoberaTropicalOrb>(), (int)(Projectile.damage * 0.4f), Projectile.knockBack / 4, Projectile.owner);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (target.boss == false)
		    target.AddBuff(ModContent.BuffType<Buffs.Debuffs.LoberaSoulslash>(), 60 * Main.rand.Next(2, 8), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.LoberaSoulslash>(), 60 * Main.rand.Next(2, 8), false);
		}
    }   
}