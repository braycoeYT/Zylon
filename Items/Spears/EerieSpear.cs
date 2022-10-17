using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class EerieSpear : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots otherworldly fangs on use");
		}
		public override void SetDefaults() {
			Item.width = 60;
			Item.height = 60;
			Item.damage = 39;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 31;
			Item.useTime = 31;
			Item.knockBack = 6f;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 2);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.EerieSpear>();
			Item.shootSpeed = 5f;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == ModContent.ProjectileType<Projectiles.Spears.EerieSpear>()) {
                    return false;
                }
            }
            return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Materials.EerieBell>(), 12);
			recipe.AddIngredient(ItemType<Materials.OtherworldlyFang>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}