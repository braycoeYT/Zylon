using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Cave
{
	public class Stalactite : ModItem
	{
		public override void SetDefaults() 
		{
			item.damage = 14;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5f;
			item.value = 25000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 40);
			recipe.AddIngredient(ItemID.MarbleBlock, 10);
			recipe.AddIngredient(ItemID.GraniteBlock, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}