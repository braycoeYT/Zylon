using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.VoidDream
{
	public class DreamyRod : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Shoot a bunch of stars\nVoid Dream");
		}

		public override void SetDefaults() 
		{
			item.damage = 9;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 40000;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 12;
			item.shootSpeed = 8f;
			item.noMelee = true;
			item.mana = 8;
			item.stack = 1;
			item.UseSound = SoundID.Item13;
		}
	}
}