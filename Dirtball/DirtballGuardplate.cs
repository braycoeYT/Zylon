using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Dirtball
{
	[AutoloadEquip(EquipType.Body)]
	public class DirtballGuardplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Disgusting and sticky...\n+5% Magic Damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 3500;
			item.rare = -1;
			item.defense = 4;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.05f;
		}
	}
}