using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using System;

namespace Zylon.Items.Materials
{
	public class FantasticalFinality : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.ItemNoGravity[Item.type] = true;
			Item.ResearchUnlockCount = 25;
		}
		public override void SetDefaults() {
			Item.width = 48;
			Item.height = 70;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ModContent.RarityType<Magenta>();
		}
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			float newScale = (float)Math.Sin(Main.GameUpdateCount/10f)/4f + 0.5f;
			spriteBatch.Draw(texture, position, frame, Main.DiscoColor, 0f, origin, newScale*0.7f, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;
			float newScale = (float)Math.Sin(Main.GameUpdateCount/10f)/4f + 0.5f;
			spriteBatch.Draw(texture, drawPos, null, Main.DiscoColor, rotation, frameOrigin, newScale, SpriteEffects.None, 0);
			return false;
        }
    }
}