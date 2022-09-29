using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class PocketGrenade : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Each year these get smaller and smaller... wasn't it already pocket enough?'\nFor use with blowpipes");
        }
		public override void SetDefaults() {
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 12;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 6f;
			Item.value = 50;
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileType<Projectiles.Ammo.PocketGrenade>();
			Item.ammo = AmmoID.Dart;
		}
	}
}