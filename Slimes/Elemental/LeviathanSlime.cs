using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Slimes.Elemental
{
	public class LeviathanSlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Leviathan Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
		
        public override void SetDefaults()
		{
			npc.width = 208;
			npc.height = 224;
			npc.damage = 201;
			npc.defense = 37;
			npc.lifeMax = 41000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 20000f;
			npc.aiStyle = 103;
			npc.knockBackResist = 0f;
			animationType = 1;
			npc.npcSlots = 1f;
			npc.alpha = 150;
			npc.scale = 1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			for (int k = 0; k < npc.buffImmune.Length; k++)
			{
				npc.buffImmune[k] = true;
			}
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
			    return SpawnCondition.OceanMonster.Chance * 0.01f;
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
			if (Main.rand.Next(10) == 0)
			NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<OceanTear>(), 0, npc.whoAmI);
		}
	}
}