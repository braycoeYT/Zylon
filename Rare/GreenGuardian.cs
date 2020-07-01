using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Rare
{
	public class GreenGuardian : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Swing to your heart's content\nRare Item");
		}

		public override void SetDefaults() 
		{
			item.damage = 9;
			item.melee = true;
			item.width = 31;
			item.height = 31;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 1;
			item.knockBack = 1.6f;
			item.value = 44000;
			item.rare = -11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}
	}
}