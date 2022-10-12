using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Misc
{
	public class SurgeonsKnife : ModItem
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Surgeon's Knife");
			Tooltip.SetDefault("'110% surgery approved, though not approved for culinary use'\nBounces four times before dissipating");
        }
        public override void SetDefaults() {
			Item.width = 20;
			Item.height = 42;
			Item.damage = 17;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 12;
			Item.useTime = 12;
			Item.knockBack = 3.1f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 2);
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Misc.SurgeonsKnife>();
			Item.shootSpeed = 12f;
		}
	}
}