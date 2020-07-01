using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Dirtball
{
	[AutoloadEquip(EquipType.Legs)]
	public class DirtballLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Weird and dirty...\n+12% Movement speed\n+2% Magic Crit");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 2500;
			item.rare = -1;
			item.defense = 3;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxRunSpeed += 0.12f;
			player.magicCrit += 2;
		}
	}
}