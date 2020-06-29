using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Dark
{
	public class DarkToothNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Tooth Necklace");
			Tooltip.SetDefault("Increases armor penetration by 10\nCauses giant darkstars to fall after taking damage");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 100000;
			item.rare = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.armorPenetration += 10;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.darkstarFall = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3212);
			recipe.AddIngredient(mod.ItemType("DarkStarMedal"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}