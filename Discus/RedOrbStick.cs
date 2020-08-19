using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Discus
{
	public class RedOrbStick : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Red Orb on a Stick");
			Tooltip.SetDefault("Who did this? Who put a powerful orb on the end of a random stick?\nShoots crumbling red orbs which drop shards");
		}
		public override void SetDefaults() 
		{
			item.damage = 10;
			item.magic = true;
			item.width = 29;
			item.height = 34;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 4.1f;
			item.value = 25000;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("RedOrb");
			item.shootSpeed = 7.5f;
			item.noMelee = true;
			item.mana = 9;
			item.stack = 1;
			item.UseSound = SoundID.Item12;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WandofSparking);
			recipe.AddIngredient(mod.ItemType("ZylonianDesertCore"), 3);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}