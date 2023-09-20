using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Projectiles.Boomerangs
{
	public class Mephiles_Shadow : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 70;
			Projectile.height = 70;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.extraUpdates = 1;
			Projectile.scale = 0.75f;
		}
		int hitCount;
		public override void AI() {
			Projectile.ai[0]++;
			Projectile.ai[1]++;
			Projectile.rotation += 0.1f;
			if (Projectile.ai[0] > 48) {
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < 60) Projectile.Kill();
				speed.Normalize();
				Projectile.velocity = speed*-12f;
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(5, 8) * 60);
			if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Mephiles_ShadowStick>(), Projectile.damage, Projectile.knockBack, Projectile.owner, target.whoAmI, Projectile.rotation, 0f);
			Projectile.Kill();
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Mephiles_ShadowStick>(), Projectile.damage, Projectile.knockBack, Projectile.owner, target.whoAmI, Projectile.rotation, 1f);
			Projectile.Kill();
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			if (Projectile.ai[0] < 48) {
				hitCount++;
				Projectile.velocity = -oldVelocity;
				if (Projectile.ai[0] > 20 || hitCount >= 2) Projectile.ai[0] = 48;
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			}
            return false;
        }
    }   
}