using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.OtherArrows
{
	public class PoisonousArrow : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poisonous Arrow");
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
			item.value = 100;
			item.rare = 1;
			item.shoot = ProjectileType<Projectiles.OtherArrows.PoisonousArrow>();
			item.shootSpeed = 2f;
			item.ammo = AmmoID.Arrow;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 100);
			recipe.AddIngredient(ItemID.JungleSpores);
			recipe.AddIngredient(ItemID.Stinger);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
	}   
}