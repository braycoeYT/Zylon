using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Wands
{
	public class WandofHexingProj : ModProjectile
	{
        public override void SetStaticDefaults() {
<<<<<<< HEAD
			DisplayName.SetDefault("Wand of Hexing");
=======
			// DisplayName.SetDefault("Wand of Hexing");
>>>>>>> ProjectClash
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 90;
			Projectile.DamageType = DamageClass.Magic;
			AIType = ProjectileID.Seed;
		}
        /*public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            damage = (int)(damage*1.2f);
        }
        public override void ModifyHitPvp(Player target, ref int damage, ref bool crit) {
            damage = (int)(damage*1.2f);
        }*/
<<<<<<< HEAD
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(2, 5)*60);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(2, 5)*60);
=======
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(2, 5)*60);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
                target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(2, 5) * 60);
            }
>>>>>>> ProjectClash
        }
        public override void PostAI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
        }
    }   
}