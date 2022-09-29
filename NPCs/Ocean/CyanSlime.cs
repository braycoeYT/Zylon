using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Ocean
{
	public class CyanSlime : ModNPC
	{
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 2;
        }
        public override void SetDefaults() {
            NPC.width = 32;
			NPC.height = 26;
			NPC.damage = 11;
			NPC.defense = 12;
			NPC.lifeMax = 19;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 12;
			NPC.aiStyle = 1;
			NPC.knockBackResist = 1f;
			AnimationType = 1;
			NPC.alpha = 50;
			NPC.scale = 0.75f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.CyanSlimeBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 35;
			NPC.damage = 25;
			NPC.value = 25;
			NPC.defense = 12;
			if (Main.hardMode) {
				NPC.lifeMax = 191;
				NPC.damage = 89;
				NPC.value = 80;
            }
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
				new FlavorTextBestiaryInfoElement("A water-filled slime that preys on anything that gets too close to the surface of the water.")
			});
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return SpawnCondition.Ocean.Chance * 0.1f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 2, 5, 1));
			npcLoot.Add(ItemDropRule.NormalvsExpert(ItemID.SlimeStaff, 10000, 7500));
			npcLoot.Add(new CommonDrop(ItemID.Coconut, 50, 1, 1, 1).OnFailedRoll(new CommonDrop(ItemID.Banana, 50, 1, 1, 1)).OnFailedRoll(ItemDropRule.OneFromOptionsNotScalingWithLuck(2, ItemID.Coral, ItemID.Starfish, ItemID.Seashell)));
		}
    }
}