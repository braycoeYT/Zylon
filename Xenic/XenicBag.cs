using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Xenic
{
	public class XenicBag : ModItem
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
			player.QuickSpawnItem(mod.ItemType("GalacticDiamondium"), Main.rand.Next(6, 11));
			player.QuickSpawnItem(mod.ItemType("XenicCore"));
			player.QuickSpawnItem(mod.ItemType("XenonTank"));
		}
		public override int BossBagNPC => NPCType<NPCs.Minibosses.XenicAcidpumper>();
	}
}