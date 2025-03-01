using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Food
{
	public class Potato : ModItem
	{
		bool PotatoAlchemy = false;
		int PotatoAlchemyTimer = 0;
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 5;
		}
		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 18;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 9999;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed;
            Item.buffTime = 43200;
		}
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			Tile tile = Main.tile[(int)Item.position.X / 16, (int)Item.position.Y / 16];

			if (tile.HasTile && tile.TileType == TileID.AlchemyTable)
			{
				int ItemValue = 0;
				Player NearestPlayer = null;
				float lowestDistance = 1000f;
				for (int p = 0; p < Main.maxPlayers; p++)
				{
					if (Main.player[p].active && Vector2.Distance(Item.Center, Main.player[p].Center) < lowestDistance)
					{
						lowestDistance = Vector2.Distance(Item.Center, Main.player[p].Center);
						NearestPlayer = Main.player[p];
						ItemValue = p;
					}
				}
				if (NearestPlayer != null && NearestPlayer.ZoneGraveyard)
				{
					PotatoAlchemy = true;
					PotatoAlchemyTimer++;

					if (Main.rand.NextBool(4))
                    {
						Dust.NewDust(Item.Center, 0, 0, ModContent.DustType<Dusts.EctoDust>(), Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(-4, 4), 0, Color.White, 1f);
					}
					if (PotatoAlchemyTimer >= 150)
                    {
						gravity = -0.01f;
                    }

					if (PotatoAlchemyTimer >= 200)
                    {
						SoundEngine.PlaySound(new SoundStyle($"Zylon/Sounds/Items/SoulInfusion"){Volume = 0.9f, PitchVariance = 0.3f, MaxInstances = 2,}, Item.position);
						for (int d = 0; d < 12; d++)
						{
							Dust.NewDust(Item.Center, 0, 0, ModContent.DustType<Dusts.EctoDust>(), Main.rand.NextFloat(-12, 12), Main.rand.NextFloat(-12, 12), 0, Color.White, 2.3f);
						}
						if (Main.myPlayer == ItemValue)
                        {
							Item.NewItem(Item.GetSource_FromThis(), Item.Center, ModContent.ItemType<Items.Puzzles.Potato.SoulInfusedPotato>());
						}

						Item.active = false;
                    }

				} else
                {
					PotatoAlchemy = false;
					PotatoAlchemyTimer = 0;
				}
			}
			else
			{
				PotatoAlchemy = false;
				PotatoAlchemyTimer = 0;
			}
		}

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
			Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Food/Potato_glow");
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

			if (PotatoAlchemy)
            {
				spriteBatch.Draw(glow, drawPos, frame, Item.GetAlpha(Color.White) * (PotatoAlchemyTimer / 200f) * 0.2f, rotation, frameOrigin, scale + 0.4f, SpriteEffects.None, 0);
				spriteBatch.Draw(glow, drawPos, frame, Item.GetAlpha(Color.White) * (PotatoAlchemyTimer / 200f) * 0.2f, rotation, frameOrigin, scale + 0.3f, SpriteEffects.None, 0);
				spriteBatch.Draw(glow, drawPos, frame, Item.GetAlpha(Color.White) * (PotatoAlchemyTimer / 200f) * 0.2f, rotation, frameOrigin, scale + 0.2f, SpriteEffects.None, 0);
				spriteBatch.Draw(glow, drawPos, frame, Item.GetAlpha(Color.White) * (PotatoAlchemyTimer / 200f) * 0.2f, rotation, frameOrigin, scale + 0.1f, SpriteEffects.None, 0);
				spriteBatch.Draw(texture, drawPos, frame, Item.GetAlpha(lightColor), rotation, frameOrigin, scale, SpriteEffects.None, 0);
				spriteBatch.Draw(glow, drawPos, frame, Item.GetAlpha(Color.White) * (PotatoAlchemyTimer / 400f), rotation, frameOrigin, scale, SpriteEffects.None, 0);
				spriteBatch.Draw(bloom, drawPos, null, Item.GetAlpha(Color.White) * (PotatoAlchemyTimer / 200f) * 0.2f, 0f, bloomOrigin, scale * 0.6f, SpriteEffects.None, 0);

				return false;
			}

			return true;
        }


    }
}