using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome.Crate
{
	public class ATPistol : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("A..T. Pistol");
		}

		public override void SetDefaults() 
		{
			item.value = 75000;
			item.useStyle = 5;
			item.useAnimation = 27;
			item.useTime = 27;
			item.damage = 23;
			item.width = 36;
			item.height = 24;
			item.knockBack = 4.1f;
			item.shoot = 14;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = 1;
		}
	}
}