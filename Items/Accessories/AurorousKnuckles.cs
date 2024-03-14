using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class AurorousKnuckles : ModItem
	{
		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.LightPurple;
			Item.defense = 8;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.aggro += 400;
			if (player.statLife <= player.statLifeMax2 * 0.5f)
				player.AddBuff(62, 5, true);
			if (p.fleKnuCheck) player.statDefense -= 8;
			p.fleKnuCheck = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FleshKnuckles);
			recipe.AddIngredient(ItemID.FrozenTurtleShell);
			recipe.AddIngredient(ItemID.SoulofMight, 8);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}