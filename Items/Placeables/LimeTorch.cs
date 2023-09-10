using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Placeables
{
	public class LimeTorch : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
			ItemID.Sets.Torches[Type] = true;
		}

		public override void SetDefaults() {
			Item.flame = true;
			Item.noWet = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.holdStyle = ItemHoldStyleID.HoldFront;
			Item.autoReuse = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.LimeTorch>();
			Item.width = 10;
			Item.height = 12;
			Item.value = 50;
		}

		public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup) { // Overrides the default sorting method of this Item.
			itemGroup = ContentSamples.CreativeHelper.ItemGroup.Torches; // Vanilla usually matches sorting methods with the right type of item, but sometimes, like with torches, it doesn't. Make sure to set whichever items manually if need be.
		}

		public override void HoldItem(Player player) {
			// Randomly spawn sparkles when the torch is held. Twice bigger chance to spawn them when swinging the torch.
			if (Main.rand.NextBool(player.itemAnimation > 0 ? 40 : 80)) {
				Dust.NewDust(new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir), 4, 4, ModContent.DustType<Dusts.JadeDust2>());
			}

			// Create a white (1.0, 1.0, 1.0) light at the torch's approximate position, when the item is held.
			Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);

			Lighting.AddLight(position, 0.2f, 0.8f, -1f);
		}

		public override void PostUpdate() {
			// Create a white (1.0, 1.0, 1.0) light when the item is in world, and isn't underwater.
			if (!Item.wet) {
				Lighting.AddLight(Item.Center, 0.2f, 0.8f, -1f);
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(10);
			recipe.AddIngredient(ItemID.Torch, 10);
			recipe.AddIngredient(ModContent.ItemType<Materials.Jade>());
			recipe.Register();
		}
	}
}