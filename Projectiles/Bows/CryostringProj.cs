using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bows
{
    public class CryostringProj : ModProjectile
    {
        public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 3;
        }
        public override void SetDefaults() {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.Frostburn, Main.rand.Next(3, 6)*60);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) target.AddBuff(BuffID.Frostburn, Main.rand.Next(3, 6)*60);
        }
        public override void AI() {
            Projectile.frame = (int)Projectile.ai[0];
            if (Main.GameUpdateCount % 5 == 0) Projectile.velocity.Y += 1;
            Projectile.rotation += 0.08f;
        }
        public override void OnKill(int timeLeft) {
            for (int a = 0; a < 3; a++) {
                Dust killDust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, DustID.Ice);
                killDust.velocity *= 1.4f;
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item50, Projectile.position);
        }
    }
}