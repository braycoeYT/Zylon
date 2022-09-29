using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Flails
{
	public class StickyHand : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sticky Hand");
			Tooltip.SetDefault("'Does not get dirty after 20 minutes of use, somehow'\nSticks to enemies when thrown, dealing loads of extra damage");
		}
		public override void SetDefaults() {
			Item.width = 56;
			Item.height = 60;
			Item.value = Item.sellPrice(0, 6);
			Item.rare = ItemRarityID.Pink;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.knockBack = 0f;
			Item.damage = 87;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Flails.StickyHand>();
			Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
		}
	}
}