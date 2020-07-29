using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Magentite
{
	public class MagentiteBlowpipe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Uses seed as ammo");
		}
		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 10;
			item.knockBack = 3.6f;
			item.shootSpeed = 11f;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(0, -5);
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MagentiteBar"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}