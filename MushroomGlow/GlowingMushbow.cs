using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.MushroomGlow
{
	public class GlowingMushbow : ModItem
	{
		public override void SetDefaults() 
		{
			item.value = 50000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 14;
			item.useTime = 14;
			item.damage = 10;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Mushbow"));
			recipe.AddIngredient(mod.ItemType("GlazedLens"));
			recipe.AddIngredient(ItemID.GlowingMushroom, 18);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}