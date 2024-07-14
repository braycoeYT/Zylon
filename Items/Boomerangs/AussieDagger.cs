using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class AussieDagger : ModItem
	{
		public override void SetDefaults() { //Reference to Sonic '06
			Item.damage = 159;
			Item.DamageType = DamageClass.Melee;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5.5f;
			Item.value = Item.sellPrice(0, 15);
			Item.rare = ModContent.RarityType<Magenta>();
			Item.UseSound = SoundID.Item1; //71
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.AussieDagger>();
			Item.shootSpeed = 34f;
			Item.noUseGraphic = true;
			Item.crit = 2;
		}
        public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot && Main.projectile[i].ai[0] == 0f) {
                    return false;
                }
            }
            return true;
        }
	}
}