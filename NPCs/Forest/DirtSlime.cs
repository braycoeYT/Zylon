using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Forest
{
	public class DirtSlime : ModNPC
	{
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 2;
        }
        public override void SetDefaults() {
            NPC.width = 32;
			NPC.height = 26;
			NPC.damage = 19;
			NPC.defense = 0;
			NPC.lifeMax = 35;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 32;
			NPC.aiStyle = 1;
			NPC.knockBackResist = 1f;
			AnimationType = 1;
			NPC.alpha = 50;
			NPC.scale = 1.25f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.DirtSlimeBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.lifeMax = 69;
			NPC.damage = 38;
			NPC.value = 64;
			NPC.defense = 0;
			if (Main.hardMode) {
				NPC.lifeMax = 289;
				NPC.damage = 118;
				NPC.value = 128;
            }
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
				new FlavorTextBestiaryInfoElement("Simply just a slime that rolled into some dirt or mud.")
			});
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (SpawnCondition.Ocean.Chance > 0) return 0f;
            return ((SpawnCondition.OverworldDaySlime.Chance*1.5f) + SpawnCondition.Underground.Chance + (SpawnCondition.Cavern.Chance*0.5f)) * 0.05f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 2, 5, 1));
			npcLoot.Add(new CommonDrop(ItemID.DirtBlock, 1, 2, 5, 1));
			npcLoot.Add(new CommonDrop(ItemID.MudBlock, 1, 2, 5, 1));
			npcLoot.Add(ItemDropRule.NormalvsExpert(ItemID.SlimeStaff, 7500, 5000));
			npcLoot.Add(ItemDropRule.NormalvsExpert(ModContent.ItemType<Items.Food.MudPie>(), 50, 45));
		}
    }
}