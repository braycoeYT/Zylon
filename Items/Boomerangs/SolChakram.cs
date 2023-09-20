using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Boomerangs
{
	public class SolChakram : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 23;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 18;
			Item.useTime = 18;
			Item.shootSpeed = 12f;
			Item.knockBack = 5.6f;
			Item.width = 70;
			Item.height = 70;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(0, 1, 60);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Boomerangs.SolChakram>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1 && player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Boomerangs.SolChakram_Mini>()] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Materials.SearedStone>(), 30);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}