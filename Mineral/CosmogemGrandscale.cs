using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class CosmogemGrandscale : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Immunity to bleeding, broken armor, burning, chilled, confused,\ncursed, darkness, electrified, feral bite, frostburn, frozen, \npoisoned, silenced, slow, stoned, on fire, and weak\nLava damage is reduced");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.defense = 5;
		}
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[46] = true;
			player.noKnockback = true;
			player.fireWalk = true;
			player.lavaRose = true;
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
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Frostburn] = true;
			//player.buffImmune[mod.BuffType("Crystalizing")] = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AnkhShield);
			recipe.AddIngredient(ItemID.HandWarmer);
			recipe.AddIngredient(ItemID.PocketMirror);
			recipe.AddIngredient(mod.ItemType("MagicalVaccine"));
			recipe.AddIngredient(mod.ItemType("ElectrifyingScent"));
			recipe.AddIngredient(ItemID.ObsidianRose);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}