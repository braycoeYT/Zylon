using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome
{
	[AutoloadEquip(EquipType.Legs)]
	public class SymbiosisLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases max health by 20");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 30000;
			item.rare = 1;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 20;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TwistedMembraneBar"), 20);
			recipe.AddIngredient(mod.ItemType("Cytoplasm"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}