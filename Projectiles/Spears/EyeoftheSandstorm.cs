using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class EyeoftheSandstorm : SpearProj
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Eye of the Sandstorm");
		}

		public EyeoftheSandstorm() : base(-23f, 8, 12.5f, 75f, 0, 12, 90f, 0f, 1.5f, false, false, false) { }

		public override void SpearDefaultsSafe()
        {
			Projectile.width = 54;
			Projectile.height = 54;
		}
        public override void SpearOnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (target.type != NPCID.TargetDummy && Projectile.owner == Main.myPlayer) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Vector2(Main.rand.Next(-128, 129), Main.rand.Next(-128, 129)), new Vector2(), ModContent.ProjectileType<DesertSpiritFlameFriendly>(), (int)(Projectile.damage * 0.75f), Projectile.knockBack / 2, Main.myPlayer);
		}
        public override void SpearOnHitPVP(Player target, int damage)
        {
			if (Projectile.owner == Main.myPlayer) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Vector2(Main.rand.Next(-128, 129), Main.rand.Next(-128, 129)), new Vector2(), ModContent.ProjectileType<DesertSpiritFlameFriendly>(), (int)(Projectile.damage * 0.75f), Projectile.knockBack / 2, Main.myPlayer);
		}

		public override void PostAI()
		{
			Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Sand);
			dust.noGravity = true;
			dust.scale = 1f;
			dust.velocity = Projectile.velocity * 3f;
		}
	}
}