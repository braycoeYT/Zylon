using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using System;

namespace Zylon.Items.Accessories
{
	public class CosmicDie : ModItem
	{
		public override void SetDefaults() {
			Item.width = 46;
			Item.height = 46;
			Item.value = Item.sellPrice(0, 10);
			Item.rare = ItemRarityID.Red;
		}
        public override void UpdateInventory(Player player) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.cosmicDie = true;
        }
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D sideNumbers = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/CosmicDie_Numbering");

			//Main
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			spriteBatch.Draw(texture, position, null, Color.White, 0f, frameOrigin, 0.7f, SpriteEffects.None, 0);

			//Side Numbering - same texture size as main
			int rot = (int)(Main.GameUpdateCount/10f) % 4;
			spriteBatch.Draw(sideNumbers, position, null, Color.White, MathHelper.ToRadians(rot*90), frameOrigin, 0.7f, SpriteEffects.None, 0);

			float val = ((int)(Main.GameUpdateCount%5000/10)+52)*279.6719f; //Faux randomness every 10 frames
			String val2 = val.ToString();

			int first = Math.Abs(val2[val2.Length-1]);
			int second = 48;
			if (val2.Length > 1) second = Math.Abs(val2[val2.Length-2]);

			if (first < 48) first = 48;
			if (first > 57) first = 57;
			if (second < 48) second = 48;
			if (second > 57) second = 57;

			Texture2D num1 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/CosmicDie_" + (first-48));
			Texture2D num2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/CosmicDie_" + (second-48));

			Rectangle frameNum = num1.Frame();
			Vector2 frameOriginNum = num1.Size() / 2f;
			Vector2 offsetNum = new Vector2(Item.width / 2 - frameOriginNum.X, Item.height - frameNum.Height);
			spriteBatch.Draw(num1, position - new Vector2(4, 0), null, Color.White, 0f, frameOriginNum, 0.7f, SpriteEffects.None, 0);
			spriteBatch.Draw(num2, position + new Vector2(4, 0), null, Color.White, 0f, frameOriginNum, 0.7f, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D sideNumbers = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/CosmicDie_Numbering");

			//Main
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset + new Vector2(0, 2);
			spriteBatch.Draw(texture, drawPos, null, Color.White, rotation, frameOrigin, 1f, SpriteEffects.None, 0);

			//Side Numbering - same texture size as main
			int rot = (int)(Main.GameUpdateCount/10f) % 4;
			spriteBatch.Draw(sideNumbers, drawPos, null, Color.White, MathHelper.ToRadians(rot*90)+rotation, frameOrigin, 1f, SpriteEffects.None, 0);

			float val = ((int)(Main.GameUpdateCount%5000/10)+52)*279.6719f; //Faux randomness every 10 frames
			String val2 = val.ToString();

			int first = Math.Abs(val2[val2.Length-1]);
			int second = 48;
			if (val2.Length > 1) second = Math.Abs(val2[val2.Length-2]);

			if (first < 48) first = 48;
			if (first > 57) first = 57;
			if (second < 48) second = 48;
			if (second > 57) second = 57;

			Texture2D num1 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/CosmicDie_" + (first-48));
			Texture2D num2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/CosmicDie_" + (second-48));

			Rectangle frameNum = num1.Frame();
			Vector2 frameOriginNum = num1.Size() / 2f;
			Vector2 offsetNum = new Vector2(Item.width / 2 - frameOriginNum.X, Item.height - frameNum.Height);
			spriteBatch.Draw(num1, drawPos - new Vector2(4*1.42857f, 0).RotatedBy(rotation), null, Color.White, rotation, frameOriginNum, 1f, SpriteEffects.None, 0);
			spriteBatch.Draw(num2, drawPos + new Vector2(4*1.42857f, 0).RotatedBy(rotation), null, Color.White, rotation, frameOriginNum, 1f, SpriteEffects.None, 0);
			return false;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<LoadedDie>());
			recipe.AddIngredient(ModContent.ItemType<SnakeEye>(), 2);
			recipe.AddIngredient(ModContent.ItemType<SharpKey>());
			recipe.AddIngredient(ModContent.ItemType<Misc.Jack>(), 10);
			recipe.AddIngredient(ItemID.WhitePearl);
			recipe.AddIngredient(ItemID.LadyBug, 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.NeutronFragment>(), 13);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
    }
}