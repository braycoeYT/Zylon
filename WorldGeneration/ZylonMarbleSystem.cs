using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace Zylon.WorldGeneration
{
	public class ZylonMarbleSystem : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex((GenPass genpass) => genpass.Name.Equals("Shinies"));
			int HerbsIndex = tasks.FindIndex((GenPass genpass) => genpass.Name.Equals("Herbs"));
			if (ShiniesIndex != -1)
			{
				tasks.Insert(ShiniesIndex + 1, new ZylonZincPass("Zinc Ore", 237.4298f));
				tasks.Insert(ShiniesIndex + 2, new ZylonBloodLeavesPass("Blood Leaves", 237.4298f));
			}
			if (HerbsIndex != -1)
			{
				tasks.Insert(HerbsIndex + 1, new ZylonGloryPlantsPass("Glory Plants", 237.4298f));
			}
		}
	}
}
