using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ectojewelo
{
	public class EctojeweloBar : ModItem
	{
		public override void SetDefaults() {
			item.rare = 11;
			item.width = 20;
			item.height = 20;
			item.maxStack = 9999;
			item.value = 50000;
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.EctojeweloBar>();
			item.placeStyle = 0;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<EctojeweloOre>(), 4);
			recipe.AddIngredient(ItemID.Amethyst);
			recipe.AddIngredient(ItemID.Ectoplasm);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}