using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class WindWalkerHelm : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Not to be confused with the Wind Waker'\nIncreases run acceleration and deceleration speed by 10%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 15);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 1;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<WindWalkerBreastplate>() && legs.type == ModContent.ItemType<WindWalkerBoots>();
		}
        public override void UpdateEquip(Player player) {
			player.runAcceleration += 0.1f;
			player.runSlowdown += 0.1f;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = "Increases the ability of Hermes Boots\nGreatly increases max jump height\nNegates fall damage";
			if (player.accRunSpeed > 0)
				player.accRunSpeed += 1.25f;
			player.jumpSpeedBoost += 2.5f;
			player.noFallDmg = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SunplateBlock, 12);
			recipe.AddIngredient(ItemID.Feather, 9);
			recipe.AddIngredient(ModContent.ItemType<Materials.WindEssence>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpeckledStardust>(), 8);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();
		}
	}
}