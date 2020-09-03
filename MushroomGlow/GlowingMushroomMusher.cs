using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.MushroomGlow
{
	public class GlowingMushroomMusher : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Shoots a large wave");
		}

		public override void SetDefaults() 
		{
			item.damage = 13;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.2f;
			item.value = 50000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = false;
			item.shoot = mod.ProjectileType("GlowingMushroomWave");
			item.shootSpeed = 20f;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MushroomMusher"));
			recipe.AddIngredient(mod.ItemType("GlazedLens"));
			recipe.AddIngredient(ItemID.GlowingMushroom, 18);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}