using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class Solaris : ModItem
	{
		public override void SetDefaults() { //Reference to Sonic '06
			Item.damage = 104; //This progression is getting MOVED when we start PML, I've had to cut the damage down so much AAAA | og damage was like 150 or smth
			Item.DamageType = DamageClass.Melee;
			Item.width = 102;
			Item.height = 108;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 8.2f;
			Item.value = Item.sellPrice(0, 20);
			Item.rare = ModContent.RarityType<PurpleModded>();
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.Solaris>();
			Item.shootSpeed = 10f;
			Item.noUseGraphic = true;
			Item.crit = 4;
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
			recipe.AddIngredient(ModContent.ItemType<Iblis>());
			recipe.AddIngredient(ModContent.ItemType<Mephiles>());
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(ItemID.FragmentSolar, 23);
			recipe.AddRecipeGroup("Zylon:AnyGem", 7);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}