using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Items.Accessories
{
	public class ExtraShinyOreNugget : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pyrite");
            Tooltip.SetDefault("Emits a faint glow from within your pack");
		}
		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 22;
			Item.value = Item.sellPrice(0, 5);
			Item.rare = ItemRarityID.Green;
		}
        public override void UpdateInventory(Player player) {
            float time = Main.GlobalTimeWrappedHourly;
            time %= 4f;
            time /= 2f;

            if (time >= 1f)
            {
                time = 2f - time;
            }

            time = time * 0.5f + 0.5f;

            Lighting.AddLight(player.Center, 0.25f * time, 0.25f * time, 0f * time);
        }
        public override void Update(ref float gravity, ref float maxFallSpeed) {
            float time = Main.GlobalTimeWrappedHourly;
            time %= 4f;
            time /= 2f;

            if (time >= 1f)
            {
                time = 2f - time;
            }

            time = time * 0.5f + 0.5f;

            Lighting.AddLight(Item.Center, 0.25f * time, 0.25f * time, 0f * time);
        }

        public override void PostUpdate()
        {
            if (Item.timeSinceItemSpawned % 12 == 0)
            {
                Vector2 center = Item.Center + new Vector2(0f, Item.height * -0.1f);
                Vector2 direction = Main.rand.NextVector2CircularEdge(Item.width * 0.6f, Item.height * 0.6f);
                float distance = 0.3f + Main.rand.NextFloat() * 0.5f;
                Vector2 velocity = new Vector2(0f, -Main.rand.NextFloat() * 0.3f - 1.5f);

                Dust dust = Dust.NewDustPerfect(center + direction * distance, DustID.SilverFlame, velocity);
                dust.scale = 0.5f;
                dust.fadeIn = 1.1f;
                dust.noGravity = true;
                dust.noLight = true;
                dust.alpha = 0;
            }
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;

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

            for (float i = 0f; i < 1f; i += 0.25f)
            {
                float radians = (i + timer + (time / 3)) * MathHelper.TwoPi;

                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * (time * time), frame, new Color(255, 152, 222, 120) * 0.275f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 16f).RotatedBy(radians) * (time * time), frame, new Color(255, 152, 222, 120) * 0.275f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }


            spriteBatch.Draw(texture, drawPos, frame, Color.White, rotation, frameOrigin, scale, SpriteEffects.None, 0);
            spriteBatch.Draw(texture, drawPos, frame, new Color(255, 152, 222, 120) * (time/2f), rotation, frameOrigin, scale, SpriteEffects.None, 0);

            return false;
        }


    }
}