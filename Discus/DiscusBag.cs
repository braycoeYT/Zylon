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
			int ran = Main.rand.Next(1, 2);
			if (ran == 1) player.QuickSpawnItem(ItemID.SandBlock, Main.rand.Next(5, 20)); //just so I don't forget how to random :P
			player.QuickSpawnItem(ItemID.Amber, Main.rand.Next(2, 4));
			player.QuickSpawnItem(ItemID.GoldBar, Main.rand.Next(2, 4));
			player.QuickSpawnItem(mod.ItemType("ZylonianDesertCore"), Main.rand.Next(8, 13));
			player.QuickSpawnItem(mod.ItemType("DiscusGuardianPendant"));
			if (WorldEdit.voidDream)
			{
				player.QuickSpawnItem(mod.ItemType("BandOfInfection"));
				player.QuickSpawnItem(mod.ItemType("VoidingMotherboard"));
				player.QuickSpawnItem(mod.ItemType("ZylonianDesertCore"), Main.rand.Next(1, 2));
				if (Main.rand.NextFloat() < .1f)
				player.QuickSpawnItem(mod.ItemType("HappyDiscus"));
				player.QuickSpawnItem(mod.ItemType("BrokenDiscus"), Main.rand.Next(1, 3));
			}
			else if (Main.rand.NextFloat() < .75f)
			player.QuickSpawnItem(mod.ItemType("BandOfInfection"));
			player.QuickSpawnItem(mod.ItemType("ZylonianDesertCore"), Main.rand.Next(4, 8));
			player.QuickSpawnItem(mod.ItemType("BrokenDiscus"), Main.rand.Next(5, 13));
			
			if (Main.expertMode)
			{
				if (Main.rand.NextFloat() < .2f)
				player.QuickSpawnItem(mod.ItemType("HappyDiscus"));
			}
		}
		public override int BossBagNPC => NPCType<NPCs.Bosses.AncientDesertDiscus>();
	}
}