using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items
{
	public class DiscusBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() {
			item.maxStack = 99;
			item.consumable = true;
			item.width = 40;
			item.height = 36;
			item.rare = 12;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			player.TryGettingDevArmor();
			int ran = Main.rand.Next(1, 3);
			if (ran == 1) player.QuickSpawnItem(ItemID.SandBlock, Main.rand.Next(5, 20)); //just so I don't forget how to random :P
			if (ran == 2) player.QuickSpawnItem(ItemID.SandBlock, Main.rand.Next(10, 30));
			 player.QuickSpawnItem(ItemID.Amber, Main.rand.Next(2, 4));
			 player.QuickSpawnItem(ItemID.GoldBar, Main.rand.Next(2, 4));
			 player.QuickSpawnItem(mod.ItemType("StoryDiscus"));
			 player.QuickSpawnItem(mod.ItemType("ZylonianDesertCore"), Main.rand.Next(8, 13));
		}
		public override int BossBagNPC => NPCType<NPCs.Bosses.AncientDesertDiscus>();
	}
}