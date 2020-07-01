using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherBows
{
	public class TwinOpticbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Twin Opticbow");
			Tooltip.SetDefault("A 10% Chance to shoot a cursed flame or laser");
		}

		public override void SetDefaults() 
		{
			item.value = 119565;
			item.useStyle = 5;
			item.useAnimation = 11;
			item.useTime = 11;
			item.damage = 69;
			item.width = 12;
			item.height = 24;
			item.knockBack = 2f;
			item.shoot = 1;
			item.shootSpeed = 9f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.rare = 6;
		}
		
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int ran = Main.rand.Next(1, 21);
            if (ran == 1) type = 95;
			if (ran == 2) type = 14;
            return true;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 11);
			recipe.AddIngredient(ItemID.SoulofSight, 9);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}