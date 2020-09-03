using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.OtherSeeds.PH
{
	public class Vineshot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vineshot");
			Tooltip.SetDefault("For use with blowpipes\nEach seedshot has a chance of poisoning enemies");
        }
		public override void SetDefaults()
		{
			item.damage = 8; //3
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f; //0
			item.value = 10; //0
			item.rare = ItemRarityID.White;
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.Vineshot>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Seed, 225);
			recipe.AddIngredient(ItemID.Vine);
			recipe.AddIngredient(ItemID.JungleSpores);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 225);
			recipe.AddRecipe();
		}
	}
}