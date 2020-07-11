using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class PhoenixDriver : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Phoenix Driver");
		}
		public override void SetDefaults() 
		{
			item.damage = 29;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.knockBack = 0.5f;
			item.value = 37500;
			item.rare = 2;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 376;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.mana = 8;
			item.stack = 1;
			item.UseSound = SoundID.Item12;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddIngredient(ItemID.Fireblossom);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}