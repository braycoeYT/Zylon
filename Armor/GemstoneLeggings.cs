using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class GemstoneLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The boots are surprisingly light\n+4% damage\n+175% max speed\n+6% endurance\nThe boots whisper that the true powers of the armor can only be unlocked with all 3 pieces...");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 500000;
			item.rare = 11;
			item.defense = 31;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.allDamage += 0.04f;
			player.maxRunSpeed += 1.75f;
			player.endurance += 0.06f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 15);
			recipe.AddIngredient(ItemID.Amethyst, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}