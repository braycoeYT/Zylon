using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Zylon.Items.Boomerangs
{
	public class XBlade : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 915;
			Item.DamageType = DamageClass.Melee;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 9f;
			Item.value = Item.sellPrice(13);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.XBlade>();
			Item.shootSpeed = 20f;
			Item.noUseGraphic = true;
			Item.crit = 13;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.OverrideColor = new Color(116, 179, 237);
                }
            }
        }
		int counter;
		public override bool CanUseItem(Player player) {
			counter = 0;
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot) {
                    counter++;
                }
            }
            return counter < 2;
        }
	}
}