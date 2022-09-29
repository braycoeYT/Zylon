using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Misc
{
	public class MagnificentOrb : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Magnificent Orb");
			Tooltip.SetDefault("'Looks like a rubber ball, but does something important, I think.'");
		}
		public override void SetDefaults() {
			Item.damage = 23;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2.5f;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.LightRed;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Misc.MagnificentOrbProj>();
			Item.shootSpeed = 20f;
			Item.noMelee = true;
			Item.mana = 11;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        	for (int i = 0; i < 5; i++) {
				Vector2 spawn = new Vector2(Main.MouseWorld.X + (i-2)*80, player.position.Y - 400);
				Vector2 target = spawn - Main.MouseWorld;
				target.Normalize();
				Projectile.NewProjectile(Item.GetSource_FromThis(), spawn, target*-20f, type, damage, knockback, Main.myPlayer);
			}
			for (int i = 0; i < 5; i++) {
				Vector2 spawn = new Vector2(Main.MouseWorld.X + (i-2)*80, player.position.Y + 400);
				Vector2 target = spawn - Main.MouseWorld;
				target.Normalize();
				Projectile.NewProjectile(Item.GetSource_FromThis(), spawn, target*-20f, type, damage, knockback, Main.myPlayer);
			}
			return false;
		}
	}
}