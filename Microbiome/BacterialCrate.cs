using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome
{
	public class BacterialCrate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bacterial Crate");
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
			item.createTile = mod.TileType("BacterialCrate");
			item.placeStyle = 0;
			item.value = 50000;
        }
		public override bool CanRightClick()
		{
			return true;
		}
		public override void RightClick(Player player)
        {
			int crateRand = Main.rand.Next(0, 5);
			if (crateRand == 0)
			player.QuickSpawnItem(mod.ItemType("BandOfFlashspeed"));
			if (crateRand == 1)
			player.QuickSpawnItem(mod.ItemType("ATPistol"));
			if (crateRand == 2)
			player.QuickSpawnItem(mod.ItemType("CellularRemote"));
			if (crateRand == 3)
			player.QuickSpawnItem(mod.ItemType("Celldigger"));
			if (crateRand == 4)
			player.QuickSpawnItem(mod.ItemType("WingedMenace"));

			if (Main.rand.NextFloat() < .75f)
			player.QuickSpawnItem(mod.ItemType("TwistedMembraneOre"), Main.rand.Next(15, 25));
			if (Main.rand.NextFloat() < .75f)
			player.QuickSpawnItem(mod.ItemType("TwistedMembraneBar"), Main.rand.Next(5, 11));

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

			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.SpelunkerPotion, Main.rand.Next(2, 5));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.GravitationPotion, Main.rand.Next(2, 5));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.MiningPotion, Main.rand.Next(2, 5));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(mod.ItemType("BloodDropPotion"), Main.rand.Next(2, 5));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(mod.ItemType("ManareachPotion"), Main.rand.Next(2, 5));

			if (Main.rand.Next(2) == 0)
			player.QuickSpawnItem(ItemID.HealingPotion, Main.rand.Next(5, 18));
			if (Main.rand.Next(2) == 0)
			player.QuickSpawnItem(ItemID.ManaPotion, Main.rand.Next(5, 18));

			if (Main.rand.Next(2) == 0)
			player.QuickSpawnItem(ItemID.JourneymanBait, Main.rand.Next(2, 7));
			if (Main.rand.Next(2) == 0)
			player.QuickSpawnItem(ItemID.MasterBait, Main.rand.Next(2, 7));

			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(5, 13));
		}
	}
}