using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.Projectiles.Minions
{
	public class MeteorbProtect : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Meteorb");
        }
        public override void SetDefaults() {
            Projectile.width = 60;
			Projectile.height = 60;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 30;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.alpha = 255;
			Projectile.friendly = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 30;
			Projectile.scale = 0f;
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(2, 5), false);
		}
        public override void OnHitPvp(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(2, 5), false);
        }
		bool init;
        Projectile main;
        public override void AI() {
			if (!init) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(), ModContent.ProjectileType<MeteorbProtectDeco>(), 0, 0f, Main.myPlayer, Projectile.whoAmI);
				init = true;
            }
			main = Main.projectile[(int)Projectile.ai[0]];
			Projectile.Center = main.Center;
			Projectile.alpha -= 25;
			Projectile.scale += 0.05f;
			Projectile.width = (int)(60*Projectile.scale);
			Projectile.height = (int)(60*Projectile.scale);
        }
    }
}