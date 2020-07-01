using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.PHBoss
{
	public class Stalkeye : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Stalkeye");
			Tooltip.SetDefault("It stares...");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 3f;
			item.damage = 16;
			item.rare = 1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = 2000;
			item.shoot = ProjectileType<Projectiles.OtherYoyos.Stalkeye>();
		}
	}
}