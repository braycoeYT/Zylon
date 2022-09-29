using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Flails
{
	public class DiskiteonaLeash : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Diskite on a Leash");
			Tooltip.SetDefault("Does not collide with tiles and fires lasers at random on use");
		}
		public override void SetDefaults() {
			Item.width = 42;
			Item.height = 38;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Blue;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.knockBack = 6.1f;
			Item.damage = 31;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Flails.DiskiteonaLeash>();
			Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.DiskiteCrumbles>(), 9);
			recipe.AddIngredient(ModContent.ItemType<Materials.RustedTech>(), 11);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}