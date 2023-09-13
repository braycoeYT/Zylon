using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Tomes
{
	public class DarkPrognosticusChaosHeart : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Determination Breaker");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 122;
			Projectile.height = 112;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 220;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
		}
		bool stop;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			if (target.boss == false) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), Main.rand.Next(30, 91));
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) {
				target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), Main.rand.Next(30, 91));
			}
        }
		int Timer;
        bool init;
        public override void AI() {
			Timer++;
			Projectile.scale = (float)Timer*0.03f;
			if (Projectile.scale > 1f) Projectile.scale = 1f;
            if (Timer % 60 == 0) {
				for (int x = 0; x < 8; x++) {
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<DarkPrognosticusVoid>(), Projectile.damage/5, Projectile.knockBack, Main.myPlayer, x*45);
                }
				init = true;
            }
			if (Projectile.timeLeft < 30) Projectile.alpha += 9;
        }
    }   
}