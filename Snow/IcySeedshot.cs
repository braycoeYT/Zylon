using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Snow
{
	public class IcySeedshot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icy Seedshot");
			Tooltip.SetDefault("For use with blowpipes\nEach seedshot has a chance of frostburning enemies");
        }
		public override void SetDefaults()
		{
			item.damage = 4; //3
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f; //0
			item.value = 5; //0
			item.rare = 0;
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.IcySeedshot>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Seed, 150);
			recipe.AddIngredient(mod.ItemType("CryoCrystal"), 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}