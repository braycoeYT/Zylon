using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Gems
{
	public class AmethystBow : ModItem
	{
		public override void SetDefaults() {
			item.value = Item.buyPrice(0, 0, 45, 0);
			item.useStyle = 5;
			item.useAnimation = 28;
			item.useTime = 28;
			item.damage = 9;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0;
			item.shoot = 1;
			item.shootSpeed = 6.6f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amethyst);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}