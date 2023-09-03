using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class EyeoftheSandstorm : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.Spears[Item.type] = true;
			// DisplayName.SetDefault("Eye of the Sandstorm");
			// Tooltip.SetDefault("Releases homing desert spirits after striking a foe");
		}
		public override void SetDefaults() {
			Item.damage = 49;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.useAnimation = 8;
			Item.useTime = 8;
			Item.shootSpeed = 7f;
			Item.knockBack = 5.4f;
			Item.width = 32;
			Item.height = 32;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.sellPrice(0, 10);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.EyeoftheSandstorm>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
	}
}