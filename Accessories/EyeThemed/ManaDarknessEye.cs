using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.EyeThemed
{
	public class ManaDarknessEye : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("+20 Mana, +9% Magic Attack, +2 Mana Regen, -5 HP, +1 Defense");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 3205;
			item.rare = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.09f;
			player.statManaMax2 += 20;
			player.statLifeMax2 -= 5;
			player.manaRegen += 2;
			player.statDefense += 1;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ManaSkullium"));
			recipe.AddIngredient(mod.ItemType("EyeOfPrejudice"));
			recipe.AddIngredient(ItemID.SoulofSight, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}