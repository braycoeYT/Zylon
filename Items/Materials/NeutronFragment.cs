using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class NeutronFragment : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Neutron Fragment");
			Tooltip.SetDefault("'The manifestations of death and intensity inhabit this heavily dense fragment'");
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 28;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = ItemRarityID.Cyan;
		}
		public override void AddRecipes()  {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentStardust);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}