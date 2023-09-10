using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class LeafBracelet : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Grants two seconds of invincibility after using a healing potion\nIncreases invincibility time after taking damage\nReduces the cooldown of healing potions by 25%\nIncreases life regen slightly");
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 10, 81);
			Item.rare = ItemRarityID.Yellow;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (!player.buffImmune[BuffID.PotionSickness]) p.leafBracer = true; //POINTLESS BUT JUST IN CASE
			player.pStone = true;
			player.longInvince = true;
			player.lifeRegen += 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<LeafBracer>());
			recipe.AddIngredient(ItemID.CharmofMyths);
			recipe.AddIngredient(ItemID.CrossNecklace);
			recipe.AddIngredient(ItemID.BeetleHusk, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}