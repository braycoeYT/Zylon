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
	public class FlameGarnet : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Flame Garnet");
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 40;
			npc.height = 40;
			npc.damage = 215;
			npc.defense = 47;
			npc.lifeMax = 801;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 98;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1432;
            npc.damage = 289;
			npc.defense = 78;
        }
	}
}