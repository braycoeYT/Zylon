using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Ocean
{
	public class EerieJellyfish : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[NPC.type] = 2;
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				SpecificallyImmuneTo = new int[] {
					BuffID.Confused
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
		}
        public override void SetDefaults() {
			NPC.width = 30;
			NPC.height = 28;
			NPC.damage = 35;
			NPC.defense = 8;
			NPC.lifeMax = 105;
			NPC.HitSound = SoundID.NPCHit25;
			NPC.DeathSound = SoundID.NPCDeath28;
			NPC.value = Item.sellPrice(0, 0, 1);
			NPC.aiStyle = 18;
			AnimationType = 1;
			NPC.noGravity = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 210;
            NPC.damage = 70;
			NPC.knockBackResist = 0.9f;
        }
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 4; i++) {
				int dustType = ModContent.DustType<Dusts.JellyDust>();
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		int mode;
		int timer;
		public override void AI() {
			if (mode == 0) {
				if (NPC.alpha < 255)
				NPC.alpha += 3;
				else
				timer++;
				if (timer >= 60) {
					mode = 1;
					timer = 0;
				}
			}
			if (mode == 1) {
				if (NPC.alpha > 0)
				NPC.alpha -= 3;
				else
				timer++;
				if (timer >= 60) {
					mode = 0;
					timer = 0;
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (NPC.downedBoss3) return ((SpawnCondition.CaveJellyfish.Chance*2f) + SpawnCondition.OceanMonster.Chance) * 0.625f;
			else return 0f;
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
				new FlavorTextBestiaryInfoElement("A ghastly jellyfish capable of turning invisible temporarily.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Glowstick, 1, 1, 4));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Materials.EerieBell>(), 4, 1, 1, 3), new CommonDrop(ModContent.ItemType<Items.Materials.EerieBell>(), 1)));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.JellyfishNecklace, 100), new CommonDrop(ItemID.JellyfishNecklace, 80)));
		}
	}
}