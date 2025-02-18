using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Accessories
{
	public class CoreofMending : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 26;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.coreofMending = true;

			//Main.NewText(p.coreofMendingCounter + " | " + player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Accessories.CoreofMendingProj>()]);

			if (p.coreofMendingCounter > 0 && player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Accessories.CoreofMendingProj>()] < 1 && Main.myPlayer == player.whoAmI) {
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Accessories.CoreofMendingProj>(), 0, 0f, player.whoAmI);
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 9);
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpeckledStardust>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}