using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Yoyos
{
	public class EarthDay : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'The day the earth stood up for itself'\nShoots acorns at nearby enemies\nRains mushroom spores on foes");
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 24;
			Item.height = 24;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 16f;
			Item.knockBack = 4f;
			Item.damage = 100;
			Item.rare = ItemRarityID.Yellow;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(0, 10);
			Item.shoot = ModContent.ProjectileType<Projectiles.Yoyos.EarthDay>();
		}
	}
}