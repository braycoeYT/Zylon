using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class LivingBranch : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}
		public override void SetDefaults() {
			Item.width = 44;
			Item.height = 22;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 0, 16);
			Item.rare = ItemRarityID.White;
		}
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			if (WorldGen.currentWorldSeed.ToLower() == "autumn") texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Materials/LivingBranch_Autumn");
			spriteBatch.Draw(texture, position, frame, drawColor, 0f, origin, scale, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			if (WorldGen.currentWorldSeed.ToLower() == "autumn") texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Materials/LivingBranch_Autumn");
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;
			spriteBatch.Draw(texture, drawPos, null, lightColor, rotation, frameOrigin, scale, SpriteEffects.None, 0);
			return false;
        }
	}
}