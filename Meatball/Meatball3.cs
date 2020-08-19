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
	public class Meatball3 : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Meatball");
			Main.npcFrameCount[npc.type] = 8;
		}

        public override void SetDefaults()
		{
			npc.value = 15;
			npc.width = 32;
			npc.height = 32;
			npc.damage = 31;
			npc.defense = 8;
			npc.lifeMax = 54;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.55f;
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
            npc.lifeMax = 109;
            npc.damage = 62;
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
			return 0.06f;
			return 0f;
        }
		public override void NPCLoot()
		{
			if (Main.rand.NextFloat() < .4f)
				Item.NewItem(npc.getRect(), mod.ItemType("MeatShard"), Main.rand.Next(1, 3));
			if (Main.rand.NextFloat() < .08f)
				Item.NewItem(npc.getRect(), mod.ItemType("PlainNoodle"));
			if (Main.rand.NextFloat() < .005f)
				Item.NewItem(npc.getRect(), mod.ItemType("MeatballSpecial"));
		}
	}
}