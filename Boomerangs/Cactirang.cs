using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class Cactirang : ModItem
	{
		public override void SetStaticDefaults()  {
			Tooltip.SetDefault("Spiky!");
		}
		public override void SetDefaults() {
			item.damage = 6;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 72;
			item.useAnimation = 72;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.knockBack = 4.5f;
			item.value = 500;
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Cactirang");
			item.shootSpeed = 8f;
			item.noUseGraphic = true;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot) {
                    return false;
                }
            }
            return true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cactus, 11);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}