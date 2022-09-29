using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Shortswords
{
	public class StoneShortsword : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 6;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 4f;
			Item.value = 150;
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shoot = ProjectileType<Projectiles.Shortswords.StoneShortsword>();
			Item.shootSpeed = 4.3f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 10);
			recipe.AddIngredient(ItemID.Gel, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}