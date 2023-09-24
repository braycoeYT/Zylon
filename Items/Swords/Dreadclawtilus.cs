using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Dreadclawtilus : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 51;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 30;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1.2f;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.DreadclawtilusProj>();
			Item.shootSpeed = 12f;
		}
		int s = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Vector2 shootDir = new(0, Item.shootSpeed*-1);
			int rot = 30 + (s%3)*25;
			s++;
			Projectile.NewProjectile(source, position, shootDir.RotatedBy(MathHelper.ToRadians(rot*player.direction)), type, damage, knockback, Main.myPlayer);
			return false;
        }
        /*public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			if (target.type != NPCID.TargetDummy) {
				player.statLife += 1;
				player.HealEffect(1, true);
			}
		}
		public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
			player.statLife += 1;
			player.HealEffect(1, true);
		}*/
    }
}