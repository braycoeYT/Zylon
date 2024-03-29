using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class ShiverthornSprouted : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Shiverthorn");
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 2;
			Projectile.rotation = 0;
		}
		int Timer;
        public override void AI() {
            Timer++;
			if (Timer % 60 == 0)
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2 (0, -8), ModContent.ProjectileType<IceBoltRanged>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (p.bigOlBouquet && Main.rand.NextFloat() < .13f) Main.player[Projectile.owner].Heal(Main.rand.Next(1, 3));
			Projectile.damage /= 2;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) {
				ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
				if (p.bigOlBouquet && Main.rand.NextFloat() < .13f) Main.player[Projectile.owner].Heal(Main.rand.Next(1, 3));
				Projectile.damage /= 2;
            }
        }
    }   
}