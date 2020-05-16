using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	public class DreamsdayBullet : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dreamsday Bullet");
			Tooltip.SetDefault("An optical illusion of power\nCan pierce 12 times, can inflict venom, and can inflict Frostburn.");
        }
		public override void SetDefaults()
		{
			item.damage = 55;
			item.ranged = true;
			item.width = 14;
			item.height = 39;
			item.maxStack = 9999;
			item.consumable = true;
			item.knockBack = 3.75f;
			item.value = 1000;
			item.rare = 9;
			item.shoot = ProjectileType<Projectiles.DreamsdayBullet>();
			item.shootSpeed = 6f;
			item.ammo = AmmoID.Bullet;
			item.crit = 10;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 500);
			recipe.AddIngredient(ItemType<GalacticDiamondium>(), 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 500);
			recipe.AddRecipe();
		}
	}   
}