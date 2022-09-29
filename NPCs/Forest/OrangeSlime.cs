using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Forest
{
	public class OrangeSlime : ModNPC
	{
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 2;
        }
        public override void SetDefaults() {
            NPC.width = 32;
			NPC.height = 26;
			NPC.damage = 17;
			NPC.defense = 7;
			NPC.lifeMax = 51;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 25;
			NPC.aiStyle = 1;
			NPC.knockBackResist = 1f;
			AnimationType = 1;
			NPC.alpha = 50;
			NPC.scale = 1.25f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.OrangeSlimeBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 102;
			NPC.damage = 19;
			NPC.value = 50;
			NPC.defense = 7;
			if (Main.hardMode) {
				NPC.lifeMax = 309;
				NPC.damage = 91;
				NPC.value = 120;
            }
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
				new FlavorTextBestiaryInfoElement("An uncommon slime that is pretty high up on the slime hierarchy.")
			});
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (SpawnCondition.Ocean.Chance > 0) return 0f;
            return (SpawnCondition.OverworldDaySlime.Chance + SpawnCondition.Underground.Chance) * 0.05f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 2, 5, 1));
			npcLoot.Add(ItemDropRule.NormalvsExpert(ItemID.SlimeStaff, 7500, 5000));
			npcLoot.Add(new CommonDrop(ItemID.BloodOrange, 100, 1, 1, 3));
		}
    }
}