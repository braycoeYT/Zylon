using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using System;

namespace Zylon.NPCs.Forest
{
	public class SaplingWarrior : ModNPC
	{
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 5;
        }
        public override void SetDefaults() {
            NPC.width = 36;
			NPC.height = 56;
			NPC.damage = 8;
			NPC.defense = 5;
			NPC.lifeMax = 23;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 50;
			NPC.aiStyle = 3;
			AIType = NPCID.GiantWalkingAntlion;
			NPC.knockBackResist = 0.75f;
			//Banner = NPC.type;
            //BannerItem = ModContent.ItemType<Items.Banners.OrangeSlimeBanner>();
        }

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
			NPC.lifeMax = 46;
			NPC.damage = 16;
			NPC.value = 100;
			NPC.defense = 5;
		}
		int frameID;
		float frameCounter;
        public override void AI() {
			NPC.spriteDirection = NPC.direction;
            frameCounter += Math.Abs(NPC.velocity.X);
			if (frameCounter > 10) {
				frameID++;
				frameCounter = 0;
            }
			NPC.frame.Y = (frameID % 4)*60;
			if (NPC.velocity.X == 0) NPC.frame.Y = 0;
			if (NPC.velocity.Y != 0) NPC.frame.Y = 240;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("A strange creature born from the roots of giant trees, created to protect the forests.")
			});
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (!Main.dayTime) return 0f;
			if ((SpawnCondition.Ocean.Chance + SpawnCondition.OverworldDayDesert.Chance + SpawnCondition.Corruption.Chance + SpawnCondition.Crimson.Chance + SpawnCondition.SurfaceJungle.Chance + SpawnCondition.OverworldDaySnowCritter.Chance) > 0) return 0f;
            return SpawnCondition.OverworldDay.Chance * 0.07f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Wood, 1, 1, 3));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.LivingBranch>(), 1, 1, 2));
			npcLoot.Add(new CommonDrop(ItemID.Acorn, 2, 1));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Bags.BagofFruits>(), 30), new CommonDrop(ModContent.ItemType<Items.Bags.BagofFruits>(), 25)));
		}
    }
}