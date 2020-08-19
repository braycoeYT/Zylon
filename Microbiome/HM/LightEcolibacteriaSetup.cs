using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome.HM
{
	public class LightEcolibacteriaSetup : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.width = 1;
			npc.height = 1;
			npc.damage = 0;
			npc.defense = 7765439;
			npc.lifeMax = 1;
			npc.knockBackResist = 0f;
			npc.aiStyle = 0;
			npc.noGravity = true;
			npc.noTileCollide = true;
		}
		int posY2;
		int killNum;
		int rand = Main.rand.Next(4, 7);
		public override void AI()
		{
			if (Main.expertMode)
				rand = Main.rand.Next(3, 9);
			int posY = (int)npc.position.Y - (int)(54 * rand / 2);
			if (!(rand < killNum))
				for (int i = 0; i < rand; i++)
				{
					NPC.NewNPC((int)npc.position.X, (int)posY + posY2, mod.NPCType("Ecolibacteria"));
					posY2 += 54;
					killNum += 1;
				}
			if (rand < killNum)
				npc.life = 0;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode)
				return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome && spawnInfo.player.ZoneSkyHeight ? 0.14f : 0f;
			return 0f;
		}
	}
}