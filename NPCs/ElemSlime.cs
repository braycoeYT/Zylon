using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs
{
	public class ElemSlime : ModNPC
	{
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 2;
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				ImmuneToAllBuffsThatAreNotWhips = true
			};
			NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
        }
        public override void SetDefaults() {
            NPC.width = 32;
			NPC.height = 26;
			NPC.damage = 45;
			NPC.defense = 20;
			NPC.lifeMax = 519;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 750;
			NPC.aiStyle = 1;
			NPC.knockBackResist = 0.1f;
			//AnimationType = 1;
			NPC.alpha = 50;
			NPC.scale = 1.5f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.ElemSlimeBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 1038;
			NPC.damage = 90;
			NPC.value = 1000;
			NPC.defense = 20;
        }
		public override void HitEffect(int hitDirection, double damage) {
			if (NPC.life > 0) {
				for (int i = 0; i < 2; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.ElemDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
					dust.noGravity = true;
				}
			}
			else for (int i = 0; i < 12; i++) {
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.ElemDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
				dust.noGravity = true;
			}
		}
		int Timer;
		int animationTimer;
        public override void AI() {
            Timer++;
			if (Timer % 10 == 0)
				animationTimer++;
			if (animationTimer > 1)
				animationTimer = 0;
			NPC.frame.Y = animationTimer * 26;
			NPC.spriteDirection = NPC.direction;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("What used to be a common slime has absorbed a piece of elemental goop and become another factory for the creation of more goop.")
			});
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (!NPC.downedPlantBoss) return 0f;
			if (SpawnCondition.OverworldDaySlime.Chance > 0) return 0.075f;
            else return 0.01f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 2, 5));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.ElementalGoop>(), 2));
			npcLoot.Add(ItemDropRule.NormalvsExpert(ItemID.SlimeStaff, 7500, 5000));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Food.GalacticBrownie>(), 25));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Accessories.SlimePendant>(), 125), new CommonDrop(ModContent.ItemType<Items.Accessories.SlimePendant>(), 100)));
		}
    }
}