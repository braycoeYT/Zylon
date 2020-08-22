using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class Meatyrang : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Meatyrangs are definitely poisoned");
		}
		public override void SetDefaults() {
			item.damage = 27;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 4;
			item.knockBack = 2.5f;
			item.value = 32500;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Meatyrang");
			item.shootSpeed = 12f;
			item.noUseGraphic = true;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot) {
                    return false;
                }
            }
            return true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MeatShard"), 20);
			recipe.AddIngredient(mod.ItemType("PlainNoodle"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}