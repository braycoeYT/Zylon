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
	public class Ubercabachon : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ubercabachon");
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 60;
			npc.height = 36;
			npc.damage = 333;
			npc.defense = 60;
			npc.lifeMax = 5670;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.knockBackResist = 0f;
			npc.aiStyle = 63;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 9385;
            npc.damage = 444;
			npc.defense = 90;
        }
	}
}