using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.EyeThemed
{
	public class HoneyFlavoredEyeCandy : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Honey Flavored Eye Candy");
			Tooltip.SetDefault("The wrapper has an unbearable bee pun on it\nAfter taking damage, mana cost is halved and bees are summoned");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 84000;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.eyeCandy = true;
			player.bee = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EyeCandy"));
			recipe.AddIngredient(ItemID.HoneyComb);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}