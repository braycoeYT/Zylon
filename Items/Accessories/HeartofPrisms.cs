using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class HeartofPrisms : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Heart of Prisms");
			// Tooltip.SetDefault("Puts a spike ring around the player\nEnemies hit by the ring are thrown away");
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 20;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.White;
			Item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.ADDExpert = true;
			player.AddBuff(ModContent.BuffType<Buffs.ADDSpikeRing>(), 60);
			//if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Bosses.ADD.ADD_SpikeRingFriendly>()] < 1 && player.whoAmI == Main.myPlayer)
			//	Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADD_SpikeRingFriendly>(), 20, 9f, Main.myPlayer);
		}
	}
}