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
		public static int diskiteBoss = -1;
		public static int dirtballBoss = -1;
		public static int metelordBoss = -1;
        public override void HitEffect(NPC npc, NPC.HitInfo hit) {
            if (npc.type == NPCID.Plantera && npc.life < 1 && !NPC.downedPlantBoss)
				ProjectileHelpers.NewNetProjectile(npc.GetSource_FromThis(), npc.Center, new Vector2(0, 0), ProjectileType<Projectiles.PlanteraElementalGel>(), 0, 0, Main.myPlayer, BasicNetType: 2);
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			if (npc.type == NPCID.Harpy)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Yoyos.GlazingStar>(), 75), new CommonDrop(ItemType<Items.Yoyos.GlazingStar>(), 65)));
			if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Materials.BloodySpiderLeg>(), 8), new CommonDrop(ItemType<Items.Materials.BloodySpiderLeg>(), 6)));
			if (npc.type == NPCID.KingSlime) {
				npcLoot.Add(new CommonDrop(ItemID.GoldCrown, 3));
				npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 12, 30));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Materials.SlimyCore>(), 1, 8, 12), new CommonDrop(ItemType<Items.Materials.SlimyCore>(), 1, 10, 15)));
			}
			if (npc.type == NPCID.EyeofCthulhu) {
				npcLoot.Add(new CommonDrop(ItemType<Items.Yoyos.Insomnia>(), 3));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Lens, 1, 3, 5), new CommonDrop(ItemID.Lens, 1, 4, 6)));
				if (WorldGen.crimson)
					npcLoot.Add(new CommonDrop(ItemType<Items.Ammo.BloodiedArrow>(), 1, 20, 50, 1));
            }
			if (npc.type == NPCID.EaterofWorldsHead) {
				npcLoot.Add(new CommonDrop(ItemID.WormTooth, 3, 1, 2, 2));
            }
			if (npc.type == NPCID.Creeper) {
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.BloodySpiderLeg>(), 6));
            }
			if (npc.type == NPCID.QueenBee) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Stinger, 1, 3, 6), new CommonDrop(ItemID.Stinger, 1, 4, 7)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Blowpipes.Beepipe>(), 3), new CommonDrop(ItemType<Items.Blowpipes.Beepipe>(), 2)));
			}
			if (npc.type == NPCID.SkeletronHead)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Bone, 1, 20, 30), new CommonDrop(ItemID.Bone, 1, 30, 40)));
			//if (NPC.downedBoss3 && (npc.type == NPCID.Skeleton || npc.type == NPCID.SkeletonAlien || npc.type == NPCID.SkeletonArcher || npc.type == NPCID.SkeletonAstonaut || npc.type == NPCID.SkeletonSniper || npc.type == NPCID.ArmoredSkeleton || npc.type == NPCID.BigHeadacheSkeleton || npc.type == NPCID.BigMisassembledSkeleton || npc.type == NPCID.BigPantlessSkeleton || npc.type == NPCID.BigSkeleton || npc.type == NPCID.HeadacheSkeleton || npc.type == NPCID.HeadacheSkeleton|| npc.type == NPCID.MisassembledSkeleton || npc.type == NPCID.PantlessSkeleton || npc.type == NPCID.SmallHeadacheSkeleton || npc.type == NPCID.SmallMisassembledSkeleton || npc.type == NPCID.SmallPantlessSkeleton|| npc.type == NPCID.SmallSkeleton || npc.type == NPCID.SporeSkeleton))
			//	npcLoot.Add(new CommonDrop(ItemID.Bone, 1, 1, 3));
			/*if (npc.type == NPCID.WallofFlesh) {
				npcLoot.Add(ItemDropRule.OneFromOptions(2, ItemType<Items.Blowpipes.FamiliarFoamDartPistol>(), ItemType<Items.Misc.MagnificentOrb>()));
            }*/
			if (npc.type == NPCID.BloodNautilus) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Swords.Dreadclawtilus>(), 5), new CommonDrop(ItemType<Items.Swords.Dreadclawtilus>(), 4)));
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.BloodDroplet>(), 1, 3, 6));
			}
			if (npc.type == NPCID.Spazmatism)
				ItemDropRule.ByCondition(new Conditions.MissingTwin(), ItemType<Items.Minions.SpazmaticScythe>(), 4);
			if (npc.type == NPCID.Plantera) {
				npcLoot.Add(new CommonDrop(ItemID.JungleRose, 3));
				npcLoot.Add(new CommonDrop(ItemID.NaturesGift, 3));
				npcLoot.Add(new CommonDrop(ItemID.ChlorophyteOre, 1, 20, 30));
			}
			if (npc.type == NPCID.Golem)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Spears.LihzahrdLance>(), 4), new CommonDrop(ItemType<Items.Spears.LihzahrdLance>(), 3)));
			/*if (npc.type == NPCID.MoonLordCore) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Blowpipes.RoxinBlowgun>(), 3), new CommonDrop(ItemType<Items.Blowpipes.RoxinBlowgun>(), 2)));
            }*/
			if (npc.type == NPCID.MossHornet) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Stinger, 2), new CommonDrop(ItemID.Stinger, 1)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Vine, 5), new CommonDrop(ItemID.Vine, 4)));
            }
			if (npc.type == NPCID.SeekerHead) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.RottenChunk, 1, 1, 3), new CommonDrop(ItemID.RottenChunk, 1, 2, 4)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.WormTooth, 1, 3, 9), new CommonDrop(ItemID.WormTooth, 1, 5, 11)));
            }
			if (npc.type == NPCID.GoblinSorcerer) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Tomes.ChaosCaster>(), 15), new CommonDrop(ItemType<Items.Tomes.ChaosCaster>(), 18)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.HexNecklace>(), 20), new CommonDrop(ItemType<Items.Accessories.HexNecklace>(), 25)));
			}
			if (npc.type == NPCID.IceBat || npc.type == NPCID.SnowFlinx || npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.UndeadViking)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Tomes.Snowfall>(), 100), new CommonDrop(ItemType<Items.Tomes.Snowfall>(), 90)));
			if ((npc.type == NPCID.Hornet) || (npc.type >= NPCID.HornetFatty && npc.type <= NPCID.HornetStingy) || (npc.type >= -56 && npc.type <= -65) || (npc.type == -16) || (npc.type == -17))
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Food.CocoaBeans>(), 30), new CommonDrop(ItemType<Items.Food.CocoaBeans>(), 25)));
			if (npc.type == NPCID.GreenSlime || npc.type == NPCID.BlueSlime || npc.type == NPCID.RedSlime || npc.type == NPCID.YellowSlime || npc.type == NPCID.BlackSlime || npc.type == NPCID.MotherSlime)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.SlimePendant>(), 150), new CommonDrop(ItemType<Items.Accessories.SlimePendant>(), 125)));
			if (npc.type == NPCID.WindyBalloon || npc.type == NPCID.Dandelion)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Materials.WindEssence>(), 3, 1, 2), new CommonDrop(ItemType<Items.Materials.WindEssence>(), 2, 1, 2)));
