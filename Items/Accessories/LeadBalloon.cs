using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class LeadBalloon : ModItem
	{
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			Tooltip.SetDefault("'I saw this in a video game once'\nIncreases jump height\nIncreases max falling speed and grants immunity to fall damage\nIncreases blowpipe charge speed by 6/s (does not stack with other balloons)");
=======
			// Tooltip.SetDefault("'I saw this in a video game once'\nIncreases jump height\nIncreases max falling speed and grants immunity to fall damage\nIncreases blowpipe charge speed by 6/s (does not stack with other balloons)");
>>>>>>> ProjectClash
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 2;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.maxFallSpeed += 6f;
			player.jumpBoost = true;
			player.noFallDmg = true;
			if (!p.balloonCheck) { 
				p.blowpipeChargeInc += 0.2f;
			}
			p.balloonCheck = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShinyRedBalloon);
			recipe.AddIngredient(ItemID.Shackle);
			recipe.AddIngredient(ItemID.LuckyHorseshoe);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}