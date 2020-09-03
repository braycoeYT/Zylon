using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Blowpipes.PH
{
	public class EaterOfSeeds : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Eater of Seeds");
			Tooltip.SetDefault("Uses seed shots as ammo\nWhile in your inventory, the following enemies will drop Corrupt Seedshots:\nEater of Souls, Corrupt Discus, Devourer");
		}
		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 16; //9
			item.knockBack = 2.5f; //3.5
			item.shootSpeed = 12f; //11
			item.useTime = 31; //45
			item.useAnimation = 31; //45
			item.rare = ItemRarityID.Blue;
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
			recipe.AddIngredient(ItemID.DemoniteBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}