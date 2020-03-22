using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class ElementalBands : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Bands");
			Tooltip.SetDefault("'It's kind of obscure to have a band with 5 smaller bands hooked to it...'\nReduces the cooldown of healing potions\nIncreases Max HP, Mana, and Contagional Points by 50 and their regen by 3\n10% increased all damage\n2% increased all crit\n+15% mining speed\n50% increased minion knockback\nYou can climb walls\nYou can do a ninja dash\n+10% chance of dodging attacks");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 286050;
			item.rare = 8;
			item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			
			player.pStone = true;
			
			player.statLifeMax2 += 50;
			player.statManaMax2 += 50;
			modPlayer.ContagionalResourceMax2 += 50;
			
			player.lifeRegen += 3;
			player.manaRegen += 3;
			modPlayer.ContagionalRegenAmount += 3;
			
			player.meleeSpeed += 0.1f;
			player.meleeDamage += 0.1f;
			player.meleeCrit += 2;
			player.rangedDamage += 0.1f;
			player.rangedCrit += 2;
			player.magicDamage += 0.1f;
			player.magicCrit += 2;
			player.pickSpeed -= 0.15f;
			player.minionDamage += 0.1f;
			player.minionKB += 0.5f;
			player.thrownDamage += 0.1f;
			player.thrownCrit += 2;
			
			player.blackBelt = true;
			player.dash = 1;
			player.spikedBoots = 2;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shackle);
			recipe.AddIngredient(860);
			recipe.AddIngredient(982);
			recipe.AddIngredient(mod.ItemType("ContagionalRegenerationBand"));
			recipe.AddIngredient(1865);
			recipe.AddIngredient(984);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 2);
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}