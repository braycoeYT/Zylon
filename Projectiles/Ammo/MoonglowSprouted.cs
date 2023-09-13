using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Ammo
{
	public class MoonglowSprouted : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Moonglow");
        }
		public override void SetDefaults() {
			Projectile.width = 12; //16
			Projectile.height = 20; //36
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 4;
			Projectile.rotation = 0;
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