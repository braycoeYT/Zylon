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
	public class TheEmbeded : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Embeded");
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 38;
			npc.height = 38;
			npc.damage = 30;
			npc.defense = 4;
			npc.lifeMax = 68;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 10;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 88;
            npc.damage = 42;
			npc.defense = 7;
        }
	}
}