using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bosses.Metelord
{
	public class MiniCursorInfernoRing : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Mini Inferno");
			Main.projFrames[Projectile.type] = 3;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.aiStyle = -1;
		}
        public override void AI() {
            ZylonPlayer p = Main.player[Projectile.owner].GetModPlayer<ZylonPlayer>();
			if (!p.metelordExpert) Projectile.timeLeft = 0;
			Projectile.Center = Main.MouseWorld + Main.player[Projectile.owner].velocity;
			Projectile.rotation += 0.05f;
			if (++Projectile.frameCounter >= 3) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 3)
					Projectile.frame = 0;
			}
			for (int i = 0; i < Main.maxNPCs; i++) {
				if (Vector2.Distance(Projectile.Center, Main.npc[i].Center) < 45)
					if (Main.npc[i].friendly == false)
					Main.npc[i].AddBuff(BuffID.OnFire, Main.rand.Next(5, 11)*60);
            }
			Lighting.AddLight(Projectile.Center, 0.7f, 0.125f, 0.125f);
        }
    }
}