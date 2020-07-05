using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Rare
{
	public class RainbowRose : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Throws a rainbow rose that explodes into rainbows\nRare Item");
		}
		
		public override void SetDefaults() 
		{
			item.damage = 10;
			item.width = 33;
			item.height = 33;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 4;
			item.knockBack = 5.9f;
			item.value = 55050;
			item.rare = -11;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("RainbowRose");
			item.shootSpeed = 10f;
			item.noUseGraphic = true;
			item.consumable = true;
			item.maxStack = 999;
		}
	}
}