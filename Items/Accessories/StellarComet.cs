using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Accessories
{
	public class StellarComet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 46;
			Item.height = 40;
			Item.value = Item.sellPrice(0, 3, 78);
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
		}
		int div = Main.rand.Next(10, 21);
		int Timer;
		int extraMana;
        public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
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
			}
			p.CHECK_SlimyShell = true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GelatinComet>());
			recipe.AddIngredient(ItemID.StarCloak);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}