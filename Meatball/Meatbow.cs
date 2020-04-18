using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Meatball
{
	public class Meatbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("10% Chance of shooting a meatball\nMeatballs may or may not be poisoned...");
		}

		public override void SetDefaults() 
		{
			item.value = 32500;
			item.useStyle = 5;
			item.useAnimation = 14;
			item.useTime = 14;
			item.damage = 18;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1.2f;
			item.shoot = 1;
			item.shootSpeed = 6.1f;
			item.noMelee = true;
			item.ranged = true;
			item.crit = 2;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.useTurn = true;
			item.rare = 3;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int ran = Main.rand.Next(1, 10);
			
			PlayerEdit p = player.GetModPlayer<PlayerEdit>();
			
			if (p.UpgradeMeatball)
			{
				if (ran == 1) type = mod.ProjectileType("MeatballBig");
			}
			else
			{
				if (ran == 1) type = mod.ProjectileType("Meatball");
			}
            return true;
        }
	}
}