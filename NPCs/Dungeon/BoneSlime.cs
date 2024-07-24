using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Dungeon
{
	public class BoneSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[NPC.type] = 2;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
		}
        public override void SetDefaults() {
			NPC.width = 38;
			NPC.height = 18;
			NPC.damage = 41;
			NPC.defense = 9;
			NPC.lifeMax = 91;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 1, 50);
			NPC.aiStyle = 1;
			NPC.knockBackResist = 1f;
			AnimationType = 1;
			NPC.alpha = 50;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.BoneSlimeBanner>();
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 189;
            NPC.damage = 71;
			NPC.knockBackResist = 0.8f;
			NPC.value = Item.buyPrice(0, 0, 3);
			if (Main.hardMode) {
				NPC.lifeMax = 249;
				NPC.damage = 82;
				NPC.value = Item.buyPrice(0, 0, 3, 25);
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 301;
				NPC.damage = 95;
				NPC.value = Item.buyPrice(0, 0, 4);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.6f;
            }
        }
		public override void AI() {
			NPC.spriteDirection = NPC.direction;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon,
				new FlavorTextBestiaryInfoElement("A slime that absorbed one of the many corpses in the dungeon.")
			});
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Dungeon.Chance * 0.1f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 1, 3));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Bone, 1, 0, 3), new CommonDrop(ItemID.Bone, 1, 1, 3)));
			npcLoot.Add(new CommonDrop(ItemID.GoldenKey, 23));
		}
	}
}