using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class ElementalBands : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Elemental Bands");
			Tooltip.SetDefault("It's kind of odd to have a band with smaller bands hooked to it...\nIncreases life and mana regen by 2\nIncreases movement speed by 75%\nIncreases armor penetration by 10\nCyanix pill and healing potion cooldown are decreased\nIncreases length of invincibility after taking damage");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 350000;
			item.rare = 8;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.pStone = true;
			player.longInvince = true;
			player.lifeRegen += 2;
			player.manaRegen += 2;
			player.maxRunSpeed += 1.5f;
			player.moveSpeed += 0.75f;
			player.armorPenetration += 10;
			p.cyanixShort = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BandofRegeneration);
			recipe.AddIngredient(ItemID.BandofStarpower);
			recipe.AddIngredient(mod.ItemType("BandOfFlashspeed"));
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddIngredient(ItemID.CrossNecklace);
			recipe.AddIngredient(mod.ItemType("DealersStone"));
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 15);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}