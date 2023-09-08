using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using static Terraria.ModLoader.ModContent;

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
		public bool bandofZinc;
		public bool jellyExpert;
		public bool ADDExpert;
		public bool diskbringerSet;
		public bool slimePendant;
		public bool glazedLens;
		public bool deadlyToxins;
		public bool trueMelee10;
		public bool dirtballExpert;
		public bool dirtRegalia;
		public bool elemDegen;
		public bool nightmareCatcher;
		public bool shadowflameMagic;
		public bool metelordExpert;
		public bool stncheck;
		public bool st2check;
		public bool discoCanister;
		public bool hexNecklace;
		public bool shivercrown;
		public bool bloodContract;
		public bool balloonCheck;
		public bool rootGuard;
		public bool leafBracer;
		public bool leafBracerTempBool;
		public bool friendshipBracelet;
		public bool fleKnuCheck;
		public bool glassArmor;

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
			bandofZinc = false;
			jellyExpert = false;
			ADDExpert = false;
			diskbringerSet = false;
			slimePendant = false;
			glazedLens = false;
			deadlyToxins = false;
			trueMelee10 = false;
			dirtballExpert = false;
			dirtRegalia = false;
			elemDegen = false;
			nightmareCatcher = false;
			shadowflameMagic = false;
			metelordExpert = false;
			stncheck = false;
			st2check = false;
			discoCanister = false;
			hexNecklace = false;
			shivercrown = false;
			bloodContract = false;
			balloonCheck = false;
			rootGuard = false;
			leafBracer = false;
			friendshipBracelet = false;
			fleKnuCheck = false;
			glassArmor = false;
			critExtraDmg = 0f;
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
		}
		public override void UpdateDead() {
			Heartdaze = false;
			outofBreath = false;
			shroomed = false;
			deadlyToxins = false;
			elemDegen = false;
			hitTimer30 = 0;
			sojDamageCount = 0;
			sojCooldown = 0;
			metecoreFloat = 1f;
		}
		public override void UpdateBadLifeRegen() {
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

			hitTimer30 -= 1;
			sojCooldown -= 1;
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
				if (bandofZinc && Player.HasBuff(BuffID.Swiftness)) {
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
				Player.npcTypeNoAggro[NPCType<NPCs.Forest.OrangeSlime>()] = true;
				//Player.npcTypeNoAggro[NPCType<NPCs.Ocean.CyanSlime>()] = true;
				//Player.npcTypeNoAggro[NPCType<NPCs.Sky.StarpackSlime>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Snow.LivingMarshmallow>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Snow.RoastedLivingMarshmallow>()] = true;
            }
			if (leafBracer) {
				if (!Player.HasBuff(BuffID.PotionSickness) && !leafBracerTempBool) leafBracerTempBool = true;
				if (Player.HasBuff(BuffID.PotionSickness) && leafBracerTempBool) {
					Player.AddBuff(BuffType<Buffs.LeafBracer>(), 120);
					leafBracerTempBool = false;
                }
            }
        }
		float trueMeleeBoost;
		float critBoost;
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) {
        critBoost = 1f;
			if (crit) critBoost += critExtraDmg;
			trueMeleeBoost = 1f;
			if (trueMelee10) trueMeleeBoost += 0.1f;
			if (trueMelee15) trueMeleeBoost += 0.15f;
			damage = (int)(damage * trueMeleeBoost * critBoost);
		}
        public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit) {
			critBoost = 1f;
			if (crit) critBoost += critExtraDmg;
            trueMeleeBoost = 1f;
			if (trueMelee10) trueMeleeBoost += 0.1f;
			if (trueMelee15) trueMeleeBoost += 0.15f;
			damage = (int)(damage * trueMeleeBoost * critBoost);
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            critBoost = 1f;
			if (crit) critBoost += critExtraDmg;
			damage = (int)(damage * critBoost);
        }
        public override void ModifyHitPvpWithProj(Projectile proj, Player target, ref int damage, ref bool crit) {
            critBoost = 1f;
			if (crit) critBoost += critExtraDmg;
			damage = (int)(damage * critBoost);
        }
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) {
			OnHitNPCGlobal(item, null, target, damage, knockback, crit, target.type == NPCID.TargetDummy, true);
		}
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
			OnHitNPCGlobal(null, proj, target, damage, knockback, crit, target.type == NPCID.TargetDummy, false);
		}
        public override void OnHitPvp(Item item, Player target, int damage, bool crit) {
			OnHitPVPGlobal(item, null, target, damage, crit, true);
		}
        public override void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit) {
			OnHitPVPGlobal(null, proj, target, damage, crit, false);
		}
		public void OnHitNPCGlobal(Item item, Projectile proj, NPC target, int damage, float knockback, bool crit, bool isDummy, bool TrueMelee) {
			hitTimer30 = 1800;
			if (proj != null) {
				if (proj.type == ProjectileType<Projectiles.Spears.SpearofJustice>() && sojCooldown < 1) {
					sojDamageCount += damage;
					sojCooldown = 6;
					if (sojDamageCount > 749) {
						CombatText.NewText(Player.getRect(), Color.Cyan, "MAX!");
						sojDamageCount = 0;
						for (int x = 0; x < 3; x++) {
							Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Spears.SpearofJusticeClone>(), 65, 4f, Main.myPlayer, x);
				        }
				    }
					else CombatText.NewText(Player.getRect(), Color.Cyan, sojDamageCount);
				}
			}
			if (crit) {
				critCount++;
			}
			if (!isDummy && Main.myPlayer == Player.whoAmI) {
				if (TrueMelee) {
					if (diskbringerSet)
						DiskiteBuffs(90);
					if (nightmareCatcher && Main.rand.NextFloat() < .2f) {
						int y = 0;
						for (int x = 0; x < Main.maxItems; x++) {
							if (Main.item[x].type == ItemType<Items.Misc.LostNightmare>()) y++;
                        }
						if (y < 10) Item.NewItem(target.GetSource_FromThis(), target.getRect(), ItemType<Items.Misc.LostNightmare>());
					}
					if (crit) {
						if (glazedLens)
							Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Main.myPlayer, item.crit + Player.GetCritChance(item.DamageType));
						if (bloodContract) for (int x = 0; x < Main.rand.Next(1, 4); x++)
							if (item.crit + Player.GetCritChance(item.DamageType) < Main.rand.NextFloat(30f, 130f))
								Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center, new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-9, -5)), ProjectileType<Projectiles.Accessories.BloodContractProj>(), 0, 0, Main.myPlayer);
					}
				} else {
					// To encourage more true melee play, this only has a 75% chance of applying instead of 100
					if (diskbringerSet)
						DiskiteBuffs(60, 75);
					if (nightmareCatcher && Main.rand.NextFloat() < .07f) {
						int y = 0;
						for (int x = 0; x < Main.maxItems; x++) {
							if (Main.item[x].type == ItemType<Items.Misc.LostNightmare>()) y++;
                        }
						if (y < 10) Item.NewItem(target.GetSource_FromThis(), target.getRect(), ItemType<Items.Misc.LostNightmare>());
					}
					if (crit) {
						if (glazedLens)
							Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Main.myPlayer, proj.CritChance);
						if (bloodContract) for (int x = 0; x < Main.rand.Next(1, 3); x++)
							if (proj.CritChance < Main.rand.NextFloat(30f, 130f))
								Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center, new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-9, -5)), ProjectileType<Projectiles.Accessories.BloodContractProj>(), 0, 0, Main.myPlayer);
					}
				}
				if (bloodVial && Main.rand.NextFloat() < .1f)
					Player.Heal(1);
			}
			if (jellyExpert && crit && Player.ownedProjectileCounts[ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>()] < 2)
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>(), damage, 1f, Main.myPlayer);
			if (shadowflameMagic) {
				if (item != null)
					if (item.DamageType == DamageClass.Magic)
						target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(5, 11)*60);
				if (proj != null)
					if (proj.DamageType == DamageClass.Magic)
						target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(5, 11)*60);
            }
			if (metelordExpert && Player.ownedProjectileCounts[ProjectileType<Projectiles.Accessories.MetecoreSpirit>()] < 20 && metecoreFloat < 3f) {
				if (target.type != NPCID.TargetDummy) Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center, Vector2.Zero, ProjectileType<Projectiles.Accessories.MetecoreSpirit>(), 0, 0, Main.myPlayer);
            }
		}
		public void OnHitPVPGlobal(Item item, Projectile proj, Player target, int damage, bool crit, bool TrueMelee) {
			hitTimer30 = 1800;
			if (proj != null) {
				if (proj.type == ProjectileType<Projectiles.Spears.SpearofJustice>() && sojCooldown < 1) {
					sojDamageCount += damage;
					sojCooldown = 6;
					if (sojDamageCount > 749) {
						CombatText.NewText(Player.getRect(), Color.Cyan, "MAX!");
						sojDamageCount = 0;
						for (int x = 0; x < 3; x++) {
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
				if (diskbringerSet)
					DiskiteBuffs(90);
				if (glazedLens && crit)
					Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Main.myPlayer, item.crit + Player.GetCritChance(item.DamageType));
			} else {
				// To encourage more true melee play, this only has a 75% chance of applying instead of 100
				if (diskbringerSet)
					DiskiteBuffs(60, 75);
				if (glazedLens && crit)
					Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Main.myPlayer, proj.CritChance);
			}
			if (bloodVial && Main.rand.NextFloat() < .1f)
				Player.Heal(1);
			if (jellyExpert && crit && Player.ownedProjectileCounts[ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>()] < 2)
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>(), damage, 1f, Main.myPlayer);
			if (metelordExpert && Player.ownedProjectileCounts[ProjectileType<Projectiles.Accessories.MetecoreSpirit>()] < 20 && metecoreFloat < 3f) {
				Projectile.NewProjectile(Player.GetSource_FromThis(), target.Center, Vector2.Zero, ProjectileType<Projectiles.Accessories.MetecoreSpirit>(), 0, 0, Main.myPlayer);
            }
		}
		public void DiskiteBuffs(int Bufftime) {
			switch (Main.rand.Next(3)) {
				case 0:
					Player.AddBuff(BuffType<Buffs.Armor.DiskiteOffense>(), Bufftime);
					return;
				case 1:
					Player.AddBuff(BuffType<Buffs.Armor.DiskiteDefense>(), Bufftime);
					return;
				case 2:
					Player.AddBuff(BuffType<Buffs.Armor.DiskiteAgility>(), Bufftime);
					return;
            }
		}
		public void DiskiteBuffs(int Bufftime, int PercentChance) {
			if (Main.rand.Next(1, 100) <= PercentChance)
				DiskiteBuffs(Bufftime);
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (rootGuard) for (int x = 0; x < 3; x++) { //FINISH
				int pos = Main.rand.Next(32, 65);
				if (Main.rand.NextBool()) pos *= -1;
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center + new Vector2(pos, -12), Vector2.Zero, ProjectileType<Projectiles.Accessories.RootGuardProj>(), 10, 0f, Main.myPlayer);
			}
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            if (rootGuard) for (int x = 0; x < 3; x++) { //FINISH
				int pos = Main.rand.Next(32, 65);
				if (Main.rand.NextBool()) pos *= -1;
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center + new Vector2(pos, -12), Vector2.Zero, ProjectileType<Projectiles.Accessories.RootGuardProj>(), 10, 0f, Main.myPlayer);
			}
        }
        /*public override void OnHitByNPC(NPC npc, int damage, bool crit) {
            if ((npc.type == NPCType<NPCs.Bosses.ADD.ADD_SpikeRing>() || npc.type == NPCType<NPCs.Bosses.ADD.ADD_Center>()) && !Player.noKnockback) {
				Vector2 vector1;
				vector1 = npc.Center - Player.Center;
				vector1.Normalize();
				Player.velocity = vector1*-12f;
            }
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit) {
            if ((proj.type == ProjectileType<Projectiles.Bosses.ADD.ADD_SpikeRingFriendly>()) && !Player.noKnockback) {
				Vector2 vector1;
				vector1 = proj.Center - Player.Center;
				vector1.Normalize();
				Player.velocity = vector1*-12f;
            }
        }*/
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter) {
			if (stealthPotion && Main.rand.NextFloat() < .04f) {
				damage = 0;
				Player.NinjaDodge();
				return false;
			}
			if (slimePendant) {
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(-4.5f, -3), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Main.myPlayer);
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(-1.5f, -5), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Main.myPlayer);
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(1.5f, -5), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Main.myPlayer);
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(4.5f, -3), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Main.myPlayer);
            }
			if (glassArmor) {
				int temp = damage / 10;
				if (temp < 3) temp = 3;
				if (temp > 15) temp = 15;
				int temp2 = (damage + 20) / 20;
				if (temp2 < 4) temp2 = 4;
				if (temp2 > 8) temp2 = 8;
				int z = 0;
				for (int y = 0; y < Main.maxProjectiles; y++) if (Main.projectile[y].type == ProjectileType<Projectiles.GlassShard>() && Main.projectile[y].active == true) z++;
				if (z < 40) for (int x = 0; x < temp; x++) Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(0, temp2).RotatedByRandom(Math.PI*2), ModContent.ProjectileType<Projectiles.GlassShard>(), damage, 2.5f, Main.myPlayer);
            }
			return true;
        }
		float check;
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition) {
            if (Main.hardMode) check = 1f;
			Player owner = Main.player[(int)Player.FindClosest(Player.position, Player.width, Player.height)];
			if ((owner.ZoneDirtLayerHeight || owner.ZoneRockLayerHeight) && Main.rand.NextFloat() < .04f)
				itemDrop = ItemType<Items.Materials.Fish.LabyrinthFish>();
			if (owner.ZoneRockLayerHeight && Main.rand.NextFloat() < .07f && Player.HasBuff(BuffID.Hunter))
				itemDrop = ItemType<Items.Materials.Fish.PaintedGlassTetra>();
			if (owner.ZoneBeach && Main.rand.NextFloat() < (.04f-(.02f*check)))
				itemDrop = ItemType<Items.Blowpipes.Shellshocker>();
        }
    }
}