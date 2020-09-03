using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Slime
{
	public class SlimeBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Turns regular arrows into slime arrows");
		}

		public override void SetDefaults() 
		{
			item.value = 18000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.damage = 9;
			item.width = 12;
			item.height = 24;
			item.knockBack = 3.1f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 6.1f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = mod.ProjectileType("SlimeArrow");
			}
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SlimyCore"), 3);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}