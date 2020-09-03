using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSeeds
{
	public class EndlessSeedPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Seed Pouch");
			Tooltip.SetDefault("For use with blowpipes");
        }
		public override void SetDefaults()
		{
			item.damage = 3; //3
			item.ranged = true;
			item.width = 24;
			item.height = 32;
			item.maxStack = 1;
			item.consumable = false;
			item.knockBack = 0f; //0
			item.value = 10000; //0
			item.rare = ItemRarityID.Green;
			item.shoot = ProjectileID.Seed;
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Seed, 3996);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}