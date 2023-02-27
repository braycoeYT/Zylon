using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class TungstenDartGun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Uses seeds as ammo");
		}
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 10;
			Item.knockBack = 2.25f;
			Item.shootSpeed = 13.25f;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.value = Item.sellPrice(0, 0, 12);
			Item.autoReuse = true;
			Item.width = 34;
			Item.height = 24;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TungstenBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}