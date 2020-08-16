using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome
{
	public class HyperchargedNucleolus : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Constantly rains down navycell debris on enemies\nIncreased life regen after striking an enemy");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 100000;
			item.rare = 3;
			item.expert = true;
		}
		int playerTimer;
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.hyperCell = true;
			playerTimer++;
			if (playerTimer % 300 == 0)
			{
				Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 601), player.Center.Y - 600, Main.rand.Next(-3, 4), 5, mod.ProjectileType("GoodND"), 34, 1f, player.whoAmI);
			}
			if (playerTimer % 300 == 100)
			{
				Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 601), player.Center.Y - 600, Main.rand.Next(-3, 4), 5, mod.ProjectileType("GoodND2"), 31, 1f, player.whoAmI);
			}
			if (playerTimer % 300 == 200)
			{
				Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 601), player.Center.Y - 600, Main.rand.Next(-3, 4), 5, mod.ProjectileType("GoodND3"), 28, 1f, player.whoAmI);
			}
		}
	}
}