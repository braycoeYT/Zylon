using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Slimes
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
			npc.width = 310;
			npc.height = 100;
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
			if (NPC.downedPlantBoss)
			{
				npc.damage = 297;
				npc.lifeMax = 41000;
				npc.defense = 28;
				npc.value = 20000;
				npc.aiStyle = 22;
				npc.knockBackResist = 0f;
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
			Item.NewItem(npc.getRect(), mod.ItemType("ElementamaxSludge"));
        }
	}
}