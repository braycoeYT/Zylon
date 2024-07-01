using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Sky
{
	public class Stratoslime : ModNPC
	{
		public override void SetStaticDefaults()  {
			// DisplayName.SetDefault("Starpack Slime");
			Main.npcFrameCount[NPC.type] = 2;
		}
        public override void SetDefaults() {
			NPC.width = 54;
			NPC.height = 26;
			NPC.damage = 17;
			NPC.defense = 6;
			NPC.lifeMax = 83;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.value = Item.buyPrice(0, 0, 3);
			NPC.aiStyle = 1; //og 14
			NPC.knockBackResist = 0.67f;
			AnimationType = 1;
			//NPC.noGravity = true; //for old ai
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.StratoslimeBanner>();

			NPC.GravityIgnoresSpace = true; //So the enemy doesn't ascend into space if it goes too high. Icarus be gone!
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 176;
			NPC.damage = 34;
			NPC.knockBackResist = 0.5f;
			NPC.value = Item.buyPrice(0, 0, 6);
			if (Main.hardMode) {
				NPC.lifeMax = 319;
				NPC.damage = 83;
				NPC.value = Item.buyPrice(0, 0, 7, 50);
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 402;
				NPC.damage = 101;
				NPC.value = Item.buyPrice(0, 0, 8);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 0.35f;
            }
        }
		int Timer;
		int Timer2;
		int Timer3;
		//int Timer4;
		bool ready;
        public override void PostAI() {
			//Checks if standing still
			/*if (Math.Abs(NPC.velocity.Y) + Math.Abs(NPC.velocity.X) < 0.05f) Timer4++;
			else Timer4 = 0;

			if (Timer4 > 3) { //Don't start flying if sitting still for at least a few frames
				Timer4 = 0;
				Timer2 = 0;
			}*/

			//if (NPC.collideY && Math.Abs(NPC.velocity.X) < 0.01f) Timer -= 5;

			if (NPC.collideY && NPC.velocity.Y > 0) Timer2 = 0; //Best fix I could think of for when they collide with the ground but keep flying anyway - I know almost nothing about npc collision

			Timer++; //Cooldown timer - when above 0, you can fly again

			if (NPC.velocity.Y > 1) Timer2++; //og 1
			else Timer2 = 0; //Timer 2 checks if the slime has fallen for long enough

            if (Timer2 > 40) ready = true; //og 40

			//Ready means it will start flying. It detects if the slime has been falling for long enough.
			if (ready && Timer > 0) {
				if (Main.GameUpdateCount % 5 == 0 && Timer3 < 45) SoundEngine.PlaySound(SoundID.Item13.WithVolumeScale(0.5f), NPC.position);

				//NPC.noGravity = true;
				Timer3++;
				NPC.velocity.Y -= 1.5f;
				if (NPC.velocity.Y < -5f) NPC.velocity.Y = -5f;

				if (Timer3 > 90) {
					Timer3 = 0;
					ready = false;
					Timer = -70; //og -70
				}

				//Dust rocket
				for (int i = 0; i < 2; i++) { //Left
					int dustIndex = Dust.NewDust(NPC.position, 1, 1, 58);
					Dust dust = Main.dust[dustIndex];
					dust.position = NPC.Center + new Vector2(-20+NPC.velocity.X, -4);
					dust.velocity = new Vector2(Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(6f, 9f));
					dust.noGravity = true;
					dust.scale = Main.rand.NextFloat(1.25f, 2f);
				}
				for (int i = 0; i < 2; i++) { //Right
					int dustIndex = Dust.NewDust(NPC.position, 1, 1, 58);
					Dust dust = Main.dust[dustIndex];
					dust.position = NPC.Center + new Vector2(20+NPC.velocity.X, -4);
					dust.velocity = new Vector2(Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(6f, 9f));
					dust.noGravity = true;
					dust.scale = Main.rand.NextFloat(1.25f, 2f);
				}
			}
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
				new FlavorTextBestiaryInfoElement("A heavenly slime that has adapted to the skies by adopting a propulsion device allowing it to fly.")
			});
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Sky.Chance * 0.4f;
        }
	    public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 1, 3));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 1, 2, 3));
			npcLoot.Add(ItemDropRule.ByCondition(new ElemGelCondition(), ModContent.ItemType<Items.Materials.ElementalGoop>(), 2, 1, 3));
		}
	}
}