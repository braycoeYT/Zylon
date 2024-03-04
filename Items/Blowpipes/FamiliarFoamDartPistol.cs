using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Blowpipes
{
	public class FamiliarFoamDartPistol : ModItem
	{
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 33;
			Item.knockBack = 3.5f;
			Item.shootSpeed = 15f;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.value = Item.buyPrice(0, 15);
			Item.autoReuse = true;
			Item.rare = ItemRarityID.LightRed;
			Item.useStyle = ItemUseStyleID.Shoot;
		}
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			if (shootCount % 4 == 0) {
				Projectile.NewProjectile(source, position, velocity*1.5f, ModContent.ProjectileType<Projectiles.Blowpipes.TacticalFoamDart>(), (int)(damage*1.5f), knockback*1.5f, Main.myPlayer);
				SoundEngine.PlaySound(SoundID.Item98, position);
			}
			return !(shootCount % 4 == 0);
        }
    }
}