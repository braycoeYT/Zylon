using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Contagional
{
	public class MeatyJar : ContagionalItem
	{
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Noodles only in the meatballs? How odd.\nShoot meatballs\nMeatballs may or may not be poisoned");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 19;
			item.width = 33;
			item.height = 33;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 2.5f;
			item.value = 32500;
			item.rare = 3;
			item.UseSound = SoundID.Item2;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Meatball");
			item.shootSpeed = 8;
			ContagionalResourceCost = 5;
			item.noUseGraphic = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			PlayerEdit p = player.GetModPlayer<PlayerEdit>();
			
            if (p.UpgradeMeatball)
			{
				type = mod.ProjectileType("MeatballBig");
			}
			else
			{
				type = mod.ProjectileType("Meatball");
			}
            return true;
        }
	}
}