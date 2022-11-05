/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.MagicGuns
{
	public class PocketSunBlaster : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Harness the power of the sun'\nFires sun blasts that are strengthened as your mana decreases");
		}
		public override void SetDefaults() {
			Item.damage = 59;
			Item.DamageType = DamageClass.Magic;
			Item.width = 72;
			Item.height = 30;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.4f;
			Item.value = Item.sellPrice(0, 4, 0, 0);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.useTurn = true;
			//Item.shoot = ModContent.ProjectileType<Projectiles.MagicGuns.PocketSunBlast>();
			Item.shootSpeed = 15f;
			Item.noMelee = true;
			Item.mana = 12;
			Item.UseSound = SoundID.Item47;
		}
        /*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (player.statMana < player.statManaMax2 * 0.25f) type = ModContent.ProjectileType<Projectiles.MagicGuns.PocketSunBlast4>();
			else if (player.statMana < player.statManaMax2 * 0.5f) type = ModContent.ProjectileType<Projectiles.MagicGuns.PocketSunBlast3>();
			else if (player.statMana < player.statManaMax2 * 0.75f) type = ModContent.ProjectileType<Projectiles.MagicGuns.PocketSunBlast2>();
			else type = ModContent.ProjectileType<Projectiles.MagicGuns.PocketSunBlast>();
        }*/
        /*public override Vector2? HoldoutOffset() {
			return new Vector2(8, -4);
		}
	}
}*/