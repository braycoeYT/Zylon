using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Minions.Empress
{
	public class RoyalSlimer : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Royal Slimer");
			Main.npcFrameCount[npc.type] = 2;
		}
		
        public override void SetDefaults()
		{
			npc.width = 31;
			npc.height = 44;
			npc.damage = 74;
			npc.defense = 12;
			npc.lifeMax = 865;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.aiStyle = 14;
			animationType = 1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.knockBackResist = 0f;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1725;
            npc.damage = 144;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("RoyalMotherSlime"));
			}
		}
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(4))
			{
				player.AddBuff(163, 300, true);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (ZylonWorld.downedEmpress)
			return SpawnCondition.Sky.Chance * 0.08f;
			return 0f;
        }
	}
}