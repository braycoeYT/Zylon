using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Bosses.Metelord
{
	[AutoloadBossHead]
	internal class MetelordHead : WormHead
	{
		public override int BodyType => ModContent.NPCType<MetelordBody>();
		public override int TailType => ModContent.NPCType<MetelordTail>();
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Metelord");

			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				CustomTexturePath = "Zylon/NPCs/Bosses/Metelord/Metelord_Bestiary",
				Position = new Vector2(40f, 24f),
				PortraitPositionXOverride = 0f,
				PortraitPositionYOverride = 12f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				SpecificallyImmuneTo = new int[] {
					BuffID.Confused,
					BuffID.Slow,
					BuffID.OnFire,
					BuffID.OnFire3,
					BuffID.CursedInferno,
					BuffID.Frostburn,
					BuffID.Frostburn2,
					BuffID.Frozen,
					BuffID.ShadowFlame
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.lifeMax = (int)(2800*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 36;
			NPC.defense = 6;
			NPC.value = 50000;
			NPC.height = 52;
			NPC.width = 52;
			NPC.noGravity = true;
			CanFly = true;
			NPC.boss = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			NPC.lifeMax = (int)((4200 + ((numPlayers - 1) * 1600))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 64;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson,
				new FlavorTextBestiaryInfoElement("The fusion of many meteor heads and tails leads to the birth of a powerful defender of the meteorite.")
			});
		}
		public override void Init() {
			MinSegmentLength = 6;
			MaxSegmentLength = 6;

			CommonWormInit(this);
		}
		internal static void CommonWormInit(Worm worm) {
			worm.MoveSpeed = 14f;
			worm.Acceleration = 0.125f;
		}
		private int attackCounter;
		public override void SendExtraAI(BinaryWriter writer) {
			writer.Write(attackCounter);
		}
		public override void ReceiveExtraAI(BinaryReader reader) {
			attackCounter = reader.ReadInt32();
		}
        public override void AI() {
            NPC.active = false;
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
        public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(4, 6));
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Vertebrae, 1, 1, 3));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.BloodySpiderLeg>(), 1, 2, 6));
			npcLoot.Add(new CommonDrop(ItemID.Ichor, 1, 3, 9));
		}
	}
	internal class MetelordBody : WormBody
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Metelord");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				SpecificallyImmuneTo = new int[] {
					BuffID.Confused,
					BuffID.Slow,
					BuffID.OnFire,
					BuffID.OnFire3,
					BuffID.CursedInferno,
					BuffID.Frostburn,
					BuffID.Frostburn2,
					BuffID.Frozen,
					BuffID.ShadowFlame
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.damage = 32;
			NPC.defense = 57;
			NPC.width = 38;
			NPC.height = 38;
			NPC.noGravity = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			NPC.damage = 60;
		}
		public override void Init() {
			MetelordHead.CommonWormInit(this);
		}
	}

	internal class MetelordTail : WormTail
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Metelord");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				SpecificallyImmuneTo = new int[] {
					BuffID.Confused,
					BuffID.Slow,
					BuffID.OnFire,
					BuffID.OnFire3,
					BuffID.CursedInferno,
					BuffID.Frostburn,
					BuffID.Frostburn2,
					BuffID.Frozen,
					BuffID.ShadowFlame
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerTail);
			NPC.aiStyle = -1;
			NPC.damage = 20;
			NPC.defense = 198;
			NPC.width = 40;
			NPC.height = 40;
			NPC.noGravity = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			NPC.damage = 40;
		}
		public override void Init() {
			MetelordHead.CommonWormInit(this);
		}
	}
}