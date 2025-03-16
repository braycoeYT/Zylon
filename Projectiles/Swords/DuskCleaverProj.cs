using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Swords
{
	public class DuskCleaverProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 120;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
		}
        int Timer;
		public override void AI() {
			Player owner = Main.player[Projectile.owner];
			Projectile.Center = owner.Center;
			Projectile.velocity = Vector2.Zero;
			Timer++;
			if (Timer % 30 == 1 && Projectile.owner == Main.myPlayer) {
				Vector2 dist = Projectile.Center.DirectionTo(Main.MouseWorld)*12f;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, dist.RotatedByRandom(MathHelper.ToRadians(45)), ModContent.ProjectileType<DuskCleaverProj_Mini>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
			}
        }
    }   
}