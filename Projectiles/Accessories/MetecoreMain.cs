using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Accessories
{
	public class MetecoreMain : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.tileCollide = false;
			Projectile.friendly = false;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.alpha = 255;
		}
		int Timer;
		public override void AI() {
			Projectile.alpha -= 17;
			Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			Projectile.Center = player.Center - new Vector2(0, 60);
			if (p.metelordExpert == true) Projectile.timeLeft = 2;
			else p.metecoreFloat = 1f;
			Projectile.scale = p.metecoreFloat;
			Projectile.rotation += p.metecoreFloat*0.02f;
			if (p.metecoreFloat >= 3f) {
				Projectile.scale = 3f;
				Projectile.alpha = 255;
				Timer++;
				if (Timer == 1) for (int x = 0; x < 20; x++) {
					Projectile.NewProjectile(player.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-9f, 10f), Main.rand.NextFloat(-7f, -4f)), ProjectileType<MetecoreFireball>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
				}
				if (Timer >= 61) {
					p.metecoreFloat = 1f;
					Projectile.scale = 1f;
					Timer = 0;
                }
            }
		}
	}
}