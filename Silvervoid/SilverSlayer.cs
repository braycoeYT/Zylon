using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Silvervoid
{
	public class SilverSlayer : ModItem
	{
		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 189;
			item.width = 33;
			item.height = 33;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = 1;
			item.knockBack = 2.5f;
			item.value = 90000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("SilverSlayer");
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
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SilvervoidCore"), 11);
			recipe.AddIngredient(ItemID.LunarBar, 9);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}