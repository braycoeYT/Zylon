using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Slimebender : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 313; //797
			Item.DamageType = DamageClass.Melee;
			Item.width = 33;
			Item.height = 33;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 8f;
			Item.value = Item.sellPrice(0, 35);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.SlimeblastLarge>();
			Item.shootSpeed = 20f;
		}
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			return shootCount % 3 == 0;
        }
        public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.OverrideColor = new Color(116, 179, 237);
                }
            }
			TooltipLine xline = new TooltipLine(Mod, "Tooltip0", "~Developer Item (Braycoe)~");
			xline.OverrideColor = new Color(116, 179, 237);
			list.Add(xline);
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