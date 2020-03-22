using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class CyanixLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+25 Contagion Points");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 5500;
			item.rare = 1;
			item.defense = 4;
		}
		
		public override void UpdateEquip(Player player)
		{
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalResourceMax2 += 25;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CyanixBar"), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}