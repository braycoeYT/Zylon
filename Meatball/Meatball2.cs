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

namespace Zylon.NPCs.Meatball
{
	public class Meatball2 : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Meatball");
			Main.npcFrameCount[npc.type] = 8;
		}

        public override void SetDefaults()
		{
			npc.value = 10;
			npc.width = 24;
			npc.height = 24;
			npc.damage = 20;
			npc.defense = 5;
			npc.lifeMax = 39;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.7f;
			npc.aiStyle = 22;
			npc.noGravity = true;
			npc.noTileCollide = true;
			animationType = NPCID.Drippler;
			aiType = NPCID.Drippler;
			//for (int k = 0; k < npc.buffImmune.Length; k++) {
			//	npc.buffImmune[k] = true;
			//}
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 51;
            npc.damage = 34;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 5);
				dust.noGravity = false;
				dust.scale = 1f;
			}
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 5);
				dust.noGravity = false;
				dust.scale = 1f;
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (Main.bloodMoon && NPC.downedBoss3)
			return 0.07f;
			return 0f;
        }
		public override void NPCLoot()
		{
			if (Main.rand.NextFloat() < .2f)
				Item.NewItem(npc.getRect(), mod.ItemType("MeatShard"), Main.rand.Next(1, 3));
			if (Main.rand.NextFloat() < .05f)
				Item.NewItem(npc.getRect(), mod.ItemType("PlainNoodle"));
			if (Main.rand.NextFloat() < .0025f)
				Item.NewItem(npc.getRect(), mod.ItemType("MeatballSpecial"));
		}
	}
}