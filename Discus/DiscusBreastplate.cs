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
			DisplayName.SetDefault("Sandgrain Electroscale");
			Tooltip.SetDefault("Mining speed increased by 3%\nDamage increased by 3%\nMelee speed increased by 7%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 35000;
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.allDamage += 0.03f;
			player.pickSpeed -= 0.03f;
			player.meleeSpeed += 0.07f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DriedEssence"), 8);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}