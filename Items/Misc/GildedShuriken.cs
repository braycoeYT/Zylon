using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Misc
{
	public class GildedShuriken : ModItem
	{
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 30;
			Item.damage = 26;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 21;
			Item.useTime = 21;
			Item.knockBack = 2f;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(0, 1, 98);
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Misc.GildedShuriken>();
			Item.shootSpeed = 13f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Shuriken, 200);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 3);
			recipe.AddIngredient(ItemID.Bone, 14);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}