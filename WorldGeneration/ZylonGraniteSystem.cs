using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace Zylon.WorldGeneration
{
	public class ZylonGraniteSystem : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
		{
			int JungleTreesIndex = tasks.FindIndex((GenPass genpass) => genpass.Name.Equals("Jungle Trees"));
			int HerbsIndex = tasks.FindIndex((GenPass genpass) => genpass.Name.Equals("Herbs"));
			if (JungleTreesIndex != -1)
			{
				tasks.Insert(JungleTreesIndex + 1, new ZylonGraniteCorePass("Granite Improvements", 237.4298f));
			}
			if (HerbsIndex != -1)
			{
				tasks.Insert(HerbsIndex + 1, new ZylonOnyxPass("Growing Onyx", 237.4298f));
			}
		}
	}
}
