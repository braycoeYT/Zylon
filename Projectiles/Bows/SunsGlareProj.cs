using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Bows
{
	public class SunsGlareProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 120;
			Projectile.height = 120;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.penetrate = -1;
			Projectile.localNPCHitCooldown = 2;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, 240);
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) target.AddBuff(BuffID.OnFire, 240);
		}
		public override void AI() {
			Projectile owner = Main.projectile[(int)Projectile.ai[0]];
			Projectile.Center = owner.Center;
			Projectile.active = owner.active;
			Projectile.timeLeft = owner.timeLeft;
		}
	}   
}