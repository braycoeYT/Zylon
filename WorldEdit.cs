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
	public class WorldEdit : ModWorld
	{
		public static bool downedDirtball;
		public static bool downedDiscus;
		public static bool downedMineral;
		public static bool generatedEctojewelo;
		public static bool downedComVirus;
		public static bool generatedOblivion;
		public static bool voidDream;
		public static bool downedMeatball;
		public static bool downedMechaball;
		public static bool hasAlertSlime;
		public static bool hasAlertEvil;
		public static bool hasConversationDrop;
		
		public static int oblivionTiles;
		
		public override void Initialize()
		{
			downedDirtball = false;
			downedDiscus = false;
			downedMineral = false;
			generatedEctojewelo = false;
			downedComVirus = false;
			generatedOblivion = false;
			voidDream = false;
			downedMeatball = false;
			downedMechaball = false;
			hasAlertSlime = false;
			hasAlertEvil = false;
			hasConversationDrop = false;
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
				{"voidDream", voidDream},
				{"downedMeatball", downedMeatball},
				{"downedMechaball", downedMechaball},
				{"hasAlertSlime", hasAlertSlime},
				{"hasAlertEvil", hasAlertEvil},
				{"hasConversationDrop", hasConversationDrop}
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
			voidDream = tag.GetBool("voidDream");
			downedMeatball = tag.GetBool("downedMeatball");
			downedMechaball = tag.GetBool("downedMechaball");
			hasAlertSlime = tag.GetBool("hasAlertSlime");
			hasAlertEvil = tag.GetBool("hasAlertEvil");
			hasConversationDrop = tag.GetBool("hasConversationDrop");
        }
		
		 public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte(); //restate every "7"
            flags[0] = downedDirtball;
            flags[1] = downedDiscus;
            flags[2] = downedMineral;
			flags[3] = generatedEctojewelo;
			flags[4] = downedComVirus;
			flags[5] = generatedOblivion;
			flags[6] = voidDream;
			flags[7] = downedMeatball;
            writer.Write(flags);
			
			flags = new BitsByte();
			flags[0] = downedMechaball;
			flags[1] = hasAlertSlime;
			flags[2] = hasAlertEvil;
			flags[3] = hasConversationDrop;
        }
		
		public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte(); //same as above
            downedDirtball = flags[0];
            downedDiscus = flags[1];
            downedMineral = flags[2];
			generatedEctojewelo = flags[3];
			downedComVirus = flags[4];
			generatedOblivion = flags[5];
			voidDream = flags[6];
			downedMeatball = flags[7];
			
			flags = reader.ReadByte();
			downedMechaball = flags[0];
			hasAlertSlime = flags[1];
			hasAlertEvil = flags[2];
			hasConversationDrop = flags[3];
        }
		
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1)
			{
		    tasks.Insert(ShiniesIndex + 1, new PassLegacy("Zylonian Ores", ZylonOres));
			}
		}
		
		public override void PreUpdate()
        {
			if (!generatedEctojewelo && downedMineral)
			{
				for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00007); i++)
                {
                    WorldGen.OreRunner(
                        WorldGen.genRand.Next(0, Main.maxTilesX),
                        WorldGen.genRand.Next(0, Main.maxTilesY),
                        (double)WorldGen.genRand.Next(6, 15),
                        WorldGen.genRand.Next(6, 15),
                        (ushort)mod.TileType("EctojeweloOre")
                    );
                }
				Color messageColor = Color.LightBlue;
					string chat = "The Zylonian Mineral Extrator has blessed your world with Ectojewelo Ore!";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				generatedEctojewelo = true;
			}
			
			if (!hasAlertSlime && NPC.downedPlantBoss)
			{
				Color messageColor = Color.Green;
					string chat = "The Elemental Slimes have been unleashed!";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
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
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
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
		
		public override void ResetNearbyTileEffects()
		{
			PlayerEdit modPlayer = Main.LocalPlayer.GetModPlayer<PlayerEdit>();
			oblivionTiles = 0;
		}

		public override void TileCountsAvailable(int[] tileCounts)
		{
			oblivionTiles = tileCounts[TileType<ObliviousMatter>()]; //+ tileCounts[TileType<Sand>()];

			//Main.sandTiles += tileCounts[TileType<ExampleSand>()];
		}
	}
}