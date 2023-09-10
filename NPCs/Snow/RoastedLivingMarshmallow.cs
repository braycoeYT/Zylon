using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Snow
{
	public class RoastedLivingMarshmallow : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[NPC.type] = 2;
		}
        public override void SetDefaults() {
			NPC.width = 26;
			NPC.height = 26;
			NPC.damage = 14;
			NPC.defense = 4;
			NPC.lifeMax = 41;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.value = Item.buyPrice(0, 0, 0, 75);
			NPC.aiStyle = 1;
			NPC.knockBackResist = 0.5f;
			AnimationType = 1;
			NPC.alpha = 50;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.RoastedLivingMarshmallowBanner>();
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 82;
            NPC.damage = 28;
			NPC.knockBackResist = 0.25f;
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
				new FlavorTextBestiaryInfoElement("An enchanted marshmallow after being roasted alive by a fire attack.")
			});
		}
	    public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 1, 3));
			npcLoot.Add(new CommonDrop(ItemID.CookedMarshmallow, 4, 1, 1, 3)).OnFailedRoll(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ModContent.ItemType<Items.Food.CocoaBeans>(), ModContent.ItemType<Items.Food.GrahamCracker>()));
		}
	}
}