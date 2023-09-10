using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class Cactirang : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Spawns damaging prickly pears on critical strikes");
		}
		public override void SetDefaults() {
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.5f;
			Item.value = 500;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.Cactirang>();
			Item.shootSpeed = 8f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.channel = true;
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Cactus, 11);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}