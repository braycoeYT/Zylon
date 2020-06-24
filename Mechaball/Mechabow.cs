using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mechaball
{
	public class Mechabow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("10% Chance of shooting an electric field");
		}

		public override void SetDefaults() 
		{
			item.value = 95000;
			item.useStyle = 5;
			item.useAnimation = 16;
			item.useTime = 16;
			item.damage = 123;
			item.width = 12;
			item.height = 24;
			item.knockBack = 2f;
			item.shoot = 1;
			item.shootSpeed = 7f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.useTurn = true;
			item.rare = 8;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int ran = Main.rand.Next(1, 10);
			if (ran == 1) type = 443;
            return true;
        }
	}
}