using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSwords
{
	public class Astrafury : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Shoots giant darkstars");
		}

		public override void SetDefaults() 
		{
			item.damage = 69;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 37;
			item.useAnimation = 37;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = 500000;
			item.rare = 8;
			item.scale = 1.6f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Darkstar");
			item.shootSpeed = 30f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Starfury);
			recipe.AddIngredient(mod.ItemType("FeatheredFury"));
			recipe.AddIngredient(ItemID.FallenStar, 15);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}