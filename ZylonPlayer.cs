using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using static Terraria.ModLoader.ModContent;
using Terraria.GameInput;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria.WorldBuilding;

namespace Zylon
{
	public class ZylonPlayer : ModPlayer
	{
		public bool Heartdaze;
		public bool outofBreath;
		public bool shroomed;
		public bool wadofSpores;
		public bool bandofMetal;
		public bool bandofRegen;
		public bool bandofMagicRegen;
		public bool bandofStarpower;
		public bool trueMelee15;
		public bool bloodVial;
		public bool stealthPotion;
		public bool gooeySetBonus;
		public bool brassRing;
		public bool jellyExpert;
		public bool diskbringerSet;
		public bool glazedLens;
		public bool deadlyToxins;
		public bool trueMelee10;
		public bool dirtballExpert;
		public bool dirtRegalia;
		public bool elemDegen;
		public bool nightmareCatcher;
		public bool shadowflameMagic;
		public bool metelordExpert;
		public bool CHECK_SharkToothNecklace;
		public bool CHECK_SaberTooth;
		public bool discoCanister;
		public bool hexNecklace;
		public bool shivercrown;
		public bool bloodContract;
		public bool CHECK_Balloon;
		public bool rootGuard;
		public bool leafBracer;
		public bool leafBracerTempBool;
		public bool friendshipBracelet;
		public bool CHECK_FleshKnuckles;
		public bool glassArmor;
		public bool bigOlBouquet;
		public bool searedFlame;
		public bool neutronHood;
		public bool neutronJacket;
		public bool neutronTracers;
		public bool runeofMultiplicity;
		public bool sparkingCore;
		public bool doublePluggedCord;
		public bool dirtballExpertVanity;
		public bool golemEyeEffect;
		public bool slimePrinceArmor;
		public bool harpysCrest;
		public bool slimePendant;
		public bool livingWoodSetBonus;
		public bool sunFlower;
		public bool continuumWarper;
		public bool illusoryBulletPolish;
		public bool theRegurgitator;
		public bool maraudersKit;
		public bool ammoSling;
		public bool roundmastersKit;
		public bool succulentSap;
		public bool CHECK_ManaBlossom;
		public bool ultimaBand;
		public bool CHECK_SlimyShell;
		public bool CHECK_MysticComet;
		public bool etherealGasp;
		public bool fixCooldownIgnore;
		public bool vengefulSpirit;
		public bool shadowsWink;
		public bool sorcerersKunai;
		public bool shadeCharm;
		public bool tribalCharm;
		public bool CHECK_PygmyNecklace;
		public bool fantesseract;
		public bool blackBox;
		public bool ectoburn;
		public bool CHECK_BandofRegen;
		public bool dishonored;
		public bool sharpKey;
		public bool loadedDie;
		public bool snakeEye;
		public bool cosmicDie;
		public bool bloodContractVisual;
		public bool bloodrain;
		public bool royalArgentumChestpiece;
		public bool argentumSetBonus;
		public bool argentumHeadgear;
		public bool coreofMending;
		public bool accursedHand;
		public bool hitmansCharm;
		public bool aimBot;
		public bool darkAbsolution;
		public bool darkronSetBonus;
		public bool codebreaker;

