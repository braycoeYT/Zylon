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
		public static int adenebBoss = -1;
		public static int dirtballBoss = -1;
		public static int elemFluxBoss = -1;
		public static int saburBoss = -1;
		public static int scavengerBoss = -1;

		//For the boss to manage.
		public static Color elemFluxMain;
		public static Color elemFluxSecond;
		//For projectiles to match the boss.
		public static Color elemFluxTransition;
		public static Color elemFluxTransition2;
		public static Color elemFluxRealMain;
		public static Color elemFluxRealSecond;
        public override void SetDefaults(NPC entity) {
			if (WorldGen.currentWorldSeed == null) return;
            if (WorldGen.currentWorldSeed.ToLower() == "abyssworld" || WorldGen.currentWorldSeed.ToLower() == "flopside pit") {
				if (Main.netMode != NetmodeID.MultiplayerClient) entity.color = new Color(0, 0, 0, 255);
				if (entity.friendly) {
					entity.lifeMax /= 5;
					entity.life = entity.lifeMax;
				}
			}
			if (entity.boss && entity.type < 688) {
				entity.lifeMax = (int)(entity.lifeMax*GetInstance<ZylonConfig>().vanillaBossHpMult);
			}
        }
        public override void PostAI(NPC npc) {
			if (Main.netMode != NetmodeID.MultiplayerClient) {
			    if (WorldGen.currentWorldSeed.ToLower() == "abyssworld" || WorldGen.currentWorldSeed.ToLower() == "flopside pit") {
					npc.color = new Color(0, 0, 0, 255);
				}
				if (WorldGen.currentWorldSeed.ToLower() == "autumn") {
					if (npc.type == -25 || npc.type == -24 || (npc.type > -11 && npc.type < 0) || npc.type == NPCID.BlueSlime || npc.type == NPCID.IceSlime || npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.SandSlime || npc.type == NPCID.SpikedJungleSlime || npc.type == NPCID.BabySlime || npc.type == NPCID.LavaSlime || npc.type == NPCID.GoldenSlime || npc.type == NPCID.SlimeSpiked || npc.type == NPCID.ShimmerSlime || npc.type == NPCID.SlimeMasked || (npc.type > 332 && npc.type < 337) || npc.type == NPCID.Crimslime || npc.type == NPCID.IlluminantSlime || npc.type == NPCID.RainbowSlime || npc.type == NPCID.QueenSlimeMinionBlue || npc.type == NPCID.QueenSlimeMinionPink || npc.type == NPCID.QueenSlimeMinionPurple || npc.type == ModContent.NPCType<NPCs.Forest.DirtSlime>() || npc.type == ModContent.NPCType<ElemSlime>() || npc.type == ModContent.NPCType<NPCs.Sky.Stratoslime>() || npc.type == NPCID.Slimer2 || npc.type == ModContent.NPCType<NPCs.Dungeon.BoneSlime>() || npc.type == NPCID.MotherSlime || npc.type == NPCID.DungeonSlime || npc.type == NPCID.UmbrellaSlime || npc.type == NPCID.ToxicSludge || npc.type == NPCID.CorruptSlime || npc.type == NPCID.Slimer || npc.type == NPCID.HoppinJack || npc.type == NPCID.KingSlime || npc.type == NPCID.QueenSlimeBoss) {
						npc.color = Color.Orange;
					}
				}
			}
        }
        public override void HitEffect(NPC npc, NPC.HitInfo hit) {
			if (npc.type == NPCID.WallofFlesh && npc.life < 1 && !Main.hardMode)
				Item.NewItem(npc.GetSource_FromThis(), npc.getRect(), ItemType<Items.Misc.WinkofRadias>());
            if (npc.type == NPCID.Plantera && npc.life < 1 && !NPC.downedPlantBoss)
				ProjectileHelpers.NewNetProjectile(npc.GetSource_FromThis(), npc.Center, new Vector2(0, 0), ProjectileType<Projectiles.PlanteraElementalGel>(), 0, 0, Main.myPlayer, BasicNetType: 2);
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			if (npc.type == NPCID.Harpy) {
				//npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 1, 1, 2));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Yoyos.GlazingStar>(), 55), new CommonDrop(ItemType<Items.Yoyos.GlazingStar>(), 40)));
			}
			if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Materials.BloodySpiderLeg>(), 8), new CommonDrop(ItemType<Items.Materials.BloodySpiderLeg>(), 6)));
			if (npc.type == NPCID.KingSlime) {
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.GoldCrown, 3));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemType<Items.Accessories.SlimyShell>(), 3));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Gel, 1, 12, 30));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemType<Items.Materials.SlimyCore>(), 1, 8, 12));
            }
			if (npc.type == NPCID.EyeofCthulhu) {
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemType<Items.Yoyos.Insomnia>(), 3));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemType<Items.Whips.EyeLash>(), 3));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Lens, 1, 3, 5));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsCrimsonAndNotExpert(), ItemType<Items.Ammo.BloodiedArrow>(), 1, 20, 50, 1)); //Weirdly convienient condition but alright
            }
			if (npc.type == NPCID.EaterofWorldsHead) {
				npcLoot.Add(new CommonDrop(ItemID.WormTooth, 3, 1, 2, 2));
            }
			if (npc.type == NPCID.Creeper) {
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.BloodySpiderLeg>(), 6));
            }
			if (npc.type == NPCID.QueenBee) {
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Stinger, 1, 3, 5));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemType<Items.Blowpipes.Beepipe>(), 3));
			}
			if (npc.type == NPCID.SkeletronHead) {
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemType<Items.Accessories.RuneofMultiplicity>(), 4));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Bone, 1, 10, 15));
			}
			//if (NPC.downedBoss3 && (npc.type == NPCID.Skeleton || npc.type == NPCID.SkeletonAlien || npc.type == NPCID.SkeletonArcher || npc.type == NPCID.SkeletonAstonaut || npc.type == NPCID.SkeletonSniper || npc.type == NPCID.ArmoredSkeleton || npc.type == NPCID.BigHeadacheSkeleton || npc.type == NPCID.BigMisassembledSkeleton || npc.type == NPCID.BigPantlessSkeleton || npc.type == NPCID.BigSkeleton || npc.type == NPCID.HeadacheSkeleton || npc.type == NPCID.HeadacheSkeleton|| npc.type == NPCID.MisassembledSkeleton || npc.type == NPCID.PantlessSkeleton || npc.type == NPCID.SmallHeadacheSkeleton || npc.type == NPCID.SmallMisassembledSkeleton || npc.type == NPCID.SmallPantlessSkeleton|| npc.type == NPCID.SmallSkeleton || npc.type == NPCID.SporeSkeleton))
			//	npcLoot.Add(new CommonDrop(ItemID.Bone, 1, 1, 3));
			if (npc.type == NPCID.WallofFlesh) {
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Hellstone, 1, 15, 25));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.DemonConch, 4));
            }
			/*if (npc.type == NPCID.WallofFlesh) {
				npcLoot.Add(ItemDropRule.OneFromOptions(2, ItemType<Items.Blowpipes.FamiliarFoamDartPistol>(), ItemType<Items.Misc.MagnificentOrb>()));
            }*/
			if (npc.type == NPCID.BloodNautilus) {
				//npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Swords.Dreadclawtilus>(), 5), new CommonDrop(ItemType<Items.Swords.Dreadclawtilus>(), 4)));
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.BloodDroplet>(), 1, 3, 6));
			}
			/*if (npc.type == NPCID.Spazmatism) {
				LeadingConditionRule leadingConditionRule = new LeadingConditionRule(new Conditions.NotExpert());
				leadingConditionRule.OnSuccess(ItemDropRule.ByCondition(new Conditions.MissingTwin(), ItemType<Items.Minions.SpazmaticScythe>(), 4));
            }*/
			if (npc.type == NPCID.Plantera) {
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.JungleRose, 3));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.NaturesGift, 3));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemType<Items.Accessories.SucculentSap>(), 3));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.ChlorophyteOre, 1, 20, 30));
			}
			if (npc.type == NPCID.Golem)
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemType<Items.Spears.LihzahrdLance>(), 4));
			/*if (npc.type == NPCID.MoonLordCore) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Blowpipes.RoxinBlowgun>(), 3), new CommonDrop(ItemType<Items.Blowpipes.RoxinBlowgun>(), 2)));
            }*/
			if (npc.type == NPCID.MossHornet) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Stinger, 2), new CommonDrop(ItemID.Stinger, 1)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Vine, 5), new CommonDrop(ItemID.Vine, 4)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Food.CocoaBeans>(), 15), new CommonDrop(ItemType<Items.Food.CocoaBeans>(), 10)));
            }
			if (npc.type == NPCID.SeekerHead) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.RottenChunk, 1, 1, 3), new CommonDrop(ItemID.RottenChunk, 1, 2, 4)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.WormTooth, 1, 3, 9), new CommonDrop(ItemID.WormTooth, 1, 5, 11)));
            }
			//if (npc.type == NPCID.IceBat || npc.type == NPCID.SnowFlinx || npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.UndeadViking)
			//	npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Tomes.Snowfall>(), 100), new CommonDrop(ItemType<Items.Tomes.Snowfall>(), 90)));
			if ((npc.type == NPCID.Hornet) || (npc.type >= NPCID.HornetFatty && npc.type <= NPCID.HornetStingy) || (npc.type >= -56 && npc.type <= -65) || (npc.type == -16) || (npc.type == -17))
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Food.CocoaBeans>(), 15), new CommonDrop(ItemType<Items.Food.CocoaBeans>(), 10)));
			//if (npc.type == NPCID.GreenSlime || npc.type == NPCID.BlueSlime || npc.type == NPCID.RedSlime || npc.type == NPCID.YellowSlime || npc.type == NPCID.BlackSlime || npc.type == NPCID.MotherSlime)
			//	npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.SlimePendant>(), 150), new CommonDrop(ItemType<Items.Accessories.SlimePendant>(), 125)));
			if (npc.type == NPCID.WindyBalloon || npc.type == NPCID.Dandelion)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Materials.WindEssence>(), 3, 1, 2), new CommonDrop(ItemType<Items.Materials.WindEssence>(), 2, 1, 2)));
			if ((npc.type == NPCID.DemonEye) || (npc.type >= -43 && npc.type <= -38) || (npc.type >= NPCID.CataractEye && npc.type <= NPCID.PurpleEye) || (npc.type == NPCID.DemonEyeOwl) || (npc.type == NPCID.DemonEyeSpaceship))
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.GlazedLens>(), 60), new CommonDrop(ItemType<Items.Accessories.GlazedLens>(), 50)));
			if (npc.type == NPCID.UndeadMiner || npc.type == NPCID.GiantWormHead)
				npcLoot.Add(new CommonDrop(ItemType<Items.Accessories.ExtraShinyOreNugget>(), 30));
			if (npc.type == NPCID.CaveBat || npc.type == NPCID.BlackSlime)
				npcLoot.Add(new CommonDrop(ItemType<Items.Accessories.ExtraShinyOreNugget>(), 250));
			if (npc.type == NPCID.WindyBalloon || npc.type == NPCID.Dandelion)
				npcLoot.Add(new CommonDrop(ItemType<Items.Food.CottonCandy>(), 100));
			if (npc.type == NPCID.AngryBones || (npc.type >= NPCID.AngryBonesBig && npc.type <= NPCID.AngryBonesBigHelmet) || npc.type == NPCID.CursedSkull || npc.type == NPCID.DarkCaster)
				npcLoot.Add(new CommonDrop(ItemType<Items.Wands.SpareLeg>(), 250));
			if (npc.type == NPCID.Demon || npc.type == NPCID.VoodooDemon)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.NightmareCatcher>(), 75), new CommonDrop(ItemType<Items.Accessories.NightmareCatcher>(), 50)));
			if (npc.type == NPCID.BlackRecluse || npc.type == NPCID.BlackRecluseWall || npc.type == NPCID.JungleCreeper || npc.type == NPCID.JungleCreeperWall || npc.type == NPCID.DesertScorpionWalk || npc.type == NPCID.DesertScorpionWall)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.VenomousPills>(), 50), new CommonDrop(ItemType<Items.Accessories.VenomousPills>(), 40)));
			if (npc.type == NPCID.WyvernHead)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Bows.WyvernsCall>(), 10), new CommonDrop(ItemType<Items.Bows.WyvernsCall>(), 9)));
			if (npc.type == NPCID.Skeleton || npc.type == NPCID.SkeletonAlien || npc.type == NPCID.SkeletonArcher || npc.type == NPCID.SkeletonAstonaut || npc.type == NPCID.SkeletonSniper || npc.type == NPCID.ArmoredSkeleton || npc.type == NPCID.BigHeadacheSkeleton || npc.type == NPCID.BigMisassembledSkeleton || npc.type == NPCID.BigPantlessSkeleton || npc.type == NPCID.BigSkeleton || npc.type == NPCID.HeadacheSkeleton || npc.type == NPCID.HeadacheSkeleton|| npc.type == NPCID.MisassembledSkeleton || npc.type == NPCID.PantlessSkeleton || npc.type == NPCID.SmallHeadacheSkeleton || npc.type == NPCID.SmallMisassembledSkeleton || npc.type == NPCID.SmallPantlessSkeleton|| npc.type == NPCID.SmallSkeleton || npc.type == NPCID.SporeSkeleton)
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.ObeliskShard>(), 2, 1, 2));
			if (npc.type == NPCID.GoblinSummoner || npc.type == NPCID.RuneWizard)
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.TabooEssence>(), 1, 6, 12));
			if (npc.type == NPCID.GoblinSummoner) {
				npcLoot.Add(new CommonDrop(ItemID.TatteredCloth, 1, 5, 8));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.ShadowsWink>(), 5), new CommonDrop(ItemType<Items.Accessories.ShadowsWink>(), 3)));
			}
			if (npc.type == NPCID.GoblinSorcerer)
				ItemDropRule.ByCondition(new Conditions.IsHardmode(), ItemType<Items.Materials.TabooEssence>(), 2, 1, 2);
			if (npc.type == NPCID.GoblinPeon || npc.type == NPCID.GoblinArcher || npc.type == NPCID.GoblinScout || npc.type == NPCID.GoblinSorcerer || npc.type == NPCID.GoblinThief || npc.type == NPCID.GoblinWarrior)
				npcLoot.Add(new CommonDrop(ItemID.TatteredCloth, 3));
			if (npc.type == NPCID.ToxicSludge || npc.type == NPCID.MossHornet || npc.type == NPCID.BigMossHornet || npc.type == NPCID.TinyMossHornet || npc.type == NPCID.LittleMossHornet || npc.type == NPCID.GiantMossHornet)
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.Oozeberry>(), 1, 1, 3));
			if (npc.type == NPCID.RedDevil)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Boomerangs.Pentagram>(), 25), new CommonDrop(ItemType<Items.Boomerangs.Pentagram>(), 20)));
			if (npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.IceBat)
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.EnchantedIceCube>(), 1, 2, 4));
			if (npc.type == NPCID.Werewolf || npc.type == NPCID.Wolf) {
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.WolfPelt>(), 1, 1, 3));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.SaberTooth>(), 50), new CommonDrop(ItemType<Items.Accessories.SaberTooth>(), 30)));
			}
			if (npc.type == NPCID.GoblinScout)
				npcLoot.Add(new CommonDrop(ItemID.Goggles, 5));
			if (npc.type == NPCID.GoblinThief) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Aglet, 25), new CommonDrop(ItemID.Aglet, 20)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.AnkletoftheWind, 30), new CommonDrop(ItemID.AnkletoftheWind, 25)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.HermesBoots, 30), new CommonDrop(ItemID.HermesBoots, 25)));
            }
			if (npc.type == NPCID.GoblinPeon) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Compass, 30), new CommonDrop(ItemID.Compass, 20)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.DepthMeter, 30), new CommonDrop(ItemID.DepthMeter, 20)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.GoldWatch, 30), new CommonDrop(ItemID.GoldWatch, 20)));
            }
			if (npc.type == NPCID.GoblinWarrior) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.IronBand>(), 25), new CommonDrop(ItemType<Items.Accessories.IronBand>(), 20)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.WarriorsRibbon>(), 25), new CommonDrop(ItemType<Items.Accessories.WarriorsRibbon>(), 20)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemID.Shackle, 30), new CommonDrop(ItemID.Shackle, 20)));
            }
			if (npc.type == NPCID.GoblinArcher) {
				npcLoot.Add(new CommonDrop(ItemID.WoodenArrow, 1, 3, 7));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Bows.GoblinArchbow>(), 24), new CommonDrop(ItemType<Items.Bows.GoblinArchbow>(), 18)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.LazyCap>(), 25), new CommonDrop(ItemType<Items.Accessories.LazyCap>(), 20)));
            }
			if (npc.type == NPCID.GoblinSorcerer) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Tomes.ChaosCaster>(), 24), new CommonDrop(ItemType<Items.Tomes.ChaosCaster>(), 18)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.HexNecklace>(), 25), new CommonDrop(ItemType<Items.Accessories.HexNecklace>(), 20)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.VengefulSpirit>(), 25), new CommonDrop(ItemType<Items.Accessories.VengefulSpirit>(), 20)));
			}
			if (npc.type == NPCID.BlackRecluse || npc.type == NPCID.BlackRecluseWall || npc.type == NPCID.JungleCreeper || npc.type == NPCID.JungleCreeperWall) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.ProteinSplicer>(), 50), new CommonDrop(ItemType<Items.Accessories.ProteinSplicer>(), 60)));
            }
			if (npc.type == NPCID.WallCreeperWall || npc.type == NPCID.WallCreeper) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.ProteinSplicer>(), 75), new CommonDrop(ItemType<Items.Accessories.ProteinSplicer>(), 90)));
            }
			if (npc.type == NPCID.CursedSkull) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.RuneofMultiplicity>(), 100), new CommonDrop(ItemType<Items.Accessories.RuneofMultiplicity>(), 60)));
            }
			if (npc.type == NPCID.DarkCaster) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.SorcerersKunai>(), 20), new CommonDrop(ItemType<Items.Accessories.SorcerersKunai>(), 15)));
            }
			if (npc.type == NPCID.GraniteFlyer) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.SparkingCore>(), 30), new CommonDrop(ItemType<Items.Accessories.SparkingCore>(), 20)));
            }
			if (npc.type == NPCID.Scutlix || npc.type == NPCID.ScutlixRider || npc.type == NPCID.MartianWalker || npc.type == NPCID.GigaZapper || npc.type == NPCID.MartianEngineer || npc.type == NPCID.MartianOfficer || npc.type == NPCID.RayGunner || npc.type == NPCID.GrayGrunt || npc.type == NPCID.BrainScrambler) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Whips.Giegue>(), 60), new CommonDrop(ItemType<Items.Whips.Giegue>(), 45)));
            }
			if (npc.type == -6)
				npcLoot.Add(new CommonDrop(ItemType<Items.Materials.Cerussite>(), 1, 1, 2));
			if (npc.type == -5)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Materials.Cerussite>(), 3), new CommonDrop(ItemType<Items.Materials.Cerussite>(), 2)));
			if (npc.type == NPCID.RainbowSlime) {
				npcLoot.Add(ItemDropRule.ByCondition(new ElemGelCondition(), ItemType<Items.Materials.ElementalGoop>(), 1, 2, 4));
            }
			if (npc.type == NPCID.LavaSlime || npc.type == NPCID.SpikedJungleSlime || npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.ShimmerSlime || npc.type == NPCID.ToxicSludge || npc.type == NPCID.CorruptSlime || npc.type == NPCID.Crimslime || npc.type == NPCID.BigCrimslime || npc.type == NPCID.LittleCrimslime || npc.type == NPCID.IlluminantSlime) {
				npcLoot.Add(ItemDropRule.ByCondition(new ElemGelCondition(), ItemType<Items.Materials.ElementalGoop>(), 2, 1, 2));
            }
			if (npc.type == NPCID.JungleSlime || npc.type == NPCID.IceSlime || npc.type == NPCID.SandSlime) {
				npcLoot.Add(ItemDropRule.ByCondition(new ElemGelCondition(), ItemType<Items.Materials.ElementalGoop>(), 3, 1, 2));
            }
			if (npc.type == NPCID.MartianTurret)
				npcLoot.Add(new CommonDrop(ItemType<Items.Accessories.DoublePluggedCord>(), 20));
			if (npc.type == NPCID.Parrot)
				npcLoot.Add(new CommonDrop(ItemType<Items.Food.Cracker>(), 20));
			if (npc.type == NPCID.AngryNimbus) {
				npcLoot.Add(new CommonDrop(ItemID.Cloud, 1, 5, 8));
				npcLoot.Add(new CommonDrop(ItemID.RainCloud, 1, 2, 4));
            }
			if (npc.type == NPCID.IlluminantBat || npc.type == NPCID.IlluminantSlime)
				npcLoot.Add(new CommonDrop(ItemType<Items.Accessories.IllusoryBulletPolish>(), 50));
			if (npc.type == NPCID.ChaosElemental)
				npcLoot.Add(new CommonDrop(ItemType<Items.Accessories.IllusoryBulletPolish>(), 25));
			if (npc.type == NPCID.Tim)
				npcLoot.Add(new CommonDrop(ItemType<Items.Accessories.VengefulSpirit>(), 5));
			if (npc.type == NPCID.DungeonSpirit)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.EtherealGasp>(), 40), new CommonDrop(ItemType<Items.Accessories.EtherealGasp>(), 30)));
			if (npc.type == NPCID.SkeletonArcher)
				npcLoot.Add(new CommonDrop(ItemID.BoneArrow, 50, 100, 250));
			if (npc.type == NPCID.FlyingSnake)
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Accessories.SnakeEye>(), 30), new CommonDrop(ItemType<Items.Accessories.SnakeEye>(), 25)));
			if (npc.type == NPCID.MeteorHead) {
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Ores.HaxoniteOre>(), 1, 1, 4), new CommonDrop(ItemType<Items.Ores.HaxoniteOre>(), 1, 2, 4)));
				npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ItemType<Items.Pets.PlasticDinoFigurine>(), 2000), new CommonDrop(ItemType<Items.Pets.PlasticDinoFigurine>(), 1000)));
			}
		}
        int Timer;
		bool prevNoGrav;
		public override void AI(NPC npc) {
			if (Timer == 0)
				prevNoGrav = npc.noGravity; //Trusting my 1.3 self here... bad idea?
			int projectileCount;
			for (projectileCount = 0; projectileCount < Main.maxProjectiles; projectileCount++) {
				if (Main.projectile[projectileCount].active && Main.projectile[projectileCount].type == ProjectileType<Projectiles.BlackHole>()) {
					if (Vector2.Distance(npc.Center, Main.projectile[projectileCount].Center) < 400 && !npc.boss && npc.type != NPCID.TargetDummy) {
						npc.noGravity = true;
						if (npc.Center.X > Main.projectile[projectileCount].Center.X && npc.velocity.X > -15)
							npc.velocity.X -= 2;
						if (npc.Center.X < Main.projectile[projectileCount].Center.X && npc.velocity.X < 15)
							npc.velocity.X += 2;
						if (npc.Center.Y > Main.projectile[projectileCount].Center.Y && npc.velocity.Y > -15)
							npc.velocity.Y -= 2;
						if (npc.Center.Y < Main.projectile[projectileCount].Center.Y && npc.velocity.Y < 15)
							npc.velocity.Y += 2;
						npc.netUpdate = true;
					}
					else npc.noGravity = prevNoGrav;
				}
				else npc.noGravity = prevNoGrav;
			}
		}
        public override void ModifyGlobalLoot(GlobalLoot globalLoot) {
            //globalLoot.Add(ItemDropRule.ByCondition(new Conditions.WindyEnoughForKiteDrops(), ItemType<Items.Materials.WindEssence>(), 5));
			globalLoot.Add(ItemDropRule.ByCondition(new Conditions.IsBloodMoonAndNotFromStatue(), ItemType<Items.Materials.BloodDroplet>(), 2));
		}
        //float scaleAdd;
        /*public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone) {
            if (projectile.type == ProjectileID.SlimeGun || projectile.type == ProjectileID.WaterGun) {
				if (npc.type == -25 || npc.type == -24 || (npc.type > -11 && npc.type < 0) || npc.type == NPCID.BlueSlime || npc.type == NPCID.IceSlime || npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.SandSlime || npc.type == NPCID.SpikedJungleSlime || npc.type == NPCID.BabySlime || npc.type == NPCID.LavaSlime || npc.type == NPCID.GoldenSlime || npc.type == NPCID.SlimeSpiked || npc.type == NPCID.ShimmerSlime || npc.type == NPCID.SlimeMasked || (npc.type > 332 && npc.type < 337) || npc.type == NPCID.Slimeling || npc.type == NPCID.Crimslime || npc.type == NPCID.IlluminantSlime || npc.type == NPCID.RainbowSlime || npc.type == NPCID.QueenSlimeMinionBlue || npc.type == NPCID.QueenSlimeMinionPink || npc.type == NPCID.QueenSlimeMinionPurple || npc.type == ModContent.NPCType<Forest.DirtSlime>() || npc.type == ModContent.NPCType<Forest.OrangeSlime>() || npc.type == ModContent.NPCType<ElemSlime>() || npc.type == ModContent.NPCType<Sky.Stratoslime>() || npc.type == NPCID.Slimer2) {
					scaleAdd += 0.1f;
					if (scaleAdd > 2.5f) scaleAdd = 2.5f;
				}
				if (npc.type == NPCID.MotherSlime || npc.type == NPCID.DungeonSlime || npc.type == NPCID.UmbrellaSlime || npc.type == NPCID.ToxicSludge || npc.type == NPCID.CorruptSlime || npc.type == NPCID.Slimer || npc.type == NPCID.HoppinJack) {
					scaleAdd += 0.075f;
					if (scaleAdd > 1.5f) scaleAdd = 1.5f;
				}
			}
        }*/
        /*public override void PostAI(NPC npc) { //Please don't break anything... please...
            npc.scale += scaleAdd;
        }*/
        public override void ModifyShop(NPCShop shop) {
            if (shop.NpcType == NPCID.Dryad) {
				shop.Add(new Item(ItemID.Seed) {
					shopCustomPrice = 4,
				});
			}
			if (shop.NpcType == NPCID.WitchDoctor) {
				shop.Add(new Item(ItemID.PoisonDart) {
					shopCustomPrice = 7,
				});
			}
			if (shop.NpcType == NPCID.Demolitionist) {
				shop.Add(new Item(ItemType<Items.Ammo.PocketGrenade>()));
			}
			if (shop.NpcType == NPCID.ArmsDealer) {
				shop.Add<Items.Ammo.BloodiedArrow>(Condition.TimeNight, Condition.Hardmode);
				shop.Add<Items.Ammo.BloodiedArrow>(Condition.TimeDay);
				shop.Add<Items.Ammo.Gumball>(new Condition("Mods.Zylon.Conditions.HasGunballCondition", () => Main.player[Main.myPlayer].HasItem(ItemType<Items.Guns.Gunball>())));
			}
			if (shop.NpcType == NPCID.Cyborg) {
				shop.Add(new Item(ItemType<Items.Accessories.ContinuumWarper>()));
			}
        }
        public override void SetupTravelShop(int[] shop, ref int nextSlot) {
            if (Main.rand.NextFloat() < .75f || !Main.hardMode) {
				switch (Main.rand.Next(4)) {
					case 0:
						shop[nextSlot] = ItemType<Items.Accessories.IronfistMedal>();
						break;
					case 1:
						shop[nextSlot] = ItemType<Items.Ammo.OverclockArrow>();
						break;
					case 2:
						shop[nextSlot] = ItemType<Items.Accessories.ManaBattery>();
						break;
					case 3:
						shop[nextSlot] = ItemType<Items.Accessories.ToyClaw>();
						break;
                }
				nextSlot++;
			}
			if (Main.rand.NextFloat() < .75f && Main.hardMode) {
				if (Main.rand.NextBool()) shop[nextSlot] = ItemType<Items.Flails.StickyHand>();
				else shop[nextSlot] = ItemType<Items.Accessories.AirTank>();
				nextSlot++;
			}
			if (Main.rand.NextBool(4)) {
				shop[nextSlot] = ItemType<Items.Accessories.LoadedDie>();
				nextSlot++;
			}
			else {
				int type = ItemType<Items.Bags.LotteryTicketTier1>();
				if (Main.hardMode) type = ItemType<Items.Bags.LotteryTicketTier2>();
				if (NPC.downedMoonlord) type = ItemType<Items.Bags.LotteryTicketTier3>();

				shop[nextSlot] = type;
				nextSlot++;
			}
        }
    }
}