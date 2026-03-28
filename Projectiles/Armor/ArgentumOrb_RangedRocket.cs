using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Armor
{
	public class ArgentumOrb_RangedRocket : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 16;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			AIType = ProjectileID.RocketI;
		}
        public override bool OnTileCollide(Vector2 oldVelocity) {
			if (Projectile.timeLeft > 2) Projectile.timeLeft = 2;
            return false;
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
            if (Projectile.width == 10) {
				//Projectile.width *= 4;
				//Projectile.height *= 4;
				Projectile.position -= new Vector2(15, 15);
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.timeLeft = 2;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				if (Projectile.width == 10)
				{
					Projectile.position -= new Vector2(15, 15);
				}
				Projectile.timeLeft = 2;
			}
        }

        public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 3; i++) {
				float rand1 = Main.rand.NextFloat(-1.5f, 1.5f);
				float rand2 = Main.rand.NextFloat(-1.5f, 1.5f);
				Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(rand1, rand2), Main.rand.Next(61, 64));
			}
		}
	}   
}