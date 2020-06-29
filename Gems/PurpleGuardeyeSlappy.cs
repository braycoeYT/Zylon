using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Gems
{
	public class PurpleGuardeyeSlappy : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'This weapon makes you feel like you are being watched from the cosmos...'");
		}

		public override void SetDefaults() 
		{
			item.damage = 8;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 400;
			item.rare = 0;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 121;
			item.shootSpeed = 5;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amethyst, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}