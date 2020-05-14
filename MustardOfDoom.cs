using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class MustardOfDoom : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mustard of Doom");
			Tooltip.SetDefault("It has fury\nShoots mustard which can ichor enemies");
			Item.staff[item.type] = true;
		}
		public override void SetDefaults() 
		{
			item.damage = 98;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 28;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.knockBack = 2.5f;
			item.value = 125000;
			item.rare = 7;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("ExplosiveMustard");
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.mana = 8;
			item.stack = 1;
			item.UseSound = SoundID.Item16;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeetleHusk, 5);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddIngredient(ItemID.StoneBlock, 50);
			recipe.AddIngredient(ItemID.Fireblossom, 2);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}