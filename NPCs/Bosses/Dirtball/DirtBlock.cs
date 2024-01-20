using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.Dirtball
{
	public class DirtBlock : ModNPC
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Dirt Block");
			NPCID.Sets.ImmuneToRegularBuffs[Type] = true;
		}
        public override void SetDefaults() {
			NPC.value = 0;
			NPC.width = 16;
			NPC.height = 16;
			NPC.damage = 10;
			NPC.defense = 0;
			NPC.lifeMax = 1;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.knockBackResist = 0f;
			NPC.aiStyle = 14;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.dontCountMe = true;
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.damage = 20;
        }
		int newVel;
		float fleeRand = Main.rand.NextFloat(-0.75f, 0.75f);
		public override void AI() {
			if (ZylonGlobalNPC.dirtballBoss < 0)
											{
												NPC.active = false;
												NPC.netUpdate = true;
												return;
											}
											if (NPC.CountNPCS(ModContent.NPCType<Dirtball>()) > 0)
											{
												Vector2 vector100 = new Vector2(NPC.Center.X, NPC.Center.Y);
												float num812 = Main.npc[ZylonGlobalNPC.dirtballBoss].Center.X - vector100.X;
												float num813 = Main.npc[ZylonGlobalNPC.dirtballBoss].Center.Y - vector100.Y;
												float num814 = (float)Math.Sqrt((double)(num812 * num812 + num813 * num813));
												if (num814 > 90f)
												{
													num814 = 8f / num814;
													num812 *= num814;
													num813 *= num814;
													NPC.velocity.X = (NPC.velocity.X * 15f + num812) / 16f;
													NPC.velocity.Y = (NPC.velocity.Y * 15f + num813) / 16f;
													return;
												}
												if (Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y) < 8f)
												{
													NPC.velocity.Y = NPC.velocity.Y * 1.05f;
													NPC.velocity.X = NPC.velocity.X * 1.05f;
												}
												if (Main.netMode != NetmodeID.MultiplayerClient && ((Main.expertMode && Main.rand.NextBool(100)) || Main.rand.NextBool(200)))
												{
													NPC.TargetClosest(true);
													vector100 = new Vector2(NPC.Center.X, NPC.Center.Y);
													num812 = Main.player[NPC.target].Center.X - vector100.X;
													num813 = Main.player[NPC.target].Center.Y - vector100.Y;
													num814 = (float)Math.Sqrt((double)(num812 * num812 + num813 * num813));
													num814 = 12f / num814; //8f
													NPC.velocity.X = num812 * num814;
													NPC.velocity.Y = num813 * num814;
													NPC.ai[0] = 1f;
													NPC.netUpdate = true;
													return;
												}
											}
			if (NPC.CountNPCS(ModContent.NPCType<Dirtball>()) < 1) {
				newVel += 1;
				NPC.velocity = new Vector2(0, newVel/10).RotatedBy(fleeRand);
				return;
			}
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("An enchanted dirt block that floats around in an attempt to defend its creator.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.DirtBlock, 1));
		}
	}
}