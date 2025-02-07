using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Boomerangs
{
	public class ThousandDegreeKnife : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 87;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 35;
			Item.useTime = 35;
			Item.shootSpeed = 18f;
			Item.knockBack = 4f;
			Item.width = 44;
			Item.height = 46;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 4, 50);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Boomerangs.ThousandDegreeKnife>();
		}
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;

			Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Boomerangs/ThousandDegreeKnife_Glow");
			Color glowColor = Color.White*(Main.DiscoB/255f);

			spriteBatch.Draw(texture, position, frame, Color.White, 0f, origin, scale, SpriteEffects.None, 0);
			spriteBatch.Draw(glow, position, frame, glowColor, 0f, origin, scale, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

			Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Boomerangs/ThousandDegreeKnife_Glow");
			Color glowColor = Color.White*(Main.DiscoB/255f);

			spriteBatch.Draw(texture, drawPos, frame, Color.White, rotation, frameOrigin, 1f, SpriteEffects.None, 0);
			spriteBatch.Draw(glow, drawPos, frame, glowColor, rotation, frameOrigin, 1f, SpriteEffects.None, 0);
			return false;
        }
		public override bool CanUseItem(Player player) {
			int total = 0;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				if (Main.projectile[i].type == Item.shoot && Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer) { 
					if (Main.projectile[i].ai[0] == 0f) return false;
					total++;
				}
			}
			return total < 10;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BloodyMachete);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(ItemType<Bars.HaxoniteBar>(), 8);
			recipe.AddRecipeGroup("Zylon:AnyMythrilBar", 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}