using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class TopazPike : ModItem
	{
        public override void SetDefaults() {
			Item.damage = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.shootSpeed = 3.5f;
			Item.knockBack = 6f;
			Item.width = 52;
			Item.height = 52;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 1);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = false;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.TopazPike>();
			Item.reuseDelay = 5;
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Materials.Cerussite>(), 15);
			recipe.AddIngredient(ItemID.Topaz, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}