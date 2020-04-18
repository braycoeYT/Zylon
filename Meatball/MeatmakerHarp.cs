using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class MeatmakerHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("The lyrics are horrifying...");
		}

		public override void SetDefaults() 
		{
			item.damage = 18;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 32500;
			item.rare = 3;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 76;
			item.shootSpeed = 6.5f;
			item.noMelee = true;
			item.mana = 6;
			item.holdStyle = 3;
			item.stack = 1;
		}
	}
}