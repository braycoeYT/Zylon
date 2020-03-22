using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.PHVBoss
{
	public class KingSlicer : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'A sword that king Slime (stole and) slimified himself. Shoots bolts'");
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.melee = true;
			item.width = 35;
			item.height = 35;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 2.5f;
			item.value = 1200;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
			item.shoot = 119;
			item.shootSpeed = 4.5f;
		}
	}
}