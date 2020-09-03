using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Microbiome
{
	public class EyeOpener : ModItem
	{
		public override void SetDefaults() 
		{
			item.damage = 19;
			item.melee = true;
			item.width = 29;
			item.height = 29;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2.1f;
			item.value = 13500;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TwistedMembraneBar"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}