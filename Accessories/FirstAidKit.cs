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
			Tooltip.SetDefault("Immune to bleeding\n+20 Max HP\n+7 Life Regen");
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
			player.statLifeMax2 += 20;
			player.lifeRegen += 7;
			player.buffImmune[30] = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(885);
			recipe.AddIngredient(49);
			recipe.AddIngredient(892);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddIngredient(ItemID.LifeFruit, 2);
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}