using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Projectiles.Bosses.Scavenger;

namespace Zylon.NPCs.Bosses.Scavenger
{
	[AutoloadBossHead]
    public class MatrixScavenger : ModNPC
	{
        public override void SetStaticDefaults() {
			NPCID.Sets.BossBestiaryPriority.Add(Type);
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			Main.npcFrameCount[NPC.type] = 4;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Chilled] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frozen] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Burning] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frostburn] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.CursedInferno] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Shimmer] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Ichor] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Venom] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire3] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Daybreak] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.Shroomed>()] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.LoberaSoulslash>()] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.ElementalDegeneration>()] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.Timestop>()] = true;
		}
        public override void SetDefaults() {
            NPC.width = 130;
			NPC.height = 162;
			NPC.damage = 49;
			NPC.defense = 20;
			NPC.lifeMax = (int)(25000*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = Item.buyPrice(0, 13);
			NPC.aiStyle = -1; //14
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.boss = true;
			NPC.netAlways = true;
			NPC.lavaImmune = true;
			Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/MatrixOverload");
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = (int)(37500*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 83;
			NPC.value = 0;
			if (Main.masterMode) {
				NPC.lifeMax = (int)(50000*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 117;
            }
        }
		Player target;
		bool attackDone;
		int attackTimer; //Increments, but resets each phase change.
		int attackMode; //What "phase" each attack is in.
		int attackInt;
		float attackFloat;
		float attackFloat2;
		int attackDir; //Has a random chance to be -1 or 1, for determining attack directions
		int nextAttack = -1;
		float totalAttackTimer;
		float warpBlitzDir; //Ignore this, it's for one specific attack with special rules.

		int warpTimer; //Start incrementing 30 ticks before the warp actually occurs.
		float warpFloat;
		float warpFloat2;
		bool specialWarp; //Use if you are warping again during an attack

		float hpLeft;
		bool init;
        public override void AI() { //ai0 = attack | ai1 = frame of animation | ai2 = teleport fixer
			if (!init) {
				NPC.ai[0] = -1f;
				nextAttack = GetRandAttack();
				init = true;
			}
			
			NPC.netUpdate = true;
			NPC.TargetClosest(true);
			ZylonGlobalNPC.scavengerBoss = NPC.whoAmI;
			target = Main.player[NPC.target];

			hpLeft = (float)NPC.life/NPC.lifeMax;

			if (Main.dayTime) {
				NPC.damage = (int)(NPC.defDamage * 1.5f);
				hpLeft = 0f;
			}

			NPC.frameCounter++;
			if (NPC.frameCounter % 6 == 0)
				NPC.ai[1]++;
			if (NPC.ai[1] > 3f)
				NPC.ai[1] = 0f;
			NPC.frame.Y = (int)NPC.ai[1] * 162;

			if (attackDone) {
				//First attack, always use quarter dash
				if (nextAttack == -1) NPC.ai[0] = GetRandAttack();
				else NPC.ai[0] = nextAttack;

				nextAttack = GetRandAttack();
				while ((int)NPC.ai[0] == nextAttack) nextAttack = GetRandAttack();

				attackDone = false;
				attackTimer = 0;
				attackMode = 0;
				attackInt = 0;
				attackFloat = 0f;
				attackFloat2 = 0f;
				attackDir = -1;
				if (Main.rand.NextBool(2)) attackDir = 1;

				warpTimer = 0;
				totalAttackTimer = -1;

				specialWarp = false;

				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<ScavengerDespawn>(), 0, 0f);
            }

			if (nextAttack == -1) NPC.ai[0] = -1f;

			//Main.NewText((int)NPC.ai[0] + " | " + nextAttack + " | " + attackTimer);
			totalAttackTimer++;

			switch (NPC.ai[0]) {
				case -1:
					IntroAttack();
					break;
				case 0:
					QuarterDash();
					break;
				case 1:
					BigNumbers();
					break;
				case 2:
					DirectionSlam();
					break;
				case 3:
					WarpBlitz();
					break;
				case 4:

					break;
			}
			if (warpTimer > 0) WarpSetup();

			Main.NewText((int)NPC.ai[0] + " | " + nextAttack + " | " + specialWarp + " | " + warpTimer + " | (" + warpFloat + ", " + warpFloat2  + ")");
		}
		public void WarpBlitz() {
			attackTimer++;
			if (attackTimer == 1) {
				if (attackMode != 0) {
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<ScavengerDespawn>(), 0, 0f);
					warpTimer = 0;
					totalAttackTimer = 0;
				}
				else specialWarp = true;

				attackFloat = target.Center.X;
				attackFloat2 = target.Center.Y;

				NPC.Center = target.Center - new Vector2(0, warpFloat).RotatedBy(warpFloat2);
				NPC.velocity = new Vector2(0, 8).RotatedBy(warpFloat2+MathHelper.PiOver2*warpBlitzDir);
			}
			if (attackTimer % 5 == 0 && Main.netMode != NetmodeID.MultiplayerClient && attackTimer >= 15*hpLeft-3 && attackTimer <= 45-15*hpLeft+3) {
				Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<BigZero2>(), NPC.damage/3, 0f, -1, attackFloat, attackFloat2);
			}
			if (attackTimer >= 15) {
				specialWarp = attackMode < 11;
				warpTimer++;
				if (attackTimer == 45) {
					attackMode++;
					attackTimer = 0;
					if (!specialWarp) attackDone = true;
				}
			}
		}
		public void DirectionSlam() {
			attackTimer++;
			if (attackTimer == 1) {
				if (attackMode != 0) {
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<ScavengerDespawn>(), 0, 0f);
					warpTimer = 0;
					totalAttackTimer = 0;
				}
				else specialWarp = true;
				NPC.Center = target.Center + new Vector2(0, -300).RotatedBy(MathHelper.ToRadians(warpFloat*90)) + target.velocity*10f;
				SoundEngine.PlaySound(SoundID.Item9.WithPitchOffset(-1f));
				if (Main.netMode != NetmodeID.MultiplayerClient) {
					int offset = 2;
					if (warpFloat % 2 == 1) offset = 34; //Boss is taller than wide, so make adequate spacing here.
					bool forceFix = false; //Makes sure it is impossible for there to be a solid wall of several projectiles.
					int max = 291+(int)(30*hpLeft);
					for (int i = 0; i < 5; i++) {
						int rand = Main.rand.Next(150, max);
						if (forceFix) {
							rand = Main.rand.Next(200, max);
							forceFix = false;
						}
						if (rand < 200) forceFix = true;
						offset += rand;
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(offset, 0).RotatedBy(MathHelper.ToRadians(warpFloat*90)), Vector2.Zero, ModContent.ProjectileType<BinaryBlastSlam>(), NPC.damage/3, 0f, -1, warpFloat);
					}
					offset = 2;
					if (warpFloat % 2 == 1) offset = 34; //Boss is taller than wide, so make adequate spacing here.
					forceFix = false;
					for (int i = 0; i < 5; i++) {
						int rand = Main.rand.Next(150, max);
						if (forceFix) {
							rand = Main.rand.Next(200, max);
							forceFix = false;
						}
						if (rand < 200) forceFix = true;
						offset += rand;
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(offset, 0).RotatedBy(MathHelper.ToRadians(warpFloat*90)), Vector2.Zero, ModContent.ProjectileType<BinaryBlastSlam>(), NPC.damage/3, 0f, -1, warpFloat);
					}
				}
				NPC.velocity = new Vector2(0, -8-4*hpLeft).RotatedBy(MathHelper.ToRadians(warpFloat*90));

				//attackFloat = target.Center.Y + 120;
			}
			else {
				if (attackTimer <= 50+30*hpLeft) NPC.velocity += new Vector2(0, 0.55f+0.1f*hpLeft).RotatedBy(MathHelper.ToRadians(warpFloat*90));
				
				if (Math.Abs(NPC.velocity.X) > 12f) NPC.velocity.X = 12f*NPC.velocity.X/Math.Abs(NPC.velocity.X);
				if (Math.Abs(NPC.velocity.Y) > 12f) NPC.velocity.Y = 12f*NPC.velocity.Y/Math.Abs(NPC.velocity.Y);

				if (attackTimer > 50+30*hpLeft) {
					if (attackMode > 3) specialWarp = false;
					warpTimer++;
				}
				if (attackTimer > 80+30*hpLeft) {
					if (!specialWarp) {
						attackDone = true;
					}
					else {
						attackMode++;
						attackTimer = 0;
					}
				}
			}
		}
		public void BigNumbers() {
			attackTimer++;
			if (attackMode == 0) {
				if (attackTimer == 1) { //Reset warp manually.
					if (attackInt != 0) {
						if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<ScavengerDespawn>(), 0, 0f);
						warpTimer = 0;
					}

					int type = ModContent.ProjectileType<BigZero>();
					if (Main.rand.NextBool(2, 3)) type = ModContent.ProjectileType<BigOne>();
					if (Main.netMode != NetmodeID.MultiplayerClient && attackInt != 0) {
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, type, NPC.damage/3, 0f, -1, hpLeft);
					}
					if (attackInt != 0) SoundEngine.PlaySound(SoundID.Item9.WithPitchOffset(-1f));
				}
				NPC.Center = new Vector2(warpFloat, warpFloat2);
				NPC.velocity = Vector2.Zero;

				if (attackTimer > 25+25*hpLeft) {
					attackTimer = 0;
					attackMode = 1;
					specialWarp = true;

					if (attackInt >= 10-6*hpLeft) {
						specialWarp = false;
					}
				}
			}
			else if (attackMode == 1) {
				warpTimer++;
				if (warpTimer >= 30) {
					if (!specialWarp) { //End the attack.
						attackDone = true;
					}
					else { //Reset the attack.
						attackMode = 0;
						attackTimer = 0;
						attackInt++;
					}
				}
			}
		}
		private void QuarterDash() {
			attackTimer++;
			
			if (attackMode == 0) { //wait above player
				NPC.Center = target.Center - new Vector2(0, 360).RotatedBy(warpFloat);
				if (attackTimer > 15) {
					attackMode = 1;
					attackTimer = 0;
				}
			}
			else if (attackMode == 1) { //spin around player
				attackFloat2 += (1f-hpLeft)*0.5f;
				attackInt++;

				NPC.Center = target.Center - new Vector2(0, 360).RotatedBy(warpFloat+MathHelper.ToRadians(attackTimer+attackFloat2)*attackDir);
				if (attackInt > 15+(int)(15*hpLeft)) {
					SoundEngine.PlaySound(SoundID.Item9.WithPitchOffset(-1f));
					Vector2 speed = Vector2.Normalize(NPC.Center - target.Center);
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, speed*-13f, ModContent.ProjectileType<BinaryBlast4x4>(), NPC.damage/4, 0f);
					attackInt = 0;
				}
				if (attackTimer+attackFloat2 > 90f) {
					attackMode = 2;
					attackTimer = 0;
					attackFloat2 = 0f;
				}
			}
			else if (attackMode == 2) { //dash at player
				if (attackTimer == 1) NPC.velocity = Vector2.Normalize(NPC.Center - target.Center)*(-30f+15f*hpLeft);
				NPC.velocity *= 0.95f + 0.03f*hpLeft;
				attackFloat2 += NPC.velocity.Length();
				if (attackFloat2 > 90f) {
					SoundEngine.PlaySound(SoundID.Item9.WithPitchOffset(-1f));
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Normalize(NPC.Center - target.Center)*-0.05f, ModContent.ProjectileType<BinaryBlast4x4Chase>(), NPC.damage/3, 0f, -1, 1.1f);
					attackFloat2 -= 90f;
				}

				if (attackTimer > 75+75*hpLeft) warpTimer++;
				if (attackTimer > 105+75*hpLeft) attackDone = true;
			}
		}
		private void IntroAttack() {
			attackTimer++;
			if (attackTimer >= 30) warpTimer++;
			if (attackTimer >= 60) attackDone = true;
		}
		private int GetRandAttack() {
			return Main.rand.Next(4);
		}
		private void WarpSetup() { //Increment warp to start the teleport animation and to determine the location of the spawn.
			if (warpTimer == 1) {
				float atk = nextAttack;

				if ((nextAttack == 3f && !specialWarp) || specialWarp && NPC.ai[0] == 3f) {
					warpFloat = Main.rand.Next(400, 451); //Offset from center of player
					warpFloat2 = Main.rand.NextFloat(MathHelper.TwoPi); //Angle from player

					warpBlitzDir = 1;
					if (Main.rand.NextBool()) warpBlitzDir = -1;

					//Stop running away...
					if (target.velocity.Length() > 2f) warpFloat2 = target.velocity.ToRotation() + MathHelper.PiOver2 + MathHelper.PiOver4*warpBlitzDir + Main.rand.NextFloat(-MathHelper.PiOver4/2f, MathHelper.PiOver4/2f); //Main.rand.NextFloat(-MathHelper.PiOver4, MathHelper.PiOver4);
				}
				else if ((nextAttack == 2f && !specialWarp) || specialWarp && NPC.ai[0] == 2f) {
					int check = 0;
					if (specialWarp && warpFloat % 2 == 0) check = 1; //Must alternate between horizontal and vertical attacks.
					else if (!specialWarp && Main.rand.NextBool()) check = 1; //On first attack, is very random.
					warpFloat = Main.rand.Next(2)*2+check; //0 = up, 1 = right, 2 = down, 3 = left

					//Prevents running in one direction to cheese the attack. :D
					if (warpFloat % 2 == 0) { //Vertical
						if (target.velocity.Y > 5f) warpFloat = 2;
						else if (target.velocity.Y < -5f) warpFloat = 0;
					}
					if (warpFloat % 2 == 1) { //Horizontal
						if (target.velocity.X > 5f) warpFloat = 1;
						else if (target.velocity.X < -5f) warpFloat = 3;
					}
				}
				else if ((nextAttack == 1f && !specialWarp) || specialWarp && NPC.ai[0] == 1f) {
					int rand1 = 1;
					int rand2 = 1;
					if (Main.rand.NextBool()) rand1 = -1;
					if (Main.rand.NextBool()) rand2 = -1;

					//If player is running away, specifically get in their way
					if (Math.Abs(target.velocity.X) > 3f) {
						rand1 = (int)(target.velocity.X/Math.Abs(target.velocity.X));
						if (Math.Abs(target.velocity.Y) < 0.1f) rand2 = 0; //Nice try.
					}
					if (Math.Abs(target.velocity.Y) > 3f) rand1 = (int)(target.velocity.Y/Math.Abs(target.velocity.Y));

					Vector2 temp = target.Center + target.velocity*40f + new Vector2(Main.rand.Next(160, 321)*rand1, Main.rand.Next(160, 321)*rand2);
					warpFloat = temp.X;
					warpFloat2 = temp.Y;
				}
				else if (nextAttack == 0f && !specialWarp)
					warpFloat = Main.rand.NextFloat(MathHelper.TwoPi); 

				int attackID = nextAttack;
				if (specialWarp) attackID = (int)NPC.ai[0];
				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<ScavengerSpawn>(), 0, 0f, -1, attackID, warpFloat, warpFloat2);
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			Texture2D texture = TextureAssets.Npc[Type].Value;
			
			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			var effects = SpriteEffects.None;
			Vector2 drawOrigin = new Vector2(texture.Width*0.5f, texture.Height*0.1f);

			Vector2 scale = Vector2.One;
			if (warpTimer > 20) {
				scale = new Vector2(1f-((warpTimer-20f)/10f), 1f+((warpTimer-20f)/50f));
			}
			else if (totalAttackTimer < 10) {
				scale = new Vector2(totalAttackTimer/10f, 1.2f-(totalAttackTimer/50f));
			}
			//else if (specialWarp1 || specialWarp2 && attackTimer < 10) {
			//	scale = new Vector2(attackTimer/10f, 1.2f-(attackTimer/50f));
			//}

			spriteBatch.Draw(texture, drawPos, NPC.frame, Color.White, 0f, drawOrigin, scale, effects, 0);
			return false;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				new FlavorTextBestiaryInfoElement("???")
			});
		}
        public override void BossLoot(ref string name, ref int potionType) {
            potionType = ItemID.GreaterHealingPotion;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot) {
			LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
			//npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Trophies.AdenebTrophy>(), 10));

			notExpertRule.OnSuccess(new CommonDrop(ModContent.ItemType<Items.Vanity.BossMask.ScavengerMask>(), 7));
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Bars.DarkronBar>(), 1, 15, 30));
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Materials.SoulofByte>(), 1, 25, 40));

			npcLoot.Add(notExpertRule);

			npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.Bags.ScavengerBag>()));

			//npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Placeables.Relics.AdenebRelic>()));
			//npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<Items.Pets.OldFashionedComputer>(), 4));
		}
    }
}