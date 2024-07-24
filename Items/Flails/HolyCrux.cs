using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Flails
{
	public class HolyCrux : ModItem
	{
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.value = Item.sellPrice(0, 3, 98);
			Item.rare = ItemRarityID.LightRed;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.knockBack = 5f;
			Item.damage = 86;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Flails.HolyCrux>();
			Item.shootSpeed = 16f;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrossNecklace);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 4);
			recipe.AddIngredient(ItemID.Chain, 8);
			recipe.AddIngredient(ItemID.Pearlwood, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}