using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class BloodContract : ModItem
	{
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			Tooltip.SetDefault("'Signed in blood...'\nIncreases crit chance by 3\nCritical strikes cause blood to splatter from enemies\nCollected blood will heal the player\nChances of blood appearing are lowered at extremely high crit rates");
=======
			// Tooltip.SetDefault("'Signed in blood...'\nIncreases crit chance by 3\nCritical strikes cause blood to splatter from enemies\nCollected blood will heal the player\nChances of blood appearing are lowered at extremely high crit rates");
>>>>>>> ProjectClash
		}
		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2, 75);
			Item.rare = ItemRarityID.Orange;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetCritChance(DamageClass.Generic) += 3;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.bloodContract = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TatteredCloth, 8);
			recipe.AddIngredient(ItemID.AshBlock, 20);
			recipe.AddIngredient(ItemID.Obsidian, 3);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}