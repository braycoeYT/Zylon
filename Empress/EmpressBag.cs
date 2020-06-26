using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Empress
{
	public class EmpressBag : ModItem
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
			int ran = Main.rand.Next(1, 7);
			if (ran == 1) player.QuickSpawnItem(mod.ItemType("EmpressYolk"));
			if (ran == 2) player.QuickSpawnItem(mod.ItemType("EmpressBleeders"));
			if (ran == 3) player.QuickSpawnItem(mod.ItemType("Egg"));
			if (ran == 4) player.QuickSpawnItem(mod.ItemType("EmpressShuriken"));
			if (ran == 5) player.QuickSpawnItem(mod.ItemType("Telomere"));
			if (ran == 6) player.QuickSpawnItem(mod.ItemType("EmpressTears"));
			ran = Main.rand.Next(1, 7);
			if (ran == 1) player.QuickSpawnItem(mod.ItemType("EmpressYolk"));
			if (ran == 2) player.QuickSpawnItem(mod.ItemType("EmpressBleeders"));
			if (ran == 3) player.QuickSpawnItem(mod.ItemType("Egg"));
			if (ran == 4) player.QuickSpawnItem(mod.ItemType("EmpressShuriken"));
			if (ran == 5) player.QuickSpawnItem(mod.ItemType("Telomere"));
			if (ran == 6) player.QuickSpawnItem(mod.ItemType("EmpressTears"));
			player.QuickSpawnItem(mod.ItemType("SpikySac"));
			player.QuickSpawnItem(mod.ItemType("EmpressShard"), Main.rand.Next(11, 19));
		}
		public override int BossBagNPC => NPCType<NPCs.Bosses.EmpressSlime>();
	}
}