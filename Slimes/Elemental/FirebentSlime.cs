using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Slimes.Elemental
{
	public class FirebentSlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Firebent Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
		
        public override void SetDefaults()
		{
			npc.width = 208;
			npc.height = 167;
			npc.damage = 236;
			npc.defense = 26;
			npc.lifeMax = 38000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 20000f;
			npc.aiStyle = 14;
			npc.knockBackResist = 0f;
			animationType = 1;
			npc.npcSlots = 1f;
			npc.alpha = 50;
			npc.noGravity = true;
			npc.noTileCollide = true;
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
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 48000;
            npc.damage = 381;
			npc.defense = 39;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedPlantBoss)
			{
			    return SpawnCondition.Underworld.Chance * 0.017f;
			}
		    return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), ItemID.Gel, 14 + Main.rand.Next(1));
			Item.NewItem(npc.getRect(), mod.ItemType("ElementamaxSludge"), Main.rand.Next(3));
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.rand.Next(25) == 0)
			NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.LavaSlime, 0, npc.whoAmI);
		}
	}
}