using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Silvervoid
{
	public class SnekYoyo : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Snek outta Heck");
			Tooltip.SetDefault("Inflicts poison and venom on enemies");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 27;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 96;
			item.height = 96;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 3.1f;
			item.damage = 256;
			item.rare = 10;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = 750000;
			item.shoot = ProjectileType<Projectiles.OtherYoyos.SnekYoyo>();
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SilvervoidCore"), 11);
			recipe.AddIngredient(ItemID.LunarBar, 2);
			recipe.AddIngredient(ItemID.JungleSpores, 20);
			recipe.AddIngredient(ItemID.Stinger, 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}