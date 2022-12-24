using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;

namespace Zylon.Projectiles.Pets
{
	public class ExtinctionMeteorite : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projPet[Projectile.type] = true;
        }
        public override void SetDefaults() {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            AIType = ProjectileID.ZephyrFish;
            Projectile.width = 140;
            Projectile.height = 140;
        }
        float newRot;
        public override bool PreAI() {
            Player player = Main.player[Projectile.owner];
            player.zephyrfish = false;
            if (!player.dead && player.HasBuff<Buffs.Pets.ExtinctionMeteorite>())
                Projectile.timeLeft = 2;
            return true;
        }
        public override void PostAI() {
            newRot += 0.04f*(Math.Abs(Projectile.velocity.X)+Math.Abs(Projectile.velocity.Y))*Projectile.spriteDirection;
            Projectile.rotation = newRot;
            Lighting.AddLight(Projectile.Center, 0.1f, 0f, 0f);
            Projectile.spriteDirection = 0;
        }
    }   
}