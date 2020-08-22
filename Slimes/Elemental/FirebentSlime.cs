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
			npc.damage = 126;
			npc.defense = 26;
			npc.lifeMax = 8000;
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
			for (int k = 0; k < npc.buffImmune.Length; k++)
			{
				npc.buffImmune[k] = true;
			}
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 16000;
            npc.damage = 201;
			npc.defense = 39;
        }
		
		/*public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedPlantBoss)
			{
			    return SpawnCondition.Underworld.Chance * 0.017f;
			}
		    return 0f;
        }*/
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), ItemID.Gel, 14 + Main.rand.Next(1));
			Item.NewItem(npc.getRect(), mod.ItemType("ElementamaxSludge"), Main.rand.Next(2, 7));
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.rand.Next(25) == 0)
			NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.LavaSlime, 0, npc.whoAmI);
		}
	}
}