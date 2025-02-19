using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Swords
{
	public class SlimebenderRain : ModProjectile
	{
		public sealed override void SetDefaults() {
			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.tileCollide = false;
			Projectile.friendly = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 300;
			Projectile.alpha = 255;
		}
		int Timer;
        public override void AI() {
			Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();

			Timer++;
			if (Timer <= (int)(Projectile.ai[0]*10)+15 && Timer % 3 == 0 && Projectile.owner == Main.myPlayer) {
				int offset = Main.rand.Next(25);
				int dir = 1;
				float scale = 1f; //Main.rand.NextFloat(0.85f, 1.25f); //Scrapped "scale" mechanic. It looked kind of weird.
				if (Main.rand.NextBool()) dir = -1;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Vector2(offset*dir, 0), new Vector2(0, 5/scale), ProjectileType<SlimebenderRainProj>(), Projectile.damage, Projectile.knockBack, Projectile.owner, scale, dir, Projectile.ai[0]);
			}
			else if (Timer > (int)(Projectile.ai[0]*10)+30) Projectile.Kill();
		}
	}
}