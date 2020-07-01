using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Dark
{
	public class DarknessHive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkness Hive");
			Tooltip.SetDefault("Releases giant darkstars and bees after taking damage");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 100000;
			item.rare = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.bee = true;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.darkstarFall = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HoneyComb);
			recipe.AddIngredient(mod.ItemType("DarkStarMedal"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}