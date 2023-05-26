using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class RootGuard : ModItem
	{
		public override void SetStaticDefaults() {
			//Tooltip.SetDefault("Taking damage will summon roots nearby to damage enemies");
		}
		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 24;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 1, 25);
			Item.rare = ItemRarityID.White;
			Item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.rootGuard = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 18);
			recipe.AddIngredient(ItemID.Acorn, 6);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}