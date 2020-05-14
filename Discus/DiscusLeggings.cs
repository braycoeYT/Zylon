using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Discus
{
	[AutoloadEquip(EquipType.Legs)]
	public class DiscusLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+20% movement speed\nImmune to being blown by desert winds");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 7500;
			item.rare = 1;
			item.defense = 4;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxRunSpeed += 0.2f;
			player.buffImmune[194] = true;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZylonianDesertCore"), 6);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}