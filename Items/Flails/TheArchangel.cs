using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Flails
{
	public class TheArchangel : ModItem
	{
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.value = Item.sellPrice(0, 4, 60);
			Item.rare = ItemRarityID.Pink;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.knockBack = 6f;
			Item.damage = 115;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Flails.TheArchangel>();
			Item.shootSpeed = 16f;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}