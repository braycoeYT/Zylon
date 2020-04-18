using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Contagional.VoidDream
{
	public class OddFungus : ContagionalItem
	{
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Should... should you really eat this? No, let the enemies...\n~~~Random Debuff/Buff for 1 second (Some don't do anything)\nVoid Dream");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 13;
			item.width = 33;
			item.height = 33;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1.2f;
			item.value = 29500;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("OddFungus");
			item.shootSpeed = 8;
			ContagionalResourceCost = 10;
			item.noUseGraphic = true;
		}
	}
}