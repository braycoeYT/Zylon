using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome.Infected
{
	public class InfectedBullet : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Decreases target damage by 20%");
        }
		public override void SetDefaults()
		{
			item.damage = 13;
			item.ranged = true;
			item.width = 14;
			item.height = 14;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 4f;
			item.value = 30;
			item.rare = 3;
			item.shoot = ProjectileType<Projectiles.Microbiome.InfectedBullet>();
			item.shootSpeed = 5.25f;
			item.ammo = AmmoID.Bullet;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 150);
			recipe.AddIngredient(mod.ItemType("InfectedBlood"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}   
}