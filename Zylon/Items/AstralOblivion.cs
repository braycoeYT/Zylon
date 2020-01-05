using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items
{
	public class AstralOblivion : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'This harp is made of the light, the dark, and the void.'");
		}

		public override void SetDefaults() 
		{
			item.damage = 46981;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 5;
			item.knockBack = 2;
			item.value = 2700;
			item.rare = 11;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 76;
			item.shootSpeed = 6f;
			item.noMelee = true;
			item.mana = 50;
			item.holdStyle = 3;
			item.stack = 1;
		}
	}
}