using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Misc
{
	public class Flamecougher : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Coughs up a ball of cursed flames on use\nUses gel as ammo\nWeapons Master reward");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 2);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 27;
			Item.useTime = 27;
			Item.damage = 12;
			Item.width = 36;
			Item.height = 22;
			Item.knockBack = 0.1f;
			Item.shoot = ModContent.ProjectileType<Projectiles.CursedFlamesMelee>();
			Item.shootSpeed = 13f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Gel;
			Item.UseSound = SoundID.Item95;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Blue;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.OverrideColor = new Color(100, 60, 0);
                }
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, 1f);
			return false;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
	}
}