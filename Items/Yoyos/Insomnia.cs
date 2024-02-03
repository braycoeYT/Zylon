using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Yoyos
{
	public class Insomnia : ModItem
	{
		public override void SetStaticDefaults() {
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
			Item.knockBack = 1f;
			Item.damage = 10;
			Item.rare = ItemRarityID.Blue;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(0, 0, 54);
			Item.shoot = ModContent.ProjectileType<Projectiles.Yoyos.Insomnia>();
		}
	}
}