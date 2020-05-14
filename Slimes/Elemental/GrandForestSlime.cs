using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Slimes.Elemental
{
	public class GrandForestSlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Grand Forest Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
		
        public override void SetDefaults()
		{
			npc.width = 190;
			npc.height = 130;
			npc.damage = 12;
			npc.defense = 2;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 1;
			animationType = 1;
			npc.npcSlots = 1f;
			npc.alpha = 50;
			if (NPC.downedPlantBoss)
			{
				npc.damage = 297;
				npc.lifeMax = 41000;
				npc.defense = 28;
				npc.value = 20000f;
				npc.aiStyle = 22;
				npc.knockBackResist = 0f;
							npc.buffImmune[20] = true;
				npc.buffImmune[21] = true;
				npc.buffImmune[22] = true;
				npc.buffImmune[23] = true;
				npc.buffImmune[24] = true;
				npc.buffImmune[25] = true;
				npc.buffImmune[30] = true;
				npc.buffImmune[31] = true;
				npc.buffImmune[32] = true;
				npc.buffImmune[33] = true;
				npc.buffImmune[35] = true;
				npc.buffImmune[36] = true;
				npc.buffImmune[37] = true;
				npc.buffImmune[38] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[44] = true;
			npc.buffImmune[46] = true;
			npc.buffImmune[47] = true;
			npc.buffImmune[67] = true;
			npc.buffImmune[68] = true;
			npc.buffImmune[69] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[72] = true;
			npc.buffImmune[80] = true;
			npc.buffImmune[86] = true;
			npc.buffImmune[88] = true;
			npc.buffImmune[94] = true;
			npc.buffImmune[144] = true;
			npc.buffImmune[148] = true;
			npc.buffImmune[149] = true;
			npc.buffImmune[153] = true;
			npc.buffImmune[156] = true;
			npc.buffImmune[160] = true;
			npc.buffImmune[163] = true;
			npc.buffImmune[164] = true;
			npc.buffImmune[169] = true;
			npc.buffImmune[192] = true;
			npc.buffImmune[194] = true;
			npc.buffImmune[195] = true;
			npc.buffImmune[196] = true;
			npc.buffImmune[197] = true;
			npc.buffImmune[199] = true;
			npc.buffImmune[203] = true;
			npc.buffImmune[204] = true;
				npc.noGravity = true;
			    npc.noTileCollide = true;
			}
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 402;
            npc.damage = 29;
			npc.defense = 4;
			if (NPC.downedPlantBoss)
			{
				npc.lifeMax = 52000;
				npc.damage = 398;
				npc.defense = 41;
			}
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.OverworldDaySlime.Chance * 0.01f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), ItemID.Gel, 14 + Main.rand.Next(1));
			if (NPC.downedPlantBoss)
			Item.NewItem(npc.getRect(), mod.ItemType("ElementamaxSludge"), Main.rand.Next(3));
        }
	}
}