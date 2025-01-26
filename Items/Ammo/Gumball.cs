using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class Gumball : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}
		public override void SetDefaults() {
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 0f;
			Item.value = Item.sellPrice(0, 0, 0, 40);
			Item.rare = RarityType<SkymanisbtmanDev>();
			Item.shoot = ProjectileType<Projectiles.Guns.Gunball_Proj>();
			Item.ammo = AmmoID.Bullet;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
			TooltipLine xline = new TooltipLine(Mod, "Tooltip0", "~Developer Item (Skymanisbtman)~");
			xline.OverrideColor = new Color(0, 255, 0);
			list.Add(xline);
        }
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Color color = Color.Red;
			if (Main.GameUpdateCount % 180 > 60) color = Color.Blue;
			if (Main.GameUpdateCount % 180 > 120) color = Color.Green;

			spriteBatch.Draw(texture, position, frame, color, 0f, origin, scale, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

			Color color = Color.Red;
			if (Main.GameUpdateCount % 180 > 60) color = Color.Blue;
			if (Main.GameUpdateCount % 180 > 120) color = Color.Green;

			spriteBatch.Draw(texture, drawPos, null, color, rotation, frameOrigin, scale, SpriteEffects.None, 0);
			return false;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(100);
			recipe.AddIngredient(ItemID.MusketBall, 100);
			recipe.AddIngredient(ItemType<Materials.FantasticalFinality>());
			recipe.Register();
		}
	}
}