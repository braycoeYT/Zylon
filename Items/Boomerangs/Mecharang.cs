using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class Mecharang : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Occasionally fires a spread of lasers");
		}
		public override void SetDefaults() {
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.damage = 89;
			Item.width = 45;
			Item.height = 45;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1.5f;
			Item.value = Item.sellPrice(0, 4, 50, 0);
			Item.rare = ItemRarityID.LightPurple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.Mecharang>();
			Item.shootSpeed = 17;
			Item.noUseGraphic = true;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot) {
                    return false;
                }
            }
            return true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 13);
			recipe.AddIngredient(ItemID.SoulofSight, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}