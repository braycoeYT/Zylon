using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherHarps
{
	public class HarpOfTheBonechiller : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Play the tunes of the master of the cold...\nPlay Dungeonist Notes that can confuse enemies'");
			DisplayName.SetDefault("Harp of the Bonechiller");
		}

		public override void SetDefaults() 
		{
			item.damage = 20;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 3700;
			item.rare = 2;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("DungeonNote");
			item.shootSpeed = 4f;
			item.noMelee = true;
			item.mana = 6;
			item.holdStyle = 3;
			item.stack = 1;
			item.UseSound = SoundID.Item26;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(ItemID.GoldenKey);
			recipe.AddIngredient(ItemID.IceBlock, 15);
			recipe.AddIngredient(ItemID.SnowBlock, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}