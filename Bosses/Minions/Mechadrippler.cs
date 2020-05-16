using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Bosses.Minions
{
	public class Mechadrippler : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mechadrippler");
			Main.npcFrameCount[npc.type] = 8;
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 30;
			npc.height = 40;
			npc.damage = 90;
			npc.defense = 20;
			npc.lifeMax = 750;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.1f;
			npc.aiStyle = 22;
			npc.noGravity = true;
			npc.noTileCollide = true;
			aiType = NPCID.Gastropod;
			animationType = NPCID.Drippler;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.MartianMadness.Chance * 0.1f;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1000;
            npc.damage = 150;
			npc.defense = 30;
			npc.knockBackResist = 0f;
        }
	}
}