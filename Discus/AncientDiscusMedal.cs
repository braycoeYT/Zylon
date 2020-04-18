using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Discus
{
	public class AncientDiscusMedal : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("+5% Movement Speed\n+1 Minion\n+4% Melee Speed\n-3% Mana Usage");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 6000;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 1;
			player.maxRunSpeed += 0.05f;
			player.meleeSpeed += 0.04f;
			player.manaCost -= 0.03f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZylonianDesertCore"), 4);
			recipe.AddIngredient(mod.ItemType("DiscusMedal"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}