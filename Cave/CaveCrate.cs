using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Cave
{
	public class CaveCrate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cave Crate"); //not cave camp
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}
		public override void SetDefaults()
        {
			item.width = 34;
            item.height = 34;
            item.maxStack = 99;
            item.consumable = true;
            item.placeStyle = 0;
            item.useAnimation = 10;
            item.useTime = 10;
			item.useStyle = 1;
			item.rare = 2;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("CaveCrate");
			item.placeStyle = 0;
			item.value = 50000;
        }
		public override bool CanRightClick()
		{
			return true;
		}
		public override void RightClick(Player player)
        {
			int crateRand = Main.rand.Next(0, 6);
			if (crateRand == 0)
			player.QuickSpawnItem(mod.ItemType("WetDryMedal"));
			if (crateRand == 1)
			player.QuickSpawnItem(mod.ItemType("Stalactite"));
			if (crateRand == 2)
			player.QuickSpawnItem(mod.ItemType("Stalagmite"));
			if (crateRand == 3)
			player.QuickSpawnItem(mod.ItemType("Flintbow"));
			if (crateRand == 4)
			player.QuickSpawnItem(mod.ItemType("PebbleRod"));
			if (crateRand == 5)
			player.QuickSpawnItem(mod.ItemType("FloatingPebbleStaff"));

			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.CopperOre, Main.rand.Next(30, 50));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.TinOre, Main.rand.Next(30, 50));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.IronOre, Main.rand.Next(30, 50));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.LeadOre, Main.rand.Next(30, 50));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.SilverOre, Main.rand.Next(30, 50));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.TungstenOre, Main.rand.Next(30, 50));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.GoldOre, Main.rand.Next(30, 50));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.PlatinumOre, Main.rand.Next(30, 50));

			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.CopperBar, Main.rand.Next(10, 21));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.TinBar, Main.rand.Next(10, 21));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.IronBar, Main.rand.Next(10, 21));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.LeadBar, Main.rand.Next(10, 21));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.SilverBar, Main.rand.Next(10, 21));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.TungstenBar, Main.rand.Next(10, 21));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.GoldBar, Main.rand.Next(10, 21));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.PlatinumBar, Main.rand.Next(10, 21));

			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.Amethyst, Main.rand.Next(3, 5));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.Topaz, Main.rand.Next(3, 5));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.Sapphire, Main.rand.Next(3, 5));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.Emerald, Main.rand.Next(3, 5));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.Ruby, Main.rand.Next(3, 5));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.Diamond, Main.rand.Next(3, 5));

			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.ShinePotion, Main.rand.Next(1, 4));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.MiningPotion, Main.rand.Next(1, 4));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.SpelunkerPotion, Main.rand.Next(1, 4));

			if (Main.rand.Next(3) == 0)
			player.QuickSpawnItem(ItemID.LesserHealingPotion, Main.rand.Next(5, 16));
			if (Main.rand.Next(3) == 0)
			player.QuickSpawnItem(ItemID.LesserManaPotion, Main.rand.Next(5, 16));

			if (Main.rand.Next(2) == 0)
			player.QuickSpawnItem(ItemID.Worm, Main.rand.Next(1, 5));

			if (Main.rand.Next(11) == 0)
			player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(20, 91));
			if (Main.rand.Next(21) == 0)
			player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(1, 6));
		}
	}
}