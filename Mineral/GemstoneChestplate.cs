using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	[AutoloadEquip(EquipType.Body)]
	public class GemstoneChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The eyes inside are glad you freed them...\nThe eyes are happier when you are doing something\nDamage reduction increased by 5%\nIncreases all critical strike chance by 5% and damage by 10%\nIncreases max health and mana by 20, and increases health and mana regen by 2\nWhen not moving vertically, your defense is heavily increased\nWhen moving quickly vertically, your defense is slightly decreased\nThe negative effects seem worse because of the positive ones happening when you stand still");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 11;
			item.defense = 44;
		}
		
		public override void UpdateEquip(Player player)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (player.velocity.Y != 0)
			{
				player.statDefense -= (int)Math.Abs(player.velocity.Y);
			}
			else
			player.statDefense += 30;
			player.allDamage += 0.1f;
			player.endurance += 0.05f;
			player.meleeCrit += 5;
			player.rangedCrit += 5;
			player.magicCrit += 5;
			player.statLifeMax2 += 20;
			player.statManaMax2 += 20;
			player.lifeRegen += 2;
			player.manaRegen += 2;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 25);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 20);
			recipe.AddIngredient(ItemID.Amethyst, 6);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}