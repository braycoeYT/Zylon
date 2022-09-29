using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class ChaosCaster : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Casts a chaos ball that breaks into 3 shards on impact\nChaos Ball Shards do not collide with tiles");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 54, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 23;
			Item.useTime = 23;
			Item.damage = 22;
			Item.width = 28;
			Item.height = 30;
			Item.knockBack = 3.4f;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.ChaosBallFriendly>();
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Green;
			Item.mana = 9;
			Item.UseSound = SoundID.Item116;
		}
	}
}