using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class NeutronFragment : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 28;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = ItemRarityID.Cyan;
		}
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			float newRot = MathHelper.ToRadians(Main.GameUpdateCount*4f);
			int temp = (int)(25.5f*(float)Math.Sin((float)Main.GameUpdateCount/15f)+25.5f);
			int temp2 = (int)(255f-temp*3.5f);
			Color newColor = new (temp2, temp2, 255);

			for (int i = 0; i < 9; i++)
				spriteBatch.Draw(texture, position, frame, newColor*(0.125f*i), newRot+MathHelper.ToRadians(i*5), origin, 0.7f, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;
			float newRot = MathHelper.ToRadians(Main.GameUpdateCount*4f);
			int temp = (int)(25.5f*(float)Math.Sin((float)Main.GameUpdateCount/15f)+25.5f);
			int temp2 = (int)(255f-temp*3.5f);
			Color newColor = new (temp2, temp2, 255);

			for (int i = 0; i < 9; i++)
				spriteBatch.Draw(texture, drawPos, null, newColor*(0.125f*i), newRot+MathHelper.ToRadians(i*5), frameOrigin, 1f, SpriteEffects.None, 0);
			return false;
        }
        public override void AddRecipes()  {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentStardust);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}