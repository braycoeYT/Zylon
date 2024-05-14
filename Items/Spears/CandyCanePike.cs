using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class CandyCanePike : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.Spears[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 13;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 18;
			Item.useTime = 24;
			Item.shootSpeed = 3.7f;
			Item.knockBack = 6f;
			Item.width = 38;
			Item.height = 38;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 0, 20);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.CandyCanePike>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CandyCaneBlock, 34);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 11);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}