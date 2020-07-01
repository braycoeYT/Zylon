using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Discus
{
	public class DiscusBag : ModItem
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
			player.QuickSpawnItem(ItemID.SandBlock, Main.rand.Next(5, 20));
			player.QuickSpawnItem(ItemID.Amber, Main.rand.Next(3, 6));
			player.QuickSpawnItem(ItemID.GoldBar, Main.rand.Next(5, 8));
			player.QuickSpawnItem(mod.ItemType("ZylonianDesertCore"), Main.rand.Next(8, 11));
			player.QuickSpawnItem(mod.ItemType("BrokenDiscus"), Main.rand.Next(10, 15));
			if (Main.rand.NextFloat() < .5f)
				player.QuickSpawnItem(mod.ItemType("HappyDiscus"));
			else
				player.QuickSpawnItem(mod.ItemType("VoidingMotherboard"));
		}
		public override int BossBagNPC => NPCType<NPCs.Bosses.AncientDesertDiscus>();
	}
}