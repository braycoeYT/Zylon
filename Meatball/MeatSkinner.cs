using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class MeatSkinner : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Shoots a meatball\nMeatballs may or may not be poisoned...\nThe Butcher would like this");
		}

		public override void SetDefaults() 
		{
			item.damage = 18;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.knockBack = 2f;
			item.value = 32500;
			item.rare = 3;
			item.UseSound = SoundID.Item17;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Meatball");
			item.shootSpeed = 10f;
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