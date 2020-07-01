using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Cyanix
{
	[AutoloadEquip(EquipType.Body)]
	public class CyanixBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Melee speed is increased by 4%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 6000;
			item.rare = 1;
			item.defense = 5;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.04f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CyanixBar"), 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}