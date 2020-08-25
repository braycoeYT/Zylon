using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Braycoe
{
	public class Slimebender : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Developer Item\nShoots a large slimeblast that explodes into smaller slimeblasts");
		}
		public override void SetDefaults() {
			item.damage = 917;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = 31540;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("SlimeblastLarge");
			item.shootSpeed = 20f;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(116, 179, 237);
                }
            }
        }
		public override void PostUpdate() {
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(item.position, item.width, item.height, 80);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
	}
}