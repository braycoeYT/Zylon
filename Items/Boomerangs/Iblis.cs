using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class Iblis : ModItem
	{
		public override void SetDefaults() { //Reference to Sonic '06
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.width = 78;
			Item.height = 64;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 7.1f;
			Item.value = Item.sellPrice(0, 3, 98);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item74;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.Iblis>();
			Item.shootSpeed = 11.5f;
			Item.noUseGraphic = true;
			Item.scale = 0.75f;
			Item.crit = 8;
		}
        public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot) {
                    return false;
                }
            }
            return true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SolChakram>());
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}