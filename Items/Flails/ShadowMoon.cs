using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Flails
{
	public class ShadowMoon : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Shoots a barrage of fangs on throw");
		}
		public override void SetDefaults() {
			Item.width = 42;
			Item.height = 38;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Orange;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.knockBack = 6.25f;
			Item.damage = 71;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Flails.ShadowMoon>();
			Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.channel = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.EerieBell>(), 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.OtherworldlyFang>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}