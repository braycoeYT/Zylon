using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class OreTour : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 26;
			Item.DamageType = DamageClass.Melee;
			Item.width = 80;
			Item.height = 80;
			Item.useTime = 86;
			Item.useAnimation = 43;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.9f;
			Item.value = Item.sellPrice(0, 5);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.OreTourProjCenter>();
			Item.shootSpeed = 9f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyCopperBar", 6);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 8);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 8);
			recipe.AddRecipeGroup("Zylon:AnyShadowScale", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}