﻿using Zylon.Buffs.Whips;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Zylon.Items.Whips
{
	public class LivingWhip : ModItem
	{
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(LivingWhipDebuff.TagDamage);
		public override void SetDefaults() {
			Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Whips.LivingWhip>(), 10, 1.75f, 6.5f);
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(0, 0, 17);
		}
		public override bool MeleePrefix() {
			return true;
		}
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			if (WorldGen.currentWorldSeed.ToLower() == "autumn") texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Whips/LivingWhip_Autumn");
			spriteBatch.Draw(texture, position, frame, drawColor, 0f, origin, scale, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			if (WorldGen.currentWorldSeed.ToLower() == "autumn") texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Whips/LivingWhip_Autumn");
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;
			spriteBatch.Draw(texture, drawPos, null, lightColor, rotation, frameOrigin, scale, SpriteEffects.None, 0);
			return false;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.LivingBranch>(), 8);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}