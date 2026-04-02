using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Bags
{
	public class ScavengerBag : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.BossBag[Type] = true;
			ItemID.Sets.PreHardmodeLikeBossBag[Type] = true;

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
		}
		public override void SetDefaults() {
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.Purple;
			Item.expert = true;
		}
		public override bool CanRightClick() {
			return true;
		}
		public override void ModifyItemLoot(ItemLoot itemLoot) {
			itemLoot.Add(ItemDropRule.Common(ItemType<Accessories.Codebreaker>(), 1));
			itemLoot.Add(ItemDropRule.Common(ItemType<Bars.DarkronBar>(), 1, 15, 30));
			itemLoot.Add(ItemDropRule.Common(ItemType<Materials.SoulofByte>(), 1, 25, 40));
			itemLoot.Add(ItemDropRule.Coins(Item.buyPrice(0, 35), true));
			itemLoot.Add(ItemDropRule.Common(ItemType<Vanity.BossMask.ScavengerMask>(), 7));
		}
		int glitchTimer;
		int glitchType;
		bool glitch;
		Texture2D ouch1 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Bags/ScavengerBag_OuchUp");
		Texture2D ouch2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Bags/ScavengerBag_OuchDown");
		Vector2 ouch1Offset;
		Vector2 ouch2Offset;
		Vector2 allOffset;
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            glitchTimer--;
			if (glitchTimer == -1) {
				glitchTimer = 2;
				if (Main.rand.NextBool(20)) {
					glitch = true;

					glitchType = Main.rand.Next(2);

					allOffset = new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));

					ouch1 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Bags/ScavengerBag_OuchUp");
					ouch2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Bags/ScavengerBag_OuchDown");
					ouch1Offset = new Vector2(Main.rand.Next(-8, 9), 0);
					ouch2Offset = new Vector2(Main.rand.Next(-8, 9), 0);

					if (glitchType == 1) {
						ouch1 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Bags/ScavengerBag_OuchLeft");
						ouch2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Bags/ScavengerBag_OuchRight");
						ouch1Offset = new Vector2(0, Main.rand.Next(-8, 9));
						ouch2Offset = new Vector2(0, Main.rand.Next(-8, 9));
					}
				}
				else glitch = false;
			}
			Texture2D texture = TextureAssets.Item[Item.type].Value;
			Vector2 frameOrigin = frame.Size() / 2f;

			if (glitch) {
				spriteBatch.Draw(ouch1, position+allOffset+ouch1Offset, null, drawColor, 0f, frameOrigin, 0.8f, SpriteEffects.None, 0);
				spriteBatch.Draw(ouch2, position+allOffset+ouch2Offset, null, drawColor, 0f, frameOrigin, 0.8f, SpriteEffects.None, 0);
			}
			else spriteBatch.Draw(texture, position, null, drawColor, 0f, frameOrigin, 0.8f, SpriteEffects.None, 0);
			return false;
        }
        public override void RightClick(Player player) {
            if (Main.rand.NextBool(20)) Zylon.ZylonVanity(player);
        }
        public override Color? GetAlpha(Color lightColor) {
			return Color.Lerp(lightColor, Color.White, 0.4f);
		}
		public override void PostUpdate() {
			Lighting.AddLight(Item.Center, Color.White.ToVector3() * 0.4f);
			if (Item.timeSinceItemSpawned % 12 == 0) {
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
		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
			Texture2D texture = TextureAssets.Item[Item.type].Value;

			Rectangle frame;

			if (Main.itemAnimations[Item.type] != null) {
				frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
			}
			else {
				frame = texture.Frame();
			}
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;
			float time = Main.GlobalTimeWrappedHourly;
			float timer = Item.timeSinceItemSpawned / 240f + time * 0.04f;

			time %= 4f;
			time /= 2f;

			if (time >= 1f) {
				time = 2f - time;
			}

			time = time * 0.5f + 0.5f;


			//Glitch code
			glitchTimer--;
			if (glitchTimer == -1) {
				glitchTimer = 2;
				if (Main.rand.NextBool(20)) {
					glitch = true;

					glitchType = Main.rand.Next(2);

					allOffset = new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));

					ouch1 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Bags/ScavengerBag_OuchUp");
					ouch2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Bags/ScavengerBag_OuchDown");
					ouch1Offset = new Vector2(Main.rand.Next(-8, 9), 0);
					ouch2Offset = new Vector2(Main.rand.Next(-8, 9), 0);

					if (glitchType == 1) {
						ouch1 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Bags/ScavengerBag_OuchLeft");
						ouch2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Bags/ScavengerBag_OuchRight");
						ouch1Offset = new Vector2(0, Main.rand.Next(-8, 9));
						ouch2Offset = new Vector2(0, Main.rand.Next(-8, 9));
					}
				}
				else glitch = false;
			}


			for (float i = 0f; i < 1f; i += 0.25f) {
				float radians = (i + timer) * MathHelper.TwoPi;

				if (glitch) {
					spriteBatch.Draw(ouch1, drawPos+allOffset+ouch1Offset + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(90, 70, 255, 50), rotation, frameOrigin, scale, SpriteEffects.None, 0);
					spriteBatch.Draw(ouch2, drawPos+allOffset+ouch2Offset + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(90, 70, 255, 50), rotation, frameOrigin, scale, SpriteEffects.None, 0);
				}
				else spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(90, 70, 255, 50), rotation, frameOrigin, scale, SpriteEffects.None, 0);
			}

			for (float i = 0f; i < 1f; i += 0.34f) {
				float radians = (i + timer) * MathHelper.TwoPi;

				if (glitch) {

				}
				else spriteBatch.Draw(texture, drawPos + new Vector2(0f, 4f).RotatedBy(radians) * time, frame, new Color(140, 120, 255, 77), rotation, frameOrigin, scale, SpriteEffects.None, 0);
			}

			if (glitch) {
				spriteBatch.Draw(ouch1, drawPos+allOffset+ouch1Offset, frame, Color.White, rotation, frameOrigin, scale, SpriteEffects.None, 0);
				spriteBatch.Draw(ouch2, drawPos+allOffset+ouch2Offset, frame, Color.White, rotation, frameOrigin, scale, SpriteEffects.None, 0);
			}
			else spriteBatch.Draw(texture, drawPos, frame, Color.White, rotation, frameOrigin, scale, SpriteEffects.None, 0);

			return false;
		}
	}
}