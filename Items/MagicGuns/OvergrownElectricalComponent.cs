using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.MagicGuns
{
	public class OvergrownElectricalComponent : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Only at 0.1% of its true power'");
        }
        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.DamageType = DamageClass.Magic;
            Item.width = 26;
            Item.height = 22;
            Item.useTime = 27;
            Item.useAnimation = 27;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1.2f;
            Item.value = 1;
            Item.rare = ItemRarityID.Gray;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.ElectricBoltPassive>();
            Item.shootSpeed = 10f;
            Item.noMelee = true;
            Item.mana = 1;
            Item.UseSound = SoundID.Item91;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, 2f);
            return false;
        }
        public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.Dirt);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
	}
}