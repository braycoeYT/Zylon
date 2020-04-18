using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DirtballHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Melty and gross...\n+20 Mana\n+25 Contagional Points");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 3000;
			item.rare = -1;
			item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<DirtballGuardplate>() && legs.type == ItemType<DirtballLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Magic and Contagional Regen is faster";
			player.manaRegen += 3;
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalResourceRegenRate -= 0.03f;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 20;
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalResourceMax2 += 25;
		}
	}
}