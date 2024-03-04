using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Swords
{
	public class FrostbiteProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.aiStyle = -1;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 60;
			Projectile.friendly = true;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(2, 6), false);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(2, 6), false);
        }
        public override void AI() {
            Lighting.AddLight(Projectile.Center, Color.LightBlue.ToVector3() * 0.7f);
            Projectile.rotation += MathHelper.ToRadians(5);
			Projectile.velocity *= 0.95f;
        }
        public override void OnKill(int timeLeft) {
            SoundEngine.PlaySound(SoundID.Item30, Projectile.position);
			float rand = Main.rand.NextFloat(60f);
            if (Main.myPlayer == Projectile.owner) for (int i = 0; i < 6; i++) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 16).RotatedBy(MathHelper.ToRadians(i*60+rand)), ModContent.ProjectileType<FrostbiteProj2>(), Projectile.damage/2, Projectile.knockBack/2, Projectile.owner);
            }
        }
    }   
}