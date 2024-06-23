using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class ManaBlossom : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 56;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 6, 50);
			Item.rare = ItemRarityID.Yellow;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (!p.CHECK_ManaBlossom) player.manaCost -= 0.14f;
			p.CHECK_ManaBlossom = true;
			player.manaFlower = true;
			p.succulentSap = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ManaFlower);
			recipe.AddIngredient(ModContent.ItemType<SucculentSap>());
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}