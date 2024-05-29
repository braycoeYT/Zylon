using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Bows
{
	public class CeruleanArrow : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 4;
		}
        public override void AI() {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Frostburn, 180);
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Shroomed>(), 180);
			target.AddBuff(BuffID.Slimed, 180);
			target.AddBuff(BuffID.Wet, 180);
            if (Projectile.ai[0] == 0 && Projectile.owner == Main.myPlayer) for (int i = 0; i < 3; i++) { //If original projectile, split into three duplicates evenly split across 180 deg
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(-90+i*90)), Projectile.type, Projectile.damage, Projectile.knockBack, Projectile.owner, -1);
				Projectile.Kill();
			}
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) {
				target.AddBuff(BuffID.Frostburn, 180);
				target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Shroomed>(), 180);
				target.AddBuff(BuffID.Slimed, 180);
				target.AddBuff(BuffID.Wet, 180);
				if (Projectile.ai[0] == 0 && Projectile.owner == Main.myPlayer) for (int i = 0; i < 3; i++) { //If original projectile, split into three duplicates evenly split across 180 deg
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(-90+i*90)), Projectile.type, Projectile.damage, Projectile.knockBack, Projectile.owner, -1);
					Projectile.Kill();
				}
            }
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}