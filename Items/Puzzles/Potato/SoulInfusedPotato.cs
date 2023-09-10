using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Puzzles.Potato
{
	public class SoulInfusedPotato : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'Incredible energy emanates from such a vegetable'");
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 24;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Green;
		}

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
            Texture2D glowMask = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Puzzles/Potato/SoulInfusedPotato_glow");
            Texture2D bloom = (Texture2D)ModContent.Request<Texture2D>("Zylon/Assets/Bloom/Glow120_120");

            Rectangle frame;

            if (Main.itemAnimations[Item.type] != null)
            {
                frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            }
            else
            {
                frame = texture.Frame();
            }

            Vector2 frameOrigin = frame.Size() / 2f;
            Vector2 bloomOrigin = bloom.Size() / 2f;
            Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
            Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

            float time = Main.GlobalTimeWrappedHourly;
            float timer = Item.timeSinceItemSpawned / 240f + time * 0.04f;

            time %= 4f;
            time /= 2f;

            if (time >= 1f)
            {
                time = 2f - time;
            }

            time = time * 0.5f + 0.5f;

            spriteBatch.Draw(glowMask, drawPos, frame, Item.GetAlpha(Color.White) * 0.1f, rotation, frameOrigin, scale + 0.4f, SpriteEffects.None, 0);
            spriteBatch.Draw(glowMask, drawPos, frame, Item.GetAlpha(Color.White) * 0.1f, rotation, frameOrigin, scale + 0.3f, SpriteEffects.None, 0);
            spriteBatch.Draw(glowMask, drawPos, frame, Item.GetAlpha(Color.White) * 0.1f, rotation, frameOrigin, scale + 0.2f, SpriteEffects.None, 0);
            spriteBatch.Draw(glowMask, drawPos, frame, Item.GetAlpha(Color.White) * 0.1f, rotation, frameOrigin, scale + 0.1f, SpriteEffects.None, 0);

            for (float i = 0f; i < 1f; i += 0.2f)
            {
                float radians = (i + timer + (time / 3)) * MathHelper.TwoPi;

                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 2f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.1f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 4f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.1f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 6f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.1f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 8f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.1f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, drawPos, frame, Item.GetAlpha(lightColor), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            spriteBatch.Draw(glowMask, drawPos, frame, Item.GetAlpha(Color.White), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            spriteBatch.Draw(bloom, drawPos, null, Item.GetAlpha(Color.White) * 0.2f, 0f, bloomOrigin, scale * 0.6f, SpriteEffects.None, 0);

            return false;
        }

        float increase;
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
            Texture2D glowMask = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Puzzles/Potato/SoulInfusedPotato_glow");

            float time = Main.GlobalTimeWrappedHourly;
            increase++;
            float timer = increase / 240f + time * 0.04f;

            time %= 4f;
            time /= 2f;

            if (time >= 1f)
            {
                time = 2f - time;
            }

            time = time * 0.5f + 0.5f;

            for (float i = 0f; i < 1f; i += 0.2f)
            {
                float radians = (i + timer + (time / 3)) * MathHelper.TwoPi;

                spriteBatch.Draw(glowMask, position + new Vector2(0f, 2f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.1f, 0f, origin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, position + new Vector2(0f, 4f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.1f, 0f, origin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, position + new Vector2(0f, 6f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.1f, 0f, origin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, position + new Vector2(0f, 8f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.1f, 0f, origin, scale, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(texture, position, frame, Item.GetAlpha(Color.White), 0f, origin, scale, SpriteEffects.None, 0);
            spriteBatch.Draw(glowMask, position, frame, Item.GetAlpha(Color.White), 0f, origin, scale, SpriteEffects.None, 0);

            return false;
        }


    }
}