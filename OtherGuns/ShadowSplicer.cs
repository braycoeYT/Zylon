using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.OtherGuns
{
	public class ShadowSplicer : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Splicer");
			Tooltip.SetDefault("Shoots a four round burst");
		}

		public override void SetDefaults() 
		{
			item.value = 140000;
			item.useStyle = 5;
			item.useAnimation = 36;
			item.useTime = 9;
			item.damage = 22;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0f;
			item.shoot = 14;
			item.shootSpeed = 30f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = 4;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}