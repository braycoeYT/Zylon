using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class SilverDartGun : ModItem
	{
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			Tooltip.SetDefault("Uses seeds as ammo");
=======
			// Tooltip.SetDefault("Uses seeds as ammo");
>>>>>>> ProjectClash
		}
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 11;
			Item.knockBack = 2f;
			Item.shootSpeed = 13f;
			Item.useTime = 33;
			Item.useAnimation = 33;
			Item.value = Item.sellPrice(0, 0, 8);
			Item.autoReuse = true;
			Item.width = 34;
			Item.height = 24;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SilverBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}