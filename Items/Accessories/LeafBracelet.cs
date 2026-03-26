using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class LeafBracelet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 10, 81);
			Item.rare = ModContent.RarityType<PurpleModded>();
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (!player.buffImmune[BuffID.PotionSickness]) p.leafBracer = true; //POINTLESS BUT JUST IN CASE
			player.pStone = true;
			if (!p.CHECK_BandofRegen) player.lifeRegen += 1;
			p.CHECK_BandofRegen = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CharmofMyths);
			recipe.AddIngredient(ModContent.ItemType<LeafBracer>());
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}