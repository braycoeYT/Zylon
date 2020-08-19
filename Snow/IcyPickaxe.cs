using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Snow
{
	public class IcyPickaxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Icy Pickaxe");
		}
		public override void SetDefaults() 
		{
			item.damage = 6;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 1.65f;
			item.value = 10000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.pick = 36;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SnowBlock, 6);
			recipe.AddIngredient(ItemID.IceBlock, 11);
			recipe.AddIngredient(mod.ItemType("CryoCrystal"), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}