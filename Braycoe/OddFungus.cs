using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Braycoe
{
	public class OddFungus : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Should... should you really eat this? No, let the enemies...\nInflicts a random debuff on enemies (Some don't do anything)");
		}

		public override void SetDefaults()
		{
			item.damage = 13;
			item.width = 33;
			item.height = 33;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1.2f;
			item.value = 29500;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("OddFungus");
			item.shootSpeed = 8;
			item.mana = 10;
			item.noUseGraphic = true;
		}
	}
}