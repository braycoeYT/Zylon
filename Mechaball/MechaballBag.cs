using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mechaball
{
	public class MechaballBag : ModItem
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
			if (ran == 1) player.QuickSpawnItem(mod.ItemType("Electropierce"));
			if (ran == 2) player.QuickSpawnItem(2800);
			if (ran == 3) player.QuickSpawnItem(2797);
			if (ran == 4) player.QuickSpawnItem(2795);
			if (ran == 5) player.QuickSpawnItem(2882);
			if (ran == 6) player.QuickSpawnItem(mod.ItemType("Mechabow"));
			
			ran = Main.rand.Next(1, 7);
			if (ran == 1) player.QuickSpawnItem(mod.ItemType("Electropierce"));
			if (ran == 2) player.QuickSpawnItem(2800);
			if (ran == 3) player.QuickSpawnItem(2797);
			if (ran == 4) player.QuickSpawnItem(2795);
			if (ran == 5) player.QuickSpawnItem(2882);
			if (ran == 6) player.QuickSpawnItem(mod.ItemType("Mechabow"));
			
			if (WorldEdit.voidDream)
			{
				if (Main.rand.NextFloat() < .00001f)
				player.QuickSpawnItem(3124);
			}
		}
		public override int BossBagNPC => NPCType<NPCs.Bosses.Mechaball>();
	}
}