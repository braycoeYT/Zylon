using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Magentite
{
	[AutoloadEquip(EquipType.Body)]
	public class MagentiteBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("-3% Mana Cost");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 6000;
			item.rare = 1;
			item.defense = 4;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.manaCost -= 0.03f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MagentiteBar"), 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}