using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Dirtball
{
	public class DirtballBag : ModItem
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
			int ran = Main.rand.Next(1, 7);
			if (ran == 1) player.QuickSpawnItem(mod.ItemType("BrokenDirtballCopperShortsword"));
			if (ran == 2) player.QuickSpawnItem(mod.ItemType("DirtyDiscus"));
			if (ran == 3) player.QuickSpawnItem(mod.ItemType("DirtyHarp"));
			if (ran == 4) player.QuickSpawnItem(mod.ItemType("DirtyPistol"));
			if (ran == 5) player.QuickSpawnItem(mod.ItemType("DirtYoyo"));
			if (ran == 6) player.QuickSpawnItem(mod.ItemType("DirtBow"));
			
			ran = Main.rand.Next(1, 4);
			if (ran == 1) player.QuickSpawnItem(mod.ItemType("DirtballHelmet"));
			if (ran == 2) player.QuickSpawnItem(mod.ItemType("DirtballGuardplate"));
			if (ran == 3) player.QuickSpawnItem(mod.ItemType("DirtballLeggings"));
			
			ran = Main.rand.Next(1, 8);
			if (ran == 1) player.QuickSpawnItem(mod.ItemType("BrokenDirtballCopperShortsword"));
			if (ran == 2) player.QuickSpawnItem(mod.ItemType("DirtyDiscus"));
			if (ran == 3) player.QuickSpawnItem(mod.ItemType("DirtyHarp"));
			if (ran == 4) player.QuickSpawnItem(mod.ItemType("DirtyPistol"));
			if (ran == 5) player.QuickSpawnItem(mod.ItemType("DirtYoyo"));
			if (ran == 6) player.QuickSpawnItem(mod.ItemType("DirtBow"));
			
			ran = Main.rand.Next(1, 4);
			if (ran == 1) player.QuickSpawnItem(mod.ItemType("DirtballHelmet"));
			if (ran == 2) player.QuickSpawnItem(mod.ItemType("DirtballGuardplate"));
			if (ran == 3) player.QuickSpawnItem(mod.ItemType("DirtballLeggings"));
			
			player.QuickSpawnItem(ItemID.CopperBar, 1 + Main.rand.Next(5));
			player.QuickSpawnItem(ItemID.DirtBlock, 1 + Main.rand.Next(5));
			player.QuickSpawnItem(ItemID.MudBlock, 1 + Main.rand.Next(5));
			player.QuickSpawnItem(ItemID.Gel, 1 + Main.rand.Next(5));
			player.QuickSpawnItem(ItemID.Lens, 1 + Main.rand.Next(1));
			/*if (ZylonWorld.voidDream)
			{
				player.QuickSpawnItem(mod.ItemType("DirtyMedal"));
				player.QuickSpawnItem(mod.ItemType("DirtShieldOfOblivion"));
			}
			else */if (Main.rand.NextFloat() < .75f)
			player.QuickSpawnItem(mod.ItemType("DirtyMedal"));
		}
		public override int BossBagNPC => NPCType<NPCs.Bosses.Dirtball>();
	}
}