using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome.Infected
{
	public class InfectedArrow : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Decreases target damage by 20%");
        }
		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 14;
			item.height = 39;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 2.8f;
			item.value = 40;
			item.rare = 3;
			item.shoot = ProjectileType<Projectiles.Microbiome.InfectedArrow>();
			item.shootSpeed = 4.25f;
			item.ammo = AmmoID.Arrow;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 150);
			recipe.AddIngredient(mod.ItemType("InfectedBlood"), 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}   
}