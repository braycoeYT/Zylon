using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class GalacticDiamondiumDrill : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Galactic Diamondium Pax");
			Tooltip.SetDefault("'Hit it with the bright side'");
		}

		public override void SetDefaults() 
		{
			item.damage = 39;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = 132000;
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.useTurn = true;
			item.pick = 230;
			item.axe = 28;
			item.tileBoost += 4;
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
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 11);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}