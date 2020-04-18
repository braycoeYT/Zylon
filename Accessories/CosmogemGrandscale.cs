using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class CosmogemGrandscale : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmogem Grandscale");
			Tooltip.SetDefault("Immunity to bleeding, broken armor, burning, chilled, confused,\ncursed, darkness, electrified, feral bite, frostburn, frozen, \npoisoned, silenced, slow, stoned, and weak");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 279578;
			item.rare = 11;
			item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.buffImmune[46] = true;
			player.noKnockback = true;
			player.fireWalk = true;
			player.buffImmune[33] = true;
			player.buffImmune[36] = true;
			player.buffImmune[30] = true;
			player.buffImmune[20] = true;
			player.buffImmune[32] = true;
			player.buffImmune[31] = true;
			player.buffImmune[35] = true;
			player.buffImmune[23] = true;
			player.buffImmune[22] = true;
			player.buffImmune[148] = true;
			player.buffImmune[44] = true;
			player.buffImmune[47] = true;
			player.buffImmune[156] = true;
			player.buffImmune[144] = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AnkhShield);
			recipe.AddIngredient(1921);
			recipe.AddIngredient(3781);
			recipe.AddIngredient(mod.ItemType("MagicalVaccine"));
			recipe.AddIngredient(mod.ItemType("ElectrifyingScent"));
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}