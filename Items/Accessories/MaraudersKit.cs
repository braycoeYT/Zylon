using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class MaraudersKit : ModItem
	{
        public override void SetDefaults() {
			Item.width = 38;
			Item.height = 42;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 7, 50);
			Item.rare = ItemRarityID.Pink;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.magicQuiver = true;
			p.maraudersKit = true;
			p.blowpipeChargeRetain = 0.12f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MagicQuiver);
			recipe.AddIngredient(ModContent.ItemType<IllusoryBulletPolish>());
			recipe.AddIngredient(ModContent.ItemType<TheRegurgitator>());
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}