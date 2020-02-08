using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class SoulOfKitty7 : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Kitty 7 is a bit suspicious now...\n+2 Defense, +120 Mana, +10% Damage, +10 HP, +2 Mana Regen, +2 Seconds of wingtime");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 120317;
			item.rare = 11;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense += 2;
			player.statManaMax2 += 120;
			player.meleeDamage += 0.1f;
			player.rangedDamage += 0.1f;
			player.magicDamage += 0.1f;
			player.minionDamage += 0.1f;
			player.thrownDamage += 0.1f;
			player.statLifeMax2 += 10;
			player.manaRegen += 2;
			player.wingTimeMax += 120;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ManaDarknessEye"));
			recipe.AddIngredient(mod.ItemType("DreamString"), 20);
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.AddIngredient(ItemID.Ectoplasm, 15);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}