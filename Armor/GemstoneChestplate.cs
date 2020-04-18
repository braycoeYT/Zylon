using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GemstoneChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The eyes inside are glad you freed them...\nThe eyes are happier when you are doing something\n+4% all damage\n+50 HP, Mana, and Contagion Points\n+6% Damage Reduction\n+2 Health and Mana Regen\nImmunity to knockback");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 750000;
			item.rare = 11;
			item.defense = 42;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.allDamage += 0.04f;
			player.statLifeMax2 += 50;
			player.statManaMax2 += 50;
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalResourceMax2 += 50;
			player.endurance += 0.06f;
			player.lifeRegen += 2;
			player.manaRegen += 2;
			player.noKnockback = true;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 25);
			recipe.AddIngredient(ItemID.Amethyst, 6);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}