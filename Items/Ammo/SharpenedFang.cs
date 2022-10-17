using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Ammo
{
    public class SharpenedFang : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sharpened Fang");
            Tooltip.SetDefault("Inflicts bleeding on enemies\nCan be used with stake launchers");
        }
        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.Stake);
            Item.damage = 11;
            Item.crit = 9;
            Item.rare = ItemRarityID.Orange;
            Item.shoot = ModContent.ProjectileType<Projectiles.Ammo.SharpenedFang>();
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe(150);
			recipe.AddIngredient(ModContent.ItemType<Materials.OtherworldlyFang>());
			recipe.Register();
		}
    }
}
