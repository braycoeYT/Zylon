using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class StoryDiscus : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ancient Desert Discus Story");
			Tooltip.SetDefault("'The Ancient Desert Discus was originally a planet search drone.\nIt spent 12 years running across the cosmos, searching for planets with signs of life with its minions, the other discuses.\nIt found one: Terraria.\nIt began to report back to Zyl that it found a planet with life and was beginning to land.\nIt landed in the harsh desert with its collegues.\nAll of them, including their captain, fell into an antlion cave.\nThey studied the curious creatures inside and soon the leader made a decision.\nIt shut down all of its (and its minions) reporting signals, realizing that this planet was too beautiful to be destroyed.\nIt sat within the desert for years and years.\nIts minions noticed a new creature one day, and they saw that it had the power to destroy the planet.\nThey tried to wake up their boss, but their boss couldn't wake up easily after living most of its lifespan in sleep.\nSo the minions tried to defend their planet, but failed.\nThey weren't built for fighting.\nTheir leader and the remaining discuses in sleep were.\nMaybe something made of its closest friends' motherboards could wake the ancient machine up.'");
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