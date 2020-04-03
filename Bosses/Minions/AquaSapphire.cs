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
	public class AquaSapphire : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Aqua Sapphire");
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 40;
			npc.height = 40;
			npc.damage = 155;
			npc.defense = 77;
			npc.lifeMax = 987;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 49;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1876;
            npc.damage = 243;
			npc.defense = 98;
        }
	}
}