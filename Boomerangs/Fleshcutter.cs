using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class Fleshcutter : ModItem
	{
		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 40;
			item.width = 45;
			item.height = 45;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1.5f;
			item.value = 150000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Fleshcutter");
			item.shootSpeed = 17;
			item.noUseGraphic = true;
		}
		public override bool CanUseItem(Player player) {
			for (int i = 0; i < 1000; ++i) {
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot) {
					return false;
			    }
			}
        return true;
		}
	}
}