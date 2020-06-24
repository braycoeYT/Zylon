using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Empress
{
	[AutoloadEquip(EquipType.Body)]
	public class EmpressBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases your max amount of minions\nIncreases minion damage by 11%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 900000;
			item.rare = 7;
			item.defense = 18;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.minionDamage += 0.11f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EmpressShard"), 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}