using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Zylon.Items.Discus
{
	public class AncientDiscusBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Desert's Electroshot");
			Tooltip.SetDefault("10% chance of shooting an electrical bolt instead");
		}

		public override void SetDefaults() 
		{
			item.value = 25000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 26;
			item.useTime = 26;
			item.damage = 15;
			item.width = 12;
			item.height = 24;
			item.knockBack = 2.4f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 7.1f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = ItemRarityID.Blue;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int ran = Main.rand.Next(1, 11);
			if (ran == 1) type = 440;
			return true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DriedEssence"), 3);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}