using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.NPCs.Snow
{
	public class BlizzardSeer : ModNPC
	{
        public override void SetDefaults() {
			NPC.width = 28;
			NPC.height = 28;
			NPC.damage = 18;
			NPC.defense = 5;
			NPC.lifeMax = 42;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 1);
			NPC.aiStyle = 2;
			NPC.knockBackResist = 0.9f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.BlizzardSeerBanner>();
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 84;
            NPC.damage = 36;
			if (Main.masterMode) {
				NPC.lifeMax = 126;
				NPC.damage = 54;
            }
        }
		int Timer;
		public override void AI() {
			Timer++;
			NPC.rotation = NPC.velocity.ToRotation();
			if (Timer % 200 == 199) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(5, 0).RotatedBy(NPC.rotation), ProjectileID.FrostBlastHostile, (int)(NPC.damage*0.3f), 0f);
			//NPC.spriteDirection = NPC.direction;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				new FlavorTextBestiaryInfoElement("An ocular creature similar to demon eyes, but more adapted to colder temperatures.")
			});
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (spawnInfo.Player.ZoneSnow && !Main.dayTime) {
				if (Main.raining) return 0.2f;
				return 0.12f;
			}
			return 0f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Lens, 3));
			npcLoot.Add(new CommonDrop(ItemID.BlackLens, 100));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Accessories.GlazedLens>(), 100), new CommonDrop(ModContent.ItemType<Items.Accessories.GlazedLens>(), 90)));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.EnchantedIceCube>(), 1, 1, 2));
		}
	}
}