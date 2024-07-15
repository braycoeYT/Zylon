using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Yoyos
{
	public class TheRetractor : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 42;
			Item.height = 40;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 20f;
			Item.knockBack = 6f;
			Item.damage = 187;
			Item.rare = RarityType<Magenta>();
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(0, 15);
			Item.shoot = ProjectileType<Projectiles.Yoyos.TheRetractor>();
		}
	}
}