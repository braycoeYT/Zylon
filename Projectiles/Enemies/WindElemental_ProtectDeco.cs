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

namespace Zylon.Projectiles.Enemies
{
	public class WindElemental_ProtectDeco : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wind Elemental");
        }
        public override void SetDefaults() {
            Projectile.width = 70;
			Projectile.height = 66;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 180;
			Projectile.tileCollide = false;
			Projectile.penetrate = 9999;
        }
        Projectile main;
        public override void AI() {
			main = Main.projectile[(int)Projectile.ai[0]];
			Projectile.rotation += 0.15f;
			Projectile.scale = main.scale;
			Projectile.active = main.active;
			Projectile.Center = main.Center;
			Projectile.alpha = main.alpha;
        }
    }
}