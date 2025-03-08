using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class AssassinsBullet : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}
		public override void SetDefaults() {
			Item.damage = 9;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 1f;
			Item.value = Item.buyPrice(0, 0, 0, 10);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileType<Projectiles.Ammo.AssassinsBullet>();
			Item.ammo = AmmoID.Bullet;
		}
	}
}