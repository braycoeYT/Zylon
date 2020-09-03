using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Discus
{
	public class DiscusArrow : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Discus Arrow");
			Tooltip.SetDefault("Penetrates infinitely");
        }
		public override void SetDefaults()
		{
			item.damage = 10;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 2f;
			item.value = 70;
			item.rare = ItemRarityID.Blue;
			item.shoot = ProjectileType<Projectiles.Discus.DiscusArrow>();
			item.shootSpeed = 6.5f;
			item.ammo = AmmoID.Arrow;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 200);
			recipe.AddIngredient(ItemType<DriedEssence>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 200);
			recipe.AddRecipe();
		}
	}   
}