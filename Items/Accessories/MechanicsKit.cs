using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class MechanicsKit : ModItem
	{
        public override void SetDefaults() {
			Item.width = 38;
			Item.height = 42;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 9, 25);
			Item.rare = ItemRarityID.LightPurple;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetDamage(DamageClass.Ranged) += 0.12f;
			player.magicQuiver = true;
			p.maraudersKit = true;
			p.blowpipeChargeRetain = 0.12f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<MaraudersKit>());
			recipe.AddIngredient(ItemID.AvengerEmblem);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}