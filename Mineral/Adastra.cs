using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class Adastra : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Adastra");
			Tooltip.SetDefault("To the stars");
		}
		public override void SetDefaults() 
		{
			item.damage = 189;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 5;
			item.knockBack = 1f;
			item.value = 850000;
			item.rare = 2;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 617;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.mana = 10;
			item.stack = 1;
			item.UseSound = SoundID.Item12;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int ran = Main.rand.Next(1, 7);
            if (ran == 1) type = 634;
			if (ran == 2) type = 635;
			if (ran == 3) type = 617;
			if (ran == 4) type = 618;
			if (ran == 5) type = 503;
			if (ran == 6) type = 9;
            return true;
        }
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpaceGun);
			recipe.AddIngredient(mod.ItemType("PhoenixDriver"));
			recipe.AddIngredient(ItemID.FallenStar, 20);
			recipe.AddIngredient(mod.ItemType("DreamString"), 10);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}