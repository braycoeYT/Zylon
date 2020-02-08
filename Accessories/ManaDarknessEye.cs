using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class ManaDarknessEye : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("+75 Mana, +6% Magic Attack, +2 Mana Regen, -25 HP, +1 Defense");
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
			player.magicDamage += 0.06f;
			player.statManaMax2 += 75;
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