using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class VolcanicFlame : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Casts down a psychokinetic flame wall");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 54, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 34;
			Item.useTime = 34;
			Item.damage = 29;
			Item.width = 30;
			Item.height = 36;
			Item.knockBack = 0.5f;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.PKFire1>();
			Item.shootSpeed = 16f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Orange;
			Item.mana = 14;
			Item.UseSound = SoundID.Item116;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
            Texture2D glowMask = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/VolcanicFlame_glow");

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

            spriteBatch.Draw(texture, drawPos, frame, Item.GetAlpha(lightColor), rotation, frameOrigin, scale, SpriteEffects.None, 0);

            for (float i = 0f; i < 1f; i += 0.2f)
            {
                float radians = (i + timer + (time / 3)) * MathHelper.TwoPi;

                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 2f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 4f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 6f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 8f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(glowMask, drawPos, frame, Item.GetAlpha(Color.White), rotation, frameOrigin, scale, SpriteEffects.None, 0);

            return false;
        }
        float increase;
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
            Texture2D glowMask = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/VolcanicFlame_glow");

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

            spriteBatch.Draw(texture, position, frame, Item.GetAlpha(Color.White), 0f, origin, scale, SpriteEffects.None, 0);

            for (float i = 0f; i < 1f; i += 0.2f)
            {
                float radians = (i + timer + (time / 3)) * MathHelper.TwoPi;

                spriteBatch.Draw(glowMask, position + new Vector2(0f, 2f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, 0f, origin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, position + new Vector2(0f, 4f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, 0f, origin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, position + new Vector2(0f, 6f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, 0f, origin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, position + new Vector2(0f, 8f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, 0f, origin, scale, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(glowMask, position, frame, Item.GetAlpha(Color.White), 0f, origin, scale, SpriteEffects.None, 0);

            return false;
        }
    }
}