using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Misc
{
	public class WinkofRadias : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.value = 0;
			Item.rare = ItemRarityID.LightRed;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Misc.WinkofRadiasProj>();
			Item.shootSpeed = 0f;
			Item.noMelee = true;
			Item.stack = 1;
			Item.UseSound = SoundID.Item4.WithPitchOffset(-1f);
			Item.noUseGraphic = true;
			Item.consumable = true;
		}
        public override bool CanUseItem(Player player) {
            return player.ZoneOverworldHeight;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, player.Center - new Vector2(0, 600), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Misc.WinkofRadiasProj>(), 1, 1f, Main.myPlayer);
			return false;
        }
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			float newRot = MathHelper.ToRadians(Main.GameUpdateCount*4f);

			Texture2D ring = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Misc/WinkofRadias_Ring");
			Rectangle frame1 = ring.Frame();
			Vector2 frameOrigin1 = frame1.Size() / 2f;
			Vector2 offset1 = new Vector2(Item.width / 2 - frameOrigin1.X, Item.height - frame1.Height);
			float ringScale = 1f + (float)Math.Sin(MathHelper.ToRadians(Main.GameUpdateCount))/2f;
			spriteBatch.Draw(ring, position, null, Color.White, Main.GameUpdateCount/20f, frameOrigin1, 0.6f*ringScale, SpriteEffects.None, 0);

			spriteBatch.Draw(texture, position, frame, Color.White, newRot, origin, 0.6f, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;
			float newRot = MathHelper.ToRadians(Main.GameUpdateCount*4f);

			Texture2D ring = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Misc/WinkofRadias_Ring");
			Rectangle frame1 = ring.Frame();
			Vector2 frameOrigin1 = frame1.Size() / 2f;
			Vector2 offset1 = new Vector2(Item.width / 2 - frameOrigin1.X, Item.height - frame1.Height);
			float ringScale = 1f + (float)Math.Sin(MathHelper.ToRadians(Main.GameUpdateCount))/2f;
			spriteBatch.Draw(ring, drawPos, null, Color.White, Main.GameUpdateCount/20f, frameOrigin1, 0.7f*ringScale, SpriteEffects.None, 0);

			spriteBatch.Draw(texture, drawPos, frame, Color.White, newRot, frameOrigin, 0.7f, SpriteEffects.None, 0);
			return false;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PixieDust, 50);
			recipe.AddIngredient(ItemID.BlueSolution, 777);
			recipe.AddIngredient(ItemID.HallowedBar, 35);
			recipe.AddIngredient(ItemID.SoulofLight, 25);
			recipe.AddTile(TileID.CrystalBall);
			recipe.Register();
		}
	}
}