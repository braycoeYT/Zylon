using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class CarvedStabber : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.Spears[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 9;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.shootSpeed = 2.5f;
			Item.knockBack = 6.5f;
			Item.width = 32;
			Item.height = 32;
			Item.rare = ItemRarityID.White;
			Item.value = 80;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.CarvedStabber>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Wood", 12);
			recipe.AddIngredient(ItemType<Materials.LivingBranch>(), 8);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}