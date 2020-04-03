using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs
{
	public class FleshyCube : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Fleshy Cube");
		}

        public override void SetDefaults()
		{
			npc.width = 57;
			npc.height = 38;
			npc.damage = 204;
			npc.defense = 44;
			npc.lifeMax = 10000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 12599;
			npc.knockBackResist = 0f;
			npc.aiStyle = 54;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 17000;
            npc.damage = 339;
			npc.defense = 55;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedMoonlord)
			{
			    return SpawnCondition.Crimson.Chance * 0.04f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 0)
	            Item.NewItem(npc.getRect(), mod.ItemType("DankSoul"), 1 + Main.rand.Next(3));
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.rand.Next(10) == 0)
			NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<FleshyCubling>(), 0, npc.whoAmI);
		}
	}
}