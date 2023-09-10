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
			// DisplayName.SetDefault("Bone Slime");
			Main.npcFrameCount[NPC.type] = 2;
		}
        public override void SetDefaults() {
			NPC.width = 38;
			NPC.height = 18;
			NPC.damage = 41;
			NPC.defense = 9;
			NPC.lifeMax = 91;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.value = Item.buyPrice(0, 0, 0, 75);
			NPC.aiStyle = 1;
			NPC.knockBackResist = 1f;
			AnimationType = 1;
			NPC.alpha = 50;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.BoneSlimeBanner>();
        }
<<<<<<< HEAD
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.lifeMax = 189;
=======
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 189;
>>>>>>> ProjectClash
            NPC.damage = 71;
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