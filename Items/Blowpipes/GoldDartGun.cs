using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class GoldDartGun : ModItem
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
			Item.damage = 13;
			Item.knockBack = 2.75f;
			Item.shootSpeed = 13.75f;
			Item.useTime = 31;
			Item.useAnimation = 31;
			Item.value = Item.sellPrice(0, 0, 16);
			Item.autoReuse = true;
			Item.width = 34;
			Item.height = 24;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}