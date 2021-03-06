using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class DiscusThrow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Desert Discus?");
			Tooltip.SetDefault("'The odd shapes of this discus doppelganger may confuse enemies.'");
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.EnchantedBoomerang);
			item.useTime = 30;
			item.useAnimation = 30;
			item.width = 33;
			item.height = 33;
			item.damage = 8;
			item.melee = true;
			item.knockBack = 1;
			item.value = 600;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("DiscusThrowProj");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.stack = 1;
			item.noUseGraphic = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZylonianDesertCore"), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}