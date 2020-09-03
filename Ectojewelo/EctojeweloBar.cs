using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ectojewelo
{
	public class EctojeweloBar : ModItem
	{
		public override void SetDefaults() {
			item.rare = ItemRarityID.Purple;
			item.width = 20;
			item.height = 20;
			item.maxStack = 9999;
			item.value = Item.sellPrice(0, 1, 30, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.Ectojewelo.EctojeweloBar>();
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