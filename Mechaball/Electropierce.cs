using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mechaball
{
	public class Electropierce : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Shoots electrofields");
		}

		public override void SetDefaults() 
		{
			item.damage = 81;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 33;
			item.useAnimation = 33;
			item.useStyle = 3;
			item.knockBack = 5.5f;
			item.value = 100000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.crit = 6;
			item.shoot = 443;
			item.shootSpeed = 7f;
		}
	}
}