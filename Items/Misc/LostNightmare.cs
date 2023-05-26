using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Misc
{
	public class LostNightmare : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'You shouldn't be able to read this unless you're cheating, or something has gone terribly wrong!\nIn that case, hello.\nHope you like the mod.'");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4)); //first is speed, second is amount of frames
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.width = 14;
			Item.height = 30;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(0, 0, 0, 69);
			Item.rare = ItemRarityID.LightPurple;
		}
		int Timer;
		public override void Update(ref float gravity, ref float maxFallSpeed) {
			Timer++;
			if (Timer > 600) Item.active = false;
		}
        public override bool ItemSpace(Player player) {
            return true;
        }
        public override bool OnPickup(Player player) {
			int rand = Main.rand.Next(1, 4);
			player.statLife += rand;
			player.HealEffect(rand);
			for (int i = 0; i < 36; i++) {
				Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.PurpleTorch);
				dust.noGravity = true;
				dust.velocity = new Vector2(0, 4).RotatedBy(MathHelper.ToRadians(i*10));
				dust.scale = 3f;
            }
			SoundEngine.PlaySound(SoundID.NPCHit44, player.position);
            return false;
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

            spriteBatch.Draw(texture, drawPos, frame, Item.GetAlpha(Color.White), rotation, frameOrigin, scale, SpriteEffects.None, 0);

            for (float i = 0f; i < 1f; i += 0.2f)
            {
                float radians = (i + timer + (time / 3)) * MathHelper.TwoPi;

                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, Item.GetAlpha(Color.White) * 0.095f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 16f).RotatedBy(radians) * time, frame, Item.GetAlpha(Color.White) * 0.095f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            return false;
        }

    }
}