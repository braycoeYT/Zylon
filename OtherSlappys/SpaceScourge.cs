using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSlappys
{
	public class SpaceScourge : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Space is a dangerous place\nShoots shadow orbs which may confuse enemies");
		}

		public override void SetDefaults() 
		{
			item.damage = 43;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 50000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("ShadowOrb");
			item.shootSpeed = 7f;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SpaceScavenger"));
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.DarkShard);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}