using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Discus
{
	[AutoloadEquip(EquipType.Body)]
	public class DiscusBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+10% movement speed\n+5% melee speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 12500;
			item.rare = 1;
			item.defense = 5;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxRunSpeed += 0.1f;
			player.meleeSpeed += 0.05f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZylonianDesertCore"), 8);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}