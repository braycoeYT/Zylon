using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class LihzahrdLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.Spears[Item.type] = true;
			Tooltip.SetDefault("Shoots multiple high-speed lihzahrd beams");
		}
		public override void SetDefaults() {
			Item.damage = 81;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.useAnimation = 22;
			Item.useTime = 29;
			Item.shootSpeed = 5.5f;
			Item.knockBack = 5.4f;
			Item.width = 32;
			Item.height = 32;
			Item.rare = ItemRarityID.Lime;
			Item.value = Item.sellPrice(0, 6, 50, 0);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.LihzahrdLance>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
	}
}