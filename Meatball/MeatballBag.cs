using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class MeatballBag : ModItem
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
			int ran = Main.rand.Next(1, 8);
			if (ran == 1) player.QuickSpawnItem(mod.ItemType("BleedingGun"));
			if (ran == 2) player.QuickSpawnItem(mod.ItemType("Meatbow"));
			if (ran == 3) player.QuickSpawnItem(mod.ItemType("MeatmakerHarp"));
			if (ran == 4) player.QuickSpawnItem(mod.ItemType("MeatSkinner"));
			if (ran == 5) player.QuickSpawnItem(mod.ItemType("Meatyrang"));
			if (ran == 6) player.QuickSpawnItem(mod.ItemType("TheMeatbringer"));
			if (ran == 7) player.QuickSpawnItem(mod.ItemType("MeatyJar"));
			
			ran = Main.rand.Next(1, 8);
			if (ran == 1) player.QuickSpawnItem(mod.ItemType("BleedingGun"));
			if (ran == 2) player.QuickSpawnItem(mod.ItemType("Meatbow"));
			if (ran == 3) player.QuickSpawnItem(mod.ItemType("MeatmakerHarp"));
			if (ran == 4) player.QuickSpawnItem(mod.ItemType("MeatSkinner"));
			if (ran == 5) player.QuickSpawnItem(mod.ItemType("Meatyrang"));
			if (ran == 6) player.QuickSpawnItem(mod.ItemType("TheMeatbringer"));
			if (ran == 7) player.QuickSpawnItem(mod.ItemType("MeatyJar"));
			
			player.QuickSpawnItem(ItemID.MeatGrinder);
			player.QuickSpawnItem(ItemID.FleshBlock, 20 + Main.rand.Next(30));
			if (WorldEdit.voidDream)
			{
				player.QuickSpawnItem(mod.ItemType("MeatballSpecial"));
				player.QuickSpawnItem(ItemID.FleshBlock, 1 + Main.rand.Next(5));
			}
		}
		public override int BossBagNPC => NPCType<NPCs.Bosses.Meatball>();
	}
}