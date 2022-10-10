using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class Kivasana : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Struck enemies drop more money");
        }
        public override void SetDefaults() {
			Item.damage = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 18;
			Item.useTime = 24;
			Item.shootSpeed = 4f;
			Item.knockBack = 5.75f;
			Item.width = 32;
			Item.height = 32;
			Item.rare = ItemRarityID.Quest;
			Item.value = Item.sellPrice(0, 1);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = false;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.Kivasana>();
		}
		/*public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.OverrideColor = new Color(0, 0, 0);
                }
            }
        }*/
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
	}
}