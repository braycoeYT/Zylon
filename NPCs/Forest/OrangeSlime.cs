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
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
        }
        public override void SetDefaults() {
            NPC.width = 32;
			NPC.height = 26;
			NPC.damage = 17;
			NPC.defense = 7;
			NPC.lifeMax = 59;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 0, 6);
			NPC.aiStyle = 1;
			NPC.knockBackResist = 0.7f;
			AnimationType = 1;
			NPC.alpha = 50;
			NPC.scale = 1.25f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.OrangeSlimeBanner>();
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 102;
			NPC.damage = 35;
			NPC.knockBackResist = 0.55f;
			NPC.value = Item.buyPrice(0, 0, 0, 13);
			if (Main.hardMode) {
				NPC.lifeMax = 619;
				NPC.damage = 110;
				NPC.value = Item.buyPrice(0, 0, 0, 60);
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 752;
				NPC.damage = 156;
				NPC.value = Item.buyPrice(0, 0, 0, 70);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.4f;
            }
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
				new FlavorTextBestiaryInfoElement("An uncommon slime that is high up on the slime hierarchy.")
			});
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (SpawnCondition.Ocean.Chance > 0 || !NPC.downedSlimeKing) return 0f;
            return (SpawnCondition.OverworldDaySlime.Chance + SpawnCondition.Underground.Chance) * 0.05f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 2, 5));
			npcLoot.Add(ItemDropRule.NormalvsExpert(ItemID.SlimeStaff, 7500, 5000));
			npcLoot.Add(new CommonDrop(ItemID.BloodOrange, 100, 1, 1, 3));
		}
    }
}