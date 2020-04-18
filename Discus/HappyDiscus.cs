using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Discus
{
	public class HappyDiscus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Discus Control Remote");
			Tooltip.SetDefault("'Hacker mode: on'\nMost discuses are friendly");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 81723;
			item.rare = 3;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.npcTypeNoAggro[mod.NPCType("AquamarineTintedDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("CocoaTintedDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("CorruptDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("DesertDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("DungeonDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("IcyDiscus1")] = true;
			player.npcTypeNoAggro[mod.NPCType("IcyDiscus2")] = true;
			player.npcTypeNoAggro[mod.NPCType("MagmaAssaultDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("MushyDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("RainydayDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("RedTintedDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("SpaceScavengerDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("VinefuryDiscus")] = true;
		}
	}
}