		public float critExtraDmg;
		public int critCount;
		public int blowpipeMaxInc; //Increases max blowpipe charge.
		public float blowpipeChargeInc; //Increases blowpipe charge rate. 30x/s.
		public float blowpipeChargeMult; //Multiplies the blowpipe charge rate BEFORE adding the above.
		public int blowpipeChargeDamageAdd; //Increases max charge damage by a set amount.
		public int blowpipeChargeKnockbackAdd; //Increases max charge knockback by a set amount.
		public int blowpipeChargeShootSpeedAdd; //Increases max charge shoot speed by a set amount.
		public float blowpipeChargeDamageMult; //Multiplies the added max charge damage.
		public float blowpipeChargeKnockbackMult; //Multiplies the added max charge knockback.
		public float blowpipeChargeShootSpeedMult; //Multiplies the added max charge shoot speed.
		public float blowpipeChargeRetain; //What percentage of charge is retained after shooting.
		//public float blowpipeMaxOverflow; //REMOVED: Better to fix this with higher max charges. How far blowpipes can charge over the default max. Default is 150%, or 1.5f.
		public float blowpipeMinShootSpeed; //Minimum shoot speed for blowpipes.
		/*public bool blowpipeShowUI;
		public int blowpipeMinCharge;
		public int blowpipeCharge;*/
		public int hitTimer30;
		public int sojDamageCount;
		public int sojCooldown;
		public float metecoreFloat = 1f;
		public int excalipoorPower = 1;
		public int emeraldWhipNum;
		public int harpysCrestCooldown;
		public int livingWhipNum;
		public int livingWhipTimer;
		public int numof10ammo;
		public int slimebenderDamage;
		public int slimebenderCore;
		public int potionFatigue;
		public int coreofMendingCounter;
		public int nonCritCounter;
		public int codebreakerGlitch;
		public float summonCrit;
		public float summonCritBoost;
		public float damageVariation;
		public bool scaryText;
		public bool scaryText2;
		public bool summonCritHappen;
		public override void ResetEffects() {
			Heartdaze = false;
			outofBreath = false;
			shroomed = false;
			wadofSpores = false;
			bandofMetal = false;
			bandofRegen = false;
			bandofMagicRegen = false;
			bandofStarpower = false;
			trueMelee15 = false;
			bloodVial = false;
			stealthPotion = false;
			gooeySetBonus = false;
			brassRing = false;
			jellyExpert = false;
			diskbringerSet = false;
			glazedLens = false;
			deadlyToxins = false;
			trueMelee10 = false;
			dirtballExpert = false;
			dirtRegalia = false;
			elemDegen = false;
			nightmareCatcher = false;
			shadowflameMagic = false;
			metelordExpert = false;
			CHECK_SharkToothNecklace = false;
			CHECK_SaberTooth = false;
			discoCanister = false;
			hexNecklace = false;
			shivercrown = false;
			bloodContract = false;
			CHECK_Balloon = false;
			rootGuard = false;
			leafBracer = false;
			friendshipBracelet = false;
			CHECK_FleshKnuckles = false;
			glassArmor = false;
			bigOlBouquet = false;
			searedFlame = false;
			neutronHood = false;
			neutronJacket = false;
			neutronTracers = false;
			runeofMultiplicity = false;
			sparkingCore = false;
			doublePluggedCord = false;
			dirtballExpertVanity = false;
			golemEyeEffect = false;
			slimePrinceArmor = false;
			harpysCrest = false;
			slimePendant = false;
			livingWoodSetBonus = false;
			sunFlower = false;
			continuumWarper = false;
			illusoryBulletPolish = false;
			theRegurgitator = false;
			maraudersKit = false;
			ammoSling = false;
			roundmastersKit = false;
			succulentSap = false;
			CHECK_ManaBlossom = false;
			ultimaBand = false;
			CHECK_SlimyShell = false;
			CHECK_MysticComet = false;
			etherealGasp = false;
			vengefulSpirit = false;
			shadowsWink = false;
			sorcerersKunai = false;
			shadeCharm = false;
			tribalCharm = false;
			CHECK_PygmyNecklace = false;
			fantesseract = false;
			blackBox = false;
			ectoburn = false;
			CHECK_BandofRegen = false;
			dishonored = false;
			sharpKey = false;
			loadedDie = false;
			snakeEye = false;
			cosmicDie = false;
			bloodrain = false;
			argentumSetBonus = false;
			royalArgentumChestpiece = false;
			argentumHeadgear = false;
			coreofMending = false;
			accursedHand = false;
			hitmansCharm = false;
			aimBot = false;
			darkAbsolution = false;
			darkronSetBonus = false;
			codebreaker = false;

			blowpipeMaxInc = 0;
			blowpipeChargeInc = 0;
			blowpipeChargeMult = 1f;
			blowpipeChargeDamageAdd = 0;
			blowpipeChargeKnockbackAdd = 0;
			blowpipeChargeShootSpeedAdd = 0;
			blowpipeChargeDamageMult = 1f;
			blowpipeChargeKnockbackMult = 1f;
			blowpipeChargeShootSpeedMult = 1f;
			blowpipeChargeRetain = 0f;
			//blowpipeMaxOverflow = 1.5f;
			blowpipeMinShootSpeed = 0f;

			critExtraDmg = 0f;
			summonCrit = 0f;
			summonCritBoost = 0f;
			numof10ammo = 0;
			damageVariation = 1f;
			potionFatigue = 0;
		}
		public override void UpdateDead() {
			Heartdaze = false;
			outofBreath = false;
			shroomed = false;
			deadlyToxins = false;
			elemDegen = false;
			searedFlame = false;
			ectoburn = false;
			darkAbsolution = false;
			fixCooldownIgnore = false;
			hitTimer30 = 0;
			sojDamageCount = 0;
			sojCooldown = 0;
			metecoreFloat = 1f;
			emeraldWhipNum = 0;
			harpysCrestCooldown = 0;
			livingWhipNum = 0;
			livingWhipTimer = 0;
			slimebenderDamage = 0;
			slimebenderCore = 0;
			nonCritCounter = 0;
			codebreakerGlitch = 0;
		}
		public override void UpdateBadLifeRegen() {
			//Update timers here, I guess.
			if (emeraldWhipNum > 0) {
				emeraldWhipNum--;
			}
			if (harpysCrestCooldown > 0) {
				harpysCrestCooldown--;
				if (harpysCrestCooldown % 60 == 0 && harpysCrestCooldown != 0) {
					float distanceFromTarget = 100f;
					Vector2 targetCenter = Player.position;
					bool foundTarget = false;

					if (!foundTarget) {
						for (int i = 0; i < Main.maxNPCs; i++) {
							NPC npc = Main.npc[i];
							
							if (npc.CanBeChasedBy()) {
								float between = Vector2.Distance(npc.Center, Player.Center);
								bool closest = Vector2.Distance(Player.Center, targetCenter) > between;
								bool inRange = between < distanceFromTarget;
								bool lineOfSight = Collision.CanHitLine(Player.position, Player.width, Player.height, npc.position, npc.width, npc.height);
								bool closeThroughWall = false; //between < 100f;
							
								if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
									distanceFromTarget = between;
									targetCenter = npc.Center;
									foundTarget = true;
								}
							}
						}
					}
					Vector2 projDir = Vector2.Normalize(targetCenter - Player.Center) * 13f;
					if (!foundTarget) projDir = Vector2.Normalize(targetCenter - Main.MouseWorld) * 13f;
					Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, projDir, ModContent.ProjectileType<Projectiles.Accessories.HarpysCrestProj>(), 20, 5f, Main.myPlayer);
				}
			}

			if (Heartdaze) {
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 20;
			}
			if (outofBreath) {
				if (Player.lifeRegen > 0) {
					Player.lifeRegen = 0;
				}
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 12;
			}
			if (shroomed) {
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 4;
			}
			if (deadlyToxins) {
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 20;
			}
			if (elemDegen) {
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 16;
			}
			if (searedFlame) {
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 40;
			}
			if (ectoburn) {
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 28;
			}
			if (darkAbsolution) {
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 30;
			}
			hitTimer30 -= 1;
			sojCooldown -= 1;

			if (succulentSap) {
				for (int i = 0; i < Player.MaxBuffs; i++) {
					if (Player.buffType[i] == BuffID.ManaSickness && Player.buffTime[i] > 1)
						Player.buffTime[i]--;
				}
			}

			if (royalArgentumChestpiece) {
				if (Player.lifeRegen < 0) {
					Player.lifeRegen = (int)(Player.lifeRegen*0.8f);

					//Do not modify Darkron armor set bonus.
					if (Player.HasBuff(BuffType<Buffs.Armor.DarkAbsolution>())) Player.lifeRegen -= 6;
				}
			}

