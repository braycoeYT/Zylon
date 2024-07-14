using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Accessories
{
	public class MysticComet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 36;
			Item.height = 48;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 52);
			Item.rare = ItemRarityID.Blue;
		}
		int div = Main.rand.Next(45, 91);
		int Timer;
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.statMana < player.statManaMax2/4) {
				Timer++;
				if (Timer > div && Main.myPlayer == player.whoAmI) {
					Timer = 0;
					div = Main.rand.Next(45, 91);
					Projectile.NewProjectile(player.GetSource_FromThis(), player.Center - new Vector2(Main.rand.Next(-400, 401), 600), new Vector2(Main.rand.NextFloat(-4f, 4f), 16f), ModContent.ProjectileType<Projectiles.Accessories.MysticCometProj>(), 40, 5f, player.whoAmI);
				}
            }
		}
	}
}