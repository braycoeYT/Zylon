using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Zylon.Items.Wands;

namespace Zylon.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Hitman : ModNPC
	{
		public const string ShopName = "Shop";
		public override void SetStaticDefaults() {
			Main.npcFrameCount[Type] = 25;

			NPCID.Sets.ExtraFramesCount[Type] = 9;
			NPCID.Sets.AttackFrameCount[Type] = 4;
			NPCID.Sets.DangerDetectRange[Type] = 400;
			NPCID.Sets.AttackType[Type] = 1;
			NPCID.Sets.AttackTime[Type] = 23;
			NPCID.Sets.AttackAverageChance[Type] = 1;
			//NPCID.Sets.HatOffsetY[Type] = 4;

			/*NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Velocity = 1f,
				Direction = -1
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);*/

			NPC.Happiness
				.SetBiomeAffection<DungeonBiome>(AffectionLevel.Love)
				.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Love)
				.SetBiomeAffection<MushroomBiome>(AffectionLevel.Like)
				.SetBiomeAffection<JungleBiome>(AffectionLevel.Like)
				.SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Hate)
				.SetBiomeAffection<HallowBiome>(AffectionLevel.Hate)

				.SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Love)
				.SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Like)
				.SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Like)
				.SetNPCAffection(NPCID.Princess, AffectionLevel.Dislike)
				.SetNPCAffection(NPCID.Truffle, AffectionLevel.Dislike)
				.SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Dislike)
				.SetNPCAffection(NPCID.Guide, AffectionLevel.Hate)
				.SetNPCAffection(NPCID.Angler, AffectionLevel.Hate)
			;
		}
		public override void SetDefaults() {
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			AnimationType = NPCID.Guide;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("A ruthless assassin who has sacrified his morals in exchange for massive wads of cash."),
			});
		}
        public override bool CanTownNPCSpawn(int numTownNPCs) {
            return ZylonWorldCheckSystem.downedBloodMoon;
		}
        public override ITownNPCProfile TownNPCProfile() {
			return new HitmanProfile();
		}
		public override List<string> SetNPCNameList() {
			return new List<string>() {
				"James",
				"Smith",
				"Jason",
				"Tony",
				"Sandiego",
				"John",
				"Frank",
				"Bryan",
				"Liam",
				"Scabface",
				"Vito",
				"Al"
			};
		}
		public override string GetChat() {
			WeightedRandom<string> chat = new WeightedRandom<string>();
			chat.Add(Language.GetTextValue("Hey, I'm walkin' here!"));
			chat.Add(Language.GetTextValue("Have you seen da...ah, forget about it."));
			chat.Add(Language.GetTextValue("If you got da money, I'll do ya dirty work."));
			chat.Add(Language.GetTextValue("I aughta grab a slice before I head out for mah next job."));
			chat.Add(Language.GetTextValue("Whaddya want?"));
			chat.Add(Language.GetTextValue("It's about time ya showed up."));
			chat.Add(Language.GetTextValue("Before ya ask, I ain't had nuthin' ta do wif it."));
			chat.Add(Language.GetTextValue("Folks always schvitz whenever I'm around."));
			if (NPC.downedMoonlord && !ZylonWorldCheckSystem.downedSabur)
				chat.Add(Language.GetTextValue("Dis 'Sabur Rex' fella I keep hearin' about seems like a bit of un assassin 'imself."), 2);
			if (!Main.dayTime)
				chat.Add(Language.GetTextValue("Watch yaself, it's da perfect time for butchering."), 2);
			if (Main.bloodMoon)
				chat.Add(Language.GetTextValue("If anyone asks, da blood zombies were extra vicious tunight."), 3);
			if ((float)Main.player[Main.myPlayer].statLife/Main.player[Main.myPlayer].statLifeMax2 < 0.5f)
				chat.Add(Language.GetTextValue("Somethin' da matter with ya? You ain't lookin' so hot."), 6);
			if (NPC.HasBuff(BuffID.Wet) || NPC.HasBuff(BuffID.Slimed) || NPC.HasBuff(BuffID.Stinky) || NPC.HasBuff(BuffID.Lovestruck))
				chat.Add(Language.GetTextValue("I ain't appreciatin' dis monkey business yur throwin' at me. Come back when you ain't trippin' so hard."), 6);
			return chat;
		}
		int mode = 0;
		int count = -1;
		String killName;
		bool suicide;
		public override void SetChatButtons(ref string button, ref string button2) {
			if (mode == 0) button = Language.GetTextValue("LegacyInterface.28");
			else {
				button = "Kill " + killName + " (5 gold)";
			}
			button2 = Language.GetTextValue("Cycle");
		}
		public override void OnChatButtonClicked(bool firstButton, ref string shopName) {
			if (firstButton) {
				if (mode == 0) {
					shopName = "Shop";
				}
				else if (Main.npc[count] != null && Main.npc[count].townNPC) {
					int cost = (int)(50000*NPC.Happiness.NpcType);

					if (Main.player[Main.myPlayer].BuyItem(50000)) {
						SoundEngine.PlaySound(SoundID.Coins, NPC.Center);

						if (Main.npc[count].whoAmI == NPC.whoAmI) {
							String line = NPC.FullName + " had his priorities straight.";
							Main.NewText(line, 255, 25, 25);
							SoundEngine.PlaySound(NPC.DeathSound, NPC.Center);
							suicide = true;

							HurtEffects(true);
						}
						else {
							Main.npc[count].StrikeInstantKill();
							CycleNext();
						}

						Main.npcChatText = $"Da job is done. I made sure dey won't suspect a thing outta us two.";
						//mode = 0;
					}
					else Main.npcChatText = $"Whaddya think we doin', playin' around here? Come back when you got da real dough.";
				}
			}
			else { //Shuffle options.
				CycleNext();
			}
		}
        public override void AddShops() {
            var npcShop = new NPCShop(Type, ShopName)
				.Add<Items.Accessories.BrassRing>()
				.Add(ItemID.BloodyMachete)
				.Add<Items.Ammo.AssassinsArrow>()
				.Add<Items.Ammo.AssassinsBullet>()
				.Add<Items.Ammo.AssassinsDart>()
				.Add<Items.Accessories.BloodContract>(Condition.DownedEyeOfCthulhu)
				.Add<Items.Accessories.AccursedHand>(Condition.DownedSkeletron)
				.Add(ItemID.PsychoKnife, Condition.DownedCultist)
				.Add(ItemID.RifleScope, Condition.DownedCultist)
				.Add<Items.Bows.AssassinsGreatbow>(Condition.DownedMoonLord);
			npcShop.Register();
        }
        public override bool PreAI() {
			if (suicide) { NPC.active = false; suicide = false; }
            return true;
        }
        private void CycleNext() {
			mode = 1;
			bool endofCycle = false;
			count++;
			while (count != -1 && (Main.npc[count] == null || !Main.npc[count].active || !Main.npc[count].townNPC)) {
				count++;
				if (count >= Main.maxNPCs) { count = -1; endofCycle = true; mode = 0; }
			}
			if (!endofCycle) killName = Main.npc[count].TypeName;

			//Main.NewText(count);
		}
        public override void ModifyNPCLoot(NPCLoot npcLoot) {
            npcLoot.Add(new CommonDrop(ItemID.MusketBall, 6, 20, 30));
        }
		public override void HitEffect(NPC.HitInfo hit) {
			HurtEffects(NPC.life < 1);
		}
		private void HurtEffects(bool dead) {
			int num = dead ? 25 : 3;

			for (int k = 0; k < num; k++) {
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Blood);
				dust.scale = Main.rand.NextFloat(0.5f, 1f);
			}

			if (Main.netMode != NetmodeID.Server && NPC.life <= 0) {
				int hatGore = NPC.GetPartyHatGore();

				if (hatGore > 0) {
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, hatGore);
				}
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, ModContent.GoreType<Gores.TownNPCs.Hitman_GoreHead>());
				Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, ModContent.GoreType<Gores.TownNPCs.Hitman_GoreArm>());
				Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, ModContent.GoreType<Gores.TownNPCs.Hitman_GoreArm>());
				Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, ModContent.GoreType<Gores.TownNPCs.Hitman_GoreLeg>());
				Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, ModContent.GoreType<Gores.TownNPCs.Hitman_GoreLeg>());
			}
		}
        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;
		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 10;
			knockback = 1f;
			if (Main.hardMode) {
				damage = 30;
				knockback = 4f;
			}
		}
		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 3;
			randExtraCooldown = 3;
			if (Main.hardMode) {
				cooldown = 100;
				randExtraCooldown = 3;
			}
		}
		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileID.SilverBullet;
			attackDelay = 1;
			if (Main.hardMode) {
				projType = ProjectileID.ExplosiveBullet;
			}
		}
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 9f;
			randomOffset = 1f;
		}
        public override void DrawTownAttackGun(ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset) {
			int itemType = ItemID.Handgun;
			if (Main.hardMode) itemType = ItemID.SniperRifle;
            Main.GetItemDrawFrame(itemType, out item, out itemFrame);
			horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(1f, itemType).X - 4;
        }
    }
	public class HitmanProfile : ITownNPCProfile
	{
		public int RollVariation() => 0;
		public string GetNameForVariant(NPC npc) => npc.getNewNPCName();
		public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) {
			/*if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
				return ModContent.Request<Texture2D>("ExampleMod/Content/NPCs/ExamplePerson");

			if (npc.altTexture == 1)
				return ModContent.Request<Texture2D>("ExampleMod/Content/NPCs/ExamplePerson_Party");*/

			return ModContent.Request<Texture2D>("Zylon/NPCs/TownNPCs/Hitman");
		}
		public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("Zylon/NPCs/TownNPCs/Hitman_Head");
	}
}