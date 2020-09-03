using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSwords
{
	public class Starfrenzy : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Causes stars to rain from the sky\nForged from the fury of shortsword heaven");
		}

		public override void SetDefaults() {
			item.damage = 20;
			item.melee = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 5.5f;
			item.value = 50000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ProjectileID.Starfury;
			item.shootSpeed = 20f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			position.X = Main.MouseWorld.X;
			position.Y = player.position.Y - 600;
			speedX = 0;
			speedY = 20;
			return true;
		}
	}
}