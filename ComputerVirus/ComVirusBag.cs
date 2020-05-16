using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.ComputerVirus
{
	public class ComVirusBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 99;
			item.consumable = true;
			item.width = 40;
			item.height = 36;
			item.rare = 12;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			player.QuickSpawnItem(mod.ItemType("SoulOfByte"), Main.rand.Next(25, 40));
			player.QuickSpawnItem(ItemID.HallowedBar, Main.rand.Next(20, 35));
			if (Main.rand.NextFloat() < .2f)
			player.QuickSpawnItem(mod.ItemType("CrazedContraption"));
		}
		public override int BossBagNPC => NPCType<NPCs.Bosses.ComputerVirusPha2>();
	}
}