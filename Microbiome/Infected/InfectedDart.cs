using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome.Infected
{
	public class InfectedDart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use with blowpipes\nLeaves a sickening trail");
        }
		public override void SetDefaults() {
			item.damage = 11; //3
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 3.5f; //0
			item.value = 30; //0
			item.rare = ItemRarityID.Orange;
			item.shoot = ProjectileType<Projectiles.Microbiome.InfectedDart>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("InfectedBlood"));
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
	}
}