<<<<<<< HEAD
			if ((npc.type == 2) || (npc.type >= -43 && npc.type <= -38) || (npc.type >= 190 && npc.type <= 194) || (npc.type == 317) || (npc.type == 318))
=======
			if ((npc.type == NPCID.DemonEye) || (npc.type >= -43 && npc.type <= -38) || (npc.type >= NPCID.CataractEye && npc.type <= NPCID.PurpleEye) || (npc.type == NPCID.DemonEyeOwl) || (npc.type == NPCID.DemonEyeSpaceship))
>>>>>>> ProjectClash
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.GlazedLens>(), 100), new CommonDrop(ItemType<Items.Accessories.GlazedLens>(), 90)));
			if (npc.type == NPCID.UndeadMiner || npc.type == NPCID.GiantWormHead)
				npcLoot.Add(new CommonDrop(ItemType<Items.Accessories.ExtraShinyOreNugget>(), 30));
			if (npc.type == NPCID.CaveBat || npc.type == NPCID.BlackSlime)
				npcLoot.Add(new CommonDrop(ItemType<Items.Accessories.ExtraShinyOreNugget>(), 250));
			if (npc.type == NPCID.WindyBalloon || npc.type == NPCID.Dandelion)
				npcLoot.Add(new CommonDrop(ItemType<Items.Food.CottonCandy>(), 100));
			if (npc.type == NPCID.AngryBones || (npc.type >= NPCID.AngryBonesBig && npc.type <= NPCID.AngryBonesBigHelmet) || npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster)
				npcLoot.Add(new CommonDrop(ItemType<Items.Wands.SpareLeg>(), 400));
			if (npc.type == NPCID.Demon || npc.type == NPCID.VoodooDemon)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.NightmareCatcher>(), 125), new CommonDrop(ItemType<Items.Accessories.NightmareCatcher>(), 100)));
			if (npc.type == NPCID.BlackRecluse || npc.type == NPCID.BlackRecluseWall || npc.type == NPCID.JungleCreeper || npc.type == NPCID.JungleCreeperWall || npc.type == NPCID.DesertScorpionWalk || npc.type == NPCID.DesertScorpionWall)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.VenomousPills>(), 50), new CommonDrop(ItemType<Items.Accessories.VenomousPills>(), 40)));
			if (npc.type == NPCID.WyvernHead)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Bows.WyvernsCall>(), 10), new CommonDrop(ItemType<Items.Bows.WyvernsCall>(), 9)));
			if (npc.type == NPCID.Skeleton || npc.type == NPCID.SkeletonAlien || npc.type == NPCID.SkeletonArcher || npc.type == NPCID.SkeletonAstonaut || npc.type == NPCID.SkeletonSniper || npc.type == NPCID.ArmoredSkeleton || npc.type == NPCID.BigHeadacheSkeleton || npc.type == NPCID.BigMisassembledSkeleton || npc.type == NPCID.BigPantlessSkeleton || npc.type == NPCID.BigSkeleton || npc.type == NPCID.HeadacheSkeleton || npc.type == NPCID.HeadacheSkeleton|| npc.type == NPCID.MisassembledSkeleton || npc.type == NPCID.PantlessSkeleton || npc.type == NPCID.SmallHeadacheSkeleton || npc.type == NPCID.SmallMisassembledSkeleton || npc.type == NPCID.SmallPantlessSkeleton|| npc.type == NPCID.SmallSkeleton || npc.type == NPCID.SporeSkeleton)
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.ObeliskShard>(), 2, 1, 2));
			if (npc.type == NPCID.GoblinSummoner || npc.type == NPCID.RuneWizard)
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.TabooEssence>(), 1, 6, 12));
			if (npc.type == NPCID.GoblinSorcerer)
				ItemDropRule.ByCondition(new Conditions.IsHardmode(), ItemType<Items.Materials.TabooEssence>(), 2, 1, 2);
			if (npc.type == NPCID.GoblinPeon || npc.type == NPCID.GoblinArcher || npc.type == NPCID.GoblinScout || npc.type == NPCID.GoblinSorcerer || npc.type == NPCID.GoblinThief || npc.type == NPCID.GoblinWarrior)
				npcLoot.Add(new CommonDrop(ItemID.TatteredCloth, 4));
			if (npc.type == NPCID.ToxicSludge || npc.type == NPCID.MossHornet || npc.type == NPCID.BigMossHornet || npc.type == NPCID.TinyMossHornet || npc.type == NPCID.LittleMossHornet || npc.type == NPCID.GiantMossHornet)
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.Oozeberry>(), 1, 1, 3));
			if (npc.type == NPCID.RedDevil)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Boomerangs.Pentagram>(), 33), new CommonDrop(ItemType<Items.Boomerangs.Pentagram>(), 25)));
			if (npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.IceBat)
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.EnchantedIceCube>(), 1, 1, 2));
			if (npc.type == NPCID.Werewolf || npc.type == NPCID.Wolf)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.SaberTooth>(), 100), new CommonDrop(ItemType<Items.Accessories.SaberTooth>(), 80)));
			if (npc.type == NPCID.GoblinScout)
				npcLoot.Add(new CommonDrop(ItemID.Goggles, 5));
			if (npc.type == NPCID.GoblinThief) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Aglet, 50), new CommonDrop(ItemID.Aglet, 60)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.AnkletoftheWind, 75), new CommonDrop(ItemID.AnkletoftheWind, 90)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.HermesBoots, 100), new CommonDrop(ItemID.HermesBoots, 120)));
            }
			if (npc.type == NPCID.GoblinPeon) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Compass, 80), new CommonDrop(ItemID.Compass, 100)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.DepthMeter, 80), new CommonDrop(ItemID.DepthMeter, 100)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.GoldWatch, 80), new CommonDrop(ItemID.GoldWatch, 100)));
            }
			if (npc.type == NPCID.GoblinWarrior) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.IronBand>(), 75), new CommonDrop(ItemType<Items.Accessories.IronBand>(), 100)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.WarriorsRibbon>(), 20), new CommonDrop(ItemType<Items.Accessories.WarriorsRibbon>(), 35)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Shackle, 50), new CommonDrop(ItemID.Shackle, 60)));
            }
			if (npc.type == NPCID.GoblinArcher) {
				npcLoot.Add(new CommonDrop(ItemID.WoodenArrow, 1, 3, 7));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Bows.GoblinArchbow>(), 20), new CommonDrop(ItemType<Items.Bows.GoblinArchbow>(), 30)));
            }
			//if (npc.type == NPCID.Demon || npc.type == NPCID.VoodooDemon) //too similar to nightmare catcher
			//	npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.BloodContract>(), 50), new CommonDrop(ItemType<Items.Accessories.BloodContract>(), 40)));
		}
        public override void ModifyGlobalLoot(GlobalLoot globalLoot) {
            //globalLoot.Add(ItemDropRule.ByCondition(new Conditions.WindyEnoughForKiteDrops(), ItemType<Items.Materials.WindEssence>(), 5));
			globalLoot.Add(ItemDropRule.ByCondition(new Conditions.IsBloodMoonAndNotFromStatue(), ItemType<Items.Materials.BloodDroplet>(), 6));
		}
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items) {

            if (npc.type == NPCID.Dryad) {
				for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].type == ItemID.None)
                    {
						items[i].SetDefaults(ItemID.Seed);
						items[i].shopCustomPrice = 4;
						break;
                    }
                }
			}
			if (npc.type == NPCID.WitchDoctor) {
				for (int i = 0; i < items.Length; i++)
				{
					if (items[i].type == ItemID.None)
					{
						items[i].SetDefaults(ItemID.PoisonDart);
						items[i].shopCustomPrice = 7;
						break;
					}
				}
				if (Main.hardMode) {
					shop.item[nextSlot].SetDefaults(ItemType<Items.Blowpipes.FamiliarFoamDartPistol>());
						nextSlot++;
                }
			}
