using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs
{
	public class ZylonGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool severeBleeding;
		public bool shroomed;
		public bool deadlyToxins;
		public bool elemDegen;
		public static int diskiteBoss = -1;
		public static int dirtballBoss = -1;
		public override void ResetEffects(NPC npc) {
			severeBleeding = false;
			shroomed = false;
			deadlyToxins = false;
			elemDegen = false;
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (severeBleeding) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 20;
				if (!npc.boss)
					npc.lifeRegen -= 40;
				if (damage < 1) {
					damage = 1;
				}
			}
			if (shroomed) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 4;
				if (damage < 1) {
					damage = 1;
				}
			}
			if (deadlyToxins) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 20;
				if (damage < 1) {
					damage = 1;
				}
			}
			if (elemDegen) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 48;
				if (damage < 1) {
					damage = 1;
				}
			}
		}
        public override void HitEffect(NPC npc, int hitDirection, double damage) {
            if (npc.type == NPCID.Plantera && npc.life < 1 && !NPC.downedPlantBoss)
				Projectile.NewProjectile(npc.GetSource_FromThis(), npc.Center, new Vector2(0, 0), ProjectileType<Projectiles.PlanteraElementalGel>(), 0, 0, Main.myPlayer);
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			if (npc.type == NPCID.Harpy)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Yoyos.GlazingStar>(), 75), new CommonDrop(ItemType<Items.Yoyos.GlazingStar>(), 65)));
			if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Materials.BloodySpiderLeg>(), 8), new CommonDrop(ItemType<Items.Materials.BloodySpiderLeg>(), 6)));
			if (npc.type == NPCID.KingSlime)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Materials.SlimyCore>(), 1, 8, 12), new CommonDrop(ItemType<Items.Materials.SlimyCore>(), 1, 10, 15)));
			if (npc.type == NPCID.EyeofCthulhu) {
				npcLoot.Add(new CommonDrop(ItemType<Items.Yoyos.Insomnia>(), 3));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Lens, 1, 3, 5), new CommonDrop(ItemID.Lens, 1, 4, 6)));
				if (WorldGen.crimson)
					npcLoot.Add(new CommonDrop(ItemType<Items.Ammo.BloodiedArrow>(), 1, 20, 50, 1));
            }
			if (npc.type == NPCID.SkeletronHead)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Bone, 1, 20, 30), new CommonDrop(ItemID.Bone, 1, 30, 40)));
			/*if (NPC.downedBoss3 && (npc.type == NPCID.Skeleton || npc.type == NPCID.SkeletonAlien || npc.type == NPCID.SkeletonArcher || npc.type == NPCID.SkeletonAstonaut || npc.type == NPCID.SkeletonSniper || npc.type == NPCID.ArmoredSkeleton || npc.type == NPCID.BigHeadacheSkeleton || npc.type == NPCID.BigMisassembledSkeleton || npc.type == NPCID.BigPantlessSkeleton || npc.type == NPCID.BigSkeleton || npc.type == NPCID.HeadacheSkeleton || npc.type == NPCID.HeadacheSkeleton|| npc.type == NPCID.MisassembledSkeleton || npc.type == NPCID.PantlessSkeleton || npc.type == NPCID.SmallHeadacheSkeleton || npc.type == NPCID.SmallMisassembledSkeleton || npc.type == NPCID.SmallPantlessSkeleton|| npc.type == NPCID.SmallSkeleton || npc.type == NPCID.SporeSkeleton))
				npcLoot.Add(new CommonDrop(ItemID.Bone, 1, 1, 3));*/
			if (npc.type == NPCID.WallofFlesh) {
				npcLoot.Add(ItemDropRule.OneFromOptions(2, ItemType<Items.Blowpipes.FamiliarFoamDartPistol>(), ItemType<Items.Misc.MagnificentOrb>()));
            }
			if (npc.type == NPCID.BloodNautilus) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Swords.Dreadclawtilus>(), 5), new CommonDrop(ItemType<Items.Swords.Dreadclawtilus>(), 4)));
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.BloodDroplet>(), 1, 3, 6));
			}
			if (npc.type == NPCID.Golem)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Spears.LihzahrdLance>(), 4), new CommonDrop(ItemType<Items.Spears.LihzahrdLance>(), 3)));
			if (npc.type == NPCID.MoonLordCore) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Blowpipes.RoxinBlowgun>(), 3), new CommonDrop(ItemType<Items.Blowpipes.RoxinBlowgun>(), 2)));
            }
			if (npc.type == NPCID.MossHornet) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Stinger, 2), new CommonDrop(ItemID.Stinger, 1)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Vine, 10), new CommonDrop(ItemID.Vine, 8)));
            }
			if (npc.type == NPCID.SeekerHead) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.RottenChunk, 1, 1, 3), new CommonDrop(ItemID.RottenChunk, 1, 2, 4)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.WormTooth, 1, 3, 9), new CommonDrop(ItemID.WormTooth, 1, 5, 11)));
            }
			if (npc.type == NPCID.GoblinSorcerer)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Tomes.ChaosCaster>(), 20), new CommonDrop(ItemType<Items.Tomes.ChaosCaster>(), 18)));
			if (npc.type == NPCID.IceBat || npc.type == NPCID.SnowFlinx || npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.UndeadViking)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Tomes.Snowfall>(), 100), new CommonDrop(ItemType<Items.Tomes.Snowfall>(), 90)));
			if ((npc.type == 42) || (npc.type >= 231 && npc.type <= 235) || (npc.type >= -56 && npc.type <= -65) || (npc.type == -16) || (npc.type == -17))
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Food.CocoaBeans>(), 30), new CommonDrop(ItemType<Items.Food.CocoaBeans>(), 25)));
			if (npc.type == NPCID.GreenSlime || npc.type == NPCID.BlueSlime || npc.type == NPCID.RedSlime || npc.type == NPCID.YellowSlime || npc.type == NPCID.BlackSlime || npc.type == NPCID.MotherSlime)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.SlimePendant>(), 150), new CommonDrop(ItemType<Items.Accessories.SlimePendant>(), 125)));
			if (npc.type == NPCID.WindyBalloon || npc.type == NPCID.Dandelion)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Materials.WindEssence>(), 3), new CommonDrop(ItemType<Items.Materials.WindEssence>(), 2)));
			if ((npc.type == 2) || (npc.type >= -43 && npc.type <= -38) || (npc.type >= 190 && npc.type <= 194) || (npc.type == 317) || (npc.type == 318))
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.GlazedLens>(), 100), new CommonDrop(ItemType<Items.Accessories.GlazedLens>(), 90)));
			if (npc.type == NPCID.UndeadMiner || npc.type == NPCID.GiantWormHead)
				npcLoot.Add(new CommonDrop(ItemType<Items.Accessories.ExtraShinyOreNugget>(), 30));
			if (npc.type == NPCID.CaveBat || npc.type == NPCID.BlackSlime)
				npcLoot.Add(new CommonDrop(ItemType<Items.Accessories.ExtraShinyOreNugget>(), 250));
			if (npc.type == NPCID.WindyBalloon || npc.type == NPCID.Dandelion)
				npcLoot.Add(new CommonDrop(ItemType<Items.Food.CottonCandy>(), 100));
		}
        public override void ModifyGlobalLoot(GlobalLoot globalLoot) {
            //globalLoot.Add(ItemDropRule.ByCondition(new Conditions.WindyEnoughForKiteDrops(), ItemType<Items.Materials.WindEssence>(), 5));
			globalLoot.Add(ItemDropRule.ByCondition(new Conditions.IsBloodMoonAndNotFromStatue(), ItemType<Items.Materials.BloodDroplet>(), 6));
		}
        public override void SetupShop(int type, Chest shop, ref int nextSlot) {
            if (type == NPCID.Dryad) {
				shop.item[nextSlot].SetDefaults(ItemID.Seed);
				shop.item[nextSlot].shopCustomPrice = 4;
				nextSlot++;
			}
			if (type == NPCID.WitchDoctor) {
				shop.item[nextSlot].SetDefaults(ItemID.PoisonDart);
				shop.item[nextSlot].shopCustomPrice = 7;
				nextSlot++;
			}
			if (type == NPCID.Demolitionist) {
				shop.item[nextSlot].SetDefaults(ItemType<Items.Ammo.PocketGrenade>());
				nextSlot++;
			}
			if (type == NPCID.ArmsDealer) {
				if (NPC.downedBoss2) {
					if (Main.hardMode || !Main.dayTime) {
						shop.item[nextSlot].SetDefaults(ItemType<Items.Ammo.BloodiedArrow>());
						nextSlot++;
					}
				}
			}
			if (type == NPCID.Merchant) { //DB downed
				if (Main.dayTime) {
					shop.item[nextSlot].SetDefaults(ItemType<Items.Tools.TreeWhacker>());
					nextSlot++;
				}
			}
        }
        public override void SetupTravelShop(int[] shop, ref int nextSlot) {
            if (Main.rand.NextFloat() < .5f) {
				int rand = Main.rand.Next(2);
				if (rand == 0) {
					shop[nextSlot] = ItemType<Items.Ammo.OverclockArrow>();
					nextSlot++;
                }
				if (rand == 1) {
					shop[nextSlot] = ItemType<Items.Accessories.IronfistMedal>();
					nextSlot++;
                }
			}
			else if (Main.rand.NextFloat() < .5f && Main.hardMode) {
				shop[nextSlot] = ItemType<Items.Flails.StickyHand>();
				nextSlot++;
            }
			/*if (Main.rand.NextFloat() < .25f && Main.hardMode) {
				shop[nextSlot] = ItemType<Items.Accessories.AirTank>();
                nextSlot++;
			}*/
        }
    }
}