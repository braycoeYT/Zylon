using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class Meatyrang : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Toss some meatyrangs\nMeatyrangs are definitely poisoned");
		}

		public override void SetDefaults() 
		{
			item.damage = 27;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 4;
			item.knockBack = 2.5f;
			item.value = 32500;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Meatyrang");
			item.shootSpeed = 12f;
			item.noUseGraphic = true;
		}
	}
}