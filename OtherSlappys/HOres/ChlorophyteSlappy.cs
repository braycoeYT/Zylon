using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSlappys.HOres
{
	public class ChlorophyteSlappy : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Shoots a powerful orb");
		}
		
		public override void SetDefaults() 
		{
			item.damage = 49;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 1;
			item.knockBack = 1.75f;
			item.value = 55200;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 229;
			item.shootSpeed = 5f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}