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
		
		public static int oblivionTiles;
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
				{"downedCell", downedCell}
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
			progress.Message = "Sprinkling your world with Zylonian Charm...";
			for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00002); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY / 2);
				WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(4, 12), WorldGen.genRand.Next(6, 17), TileType<CyanixOre>(), false, 0f, 0f, false, true);
			}
		}
		private void Microbiome(GenerationProgress progress)
		{
			progress.Message = "Microsizing your world...";
			int microSpawnX = Main.maxTilesX - WorldGen.genRand.Next(600, Main.maxTilesX - 600);
			if ((Main.maxTilesX / 2) - 1200 < microSpawnX && (Main.maxTilesX / 2) + 1200 > microSpawnX)
			{
				if (microSpawnX - (Main.maxTilesX / 2) < 0)
					microSpawnX = (Main.maxTilesX / 2) - 1200;
				else
					microSpawnX = (Main.maxTilesX / 2) + 1200;
			}
			int microSpawnY = (int)Main.worldSurface + WorldGen.genRand.Next(-100, -50);
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
			for (int i = 0; i < WorldGen.genRand.Next(270, 301); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-190, 190), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 150), (double)WorldGen.genRand.Next(30, 91), WorldGen.genRand.Next(40, 101), TileType<Tiles.Microbiome.CellMembrane>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < WorldGen.genRand.Next(90, 121); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-190, 190), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 150), (double)WorldGen.genRand.Next(20, 31), WorldGen.genRand.Next(30, 41), TileType<Tiles.Microbiome.DiseasedStone>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < WorldGen.genRand.Next(180, 241); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-190, 190), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 150), (double)WorldGen.genRand.Next(10, 21), WorldGen.genRand.Next(20, 31), TileType<Tiles.Microbiome.DiseasedStone>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < WorldGen.genRand.Next(315, 441); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-190, 190), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 150), (double)WorldGen.genRand.Next(5, 11), WorldGen.genRand.Next(10, 21), TileType<Tiles.Microbiome.DiseasedStone>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < WorldGen.genRand.Next(600, 651); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-190, 190), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 150), (double)WorldGen.genRand.Next(1, 4), WorldGen.genRand.Next(1, 4), TileType<Tiles.Microbiome.DiseasedStone>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05); i++)
			{
				WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, Main.maxTilesY), (double)WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), TileType<Tiles.Microbiome.TwistedMembraneOre>(), false, 0f, 0f, false, true);
			}
			for (int i = 0; i < WorldGen.genRand.Next(16, 37); i++)
			{
				WorldGen.TileRunner(microSpawnX + WorldGen.genRand.Next(-190, 190), WorldGen.genRand.Next((int)Main.worldSurface - 300, (int)Main.rockLayer + 10), (double)WorldGen.genRand.Next(1, 4), WorldGen.genRand.Next(1, 4), TileType<Tiles.Microbiome.TwistedMembraneOre>(), false, 0f, 0f, false, true);
			}

			/*//hole code
			Vector2 holePos;
			int deleteX;
			int deleteY;
			int holeRand = Main.rand.Next(12, 21);
			int holeRand2 = Main.rand.Next(100, (int)Main.rockLayer + 150);
			int holeRand3 = Main.rand.Next(6, 17);
			holePos.X = microSpawnX + Main.rand.Next(-190, 190) - (int)(holeRand / 2);
			holePos.Y = (int)(Main.worldSurface + 125);
			for (int i = 0; i < holeRand3; i++)
			{
				for (deleteX = 0; deleteX < holeRand; deleteX++)
				{
					holePos.X += 1;
					for (deleteY = 0; deleteY < holeRand2; deleteY++)
					{
						holePos.Y += 1;
						Main.tile[(int)holePos.X, (int)holePos.Y].active(false);
					}
				}
			}
			/*for (int i = 0; i < Main.rand.Next(169, 235); i++)
			{
				int CreeperX = microSpawnX + Main.rand.Next(-250, 331);
				int CreeperY = Main.rand.Next((int)Main.worldSurface + 150, (int)Main.rockLayer + 120);
				//if (Main.tile[CreeperX, CreeperY].active() || Main.tile[CreeperX, CreeperY].wall > 0) 
				//{
				WorldGen.TileRunner(CreeperX, CreeperY, WorldGen.genRand.Next(7, 9), WorldGen.genRand.Next(7, 9), TileType<Tiles.Microbiome.DiseasedStone>(), false, 0f, 0f, false, true);
				WorldGen.TileRunner(CreeperX, CreeperY, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), -1, false, 0f, 0f, false, true);
				WorldGen.PlaceTile(CreeperX, CreeperY, TileType<Tiles.Microbiome.ParasiticCreeper>());
				//}
			}*/
			/*int i2 = 0;
				progress.Message = "Microsizing your world...";
				int num = 0;
				while ((double)num < (double)Main.maxTilesX * 0.00045)
				{
					float value = (float)((double)num / ((double)Main.maxTilesX * 0.00045));
					progress.Set(value);
					bool flag2 = false;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					while (!flag2)
					{
						//int num5 = 0;
						flag2 = true;
						int num6 = Main.maxTilesX / 2;
						int num7 = 200;
						if (Main.rand.NextBool())
						{
							num2 = WorldGen.genRand.Next(600, Main.maxTilesX - 320);
						}
						else
						{
							num2 = WorldGen.genRand.Next(320, Main.maxTilesX - 600);
						}
						num3 = num2 - WorldGen.genRand.Next(200) - 100;
						num4 = num2 + WorldGen.genRand.Next(200) + 100;
						if (num3 < 285)
						{
							num3 = 285;
						}
						if (num4 > Main.maxTilesX - 285)
						{
							num4 = Main.maxTilesX - 285;
						}
						if (num2 > num6 - num7 && num2 < num6 + num7)
						{
							flag2 = false;
						}
						if (num3 > num6 - num7 && num3 < num6 + num7)
						{
							flag2 = false;
						}
						if (num4 > num6 - num7 && num4 < num6 + num7)
						{
							flag2 = false;
						}
						if (num2 > WorldGen.UndergroundDesertLocation.X && num2 < WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
						{
							flag2 = false;
						}
						if (num3 > WorldGen.UndergroundDesertLocation.X && num3 < WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
						{
							flag2 = false;
						}
						if (num4 > WorldGen.UndergroundDesertLocation.X && num4 < WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
						{
							flag2 = false;
						}
						for (int k = num3; k < num4; k++)
						{
							for (int l = 0; l < (int)Main.worldSurface; l += 5)
							{
								if (Main.tile[k, l].active() && Main.tileDungeon[(int)Main.tile[k, l].type])
								{
									flag2 = false;
									break;
								}
								if (!flag2)
								{
									break;
								}
							}
						}
					}
					WorldGen.CrimStart(num2, (int)WorldGen.worldSurfaceLow - 10);
					for (int m = num3; m < num4; m++)
					{
						int num8 = (int)WorldGen.worldSurfaceLow;
						while ((double)num8 < Main.worldSurface - 1.0)
						{
							if (Main.tile[m, num8].active())
							{
								int num9 = num8 + WorldGen.genRand.Next(10, 14);
								for (int n = num8; n < num9; n++)
								{
									if ((Main.tile[m, n].type == 59 || Main.tile[m, n].type == 60) && m >= num3 + WorldGen.genRand.Next(5) && m < num4 - WorldGen.genRand.Next(5))
									{
									Main.tile[m, n].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
									}
								}
								break;
							}
							num8++;
						}
					}
					double num10 = Main.worldSurface + 40.0;
					for (int num11 = num3; num11 < num4; num11++)
					{
						num10 += (double)WorldGen.genRand.Next(-2, 3);
						if (num10 < Main.worldSurface + 30.0)
						{
							num10 = Main.worldSurface + 30.0;
						}
						if (num10 > Main.worldSurface + 50.0)
						{
							num10 = Main.worldSurface + 50.0;
						}
						i2 = num11;
						bool flag3 = false;
						int num12 = (int)WorldGen.worldSurfaceLow;
						while ((double)num12 < num10)
						{
							if (Main.tile[i2, num12].active())
							{
								if (Main.tile[i2, num12].type == 53 && i2 >= num3 + WorldGen.genRand.Next(5) && i2 <= num4 - WorldGen.genRand.Next(5))
								{
								Main.tile[i2, num12].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
							}
								if (Main.tile[i2, num12].type == 0 && (double)num12 < Main.worldSurface - 1.0 && !flag3)
								{
								Main.tile[i2, num12].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();//WorldGen.SpreadGrass(i2, num12, 0, 199, true, 0);
							}
								flag3 = true;
								if (Main.tile[i2, num12].type == 1)
								{
									if (i2 >= num3 + WorldGen.genRand.Next(5) && i2 <= num4 - WorldGen.genRand.Next(5))
									{
									Main.tile[i2, num12].type = (ushort)ModContent.TileType<Tiles.Microbiome.DiseasedStone>();
								}
								}
								else if (Main.tile[i2, num12].type == 2)
								{
								Main.tile[i2, num12].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
							}
								else if (Main.tile[i2, num12].type == 161)
								{
								Main.tile[i2, num12].type = (ushort)ModContent.TileType<Tiles.Microbiome.DiseasedStone>();
							}
								else if (Main.tile[i2, num12].type == 396)
								{
								Main.tile[i2, num12].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
							}
								else if (Main.tile[i2, num12].type == 397)
								{
								Main.tile[i2, num12].type = (ushort)ModContent.TileType<Tiles.Microbiome.DiseasedStone>();
							}
							}
							num12++;
						}
					}
					int num13 = WorldGen.genRand.Next(10, 15);
					for (int num14 = 0; num14 < num13; num14++)
					{
						int num15 = 0;
						bool flag4 = false;
						int num16 = 0;
						while (!flag4)
						{
							num15++;
							int num17 = WorldGen.genRand.Next(num3 - num16, num4 + num16);
							int num18 = WorldGen.genRand.Next((int)(Main.worldSurface - (double)(num16 / 2)), (int)(Main.worldSurface + 100.0 + (double)num16));
							if (num15 > 100)
							{
								num16++;
								num15 = 0;
							}
							if (!Main.tile[num17, num18].active())
							{
								while (!Main.tile[num17, num18].active())
								{
									num18++;
								}
								num18--;
							}
							else
							{
								while (Main.tile[num17, num18].active() && (double)num18 > Main.worldSurface)
								{
									num18--;
								}
							}
							if (num16 > 10 || (Main.tile[num17, num18 + 1].active() && Main.tile[num17, num18 + 1].type == 203))
							{
								WorldGen.Place3x2(num17, num18, 26, 1);
								if (Main.tile[num17, num18].type == 26)
								{
									flag4 = true;
								}
							}
							if (num16 > 100)
							{
								flag4 = true;
							}
						}
					}
					num++;
				}
			progress.Message = "Microsizing your world again...";
			int num19 = 0;
			while ((double)num19 < (double)Main.maxTilesX * 0.00045)
			{
				float value2 = (float)((double)num19 / ((double)Main.maxTilesX * 0.00045));
				progress.Set(value2);
				bool flag5 = false;
				int num20 = 0;
				int num21 = 0;
				int num22 = 0;
				while (!flag5)
				{
					int num23 = 0;
					flag5 = true;
					int num24 = Main.maxTilesX / 2;
					int num25 = 200;
					num20 = WorldGen.genRand.Next(320, Main.maxTilesX - 320);
					num21 = num20 - WorldGen.genRand.Next(200) - 100;
					num22 = num20 + WorldGen.genRand.Next(200) + 100;
					if (num21 < 285)
					{
						num21 = 285;
					}
					if (num22 > Main.maxTilesX - 285)
					{
						num22 = Main.maxTilesX - 285;
					}
					if (num20 > num24 - num25 && num20 < num24 + num25)
					{
						flag5 = false;
					}
					if (num21 > num24 - num25 && num21 < num24 + num25)
					{
						flag5 = false;
					}
					if (num22 > num24 - num25 && num22 < num24 + num25)
					{
						flag5 = false;
					}
					if (num20 > WorldGen.UndergroundDesertLocation.X && num20 < WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
					{
						flag5 = false;
					}
					if (num21 > WorldGen.UndergroundDesertLocation.X && num21 < WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
					{
						flag5 = false;
					}
					if (num22 > WorldGen.UndergroundDesertLocation.X && num22 < WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
					{
						flag5 = false;
					}
					for (int num26 = num21; num26 < num22; num26++)
					{
						for (int num27 = 0; num27 < (int)Main.worldSurface; num27 += 5)
						{
							if (Main.tile[num26, num27].active() && Main.tileDungeon[(int)Main.tile[num26, num27].type])
							{
								flag5 = false;
								break;
							}
							if (!flag5)
							{
								break;
							}
						}
					}
				}
				int num28 = 0;
				for (int num29 = num21; num29 < num22; num29++)
				{
					if (num28 > 0)
					{
						num28--;
					}
					if (num29 == num20 || num28 == 0)
					{
						int num30 = (int)WorldGen.worldSurfaceLow;
						while ((double)num30 < Main.worldSurface - 1.0)
						{
							if (Main.tile[num29, num30].active() || Main.tile[num29, num30].wall > 0)
							{
								if (num29 == num20)
								{
									num28 = 20;
									//WorldGen.ChasmRunner(num29, num30, WorldGen.genRand.Next(150) + 150, true);
									WorldGen.PlaceChest(num28, num29, 21, false, 2);
									//break;
								}
								if (WorldGen.genRand.Next(35) == 0 && num28 == 0)
								{
									num28 = 30;
									//bool makeOrb = true;
									//WorldGen.ChasmRunner(num29, num30, WorldGen.genRand.Next(50) + 50, makeOrb);
									WorldGen.PlaceChest(num28, num29, 21, false, 2);
									//break;
								}
								break;
							}
							else
							{
								num30++;
							}
						}
					}
					int num31 = (int)WorldGen.worldSurfaceLow;
					while ((double)num31 < Main.worldSurface - 1.0)
					{
						if (Main.tile[num29, num31].active())
						{
							int num32 = num31 + WorldGen.genRand.Next(20, 28);
							for (int num33 = num31; num33 < num32; num33++)
							{
								if ((Main.tile[num29, num33].type == 59 || Main.tile[num29, num33].type == 60) && num29 >= num21 + WorldGen.genRand.Next(5) && num29 < num22 - WorldGen.genRand.Next(5))
								{
									Main.tile[num29, num33].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
								}
							}
							break;
						}
						num31++;
					}
				}
				double num34 = Main.worldSurface + 40.0;
				for (int num35 = num21; num35 < num22; num35++)
				{
					num34 += (double)WorldGen.genRand.Next(-2, 3);
					if (num34 < Main.worldSurface + 30.0)
					{
						num34 = Main.worldSurface + 30.0;
					}
					if (num34 > Main.worldSurface + 50.0)
					{
						num34 = Main.worldSurface + 50.0;
					}
					i2 = num35;
					bool flag6 = false;
					int num36 = (int)WorldGen.worldSurfaceLow;
					while ((double)num36 < num34)
					{
						if (Main.tile[i2, num36].active())
						{
							if (Main.tile[i2, num36].type == 53 && i2 >= num21 + WorldGen.genRand.Next(5) && i2 <= num22 - WorldGen.genRand.Next(5))
							{
								Main.tile[i2, num36].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
							}
							if (Main.tile[i2, num36].type == 0 && (double)num36 < Main.worldSurface - 1.0 && !flag6)
							{
								Main.tile[i2, num36].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();//WorldGen.SpreadGrass(i2, num36, 0, 23, true, 0);
							}
							flag6 = true;
							if (Main.tile[i2, num36].type == 1 && i2 >= num21 + WorldGen.genRand.Next(5) && i2 <= num22 - WorldGen.genRand.Next(5))
							{
								Main.tile[i2, num36].type = (ushort)ModContent.TileType<Tiles.Microbiome.DiseasedStone>();
							}
							if (Main.tile[i2, num36].type == 2)
							{
								Main.tile[i2, num36].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
							}
							if (Main.tile[i2, num36].type == 161)
							{
								Main.tile[i2, num36].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
							}
							else if (Main.tile[i2, num36].type == 396)
							{
								Main.tile[i2, num36].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
							}
							else if (Main.tile[i2, num36].type == 397)
							{
								Main.tile[i2, num36].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
							}
							if (Main.tile[i2, num36].type == 59)
							{
								Main.tile[i2, num36].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
							}
							if (Main.tile[i2, num36].type == 60)
							{
								Main.tile[i2, num36].type = (ushort)ModContent.TileType<Tiles.Microbiome.CellMembrane>();
							}
						}
						num36++;
					}
				}
				for (int num37 = num21; num37 < num22; num37++)
				{
					for (int num38 = 0; num38 < Main.maxTilesY - 50; num38++)
					{
						if (Main.tile[num37, num38].active() && Main.tile[num37, num38].type == 31)
						{
							int arg_F8E_0 = num37 - 13;
							int num39 = num37 + 13;
							int num40 = num38 - 13;
							int num41 = num38 + 13;
							for (int num42 = arg_F8E_0; num42 < num39; num42++)
							{
								if (num42 > 10 && num42 < Main.maxTilesX - 10)
								{
									for (int num43 = num40; num43 < num41; num43++)
									{
										if (Math.Abs(num42 - num37) + Math.Abs(num43 - num38) < 9 + WorldGen.genRand.Next(11) && WorldGen.genRand.Next(3) != 0 && Main.tile[num42, num43].type != 31)
										{
											Main.tile[num42, num43].active(true);
											Main.tile[num42, num43].type = (ushort)ModContent.TileType<Tiles.Microbiome.DiseasedStone>();
											if (Math.Abs(num42 - num37) <= 1 && Math.Abs(num43 - num38) <= 1)
											{
												Main.tile[num42, num43].active(false);
											}
										}
										if (Main.tile[num42, num43].type != 31 && Math.Abs(num42 - num37) <= 2 + WorldGen.genRand.Next(3) && Math.Abs(num43 - num38) <= 2 + WorldGen.genRand.Next(3))
										{
											Main.tile[num42, num43].active(false);
										}
									}
								}
							}
						}
					}
				}
				num19++;
			}*/
		}

		public override void ResetNearbyTileEffects()
		{
			ZylonPlayer modPlayer = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			oblivionTiles = 0;
			microbiomeTiles = 0;
		}

		public override void TileCountsAvailable(int[] tileCounts)
		{
			oblivionTiles = tileCounts[TileType<ObliviousMatter>()]; //+ tileCounts[TileType<Sand>()];
			microbiomeTiles = tileCounts[TileType<Tiles.Microbiome.CellMembrane>()] + tileCounts[TileType<Tiles.Microbiome.DiseasedStone>()];
		}
	}
}