<<<<<<< HEAD
			if (type == NPCID.Merchant) {
				if (ZylonWorldCheckSystem.downedDirtball) {
					shop.item[nextSlot].SetDefaults(ItemType<Items.Tools.TreeWhacker>());
					nextSlot++;
				}
			}
=======
			if (npc.type == NPCID.Demolitionist) {
				for (int i = 0; i < items.Length; i++)
				{
					if (items[i].type == ItemID.None)
					{
						items[i].SetDefaults(ItemType<Items.Ammo.PocketGrenade>());
						break;
					}
				}
			}
			if (npc.type == NPCID.ArmsDealer) {
				if (NPC.downedBoss2) {
					if (Main.hardMode || !Main.dayTime) {
						for (int i = 0; i < items.Length; i++)
						{
							if (items[i].type == ItemID.None)
							{
								items[i].SetDefaults(ItemType<Items.Ammo.BloodiedArrow>());
								break;
							}
						}
					}
				}
				if (Main.hardMode) {
					for (int i = 0; i < items.Length; i++)
					{
						if (items[i].type == ItemID.None)
						{
							items[i].SetDefaults(ItemType<Items.Blowpipes.FamiliarFoamDartPistol>());
							break;
						}
					}
                }
			}
			if (npc.type == NPCID.Merchant) {
				if (ZylonWorldCheckSystem.downedDirtball) {
					for (int i = 0; i < items.Length; i++)
					{
						if (items[i].type == ItemID.None)
						{
							items[i].SetDefaults(ItemType<Items.Tools.TreeWhacker>());
							break;
						}
					}
				}
			}
>>>>>>> ProjectClash
			/*if (type == NPCID.Wizard) {
				shop.item[nextSlot].SetDefaults(ItemType<Items.Misc.MagnificentOrb>());
				nextSlot++;
			}*/
        }
        public override void SetupTravelShop(int[] shop, ref int nextSlot) {
            if (Main.rand.NextFloat() < .5f) {
				if (Main.rand.NextBool()) shop[nextSlot] = ItemType<Items.Ammo.OverclockArrow>();
				else shop[nextSlot] = ItemType<Items.Accessories.IronfistMedal>();
				nextSlot++;
			}
			if (Main.rand.NextFloat() < .5f && Main.hardMode) {
				if (Main.rand.NextBool()) shop[nextSlot] = ItemType<Items.Flails.StickyHand>();
				else shop[nextSlot] = ItemType<Items.Accessories.AirTank>();
				nextSlot++;
			}
        }
    }
}