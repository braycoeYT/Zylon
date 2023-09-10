using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class Metecore : ModItem
	{
		public override void SetStaticDefaults() { //Heavily increases your life regen and defense while on fire\n <-- scrapped
<<<<<<< HEAD
			Tooltip.SetDefault("Spawns a friendly meteor above your head\nDamaging enemies summons meteor spirits\nAs you collect meteor spirits, your friendly meteor will grow\nAt max size, the friendly meteor explodes into a flurry of fireballs");
=======
			// Tooltip.SetDefault("Spawns a friendly meteor above your head\nDamaging enemies summons meteor spirits\nAs you collect meteor spirits, your friendly meteor will grow\nAt max size, the friendly meteor explodes into a flurry of fireballs");
>>>>>>> ProjectClash
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 20;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.Green;
			Item.expert = true;
			Item.damage = 40;
			Item.knockBack = 3f;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.metelordExpert = true;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Accessories.MetecoreMain>()] < 1 && p.metecoreFloat == 1f && player.active)
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Accessories.MetecoreMain>(), Item.damage, Item.knockBack, Main.myPlayer);
		}
	}
}