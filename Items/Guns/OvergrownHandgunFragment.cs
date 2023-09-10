using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class OvergrownHandgunFragment : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'Only at 0.1% of its true power'");
		}
		public override void SetDefaults() {
			Item.value = 1;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 27;
			Item.useTime = 27;
			Item.damage = 1;
			Item.width = 26;
			Item.height = 24;
			Item.knockBack = 0.5f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Gray;
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