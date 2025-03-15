using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Items.Accessories
{
	public class SupernaturalComet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 58;
			Item.height = 50;
			Item.value = Item.sellPrice(0, 7, 50);
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
		}
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D bgTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/SupernaturalComet_BG");

			float fade = Utils.PingPongFrom01To010((Main.GameUpdateCount % 90) / 90f);
			Color cycleColor = Color.Lerp(Color.White, new Color(120, 120, 120), fade); 

			spriteBatch.Draw(bgTexture, position, frame, Color.White, 0f, origin, scale, SpriteEffects.None, 0);
			spriteBatch.Draw(texture, position, frame, cycleColor, 0f, origin, scale, SpriteEffects.None, 0);
			return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D bgTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/SupernaturalComet_BG");
			Rectangle frame = texture.Frame();
			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

			float fade = Utils.PingPongFrom01To010((Main.GameUpdateCount % 90) / 90f);
			Color cycleColor = Color.Lerp(Color.White, new Color(120, 120, 120), fade); 

			spriteBatch.Draw(bgTexture, drawPos, null, Color.White, rotation, frameOrigin, scale, SpriteEffects.None, 0);
			spriteBatch.Draw(texture, drawPos, null, cycleColor, rotation, frameOrigin, scale, SpriteEffects.None, 0);
			return false;
        }
		int div = Main.rand.Next(10, 21);
		int Timer;
		int extraMana;
        public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetDamage(DamageClass.Magic) += 0.12f;
			if (!p.CHECK_MysticComet) {
				if (player.statMana < player.statManaMax2/4) {
				Timer++;
				if (Timer > div && Main.myPlayer == player.whoAmI) {
					Timer = 0;
					div = Main.rand.Next(10, 21);
					Projectile.NewProjectile(player.GetSource_FromThis(), player.Center - new Vector2(Main.rand.Next(-300, 301), 600), new Vector2(Main.rand.NextFloat(-4f, 4f), 20f), ModContent.ProjectileType<Projectiles.Accessories.StellarCometProj>(), 60, 5.5f, player.whoAmI);
				}
            }
			p.CHECK_MysticComet = true;
			}
			if (!p.CHECK_SlimyShell) {
				if (extraMana == 0 && player.statMana >= player.statManaMax2 - 5) {
					extraMana = 40;
				}
				else if (extraMana > 0 && player.statMana < player.statManaMax2) extraMana = 0;
				
				player.statManaMax2 += extraMana;

				/*if (extraMana > 0) {
					float max = extraMana;
					float now = player.statManaMax2-player.statMana;
					float per = 1f-(now/max);
					player.GetDamage(DamageClass.Magic) += 0.05f*per;
				}*/
			}
			p.CHECK_SlimyShell = true;

			p.etherealGasp = true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<MetallicComet>());
			recipe.AddIngredient(ModContent.ItemType<EtherealGasp>());
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}