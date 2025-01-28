using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Accessories
{
	public class OverchargedManaCapsule : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		public override void SetDefaults() {
			Item.width = 68;
			Item.height = 70;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/OverchargedManaCapsule_Glow");

			spriteBatch.Draw(texture, position, frame, drawColor, 0f, origin, scale, SpriteEffects.None, 0);
			spriteBatch.Draw(glow, position, frame, Color.White, 0f, origin, scale, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/OverchargedManaCapsule_Glow");
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

			spriteBatch.Draw(texture, drawPos, null, lightColor, rotation, frameOrigin, scale, SpriteEffects.None, 0);
			spriteBatch.Draw(glow, drawPos, null, Color.White, rotation, frameOrigin, scale, SpriteEffects.None, 0);
			return false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			
            if (player.velocity.X < 0.01f && player.velocity.Y < 0.01f) player.manaRegen += 2;
			if (!player.ZoneUnderworldHeight && !player.ZoneRockLayerHeight && !player.ZoneDirtLayerHeight && Main.dayTime)
				player.statManaMax2 += 40;
			else player.statManaMax2 += 10;

			p.sparkingCore = true;

			if (player.statMana < 20 && !player.HasBuff(ModContent.BuffType<Buffs.Accessories.ManaRechargeCooldown>())) {
				SoundEngine.PlaySound(SoundID.Item27);
				player.ManaEffect(player.statManaMax2-player.statMana);
				player.statMana = player.statManaMax2;
				player.AddBuff(ModContent.BuffType<Buffs.Accessories.ManaRechargeCooldown>(), 45*60);
            }
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ManaPod>());
			recipe.AddIngredient(ModContent.ItemType<SparkingCore>());
			recipe.AddIngredient(ModContent.ItemType<ManaBattery>());
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}