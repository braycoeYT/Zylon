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
	public class WindElemental_Protect : ModProjectile
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
			Projectile.alpha = 255;
			Projectile.hostile = true;
        }
		bool init;
        NPC main;
        public override void AI() {
			if (!init) {
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(), ModContent.ProjectileType<WindElemental_ProtectDeco>(), 0, 0f, Main.myPlayer, Projectile.whoAmI, BasicNetType: 2);
				init = true;
            }
			main = Main.npc[(int)Projectile.ai[0]];
			Projectile.Center = main.Center;
			//Projectile.rotation += 0.15f;
			if (Projectile.timeLeft < 60 && main.life > 1 && main.active == true) {
				Projectile.alpha += 4;
				Projectile.scale += 0.05f;
				Projectile.width = (int)(70*Projectile.scale);
				Projectile.height = (int)(66*Projectile.scale);
				/*if (Projectile.timeLeft == 59) {
					Vector2 speed = main.Center - Main.player[main.target].Center;
					speed.Normalize();
					Projectile.velocity = speed * -7f;
                }*/
            }
			else if (!(main.life > 1 && main.active == true)) {
				Projectile.alpha += 7;
				if (Projectile.alpha > 254) Projectile.active = false;
				//Projectile.Center = main.Center;
            }
			else { 
				Projectile.alpha -= 5;
				if (Projectile.alpha < 0) Projectile.alpha = 0;
				//Projectile.Center = main.Center;
			}
        }
    }
}