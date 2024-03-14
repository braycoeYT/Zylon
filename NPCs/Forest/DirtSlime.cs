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
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
        }
        public override void SetDefaults() {
            NPC.width = 32;
			NPC.height = 26;
			NPC.damage = 19;
			NPC.defense = 0;
			NPC.lifeMax = 35;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 0, 15);
			NPC.aiStyle = 1;
			NPC.knockBackResist = 1f;
			AnimationType = 1;
			NPC.alpha = 50;
			NPC.scale = 1.25f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.DirtSlimeBanner>();
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 69;
			NPC.damage = 36;
			NPC.knockBackResist = 0.8f;
			NPC.value = Item.buyPrice(0, 0, 0, 30);
			if (ZylonWorldCheckSystem.downedDirtball) {
				NPC.lifeMax = 98;
				NPC.damage = 48;
				NPC.value = Item.buyPrice(0, 0, 35);
            }
			if (Main.hardMode) {
				NPC.lifeMax = 312;
				NPC.damage = 92;
				NPC.value = Item.buyPrice(0, 0, 60);
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 398;
				NPC.damage = 131;
				NPC.value = Item.buyPrice(0, 0, 70);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.6f;
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
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Food.ChocolateMacaron>(), 75));
			npcLoot.Add(ItemDropRule.ByCondition(new ElemGelCondition(), ModContent.ItemType<Items.Materials.ElementalGoop>(), 2, 1, 3));
		}
    }
}