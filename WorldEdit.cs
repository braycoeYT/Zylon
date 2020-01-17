using Zylon.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);
				WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(7, 15), WorldGen.genRand.Next(13, 22), TileType<CyanixOre>(), false, 0f, 0f, false, true);
			}
		}
	}
}