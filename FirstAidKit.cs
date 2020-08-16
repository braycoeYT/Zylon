using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class FirstAidKit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("First Aid Kit");
			Tooltip.SetDefault("Immune to bleeding and weak\nIncreases life regen by 4\nIncreases max life by 50\nYou gain life every time you take damage\nWhen you have low health, you have heavily increased life regen");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 120050;
			item.rare = 8;
			item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 50;
			player.lifeRegen += 4;
			player.buffImmune[30] = true;
			player.buffImmune[BuffID.Weak] = true;
			if (player.statLife < player.statLifeMax2 / 4)
				player.lifeRegen += 4;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FruitOfLife"));
			recipe.AddIngredient(mod.ItemType("SunProtection"));
			recipe.AddIngredient(ItemID.AdhesiveBandage);
			recipe.AddIngredient(ItemID.BandofRegeneration);
			recipe.AddIngredient(ItemID.Vitamins);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddIngredient(ItemID.LifeFruit);
			recipe.AddIngredient(mod.ItemType("PlainNoodle"));
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 10);
			recipe.AddIngredient(mod.ItemType("InfectedOnyx"));
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}