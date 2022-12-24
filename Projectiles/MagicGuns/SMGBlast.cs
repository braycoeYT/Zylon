using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.MagicGuns
{
    public class SMGBlast : ModProjectile
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Space Machine Gun");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults() {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 9999;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 4;
            Projectile.extraUpdates = 1;
        }
        int counter;
        public override void PostAI() {
            counter++;
            if (counter % 3 == 0) Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Firework_Red);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Lighting.AddLight(Projectile.Center, 1f, 0f, 0f);
        }
        public override void Kill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item127, Projectile.position);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}