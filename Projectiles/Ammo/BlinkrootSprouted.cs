using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Ammo
{
	public class BlinkrootSprouted : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Blinkroot");
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 5;
			Projectile.rotation = 0;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (target.boss == false)
				target.velocity *= 0.25f;
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (p.bigOlBouquet && Main.rand.NextFloat() < .13f) Main.player[Projectile.owner].Heal(Main.rand.Next(1, 3));
			Projectile.damage /= 2;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
			if (info.PvP)
            {
				target.velocity *= 0.25f;
				ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
				if (p.bigOlBouquet && Main.rand.NextFloat() < .13f) Main.player[Projectile.owner].Heal(Main.rand.Next(1, 3));
				Projectile.damage /= 2;
			}
        }
    }   
}