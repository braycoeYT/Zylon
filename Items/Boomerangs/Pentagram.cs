using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Boomerangs
{
	public class Pentagram : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 52;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 26;
			Item.useTime = 28;
			Item.shootSpeed = 15f;
			Item.knockBack = 6.3f;
			Item.width = 50;
			Item.height = 54;
			Item.rare = ItemRarityID.LightPurple;
			Item.value = Item.sellPrice(0, 5);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Boomerangs.Pentagram>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;// && player.ownedProjectileCounts[ProjectileType<Projectiles.Boomerangs.Pentagram_2>()] < 1;
		}
	}
}