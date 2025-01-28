using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Terraria.GameContent;

namespace Zylon.Items.Accessories
{
	public class ManaPod : ModItem
	{
		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 30;
			Item.value = Item.sellPrice(0, 1, 23);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/ManaPod_Glow");

			spriteBatch.Draw(texture, position, frame, drawColor, 0f, origin, scale, SpriteEffects.None, 0);
			spriteBatch.Draw(glow, position, frame, Color.White, 0f, origin, scale, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/ManaPod_Glow");
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

			spriteBatch.Draw(texture, drawPos, null, lightColor, rotation, frameOrigin, scale, SpriteEffects.None, 0);
			spriteBatch.Draw(glow, drawPos, null, Color.White, rotation, frameOrigin, scale, SpriteEffects.None, 0);
			return false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
            if (player.velocity.X < 0.01f && player.velocity.Y < 0.01f) player.manaRegen += 2;
			if (!player.ZoneUnderworldHeight && !player.ZoneRockLayerHeight && !player.ZoneDirtLayerHeight && Main.dayTime)
				player.statManaMax2 += 40;
			else player.statManaMax2 += 10;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(ItemID.Glass, 10);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpeckledStardust>(), 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}