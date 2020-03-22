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
		public static bool voidDream;
		
		public override void Initialize()
		{
			downedDirtball = false;
			downedDiscus = false;
			downedMineral = false;
			voidDream = false;
		}
		
		public override TagCompound Save()
        {
            return new TagCompound
            {
                {"downedDirtball", downedDirtball},
                {"downedDiscus", downedDiscus},
                {"downedMineral", downedMineral}
            };
        }
		
        public override void Load(TagCompound tag)
        {
            downedDirtball = tag.GetBool("downedDirtball");
			downedDiscus = tag.GetBool("downedDiscus");
			downedMineral = tag.GetBool("downedMineral");
        }
		
		 public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte(); //restate every "7"
            flags[0] = downedDirtball;
            flags[1] = downedDiscus;
            flags[2] = downedMineral;
            writer.Write(flags);
        }
		
		public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte(); //same as above
            downedDirtball = flags[0];
            downedDiscus = flags[1];
            downedMineral = flags[2];
        }
		
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1)
			{
		    tasks.Insert(ShiniesIndex + 1, new PassLegacy("Zylonian Ores", ZylonOres));
			}
		}
		
		private void ZylonOres(GenerationProgress progress)
		{
			progress.Message = "Sprinkling your world with Zylonian Charm...";
			for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.000061); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY / 2);
				WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(4, 12), WorldGen.genRand.Next(6, 17), TileType<CyanixOre>(), false, 0f, 0f, false, true);
			}
		}
	}
}