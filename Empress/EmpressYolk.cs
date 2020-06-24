using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Empress
{
	public class EmpressYolk : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Empress's Yolk");
			Tooltip.SetDefault("Let go of the yoyo to barrage with poisonous yolk\nRight click to end the yolk barrage\nYou cannot use any items until you stop the yolk barrage");
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
			item.knockBack = 4f;
			item.damage = 90;
			item.rare = 7;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = 500000;
			item.shoot = ProjectileType<Projectiles.OtherYoyos.EmpressYolk>();
		}
	}
}