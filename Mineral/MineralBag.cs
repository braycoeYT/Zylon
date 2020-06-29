using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	public class MineralBag : ModItem
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
			player.QuickSpawnItem(mod.ItemType("GemstoneWings"));
			player.QuickSpawnItem(mod.ItemType("GalacticDiamondium"), Main.rand.Next(20, 35));
			player.QuickSpawnItem(ItemID.Amethyst, Main.rand.Next(15, 30));
		}
		public override int BossBagNPC => NPCType<NPCs.Bosses.ZylonianMineralExtractor>();
	}
}