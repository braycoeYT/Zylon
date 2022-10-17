using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Slimebender : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("UNOBTAINABLE: Developer item\nShoots a large slimeblast that explodes into smaller slimeblasts");
		}
		public override void SetDefaults() {
			Item.damage = 797;
			Item.DamageType = DamageClass.Melee;
			Item.width = 33;
			Item.height = 33;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5f;
			Item.value = Item.sellPrice(2, 0, 0, 0);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.SlimeblastLarge>();
			Item.shootSpeed = 20f;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.OverrideColor = new Color(116, 179, 237);
                }
            }
        }
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.Ice);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
	}
}