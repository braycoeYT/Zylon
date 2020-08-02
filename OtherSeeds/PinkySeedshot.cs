using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.OtherSeeds
{
	public class PinkySeedshot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pinky's Seedshot");
			Tooltip.SetDefault("For use with blowpipes\nEach seedshot is slightly larger than normal\nEach seedshot has a very high chance of sliming enemies");
        }
		public override void SetDefaults()
		{
			item.damage = 5; //3
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0.5f; //0
			item.value = 5; //0
			item.rare = 0;
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PinkySeedshot>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
			item.width = 16;
			item.height = 14;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SlimySeedshot"), 80);
			recipe.AddIngredient(ItemID.PinkGel);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this, 80);
			recipe.AddRecipe();
		}
	}
}