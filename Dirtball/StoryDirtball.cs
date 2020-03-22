using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Dirtball
{
	public class StoryDirtball: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dirtball Story");
			Tooltip.SetDefault("'It's hilarious to think that this is the prototype of the Desert Discus.\nIt's signals failed only a few light years away from Zylon.\nIt took it a very long time to reach Terraria, but it did a few minutes before the Desert Discus Captain did.\nThe prototype was barely flying around when the landing of the desert discus group blinded it and it fell into mud.\nIt kept on rolling in the mud and looked similar to how it does today.\nLater, at night, it crashed into a few floating eyeballs, while it was adjusting to its new body.\nWithin a few decades, the eyes had joined into a hive mind: the Dirtball.\nMaybe you could find it floating around or use some odd mud to find it?'");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 1;
			item.rare = 12;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.expert = true;
		}
	}
}