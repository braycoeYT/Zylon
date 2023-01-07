using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Flails
{
	public class TheMeteorite : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Has a large range");
		}
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.value = Item.sellPrice(0, 3, 12);
			Item.rare = ItemRarityID.Green;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.knockBack = 5.25f;
			Item.damage = 37;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Flails.TheMeteorite>();
			Item.shootSpeed = 16f;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.HaxoniteBar>(), 10);
			recipe.AddIngredient(ItemID.MeteoriteBar, 4);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}