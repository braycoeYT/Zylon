using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Zylon.Items.Accessories
{
	public class Fantesseract : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}
        public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 25);
			Item.rare = ItemRarityID.Expert;
			Item.expert = true;
		}
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D ring1 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/Fantesseract_1");
			Texture2D ring2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/Fantesseract_2");
			Texture2D ring3 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/Fantesseract_3");
			Texture2D ring4 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/Fantesseract_4");

			//Main
			//Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			spriteBatch.Draw(texture, position, null, Color.White, 0f, frameOrigin, 0.7f, SpriteEffects.None, 0);

			//Ring1
			Rectangle frame1 = ring1.Frame();
			Vector2 frameOrigin1 = frame1.Size() / 2f;
			Vector2 offset1 = new Vector2(Item.width / 2 - frameOrigin1.X, Item.height - frame1.Height);
			spriteBatch.Draw(ring1, position, null, Color.White, Main.GameUpdateCount/20f, frameOrigin1, 0.7f, SpriteEffects.None, 0);

			//Ring2
			Rectangle frame2 = ring2.Frame();
			Vector2 frameOrigin2 = frame2.Size() / 2f;
			Vector2 offset2 = new Vector2(Item.width / 2 - frameOrigin2.X, Item.height - frame2.Height);
			spriteBatch.Draw(ring2, position, null, Color.White, -Main.GameUpdateCount/20f, frameOrigin2, 0.7f, SpriteEffects.None, 0);

			//Ring3
			Rectangle frame3 = ring3.Frame();
			Vector2 frameOrigin3 = frame3.Size() / 2f;
			Vector2 offset3 = new Vector2(Item.width / 2 - frameOrigin3.X, Item.height - frame3.Height);
			spriteBatch.Draw(ring3, position, null, Color.White, Main.GameUpdateCount/20f, frameOrigin3, 0.7f, SpriteEffects.None, 0);

			//Ring4
			Rectangle frame4 = ring4.Frame();
			Vector2 frameOrigin4 = frame4.Size() / 2f;
			Vector2 offset4 = new Vector2(Item.width / 2 - frameOrigin4.X, Item.height - frame4.Height);
			spriteBatch.Draw(ring4, position, null, Color.White, -Main.GameUpdateCount/20f, frameOrigin4, 0.7f, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D ring1 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/Fantesseract_1");
			Texture2D ring2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/Fantesseract_2");
			Texture2D ring3 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/Fantesseract_3");
			Texture2D ring4 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/Fantesseract_4");

			//Colors - looks less ominous this way
			/*float rg = (Main.DiscoR + Main.DiscoG)/255f;
			float gb = (Main.DiscoG + Main.DiscoB)/255f;
			float br = (Main.DiscoB + Main.DiscoR)/255f;
			if (rg > 1f) rg = 1f;
			if (gb > 1f) gb = 1f;
			if (br > 1f) br = 1f;
			Color rgc = new Color(rg, rg, rg, 1f);
			Color gbc = new Color(gb, gb, gb, 1f);
			Color brc = new Color(br, br, br, 1f);*/

			//Main
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset + new Vector2(0, 2);
			//float newScale = (float)Math.Sin(Main.GameUpdateCount/10f)/4f + 0.5f;
			spriteBatch.Draw(texture, drawPos, null, Color.White, 0f, frameOrigin, 1f, SpriteEffects.None, 0);

			//Ring1
			Rectangle frame1 = ring1.Frame();
			Vector2 frameOrigin1 = frame1.Size() / 2f;
			Vector2 offset1 = new Vector2(Item.width / 2 - frameOrigin1.X, Item.height - frame1.Height);
			Vector2 drawPos1 = Item.position - Main.screenPosition + frameOrigin1 + offset1 - new Vector2(0, 10);
			spriteBatch.Draw(ring1, drawPos1, null, Color.White, Main.GameUpdateCount/20f, frameOrigin1, 1f, SpriteEffects.None, 0);

			//Ring2
			Rectangle frame2 = ring2.Frame();
			Vector2 frameOrigin2 = frame2.Size() / 2f;
			Vector2 offset2 = new Vector2(Item.width / 2 - frameOrigin2.X, Item.height - frame2.Height);
			Vector2 drawPos2 = Item.position - Main.screenPosition + frameOrigin2 + offset2 - new Vector2(0, 6);
			spriteBatch.Draw(ring2, drawPos2, null, Color.White, -Main.GameUpdateCount/20f, frameOrigin2, 1f, SpriteEffects.None, 0);

			//Ring3
			Rectangle frame3 = ring3.Frame();
			Vector2 frameOrigin3 = frame3.Size() / 2f;
			Vector2 offset3 = new Vector2(Item.width / 2 - frameOrigin3.X, Item.height - frame3.Height);
			Vector2 drawPos3 = Item.position - Main.screenPosition + frameOrigin3 + offset3 - new Vector2(0, 2);
			spriteBatch.Draw(ring3, drawPos3, null, Color.White, Main.GameUpdateCount/20f, frameOrigin3, 1f, SpriteEffects.None, 0);

			//Ring4
			Rectangle frame4 = ring4.Frame();
			Vector2 frameOrigin4 = frame4.Size() / 2f;
			Vector2 offset4 = new Vector2(Item.width / 2 - frameOrigin4.X, Item.height - frame4.Height);
			Vector2 drawPos4 = Item.position - Main.screenPosition + frameOrigin4 + offset4 - new Vector2(0, -2);
			spriteBatch.Draw(ring4, drawPos4, null, Color.White, -Main.GameUpdateCount/20f, frameOrigin4, 1f, SpriteEffects.None, 0);
			return false;
        }
		int blackBoxLeft;
		int rouletteLeft;
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.fantesseract = true;
			player.runAcceleration *= 2f;
			player.wingTimeMax += 120;
			player.jumpSpeedBoost = 2;
			player.maxFallSpeed += 2f;
			player.moveSpeed += 0.1f;
			player.lifeRegen += 3;

			bool canFreeze = true;
			for (int i = 0; i < Main.maxNPCs; i++) {
				if (Main.npc[i].boss && Main.npc[i].active) canFreeze = false;
			}

			if ((Main.rand.NextBool(2000) || blackBoxLeft > 0) && canFreeze) {
				p.blackBox = true;
				if (blackBoxLeft == 0) blackBoxLeft = 45;
				blackBoxLeft--;
				player.velocity = Vector2.Zero;
			}
			if (Main.rand.NextBool(3000) || (rouletteLeft > 0 && Main.GameUpdateCount % 3 == 0)) {
				player.statLife = Main.rand.Next(1, player.statLifeMax2);
				if (rouletteLeft == 0) rouletteLeft = 20;
				rouletteLeft--;
			}
		}
	}
}