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

namespace Zylon.NPCs.Minions
{
	public class Spammer : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Spammer");
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 43;
			npc.height = 43;
			npc.damage = 37;
			npc.defense = 25;
			npc.lifeMax = 700;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.knockBackResist = 0f;
			npc.aiStyle = 5;
			npc.noGravity = true;
			npc.noTileCollide = true;
			aiType = NPCID.Probe;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1000;
            npc.damage = 59;
			npc.defense = 35;
        }
	}
}