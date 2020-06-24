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
	public class Cookie : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cookie");
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 20;
			npc.height = 20;
			npc.damage = 29;
			npc.defense = 0;
			npc.lifeMax = 450;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.knockBackResist = 0f;
			npc.aiStyle = 22;
			npc.noGravity = true;
			npc.noTileCollide = true;
			aiType = NPCID.Gastropod;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 750;
            npc.damage = 51;
			npc.defense = 10;
			
			/*if (ZylonWorld.voidDream)
			{
				npc.lifeMax = 600;
				npc.damage = 67;
				npc.aiStyle = 22;
				aiType = NPCID.IchorSticker;
			}*/
        }
	}
}