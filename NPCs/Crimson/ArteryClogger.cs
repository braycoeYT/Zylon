using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Crimson
{
	internal class ArteryCloggerHead : WormHead
	{
		public override int BodyType => ModContent.NPCType<ArteryCloggerBody>();
		public override int TailType => ModContent.NPCType<ArteryCloggerTail>();
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Artery Clogger");

			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				CustomTexturePath = "Zylon/NPCs/Crimson/ArteryClogger_Bestiary",
				Position = new Vector2(40f, 24f),
				PortraitPositionXOverride = 0f,
				PortraitPositionYOverride = 12f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.lifeMax = 475;
			NPC.damage = 78;
			NPC.defense = 30;
			NPC.value = 1000;
			NPC.height = 106;
			NPC.width = 68;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.ArteryCloggerBanner>();
		}
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
			NPC.lifeMax = 950;
			NPC.damage = 156;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson,
				new FlavorTextBestiaryInfoElement("A massive worm infamous for digging tunnels within the crimson.")
			});
		}
		public override void Init() {
			MinSegmentLength = 21;
			MaxSegmentLength = 26;

			CommonWormInit(this);
		}
		internal static void CommonWormInit(Worm worm) {
			worm.MoveSpeed = 9f;
			worm.Acceleration = 0.075f;
		}
		private int attackCounter;
		public override void SendExtraAI(BinaryWriter writer) {
			writer.Write(attackCounter);
		}
		public override void ReceiveExtraAI(BinaryReader reader) {
			attackCounter = reader.ReadInt32();
		}
        /*public override void AI() {
			if (Main.netMode != NetmodeID.MultiplayerClient) {
				if (attackCounter > 0) {
					attackCounter--;
				}
				Player target = Main.player[NPC.target];
				// If the attack counter is 0, this NPC is less than 12.5 tiles away from its target, and has a path to the target unobstructed by blocks, summon a projectile.
				if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 200 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1)) {
					Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
					direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

					int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 1, ProjectileID.ShadowBeamHostile, 5, 0, Main.myPlayer);
					Main.projectile[projectile].timeLeft = 300;
					attackCounter = 500;
					NPC.netUpdate = true;
				}
			}
		}*/
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo) {
            target.AddBuff(BuffID.Ichor, 60*Main.rand.Next(11, 21));
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (Main.hardMode)
				return SpawnCondition.Crimson.Chance * 0.02f;
			return 0f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Vertebrae, 1, 1, 3));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.BloodySpiderLeg>(), 1, 2, 6));
			npcLoot.Add(new CommonDrop(ItemID.Ichor, 1, 3, 9));
		}
	}

	internal class ArteryCloggerBody : WormBody
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Artery Clogger");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.damage = 47;
			NPC.defense = 32;
			NPC.width = 30;
			NPC.height = 24;
			Banner = Item.NPCtoBanner(ModContent.NPCType<ArteryCloggerHead>());
			BannerItem = Item.BannerToItem(Banner);
		}
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
			NPC.damage = 96;
		}
		public override void Init() {
			ArteryCloggerHead.CommonWormInit(this);
		}
	}

	internal class ArteryCloggerTail : WormTail
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Artery Clogger");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerTail);
			NPC.aiStyle = -1;
			NPC.damage = 46;
			NPC.defense = 37;
			NPC.width = 54;
			NPC.height = 32;
			Banner = Item.NPCtoBanner(ModContent.NPCType<ArteryCloggerHead>());
			BannerItem = Item.BannerToItem(Banner);
		}
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
			NPC.damage = 92;
		}
		public override void Init() {
			ArteryCloggerHead.CommonWormInit(this);
		}
	}
}