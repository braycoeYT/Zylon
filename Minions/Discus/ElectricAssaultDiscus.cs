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

namespace Zylon.NPCs.Minions.Discus
{
	public class ElectricAssaultDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Electric Assault Discus");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 77;
			npc.height = 67;
			npc.damage = 19;
			npc.defense = 0;
			npc.lifeMax = 42;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.knockBackResist = 0.2f;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
			animationType = 82;
        }
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.expertMode)
			{
				target.AddBuff(BuffID.Electrified, 45, false);
			}
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 79;
            npc.damage = 31;
			npc.knockBackResist = 0f;
        }
	}
}