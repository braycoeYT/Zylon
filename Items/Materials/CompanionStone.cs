using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using System;

namespace Zylon.Items.Materials
{
	public class CompanionStone : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 34;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 3);
			Item.rare = ItemRarityID.Orange;
		}
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D small = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Materials/CompanionStone_Small");

			//Main
			//Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			spriteBatch.Draw(texture, position - new Vector2((int)(frame.Width*0.2f), 0), null, drawColor, 0f, frameOrigin, 0.6f, SpriteEffects.None, 0);

			//Pet
			Rectangle frame1 = small.Frame();
			Vector2 frameOrigin1 = frame1.Size() / 2f;
			float heightOffset = frame.Height*(float)Math.Sin(Main.GameUpdateCount/50f)*0.33f;
			spriteBatch.Draw(small, position + new Vector2((int)(frame.Width*0.35f), heightOffset), null, drawColor, 0f, frameOrigin1, 0.8f, SpriteEffects.None, 0);

			return false;
        }
		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D small = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Materials/CompanionStone_Small");

			//Main
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset - new Vector2((int)(frame.Width*0.2f), 0);
			spriteBatch.Draw(texture, drawPos, null, Color.White, 0f, frameOrigin, 1f, SpriteEffects.None, 0);

			//Pet
			Rectangle frame1 = small.Frame();
			Vector2 frameOrigin1 = frame1.Size() / 2f;
			Vector2 offset1 = new Vector2(Item.width / 2 - frameOrigin1.X, Item.height - frame1.Height);
			float heightOffset = frame.Height*(float)Math.Sin(Main.GameUpdateCount/50f)*0.37f - 10;
			Vector2 drawPos1 = Item.position - Main.screenPosition + frameOrigin1 + offset1 + new Vector2((int)(frame.Width*0.6f), heightOffset);
			spriteBatch.Draw(small, drawPos1, null, Color.White, 0f, frameOrigin1, 1.67f, SpriteEffects.None, 0);
			return false;
        }
	}
}