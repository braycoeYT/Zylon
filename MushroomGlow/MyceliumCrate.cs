using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.MushroomGlow
{
	public class MyceliumCrate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mycelium Crate");
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
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.rare = ItemRarityID.Green;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("MyceliumCrate");
			item.placeStyle = 0;
			item.value = 50000;
        }
		public override bool CanRightClick()
		{
			return true;
		}
		public override void RightClick(Player player)
        {
			int crateRand = Main.rand.Next(0, 4);
			if (crateRand == 0)
			player.QuickSpawnItem(mod.ItemType("GlowingMushtopStaff"));
			if (crateRand == 1)
			player.QuickSpawnItem(mod.ItemType("GlowingMushroomMusher"));
			if (crateRand == 2)
			player.QuickSpawnItem(mod.ItemType("BookofGlowingShrooms"));
			if (crateRand == 3)
			player.QuickSpawnItem(mod.ItemType("GlowingMushbow"));

			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.CopperOre, Main.rand.Next(6, 24));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.TinOre, Main.rand.Next(6, 24));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.IronOre, Main.rand.Next(6, 24));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.LeadOre, Main.rand.Next(6, 24));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.SilverOre, Main.rand.Next(6, 24));
			if (Main.rand.Next(7) == 0)
			player.QuickSpawnItem(ItemID.TungstenOre, Main.rand.Next(6, 24));

			if (Main.rand.Next(9) == 0)
			player.QuickSpawnItem(ItemID.CopperBar, Main.rand.Next(2, 8));
			if (Main.rand.Next(9) == 0)
			player.QuickSpawnItem(ItemID.TinBar, Main.rand.Next(2, 8));
			if (Main.rand.Next(9) == 0)
			player.QuickSpawnItem(ItemID.IronBar, Main.rand.Next(2, 8));
			if (Main.rand.Next(9) == 0)
			player.QuickSpawnItem(ItemID.LeadBar, Main.rand.Next(2, 8));
			if (Main.rand.Next(9) == 0)
			player.QuickSpawnItem(ItemID.SilverBar, Main.rand.Next(2, 8));
			if (Main.rand.Next(9) == 0)
			player.QuickSpawnItem(ItemID.TungstenBar, Main.rand.Next(2, 8));

			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.ShinePotion, Main.rand.Next(1, 4));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.InvisibilityPotion, Main.rand.Next(1, 4));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.MiningPotion, Main.rand.Next(1, 4));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.AmmoReservationPotion, Main.rand.Next(1, 4));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(mod.ItemType("ManareachPotion"), Main.rand.Next(1, 4));

			if (Main.rand.Next(3) == 0)
			player.QuickSpawnItem(ItemID.LesserHealingPotion, Main.rand.Next(5, 16));
			if (Main.rand.Next(3) == 0)
			player.QuickSpawnItem(ItemID.LesserManaPotion, Main.rand.Next(5, 16));

			if (Main.rand.Next(2) == 0)
			player.QuickSpawnItem(ItemID.JourneymanBait, Main.rand.Next(1, 5));
			if (Main.rand.Next(2) == 0)
			player.QuickSpawnItem(ItemID.ApprenticeBait, Main.rand.Next(1, 5));
			if (Main.rand.Next(4) == 0)
			player.QuickSpawnItem(ItemID.MasterBait, Main.rand.Next(1, 5));

			if (Main.rand.Next(10) == 0)
			player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(20, 91));
			if (Main.rand.Next(20) == 0)
			player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(1, 7));
		}
	}
}