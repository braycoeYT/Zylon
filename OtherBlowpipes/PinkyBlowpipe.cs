using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.OtherBlowpipes
{
	public class PinkyBlowpipe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Pinky's Blowpipe");
			Tooltip.SetDefault("Uses seed shots as ammo\nWhile in your inventory, the following enemies will drop lots of Pinky's Seedshots:\nPinky");
		}
		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 15; //9
			item.knockBack = 4.25f; //3.5
			item.shootSpeed = 11.5f; //11
			item.useTime = 40; //45
			item.useAnimation = 40; //45
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			return true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(0, -3);
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SlimyBlowpipe"));
			recipe.AddIngredient(ItemID.PinkGel, 14);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}