using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Wands
{
	public class VaporsEonBlast : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = Main.rand.Next(25, 41);
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.tileCollide = false;
		}
        public override void AI() {
			if (Projectile.ai[0] == 1f) Projectile.scale = 2f;
			else if (Projectile.ai[0] == 0f) Projectile.scale = 1f;
			else Projectile.scale = 0.5f;
            Projectile.rotation += 0.15f;
        }
        public override void OnKill(int timeLeft) {
			float rand = Main.rand.NextFloat(MathHelper.TwoPi);
			if (Projectile.ai[0] >= 0) {
				int total = 6;
				if (Projectile.ai[0] == 1) total = 4;
				if (Main.myPlayer == Projectile.owner) for (int i = 0; i < total; i++) {
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 15).RotatedBy(rand+MathHelper.ToRadians(360*((float)i/total))), Projectile.type, (int)(Projectile.damage*0.75f), Projectile.knockBack/2, Projectile.owner, Projectile.ai[0]-1);
                }
            }
			else for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceRod);
				dust.noGravity = true;
				dust.scale = 2f;
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
    }   
}