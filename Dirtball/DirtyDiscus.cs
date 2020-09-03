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
			Tooltip.SetDefault("Feeling it makes you feel dirty...\nRapidly throw discuses");
		}

		public override void SetDefaults() 
		{
			item.damage = 12;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 31;
			item.useAnimation = 31;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.knockBack = 1.5f;
			item.value = 2000;
			item.rare = -1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("DirtyDiscus");
			item.shootSpeed = 12f;
		}
	}
}