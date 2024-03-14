using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class Inhaler : ModItem
	{
        public override void SetDefaults() {
			Item.width = 20;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1, 34);
			Item.rare = ItemRarityID.Green;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			float ch = player.velocity.Length();
			if (ch > 6f) ch = 6f;
			ch *= 50f/6f;
			p.blowpipeChargeInc += ch/100f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.AdeniteCrumbles>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Materials.WindEssence>(), 9);
			recipe.AddIngredient(ItemID.Cloud, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}