using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Blowpipes.PH
{
	public class WoodenBlowpipe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Uses seed shots as ammo\nWhile in your inventory, the following enemies will drop Seeds:\nGreen Slime, Blue Slime");
		}
		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 6; //9, mod 14
			item.knockBack = 3.5f; //3.5
			item.shootSpeed = 10f; //11
			item.useTime = 45; //45
			item.useAnimation = 45; //45
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			return true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(0, -5);
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddIngredient(ItemID.Acorn);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}