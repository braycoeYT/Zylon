using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class OverclockArrow : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("The longer the arrow is in the air before hitting an enemy, the more damage it does");
        }
		public override void SetDefaults() {
			Item.damage = 5;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 32;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 1f;
			Item.value = Item.buyPrice(0, 0, 0, 8);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileType<Projectiles.Ammo.OverclockArrow>();
			Item.ammo = AmmoID.Arrow;
		}
	}
}