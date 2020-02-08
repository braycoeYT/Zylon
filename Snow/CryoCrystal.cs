using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Snow
{
	public class CryoCrystal : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cryo Crystal");
			Tooltip.SetDefault("'Each Cryo Crystal you hold makes you feel a bit better in the cold...'");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 200;
			item.rare = 1;
			item.useStyle = 4;
		}
	}
}