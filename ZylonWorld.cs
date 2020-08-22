using Zylon;
using Zylon.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace Zylon
{
	public class ZylonWorld : ModWorld
	{
		public static bool downedDirtball;
		public static bool downedDiscus;
		public static bool downedMineral;
		public static bool generatedEctojewelo;
		public static bool downedComVirus;
		public static bool generatedOblivion;
		public static bool downedMeatball;
		public static bool downedMechaball;
		public static bool hasAlertSlime;
		public static bool hasAlertEvil;
		public static bool hasConversationDrop;
		public static bool downedXenic;
		public static bool downedEmpress;
		public static bool downedCell;
		public static bool rollercoasterTown;
		public static int microbiomeTiles;
		//public Vector2 ZMETarget;
		
		public override void Initialize()
		{
			downedDirtball = false;
			downedDiscus = false;
			downedMineral = false;
			generatedEctojewelo = false;
			downedComVirus = false;
			generatedOblivion = false;
			downedMeatball = false;
			downedMechaball = false;
			hasAlertSlime = false;
			hasAlertEvil = false;
			hasConversationDrop = false;
			downedXenic = false;
			downedEmpress = false;
			downedCell = false;
			rollercoasterTown = false;
		}
		
		public override TagCompound Save()
        {
            return new TagCompound
            {
                {"downedDirtball", downedDirtball},
                {"downedDiscus", downedDiscus},
                {"downedMineral", downedMineral},
				{"generatedEctojewelo", generatedEctojewelo},
				{"downedComVirus", downedComVirus},
				{"generatedOblivion", generatedOblivion},
				{"downedMeatball", downedMeatball},
				{"downedMechaball", downedMechaball},
				{"hasAlertSlime", hasAlertSlime},
				{"hasAlertEvil", hasAlertEvil},
				{"hasConversationDrop", hasConversationDrop},
				{"downedXenic", downedXenic},
				{"downedEmpress", downedEmpress},
				{"downedCell", downedCell},
				{"rollercoasterTown", rollercoasterTown}
			};
        }
		
        public override void Load(TagCompound tag)
        {
            downedDirtball = tag.GetBool("downedDirtball");
			downedDiscus = tag.GetBool("downedDiscus");
			downedMineral = tag.GetBool("downedMineral");
			generatedEctojewelo = tag.GetBool("generatedEctojewelo");
			downedComVirus = tag.GetBool("downedComVirus");
			generatedOblivion = tag.GetBool("generatedOblivion");
			downedMeatball = tag.GetBool("downedMeatball");
			downedMechaball = tag.GetBool("downedMechaball");
			hasAlertSlime = tag.GetBool("hasAlertSlime");
			hasAlertEvil = tag.GetBool("hasAlertEvil");
			hasConversationDrop = tag.GetBool("hasConversationDrop");
			downedXenic = tag.GetBool("downedXenic");
			downedEmpress = tag.GetBool("downedEmpress");
			downedCell = tag.GetBool("downedCell");
			rollercoasterTown = tag.GetBool("rollercoasterTown");
		}
		
		 public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte(); //restate every "7"
            flags[0] = downedDirtball;
            flags[1] = downedDiscus;
            flags[2] = downedMineral;
			flags[3] = generatedEctojewelo;
			flags[4] = downedComVirus;
			flags[5] = downedXenic;
			flags[6] = downedEmpress;
			flags[7] = downedCell;
			writer.Write(flags);
			BitsByte flags2 = new BitsByte();
			flags2[0] = hasAlertSlime;
			flags2[1] = hasAlertEvil;
			flags2[2] = hasConversationDrop;
			flags2[3] = rollercoasterTown;
			writer.Write(flags2);
		}
		
		public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte(); //same as above
            downedDirtball = flags[0];
            downedDiscus = flags[1];
            downedMineral = flags[2];
			generatedEctojewelo = flags[3];
			downedComVirus = flags[4];
			downedXenic = flags[5];
			downedEmpress = flags[6];
			downedCell = flags[7];

			BitsByte flags2 = reader.ReadByte();
			hasAlertSlime = flags2[0];
			hasAlertEvil = flags2[1];
			hasConversationDrop = flags2[2];
			rollercoasterTown = flags2[3];
		}
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1)
			{
		    tasks.Insert(ShiniesIndex + 1, new PassLegacy("Zylonian Ores", ZylonOres));
			}

			int Underworld = tasks.FindIndex(genpass => genpass.Name.Equals("Underworld"));
			if (Underworld != -1)
			{
				tasks.Insert(Underworld + 1, new PassLegacy("Microbiome", Microbiome));
			}
		}
		
		public override void PreUpdate()
        {
			if (!generatedEctojewelo && downedMineral)
			{
				for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00002); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY / 2);
				WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(2, 14), WorldGen.genRand.Next(5, 19), TileType<EctojeweloOre>(), false, 0f, 0f, false, true);
				}
				Color messageColor = Color.LightBlue;
					string chat = "The Zylonian Mineral Extrator has blessed your world with Ectojewelo Ore!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				messageColor = Color.Navy;
				chat = "The microbiome grows restless...";
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				}
				else if (Main.netMode == NetmodeID.SinglePlayer)
				{
					Main.NewText(Language.GetTextValue(chat), messageColor);
				}
				generatedEctojewelo = true;
			}
			
			if (!hasAlertSlime && NPC.downedPlantBoss)
			{
				Color messageColor = Color.Green;
					string chat = "The Elemental Slimes have been unleashed!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				hasAlertSlime = true;
			}
			
			if (!hasAlertEvil && NPC.downedMoonlord)
			{
				Color messageColor = Color.White;
				if (WorldGen.crimson)
				messageColor = Color.Red;
				else
				messageColor = Color.Purple;
					string chat = "Something has changed in this world's evil...";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				hasAlertEvil = true;
			}
		}
		
		private void ZylonOres(GenerationProgress progress)
		{
			progress.Message = "Sprinkling your world with Zylonian Ores";
			for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00002); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY / 2);
				WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(4, 12), WorldGen.genRand.Next(6, 17), TileType<CyanixOre>(), false, 0f, 0f, false, true);
			}
		}
		int sizeBonus;
		int sizeBonus2;
		private void Microbiome(GenerationProgress progress)
		{
			progress.Message = "Microsizing your world";
			int microSpawnX = Main.maxTilesX - WorldGen.genRand.Next(600, Main.maxTilesX - 600);
			if (Main.maxTilesX > 4201)
			sizeBonus = 150;
			if (Main.maxTilesX > 6201)
			sizeBonus = 300;
			int size = 230 + sizeBonus;
			if (Main.maxTilesX > 4201)
			sizeBonus2 = 11;
			if (Main.maxTilesX > 6201)
			sizeBonus2 = 22;
			if ((Main.maxTilesX / 2) - 1200 < microSpawnX && (Main.maxTilesX / 2) + 1200 > microSpawnX)
			{
				if (microSpawnX - (Main.maxTilesX / 2) < 0)
					microSpawnX = (Main.maxTilesX / 2) - 1200;
				else
					microSpawnX = (Main.maxTilesX / 2) + 1200;
			}
			int microSpawnY = (int)Main.worldSurface - 50;
			for (int k = 0; k < 0; k++)
			{
				for (int l = 0; l < (int)Main.worldSurface; l += 5)
				{
					if (Main.tile[k, l].active() && Main.tileDungeon[(int)Main.tile[k, l].type])
					{
						break;
					}
				}
			}
			for (int i = 0; i < WorldGen.genRand.Next(810, 901); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-size, size), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 150 + sizeBonus), (double)WorldGen.genRand.Next(30, 91), WorldGen.genRand.Next(40, 101), TileType<Tiles.Microbiome.CellMembrane>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < WorldGen.genRand.Next(90, 121); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-size, size), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 150 + sizeBonus), (double)WorldGen.genRand.Next(20, 31), WorldGen.genRand.Next(30, 41), TileType<Tiles.Microbiome.DiseasedStone>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < WorldGen.genRand.Next(180, 241); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-size, size), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 150 + sizeBonus), (double)WorldGen.genRand.Next(10, 21), WorldGen.genRand.Next(20, 31), TileType<Tiles.Microbiome.DiseasedStone>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < WorldGen.genRand.Next(315, 441); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-size, size), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 150), (double)WorldGen.genRand.Next(5, 11), WorldGen.genRand.Next(10, 21), TileType<Tiles.Microbiome.DiseasedStone>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < WorldGen.genRand.Next(600, 651); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-size, size), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 150), (double)WorldGen.genRand.Next(1, 4), WorldGen.genRand.Next(1, 4), TileType<Tiles.Microbiome.DiseasedStone>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05); i++)
			{
				WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, Main.maxTilesY), (double)WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), TileType<Tiles.Microbiome.TwistedMembraneOre>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < WorldGen.genRand.Next(16, 37); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-size, size), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 10), (double)WorldGen.genRand.Next(1, 4), WorldGen.genRand.Next(1, 4), TileType<Tiles.Microbiome.TwistedMembraneOre>(), false, 0f, 0f, false, true);
			}
			//cell island worldgen
			WorldGen.TileRunner(microSpawnX, (int)Main.worldSurface - 150, 60, 60, TileType<Tiles.Microbiome.CellMembrane>(), true, 0f, 0f, true, true);
			WorldGen.TileRunner(microSpawnX, (int)Main.worldSurface - 150, 30, 30, TileType<Tiles.Microbiome.DiseasedStone>(), true, 0f, 0f, true, true);
			WorldGen.TileRunner(microSpawnX, (int)Main.worldSurface - 150, 15, 15, TileType<Tiles.Microbiome.TwistedMembraneOre>(), true, 0f, 0f, true, true);
			for (int i = 0; i < WorldGen.genRand.Next(20, 41) + sizeBonus2; i++)
			{
				int cellX;
				if (WorldGen.genRand.Next(0, 2) == 0)
				cellX = microSpawnX + WorldGen.genRand.Next(-size, -50);
				else
				cellX = microSpawnX + WorldGen.genRand.Next(50, size);
				int cellY = (int)Main.worldSurface + WorldGen.genRand.Next((-225 - sizeBonus), 60);
				WorldGen.TileRunner(cellX, cellY, WorldGen.genRand.Next(12, 27), WorldGen.genRand.Next(12, 27), TileType<Tiles.Microbiome.CellMembrane>(), true, 0f, 0.4f, true, true);
				WorldGen.TileRunner(cellX, cellY, WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 9), TileType<Tiles.Microbiome.TwistedMembraneOre>(), true, 0f, 0.4f, true, true);
			}
		}
		public override void PostWorldGen() {
			int[] itemsToPlaceInSkywareChests = { ItemType<Items.OtherSwords.Starfrenzy>() };
			int itemsToPlaceInSkywareChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++) {
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 13 * 36 && WorldGen.genRand.Next(3) == 0) {
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) {
						if (chest.item[inventoryIndex].type == ItemID.None) {
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInSkywareChests[itemsToPlaceInSkywareChestsChoice]);
							itemsToPlaceInSkywareChestsChoice = (itemsToPlaceInSkywareChestsChoice + 1) % itemsToPlaceInSkywareChests.Length;
							break;
						}
					}
				}
			}
		}
		public override void ResetNearbyTileEffects()
		{
			ZylonPlayer modPlayer = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			microbiomeTiles = 0;
		}

		public override void TileCountsAvailable(int[] tileCounts)
		{
			microbiomeTiles = tileCounts[TileType<Tiles.Microbiome.CellMembrane>()] + tileCounts[TileType<Tiles.Microbiome.DiseasedStone>()];
		}
	}
}