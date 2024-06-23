using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class SucculentSap : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.width = 36;
			Item.height = 34;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 4);
			Item.rare = ItemRarityID.Lime;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (!p.CHECK_ManaBlossom) player.manaCost -= 0.11f;
			p.CHECK_ManaBlossom = true;
			p.succulentSap = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Amber, 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 13);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}