using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherHarps
{
	public class VinewireHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'The Jungle Wire Harp's sharp song can poison creatures. Not suggested for concerts.'");
		}
		public override void SetDefaults() 
		{
			item.damage = 16;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 3000;
			item.rare = 2;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("PoisonSound");
			item.shootSpeed = 6f;
			item.noMelee = true;
			item.mana = 4;
			item.holdStyle = 3;
			item.stack = 1;
			item.crit = 1;
			item.UseSound = SoundID.Item26;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Vine, 5);
			recipe.AddIngredient(ItemID.JungleSpores, 5);
			recipe.AddIngredient(ItemID.Stinger, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}