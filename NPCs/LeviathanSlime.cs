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

namespace Zylon.NPCs
{
	public class LeviathanSlime : ModNPC
	{
        public override void SetDefaults()
		{
			npc.width = 240;
			npc.height = 240;
			npc.damage = 201;
			npc.defense = 37;
			npc.lifeMax = 41000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 20000f;
			npc.aiStyle = 103;
			npc.knockBackResist = 1f;
			animationType = NPCID.GreenSlime;
			npc.npcSlots = 1f;
			npc.alpha = 150;
			npc.scale = 2;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Cursed] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
		    npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Venom] = true;
        }
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Leviathan Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 50000;
            npc.damage = 339;
			npc.defense = 49;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedPlantBoss)
			{
				if (spawnInfo.player.ZoneRockLayerHeight)
				{
			        return SpawnCondition.OceanMonster.Chance * 0.01f;
				}
				return 0f;
			}
		    return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), ItemID.Gel, 14 + Main.rand.Next(1));
			Item.NewItem(npc.getRect(), mod.ItemType("ElementamaxSludge"));
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.rand.Next(10) == 0)
			NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<OceanTear>(), 0, npc.whoAmI);
		}
	}
}