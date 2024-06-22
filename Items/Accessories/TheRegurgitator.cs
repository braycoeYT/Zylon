using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class TheRegurgitator : ModItem
	{
        public override void SetDefaults() {
			Item.width = 40;
			Item.height = 38;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 3, 98);
			Item.rare = ItemRarityID.LightRed;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.theRegurgitator = true;
			p.blowpipeChargeRetain = 0.12f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.RottenChunk, 13);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Vertebrae, 13);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}