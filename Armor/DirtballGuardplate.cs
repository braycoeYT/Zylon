using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class DirtballGuardplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Disgusting and sticky...\n+5% Magic and Contagional Damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 3500;
			item.rare = -1;
			item.defense = 3;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.05f;
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalDamageMult += 0.05f;
		}
	}
}