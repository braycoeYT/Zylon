using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Dirtball
{
	public class DirtyDiscus : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Feeling it makes you feel dirty...'\nShoots a Dirty Discus");
		}

		public override void SetDefaults() 
		{
			item.damage = 10;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 4;
			item.knockBack = 1.5f;
			item.value = 2000;
			item.rare = -1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("DirtyDiscus");
			item.shootSpeed = 12f;
		}
	}
}