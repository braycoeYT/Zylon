using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.EyeThemed
{
	public class EctojeweloManaCore : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+20 Mana, +12% Magic Attack, +3 Mana Regen");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 76500;
			item.rare = 11;
			item.defense = 3;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.12f;
			player.statManaMax2 += 20;
			player.manaRegen += 3;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ManaDarknessEye"));
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}