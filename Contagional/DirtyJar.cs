using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Contagional
{
	public class DirtyJar : ContagionalItem
	{
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'There's....There's blended up eyes and lotsa gigantic microbes here!'\n~~~50% Chance of inflicting Slow for 1 second\n~~~100% Chance of inflicting Stinky for 3 seconds\n~~~1% Chance of inflicting Slimed for 2 seconds\n~~~20% Chance of inflicting Wet for 2 Seconds");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 4;
			item.width = 33;
			item.height = 33;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 0.1f;
			item.value = 500;
			item.rare = -1;
			item.UseSound = SoundID.Item2;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("DirtyJarSpecks");
			item.shootSpeed = 8;
			ContagionalResourceCost = 2;
			item.noUseGraphic = true;
		}
	}
}