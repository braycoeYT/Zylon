using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;

namespace Zylon.Items.Accessories
{
	public class SunFlower : ModItem
	{
		public override void SetDefaults() {
			Item.width = 44;
			Item.height = 48;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 3, 25);
			Item.rare = ItemRarityID.Blue;
			Item.expert = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.sunFlower = true;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Accessories.SunFlowerProj>()] < 1 && player.statLifeMax2/2 > player.statLife && player.whoAmI == Main.myPlayer)
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Accessories.SunFlowerProj>(), 20, 15f, Main.myPlayer);
		}
    }
}