			if (WorldGen.currentWorldSeed == null) return;
			if (WorldGen.currentWorldSeed.ToLower() == "abyssworld" || WorldGen.currentWorldSeed.ToLower() == "flopside pit") { //Double debuff power in Abyssworld seed
				if (Player.lifeRegen < 0) {
					Player.lifeRegen *= 2;

					//Do not modify Darkron armor set bonus.
					if (Player.HasBuff(BuffType<Buffs.Armor.DarkAbsolution>())) Player.lifeRegen += 30;
				}
			}
		}
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath) {
			String name = Player.name.ToLower();
            if (name == "braycoe" || name == "zylontest" || name == "narcissism") {
				return [
					new Item(ItemType<Items.Vanity.Dev.BraycoeHead>()),
					new Item(ItemType<Items.Vanity.Dev.BraycoeBody>()),
					new Item(ItemType<Items.Vanity.Dev.BraycoeLegs>()),
					new Item(ItemType<Items.LightPets.MysticFurball>())
				];
			}
			return Enumerable.Empty<Item>();
        }
        public override bool CanConsumeAmmo(Item weapon, Item ammo) {
			if (neutronJacket && Main.rand.NextFloat() < .15f) return false;
			if (continuumWarper && Main.rand.NextFloat() < .85f) return false;
			if (illusoryBulletPolish && Main.rand.NextFloat() < .2f && (weapon.useAmmo == AmmoID.Bullet || weapon.useAmmo == ItemType<Items.Ammo.AdeniteShrapnel>())) return false;
			if (theRegurgitator && Main.rand.NextFloat() < .2f && weapon.useAmmo == AmmoID.Dart) return false;
			if (maraudersKit && Main.rand.NextFloat() < .1f) return false;
			if (ammoSling && Main.rand.NextFloat() < .25f) return false;
			if (roundmastersKit && Main.rand.NextFloat() < .4f) return false;
			if (argentumHeadgear && argentumSetBonus && Main.rand.NextFloat() < .25f) return false;
			for (int i = 0; i < numof10ammo; i++) {
				if (Main.rand.NextFloat() < .1f) return false;
			}
            return true;
        }
        public override void UpdateEquips() {
            if (GetInstance<ZylonConfig>().bandBuffs) {
				if (bandofRegen && Player.HasBuff(BuffID.Regeneration))
					Player.lifeRegen += 1;
				if (bandofStarpower && Player.HasBuff(BuffID.MagicPower))
					Player.GetDamage(DamageClass.Magic) += 0.05f;
				if (bandofMagicRegen && Player.HasBuff(BuffID.ManaRegeneration))
					Player.manaRegen += 1;
				if (bandofMetal && Player.HasBuff(BuffID.Ironskin))
					Player.statDefense += 4;
				if (brassRing && Player.HasBuff(BuffID.Swiftness)) {
					if (Player.accRunSpeed > 0)
						Player.accRunSpeed += 0.75f;
					Player.moveSpeed += 0.15f;
                }
            }
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
				if (Player.HasBuff(BuffID.MagicPower)) {
					Player.GetDamage(DamageClass.Magic) -= 0.15f*Player.statLife/Player.statLifeMax2;
					Player.GetDamage(DamageClass.MagicSummonHybrid) -= 0.15f*Player.statLife/Player.statLifeMax2;
					Player.manaRegen -= 2;
                }
				if (Player.HasBuff(BuffID.WellFed)) {
					blowpipeMaxInc += 10;
					blowpipeChargeInc += 0.1f;
                }
				if (Player.HasBuff(BuffID.WellFed2)) {
					blowpipeMaxInc += 20;
					blowpipeChargeInc += 0.2f;
                }
				if (Player.HasBuff(BuffID.WellFed3)) {
					blowpipeMaxInc += 40;
					blowpipeChargeInc += 0.3f;
                }
            }
			if (Player.npcTypeNoAggro[NPCID.MotherSlime]) {
				Player.npcTypeNoAggro[NPCType<NPCs.Dungeon.BoneSlime>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Forest.DirtSlime>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Forest.MechanicalSlime>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Sky.Stratoslime>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Snow.LivingMarshmallow>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Snow.RoastedLivingMarshmallow>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.ElemSlime>()] = true;
            }
			if (leafBracer) {
				if (!Player.HasBuff(BuffID.PotionSickness) && !leafBracerTempBool) leafBracerTempBool = true;
				if (Player.HasBuff(BuffID.PotionSickness) && leafBracerTempBool) {
					Player.AddBuff(BuffType<Buffs.Accessories.LeafBracer>(), 120);
					leafBracerTempBool = false;
                }
            }
			Player.statDefense += livingWhipNum; //The number of active living whip spirits.

			//if (Player.HeldItem.type == ItemType<Items.Accessories.EnchantedPocketwatch>()) Player.moveSpeed += 0.15f;
			//if (Player.HeldItem.type == ItemType<Items.Accessories.Timekeeper>()) { Player.moveSpeed += 0.33f; Player.wingTimeMax += 90; }

			if (Player.HeldItem.type != ItemType<Items.Swords.Slimebender>()) { slimebenderCore = 0; slimebenderDamage = 0; } //Resets Slimebender if not currently held.
        }
		float trueMeleeBoost;
		public override void ModifyHitNPCWithItem(Item item, NPC target, ref NPC.HitModifiers modifiers)/* tModPorter If you don't need the Item, consider using ModifyHitNPC instead */
		{
			trueMeleeBoost = 1f;
			if (trueMelee10) trueMeleeBoost += 0.1f;
			if (trueMelee15) trueMeleeBoost += 0.15f;
			if (neutronHood) trueMeleeBoost += 0.18f;
			modifiers.SourceDamage *= trueMeleeBoost;

			modifiers.CritDamage += critExtraDmg;

			if (!cosmicDie) modifiers.DamageVariationScale *= damageVariation;
			if ((item.DamageType == DamageClass.Summon || item.DamageType == DamageClass.SummonMeleeSpeed) && Main.rand.NextFloat() < summonCrit) {
				modifiers.SetCrit(); //In case some mentally insane mod does this
				summonCritHappen = true;
			}

			if (fantesseract) {
				if (!cosmicDie) modifiers.DamageVariationScale *= 2f;
				if (Main.rand.NextBool(10)) modifiers.Defense += 0.25f;
				modifiers.ScalingArmorPenetration += 0.25f;

				if (Main.rand.NextBool(25)) {
					modifiers.HideCombatText();
					modifiers.FinalDamage *= 4f;
					scaryText = true;
				}
				if (Main.rand.NextBool(25)) {
					modifiers.FinalDamage *= 0f;
					scaryText2 = true;
				}
			}

			if (sharpKey && !cosmicDie) modifiers.DamageVariationScale *= 0f;

			if (cosmicDie) modifiers.DamageVariationScale *= GetInstance<ZylonConfig>().cosmicDieVariation/15f*100f;

			if (bloodContract && Main.rand.NextBool(20)) {
				modifiers.FinalDamage *= 1.5f;
				bloodContractVisual = true;
			}

			if (potionFatigue > 5) {
				float loss = 1f - (potionFatigue-5)/10f;
				if (loss < 0f) loss = 0f;

				modifiers.FinalDamage *= loss;
			}

			if (nonCritCounter > 5 && hitmansCharm) modifiers.SetCrit();
		}
		public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)/* tModPorter If you don't need the Projectile, consider using ModifyHitNPC instead */
		{
			modifiers.CritDamage += critExtraDmg;

			if (!cosmicDie) modifiers.DamageVariationScale *= damageVariation;
			if ((proj.DamageType == DamageClass.Summon || proj.DamageType == DamageClass.SummonMeleeSpeed) && Main.rand.NextFloat() < summonCrit) {
				modifiers.SetCrit();
				summonCritHappen = true;
			}

			if (fantesseract) {
				if (!cosmicDie) modifiers.DamageVariationScale *= 2f;
				if (Main.rand.NextBool(10)) modifiers.Defense += 0.25f;
				modifiers.ScalingArmorPenetration += 0.25f;

				if (Main.rand.NextBool(25)) {
					modifiers.HideCombatText();
					modifiers.FinalDamage *= 4f;
					scaryText = true;
				}
				if (Main.rand.NextBool(25)) {
					modifiers.FinalDamage *= 0f;
					scaryText2 = true;
				}
			}

			if (sharpKey && !cosmicDie) modifiers.DamageVariationScale *= 0f;

			if (cosmicDie) modifiers.DamageVariationScale *= GetInstance<ZylonConfig>().cosmicDieVariation/15f*100f;

			if (bloodContract && Main.rand.NextBool(20)) {
				modifiers.FinalDamage *= 1.5f;
				bloodContractVisual = true;
			}

			if (potionFatigue > 5) {
				float loss = 1f - (potionFatigue-5)/10f;
				if (loss < 0f) loss = 0f;

				modifiers.FinalDamage *= loss;
			}

			if (nonCritCounter > 5 && hitmansCharm) modifiers.SetCrit();
		}
		public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
		{
			OnHitNPCGlobal(item, null, target, damageDone, hit.Knockback, hit.Crit, target.type == NPCID.TargetDummy, true);
			if (scaryText) { CombatText.NewText(target.getRect(), new Color(127, 127, 127), damageDone); scaryText = false; }
			if (scaryText2) { CombatText.NewText(target.getRect(), new Color(0, 0, 0), damageDone); scaryText2 = false; }

			if (bloodContractVisual) {
				float minKnockback = 2f;
				if (hit.Knockback > minKnockback) minKnockback = hit.Knockback;
				for (int i = 0; i < 4; i++) {
					int dustIndex = Dust.NewDust(target.position, target.width, target.height, DustID.Blood);
					Dust dust = Main.dust[dustIndex];
					dust.velocity = new Vector2(Main.rand.NextFloat(1.5f, 3f)*hit.HitDirection*minKnockback, Main.rand.NextFloat(-2f, -6f));
					dust.scale *= 3f + Main.rand.Next(-30, 31) * 0.01f;
				}
				bloodContractVisual = false;
			}
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
		{
			OnHitNPCGlobal(null, proj, target, damageDone, hit.Knockback, hit.Crit, target.type == NPCID.TargetDummy, false);
			if (scaryText) { CombatText.NewText(target.getRect(), new Color(127, 127, 127), damageDone); scaryText = false; }
			if (scaryText2) { CombatText.NewText(target.getRect(), new Color(0, 0, 0), damageDone); scaryText2 = false; }

			if (bloodContractVisual) {
				float minKnockback = 2f;
				if (hit.Knockback > minKnockback) minKnockback = hit.Knockback;
				for (int i = 0; i < 4; i++) {
					int dustIndex = Dust.NewDust(target.position, target.width, target.height, DustID.Blood);
					Dust dust = Main.dust[dustIndex];
					dust.velocity = new Vector2(Main.rand.NextFloat(1.5f, 3f)*hit.HitDirection*minKnockback, Main.rand.NextFloat(-2f, -6f));
					dust.scale *= 3f + Main.rand.Next(-30, 31) * 0.01f;
				}
				bloodContractVisual = false;
			}
			if (bloodrain && proj.DamageType == DamageClass.Summon) {
				Player.Heal(1);
			}
		}
		public void OnHitNPCGlobal(Item item, Projectile proj, NPC target, int damage, float knockback, bool crit, bool isDummy, bool TrueMelee) {
			if (summonCritHappen) { //I have to do this for some reason
				crit = true;
				summonCritHappen = false;
			}
			hitTimer30 = 1800;
			if (proj != null)
			{
				if (proj.type == ProjectileType<Projectiles.Spears.SpearofJustice>() && sojCooldown < 1 && Player.whoAmI == Main.myPlayer)
				{
					sojDamageCount += damage;
					sojCooldown = 6;
					if (sojDamageCount > 749)
					{
						CombatText.NewText(Player.getRect(), Color.Cyan, "MAX!");
						sojDamageCount = 0;
						for (int x = 0; x < 3; x++)
						{
							Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Spears.SpearofJusticeClone>(), 65, 4f, Main.myPlayer, x);
						}
					}
					else CombatText.NewText(Player.getRect(), Color.Cyan, sojDamageCount);
				}
				if (Main.rand.NextBool(10) && !proj.minion && proj.DamageType == DamageClass.SummonMeleeSpeed) {
					if (vengefulSpirit) {
						int buffID = 0;
						switch (Main.rand.Next(4)) {
							case 0:
								buffID = BuffID.OnFire;
								break;
							case 1:
								buffID = BuffID.Poisoned;
								break;
							case 2:
								buffID = BuffID.Confused;
								break;
							case 3:
								buffID = BuffID.Frostburn;
								break;
						}
						target.AddBuff(buffID, Main.rand.Next(7, 15)*60);
					}
				}
				if (shadowsWink && (proj.DamageType == DamageClass.Summon || proj.DamageType == DamageClass.SummonMeleeSpeed)) {
					if (Player.MinionAttackTargetNPC == target.whoAmI)
					target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(5, 11)*60);
				}
				if (tribalCharm && (proj.DamageType == DamageClass.Summon || proj.DamageType == DamageClass.SummonMeleeSpeed)) {
					if (Player.MinionAttackTargetNPC == target.whoAmI)
					target.AddBuff(BuffID.Venom, Main.rand.Next(5, 11)*60);
				}
				if (etherealGasp && (proj.DamageType == DamageClass.Magic || proj.DamageType == DamageClass.MagicSummonHybrid)) {
					target.AddBuff(BuffType<Buffs.Debuffs.Ectoburn>(), Main.rand.Next(2, 6)*60);
					if (Player.statLife < Player.statLifeMax2/2) {
						Player.statMana++;
						Player.ManaEffect(1);
					}
				}
			}

			if (crit) {
				critCount++;
				nonCritCounter = 0;
			}
			else {
				nonCritCounter++;
			}
			if (!isDummy && Main.myPlayer == Player.whoAmI) {
				if (TrueMelee) {
					/*if (diskbringerSet)
						DiskiteBuffs(90, Player);*/
					if (nightmareCatcher && Main.rand.NextFloat() < .2f) {
						int y = 0;
						for (int x = 0; x < Main.maxItems; x++) {
							if (Main.item[x].type == ItemType<Items.Misc.LostNightmare>()) y++;
                        }
						if (y < 10) Item.NewItem(target.GetSource_FromThis(), target.getRect(), ItemType<Items.Misc.LostNightmare>());
					}
					if (crit) {
						if (glazedLens)
							Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.GlazedLensProj>(), 20, 5f, Main.myPlayer, item.crit + Player.GetCritChance(item.DamageType));
					}
				} else {
					// To encourage more true melee play, this only has a 75% chance of applying instead of 100
					/*if (diskbringerSet)
						DiskiteBuffs(60, Player, 75);*/
					if (nightmareCatcher && Main.rand.NextFloat() < .07f) {
						int y = 0;
						for (int x = 0; x < Main.maxItems; x++) {
							if (Main.item[x].type == ItemType<Items.Misc.LostNightmare>()) y++;
                        }
						if (y < 10) Item.NewItem(target.GetSource_FromThis(), target.getRect(), ItemType<Items.Misc.LostNightmare>());
					}
					if (crit) {
						if (glazedLens)
							Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.GlazedLensProj>(), 20, 5f, Main.myPlayer, proj.CritChance);
					}
				}
				if (crit) {
					if (golemEyeEffect) {
						if (proj != null) {
							if (proj.type != ModContent.ProjectileType<Projectiles.Accessories.GolemEyeProj>()) for (int i = 0; i < Main.rand.Next(1, 4); i++)
							Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center - new Vector2(Main.rand.Next(-40, 41), 600), new Vector2(Main.rand.NextFloat(-2f, 2f), 20), ModContent.ProjectileType<Projectiles.Accessories.GolemEyeProj>(), 100, 0f, Main.myPlayer);
						}
						else for (int i = 0; i < Main.rand.Next(1, 4); i++)
							Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center - new Vector2(Main.rand.Next(-40, 41), 600), new Vector2(Main.rand.NextFloat(-2f, 2f), 20), ModContent.ProjectileType<Projectiles.Accessories.GolemEyeProj>(), 100, 0f, Main.myPlayer);
					}	
				}
				if (bloodVial && Main.rand.NextFloat() < .1f)
					Player.Heal(1);
				if (metelordExpert && Player.ownedProjectileCounts[ProjectileType<Projectiles.Accessories.MetecoreSpirit>()] < 20 && metecoreFloat < 3f && Player.whoAmI == Main.myPlayer)
				{
					Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center, Vector2.Zero, ProjectileType<Projectiles.Accessories.MetecoreSpirit>(), 0, 0, Main.myPlayer);
				}
			}
			if (jellyExpert && crit && Player.ownedProjectileCounts[ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>()] < 2)
				ProjectileHelpers.NewNetProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>(), 50, 1f, Player.whoAmI);
			if (shadowflameMagic && Player.whoAmI == Main.myPlayer) {
				if (item != null)
					if (item.DamageType == DamageClass.Magic || item.DamageType == DamageClass.MagicSummonHybrid)
						target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(5, 11)*60);
				if (proj != null)
					if (proj.DamageType == DamageClass.Magic || item.DamageType == DamageClass.MagicSummonHybrid)
						target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(5, 11)*60);
            }
			if (sparkingCore && target.life < 1 && Player.whoAmI == Main.myPlayer) {
				if (item != null)
					if (item.DamageType == DamageClass.Magic || item.DamageType == DamageClass.MagicSummonHybrid)
						Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center, Vector2.Zero, ProjectileType<Projectiles.Accessories.SparkingCoreProj>(), 0, 0f, Player.whoAmI);
				if (proj != null)
					if (proj.DamageType == DamageClass.Magic || proj.DamageType == DamageClass.MagicSummonHybrid)
						Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center, Vector2.Zero, ProjectileType<Projectiles.Accessories.SparkingCoreProj>(), 0, 0f, Player.whoAmI);
            }
			/*if ((etherealGasp || supernaturalComet) && target.life < 1 && Player.whoAmI == Main.myPlayer && Main.rand.NextFloat() < .15f && !Player.HasBuff(BuffType<Buffs.Accessories.Possessed>())) {
				if (item != null)
					if (item.DamageType == DamageClass.Magic || item.DamageType == DamageClass.MagicSummonHybrid)
						Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center, Vector2.Zero, ProjectileType<Projectiles.Accessories.EtherealGaspProj>(), 0, 0f, Player.whoAmI);
				if (proj != null)
					if (proj.DamageType == DamageClass.Magic || proj.DamageType == DamageClass.MagicSummonHybrid)
						Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center, Vector2.Zero, ProjectileType<Projectiles.Accessories.EtherealGaspProj>(), 0, 0f, Player.whoAmI);
            }*/
			if (slimePendant) target.AddBuff(BuffID.Slimed, Main.rand.Next(5, 11)*60);
			if (livingWoodSetBonus) target.AddBuff(BuffID.DryadsWardDebuff, Main.rand.Next(2, 5)*60);
			if (coreofMending) {
				if (damage >= 40) coreofMendingCounter += 3;
				else if (damage >= 16) coreofMendingCounter += 2;
				else coreofMendingCounter++;

				if (coreofMendingCounter > 60) coreofMendingCounter = 60;
			}
			if (accursedHand && target.life < target.lifeMax/4 && Main.rand.NextBool(100)) {
				if (!target.dontTakeDamage && !target.immortal && !target.boss) {
					target.StrikeInstantKill();
					CombatText.NewText(target.getRect(), new Color(180, 180, 160), "INSTAKILL!");

					for (int i = 0; i < 15; i++) {
						Dust dust = Dust.NewDustDirect(target.position, target.width, target.height, DustID.WhiteTorch);
						dust.noGravity = true;
						dust.scale = 2f;
						dust.velocity = new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(24*i));
					}
				}
			}
		}
		public void OnHitPVPGlobal(Item item, Projectile proj, Player target, int damage, bool crit, bool TrueMelee) {
			if (summonCritHappen) { //I have to do this for some reason
				crit = true;
				summonCritHappen = false;
			}
			hitTimer30 = 1800;
			if (proj != null)
			{
				if (proj.type == ProjectileType<Projectiles.Spears.SpearofJustice>() && sojCooldown < 1 && Player.whoAmI == Main.myPlayer)
				{
					sojDamageCount += damage;
					sojCooldown = 6;
					if (sojDamageCount > 749)
					{
						CombatText.NewText(Player.getRect(), Color.Cyan, "MAX!");
						sojDamageCount = 0;
						for (int x = 0; x < 3; x++)
						{
							Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Spears.SpearofJusticeClone>(), 65, 4f, Main.myPlayer, x);
						}
					}
					else CombatText.NewText(Player.getRect(), Color.Cyan, sojDamageCount);
				}
			}

			if (crit) {
				critCount++;
			}
			if (TrueMelee) {
				/*if (diskbringerSet)
					DiskiteBuffs(90, Player);*/
				if (glazedLens && crit)
					Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.GlazedLensProj>(), 20, 5f, Main.myPlayer, item.crit + Player.GetCritChance(item.DamageType));
			} else {
				// To encourage more true melee play, this only has a 75% chance of applying instead of 100
				/*if (diskbringerSet)
					DiskiteBuffs(60, Player, 75);*/
				if (glazedLens && crit)
					Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.GlazedLensProj>(), 20, 5f, Main.myPlayer, proj.CritChance);
			}
			if (crit) {
				if (golemEyeEffect) {
					if (proj != null) {
						if (proj.type != ModContent.ProjectileType<Projectiles.Accessories.GolemEyeProj>()) for (int i = 0; i < Main.rand.Next(1, 4); i++)
						Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center - new Vector2(Main.rand.Next(-40, 41), 480), new Vector2(Main.rand.NextFloat(-2f, 2f), 20), ModContent.ProjectileType<Projectiles.Accessories.GolemEyeProj>(), 100, 0f, Main.myPlayer);
					}
					else for (int i = 0; i < Main.rand.Next(1, 4); i++)
						Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center - new Vector2(Main.rand.Next(-40, 41), 480), new Vector2(Main.rand.NextFloat(-2f, 2f), 20), ModContent.ProjectileType<Projectiles.Accessories.GolemEyeProj>(), 100, 0f, Main.myPlayer);
				}	
			}
			if (bloodVial && Main.rand.NextFloat() < .1f)
				Player.Heal(1);
			if (jellyExpert && crit && Player.ownedProjectileCounts[ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>()] < 2)
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>(), 50, 1f, Main.myPlayer);
			if (metelordExpert && Player.ownedProjectileCounts[ProjectileType<Projectiles.Accessories.MetecoreSpirit>()] < 20 && metecoreFloat < 3f)
			{
				Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center, Vector2.Zero, ProjectileType<Projectiles.Accessories.MetecoreSpirit>(), 0, 0, Main.myPlayer);
			}
			if (slimePendant) target.AddBuff(BuffID.Slimed, Main.rand.Next(5, 11)*60);
		}
        /*public void DiskiteBuffs(int Bufftime, Player player) {
			switch (Main.rand.Next(3)) {
				case 0:
					player.AddBuff(BuffType<Buffs.Armor.AdenebOffense>(), Bufftime);
					return;
				case 1:
					player.AddBuff(BuffType<Buffs.Armor.AdenebDefense>(), Bufftime);
					return;
				case 2:
					player.AddBuff(BuffType<Buffs.Armor.AdenebAgility>(), Bufftime);
					return;
            }
		}*/
        /*public void DiskiteBuffs(int Bufftime, Player player, int PercentChance) {
			if (Main.rand.Next(1, 100) <= PercentChance)
				DiskiteBuffs(Bufftime, player);
        }*/
        public override void ModifyHurt(ref Player.HurtModifiers modifiers) {
            if (potionFatigue > 5) {
				float loss = 1f + (potionFatigue-5)/10f;
                modifiers.FinalDamage *= loss;
			}

			if (darkronSetBonus && Player.HasBuff(BuffType<Buffs.Armor.DarkAbsolution>())) {
				modifiers.FinalDamage *= 0.5f;

				SoundEngine.PlaySound(SoundID.NPCHit5.WithPitchOffset(-1f), Player.Center);

				for (int i = 0; i < 10; i++) {
					Dust dust = Dust.NewDustDirect(Player.position, Player.width, Player.height, DustType<Dusts.BlackDust>());
					dust.noGravity = true;
					dust.scale = 1.5f;
					dust.velocity = new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(36*i));
				}
			}
        }
        public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo) {
			if (rootGuard && Player.whoAmI == Main.myPlayer) for (int x = 0; x < 3; x++) {
				int pos = Main.rand.Next(32, 65);
				if (Main.rand.NextBool()) pos *= -1;
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center + new Vector2(pos, -12), Vector2.Zero, ProjectileType<Projectiles.Accessories.RootGuardProj>(), 10, 0f, Main.myPlayer);
			}
			if (harpysCrest) harpysCrestCooldown = 210;
		}
		public override void OnHitByProjectile(Projectile proj, Player.HurtInfo hurtInfo) {
			if (rootGuard && Player.whoAmI == Main.myPlayer) for (int x = 0; x < 3; x++) {
				int pos = Main.rand.Next(32, 65);
				if (Main.rand.NextBool()) pos *= -1;
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center + new Vector2(pos, -12), Vector2.Zero, ProjectileType<Projectiles.Accessories.RootGuardProj>(), 10, 0f, Main.myPlayer);
			}
			if (harpysCrest) harpysCrestCooldown = 210;
		}
		/*public override void OnHitByNPC(NPC npc, int damage, bool crit) {
            if ((npc.type == NPCType<NPCs.Bosses.Adeneb.Adeneb_SpikeRing>() || npc.type == NPCType<NPCs.Bosses.Adeneb.Adeneb_Center>()) && !Player.noKnockback) {
				Vector2 vector1;
				vector1 = npc.Center - Player.Center;
				vector1.Normalize();
				Player.velocity = vector1*-12f;
            }
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit) {
            if ((proj.type == ProjectileType<Projectiles.Bosses.Adeneb.Adeneb_SpikeRingFriendly>()) && !Player.noKnockback) {
				Vector2 vector1;
				vector1 = proj.Center - Player.Center;
				vector1.Normalize();
				Player.velocity = vector1*-12f;
            }
        }*/

		public override bool FreeDodge(Player.HurtInfo info)
        {
			if (stealthPotion && Main.rand.NextFloat() < .04f)
			{
				Player.NinjaDodge();
				return true;
			}
			if (argentumHeadgear && Main.rand.NextFloat() < .08f) {
				Player.NinjaDodge();
				return true;
			}

			if (codebreaker && !Player.HasBuff(BuffType<Buffs.Accessories.CodebreakerCooldown>())) {
				Player.immune = true;
				Player.immuneTime = 180;
				if (Player.longInvince) Player.immuneTime += 40;
				for (int i = 0; i < Player.hurtCooldowns.Length; i++) {
					Player.hurtCooldowns[i] = Player.immuneTime;
				}
				codebreakerGlitch = 120;
				Player.AddBuff(BuffType<Buffs.Accessories.CodebreakerCooldown>(), 2700);

				SoundEngine.PlaySound(SoundID.Item93.WithPitchOffset(-1f), Player.Center);
				return true;
			}

			if (glassArmor && Player.whoAmI == Main.myPlayer)
			{
				int temp = info.Damage / 10;
				if (temp < 3) temp = 3;
				if (temp > 15) temp = 15;
				int temp2 = (info.Damage + 20) / 20;
				if (temp2 < 4) temp2 = 4;
				if (temp2 > 8) temp2 = 8;
				int z = 0;
				for (int y = 0; y < Main.maxProjectiles; y++) if (Main.projectile[y].type == ProjectileType<Projectiles.GlassShard>() && Main.projectile[y].active == true) z++;
				if (z < 40) for (int x = 0; x < temp; x++) Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(0, temp2).RotatedByRandom(Math.PI * 2), ModContent.ProjectileType<Projectiles.GlassShard>(), info.Damage, 2.5f, Main.myPlayer);
			}

			if (darkronSetBonus && !Player.HasBuff(BuffType<Buffs.Armor.DarkAbsolution>())) {
				Player.AddBuff(BuffType<Buffs.Armor.DarkAbsolution>(), info.Damage*4);

				SoundEngine.PlaySound(SoundID.NPCHit5.WithPitchOffset(-1f), Player.Center);

				for (int i = 0; i < 15; i++) {
					Dust dust = Dust.NewDustDirect(Player.position, Player.width, Player.height, DustType<Dusts.BlackDust>());
					dust.noGravity = true;
					dust.scale = 2f;
					dust.velocity = new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(24*i));
				}

				//Manually dodge the attack.
				Player.immune = true;
				Player.immuneTime = 80;
				if (Player.longInvince) Player.immuneTime += 40;
				for (int i = 0; i < Player.hurtCooldowns.Length; i++) {
					Player.hurtCooldowns[i] = Player.immuneTime;
				}

				return true;
			}

			return false;
        }

        float check;
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition) {
            if (Main.hardMode) check = 1f;
			Player owner = Main.player[(int)Player.FindClosest(Player.position, Player.width, Player.height)];
			if ((owner.ZoneDirtLayerHeight || owner.ZoneRockLayerHeight) && Main.rand.NextFloat() < .04f)
				itemDrop = ItemType<Items.Materials.Fish.LabyrinthFish>();
			if (owner.ZoneRockLayerHeight && Main.rand.NextFloat() < .07f && Player.HasBuff(BuffID.Hunter))
				itemDrop = ItemType<Items.Materials.Fish.PaintedGlassTetra>();
			//if (owner.ZoneBeach && Main.rand.NextFloat() < (.04f-(.02f*check)))
			//	itemDrop = ItemType<Items.Blowpipes.Shellshocker>();
        }
        public override void PostUpdateEquips() {
			if (GetInstance<ZylonConfig>().summonNaturalCrit) {
				summonCrit = Player.GetCritChance(DamageClass.Generic)/100f + summonCritBoost;
			}
            if (runeofMultiplicity) { //Don't move this anywhere else, otherwise it might not work correctly
				int dupli = Player.maxMinions - 1;
				if (dupli > 3) dupli = 3;
				Player.maxMinions += dupli;
				//Main.NewText((Player.maxMinions-dupli)+" --> "+Player.maxMinions); //Testing
            }
			/*if (Player.HasBuff(BuffType<Buffs.Accessories.Possessed>())) {
				if (etherealGasp) {
					Player.GetDamage(DamageClass.Magic) += 0.33f;
					Player.manaCost += 0.175f;
				}
				else if (supernaturalComet) {
					Player.GetDamage(DamageClass.Magic) += 0.2f;
					Player.manaCost += 0.1f;
				}
			}*/
			if (fixCooldownIgnore) {
				for (int i = 0; i < Player.MaxBuffs; i++) {
					if (Player.buffType[i] == BuffID.PotionSickness && Player.buffTime[i] >= 2025) {
						if (Player.pStone) Player.buffTime[i] = 2025;
						else Player.buffTime[i] = 2700;

						fixCooldownIgnore = false;
					}
				}
			}
			if ((Player.armor[2].type == ItemType<Items.Armor.NeutronBooster>() && Player.armor[12].type == 0) || Player.armor[12].type == ItemType<Items.Armor.NeutronBooster>()) {
				if (Player.velocity.Length() > 0.01f && !Player.mount.Active) {
					float size = Player.velocity.Length()*0.5f;
					if (size > 2f) size = 2f;
					for (int i = 0; i < 3; i++) {
						Dust dust = Dust.NewDustDirect(Player.position + new Vector2(5+Player.direction*2, 38) + Player.velocity, 1, 1, DustID.Vortex);
						dust.velocity.X = Player.velocity.X*-0.5f;
						dust.velocity.Y = Player.velocity.Y*-0.5f;
						dust.scale *= size*0.25f + Main.rand.Next(-30, 31) * 0.01f;
					}
				}
			}
			if (!coreofMending && Player.ownedProjectileCounts[ProjectileType<Projectiles.Accessories.CoreofMendingProj>()] < 1) coreofMendingCounter = 0; //Resets counter if not equipped and not despawning currently.
			if (Player.HasBuff(BuffType<Buffs.Debuffs.BrokenCode>())) {
				float val = ((int)(Main.GameUpdateCount%5000/10)+1580+Player.whoAmI*35)*979.6719f; //Faux randomness every 10 frames

				Player.statDefense -= (int)val % 31;
			}
		}
        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers) {
			if (WorldGen.currentWorldSeed == null) return;
            if (WorldGen.currentWorldSeed.ToLower() == "abyssworld" || WorldGen.currentWorldSeed.ToLower() == "flopside pit") {
				if (NPC.downedMoonlord) Player.AddBuff(BuffID.Blackout, Main.rand.Next(7, 15)*60);
				else if (Main.hardMode) Player.AddBuff(BuffID.Blackout, Main.rand.Next(4, 10)*60);
				else Player.AddBuff(BuffID.Darkness, Main.rand.Next(4, 10)*60);
			}
        }
        public override void OnHurt(Player.HurtInfo info) { //Also use for reviving the player I think
            Zylon.noHitSabur = false;
        }
        public override void PostUpdateBuffs() {
			if (WorldGen.currentWorldSeed == null) return;
			if (WorldGen.currentWorldSeed.ToLower() == "abyssworld" || WorldGen.currentWorldSeed.ToLower() == "flopside pit") {
				//if (Player.ZoneDirtLayerHeight) Player.blind = true;
				//if (Player.ZoneRockLayerHeight) Player.blackout = true;
				//if (Player.ZoneUnderworldHeight) { Player.blind = true; Player.blackout = true; }

				//Above is too dark tbh
				if (Player.ZoneDirtLayerHeight || Player.ZoneRockLayerHeight || Player.ZoneUnderworldHeight) Player.blind = true;

				if (Main.netMode == NetmodeID.SinglePlayer || Main.netMode == NetmodeID.Server) {
					if (Main.dayTime) Main.time++;
				}
			}
			
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
				for (int i = 0; i < 44; i++) {
					if (Player.buffType[i] == BuffID.AmmoReservation || Player.buffType[i] == BuffID.Archery || Player.buffType[i] == BuffID.Endurance || Player.buffType[i] == BuffID.Featherfall || Player.buffType[i] == BuffID.Gravitation || Player.buffType[i] == BuffID.Lucky || Player.buffType[i] == BuffID.Heartreach || Player.buffType[i] == BuffID.Inferno || Player.buffType[i] == BuffID.Invisibility || Player.buffType[i] == BuffID.Ironskin || Player.buffType[i] == BuffID.Lifeforce || Player.buffType[i] == BuffID.MagicPower || Player.buffType[i] == BuffID.ManaRegeneration || Player.buffType[i] == BuffID.Rage || Player.buffType[i] == BuffID.Regeneration || Player.buffType[i] == BuffID.Summoning || Player.buffType[i] == BuffID.Swiftness || Player.buffType[i] == BuffID.Thorns || Player.buffType[i] == BuffID.Titan || Player.buffType[i] == BuffID.Warmth || Player.buffType[i] == BuffID.Wrath || Player.buffType[i] == BuffID.WellFed || Player.buffType[i] == BuffID.WellFed2 || Player.buffType[i] == BuffID.WellFed3 || Player.buffType[i] == BuffID.WeaponImbueCursedFlames || Player.buffType[i] == BuffID.WeaponImbueFire || Player.buffType[i] == BuffID.WeaponImbueGold || Player.buffType[i] == BuffID.WeaponImbueIchor || Player.buffType[i] == BuffID.WeaponImbueNanites || Player.buffType[i] == BuffID.WeaponImbuePoison || Player.buffType[i] == BuffID.WeaponImbueVenom || Player.buffType[i] == BuffType<Buffs.Potions.BloodiedVial>() || Player.buffType[i] == BuffType<Buffs.Potions.Feral>() || Player.buffType[i] == BuffType<Buffs.Potions.Floater>() || Player.buffType[i] == BuffType<Buffs.Potions.Gale>() || Player.buffType[i] == BuffType<Buffs.Potions.HeavyHitter>() || Player.buffType[i] == BuffType<Buffs.Potions.Manareach>() || Player.buffType[i] == BuffType<Buffs.Potions.Neutronic>() || Player.buffType[i] == BuffType<Buffs.Potions.Stealthy>())
						potionFatigue++;
				}
				if (potionFatigue > 5) Player.AddBuff(BuffType<Buffs.Debuffs.PotionFatigue>(), 1);
			}

			if (codebreakerGlitch > 0) {
				codebreakerGlitch--;
				if (Main.rand.NextBool(5)) Player.velocity = new Vector2(Main.rand.NextFloat(-9, 9), Main.rand.NextFloat(-9, 9));

				if (Main.rand.NextBool(3)) {
					int dustType = DustType<Dusts.BinaryDust>();
					Dust dust = Dust.NewDustDirect(Player.position, Player.width, Player.height, dustType, Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-3, 3));
					dust.noGravity = true;
				}
			}
        }
        public override void HideDrawLayers(PlayerDrawSet drawInfo) {
            if (blackBox) {
				drawInfo.hideEntirePlayer = true;
				Texture2D boxTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/Fantesseract_BlackBox");
				Main.spriteBatch.Draw(boxTexture, drawInfo.Center, null, Color.White, 0f, new Vector2(boxTexture.Width, boxTexture.Height), 1f, SpriteEffects.None, 0f);
			}
			if (Player.HasBuff(BuffType<Buffs.Debuffs.BrokenCode>())) {
				float val = ((int)(Main.GameUpdateCount%5000/10)+1580+Player.whoAmI*35)*1279.6719f; //Faux randomness every 10 frames

				int headval = (int)val % 281;
				int bodyval = (int)val % 106;
				int legval = (int)val % 235;

				Player.head = headval;
				Player.body = bodyval;
				Player.legs = legval;
			}
        }
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
			if (blackBox) {
				//drawInfo.hideEntirePlayer = true;
				Texture2D boxTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Accessories/Clutter/Fantesseract_BlackBox");
				a = 0f; r = 0f; g = 0f; b = 0f;
				Player.invis = true;
				Main.spriteBatch.Draw(boxTexture, drawInfo.Center - Main.screenPosition - new Vector2(0, 4), null, Color.White, 0f, new Vector2(boxTexture.Width/2f, boxTexture.Height/2f), 1f, SpriteEffects.None, 0f);
			}
        }
        public override void ProcessTriggers(TriggersSet triggersSet) {
			if (ZylonKeybindSystem.DoublePluggedCordKeybind.JustPressed && doublePluggedCord) SoundEngine.PlaySound(SoundID.Item93, Player.Center);
			if (ZylonKeybindSystem.DoublePluggedCordKeybind.Current && doublePluggedCord && Player.active && Player.statLife > 0) {
				
				if (Main.GameUpdateCount % 2 == 0) Player.statLife -= 1;
				if (Main.GameUpdateCount % 8 == 0) {
					int healCount = Main.rand.Next(8, 14);
					Player.statMana += healCount;
					Player.ManaEffect(healCount);
				}
				Player.AddBuff(BuffType<Buffs.Accessories.DoublePluggedCord>(), 1);

				if (Player.statLife < 1) { 
					String deathMessage = "";
					switch (Main.rand.Next(3)) {
						case 0:
							deathMessage = " plugged themselves in.";
							break;
						case 1:
							deathMessage = " reinvented the electric chair.";
							break;
						case 2:
							deathMessage = " stuck their fingers in the outlet.";
							break;
					}
					if (Main.rand.NextBool(4) && (Player.HasItem(ItemID.CellPhone) || Player.HasItem(ItemID.Shellphone) || Player.HasItem(ItemID.ShellphoneDummy) || Player.HasItem(ItemID.ShellphoneHell) || Player.HasItem(ItemID.ShellphoneOcean) || Player.HasItem(ItemID.ShellphoneSpawn) || Player.HasItem(ItemID.PDA)))
						deathMessage = "'s phone reached 200% charge.";
					Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + deathMessage), 1, 0);
				}
			}
			if (ZylonKeybindSystem.CodebreakerKeybind.JustPressed && codebreaker && !Player.HasBuff(BuffType<Buffs.Accessories.CodebreakerCooldown>()) && Player.active && Player.statLife > 0) {
				Player.Center = Main.MouseWorld;
				Player.AddBuff(BuffType<Buffs.Accessories.CodebreakerCooldown>(), 2700);
				SoundEngine.PlaySound(SoundID.Item93.WithPitchOffset(-1f), Player.Center);
				for (int i = 0; i < 10; i++) {
					int dustType = DustType<Dusts.BinaryDust>();
					Dust dust = Dust.NewDustDirect(Player.position, Player.width, Player.height, dustType, Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-3, 3));
					dust.noGravity = true;
				}
			}
		}
    }
}