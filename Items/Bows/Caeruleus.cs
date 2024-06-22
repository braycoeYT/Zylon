using Microsoft.Xna.Framework;
using Terraria;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace Zylon.Items.Bows
{
	public class Caeruleus : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 35);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.damage = 8670; //Temp buff so I can actually speed up the battle
			Item.width = 48;
			Item.height = 92;
			Item.knockBack = 3.5f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 18f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.rare = RarityType<BraycoeDev>();
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-8, 0);
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
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            int newType = type;
			if (Main.rand.NextBool(4)) newType = ProjectileType<Projectiles.Bows.CeruleanArrow>();

			for (int i = 0; i < 4; i++) {
				Vector2 temp = Vector2.Normalize(velocity).RotatedBy(MathHelper.PiOver2);
				Vector2 newPos = position + (temp*(30f-i*20)); //18, 12 is perfect arrow distance
				Projectile.NewProjectile(source, newPos, velocity, newType, damage, knockback, player.whoAmI);
            }
			return false;
        }
    }
}