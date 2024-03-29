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
using Terraria.ModLoader.IO;

namespace Zylon.NPCs.TownNPCs
{
	[AutoloadHead]
	public class WeaponsMaster : ModNPC
	{
		public Dictionary<int, int> TradeValues = new();

		public int NumberOfTimesTalkedTo = 0;
		public override void SetStaticDefaults() {
			Main.npcFrameCount[Type] = 25;

			NPCID.Sets.ExtraFramesCount[Type] = 9;
			NPCID.Sets.AttackFrameCount[Type] = 4;
			NPCID.Sets.DangerDetectRange[Type] = 700;
			NPCID.Sets.AttackType[Type] = 0;
			NPCID.Sets.AttackTime[Type] = 90;
			NPCID.Sets.AttackAverageChance[Type] = 30;
			//NPCID.Sets.HatOffsetY[Type] = 4;

			/*NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Velocity = 1f,
				Direction = -1
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);*/
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);

			NPC.Happiness
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Dislike)
				.SetBiomeAffection<DungeonBiome>(AffectionLevel.Love)
				.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Love)
				.SetBiomeAffection<DesertBiome>(AffectionLevel.Like)
				.SetBiomeAffection<SnowBiome>(AffectionLevel.Like)
				.SetBiomeAffection<JungleBiome>(AffectionLevel.Hate)
				.SetBiomeAffection<HallowBiome>(AffectionLevel.Like)
				.SetNPCAffection(NPCID.Merchant, AffectionLevel.Like)
				.SetNPCAffection(NPCID.Pirate, AffectionLevel.Like)
				.SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Love)
				.SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Love)
				.SetNPCAffection(NPCID.Cyborg, AffectionLevel.Love)
				.SetNPCAffection(NPCID.Dryad, AffectionLevel.Dislike)
				.SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Dislike)
				.SetNPCAffection(NPCID.Guide, AffectionLevel.Hate)
				.SetNPCAffection(633, AffectionLevel.Dislike)
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
				new FlavorTextBestiaryInfoElement("Back in the '90s, the Weapons Master used to be the protagonist of his own game. Nowadays, he gives the weapons he's found over time away in trade for the rarest trophies."),
			});
		}
		/*public override bool CanTownNPCSpawn(int numTownNPCs, int money) { // Requirements for the town NPC to spawn.
			return (NPC.downedSlimeKing || NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || Main.hardMode);
		}*/ //look here!
		public override ITownNPCProfile TownNPCProfile() {
			return new WeaponsMasterProfile();
		}
		public override List<string> SetNPCNameList() {
			return new List<string>() {
				"von Ultima",
				"Squell Tigerheart",
				"Clyde Stroff",
				"Nell",
				"Tivus",
				"Saro",
				"Au Ron",
				"Gigamax",
				"Seth I. Roth",
				"Zak",
				"Ruki",
				"Hero"
			};
		}
		public override void FindFrame(int frameHeight) {
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}
		public override string GetChat() {
			WeightedRandom<string> chat = new WeightedRandom<string>();
			chat.Add(Language.GetTextValue("You know, when I was your age, we used to take turns when fighting!"));
			chat.Add(Language.GetTextValue("Back in my day, I used to be a protagonist... Nowadays I'm just a side character!"));
			chat.Add(Language.GetTextValue("I wonder who the main character is..."));
			chat.Add(Language.GetTextValue("Give me your rare trophies, and I'll give you rare weapons I've collected from my time."), 2);
			chat.Add(Language.GetTextValue("If you aren't dealing 9999 damage with each hit, you're doing something wrong."));
			chat.Add(Language.GetTextValue("What?! There's no leveling system here?!"));
			chat.Add(Language.GetTextValue("I've heard this world allows you to deal over 4 digits of damage, but that just feels wrong."));
			chat.Add(Language.GetTextValue("Where I'm from, the healing potions healed ALL your HP!"));
			chat.Add(Language.GetTextValue("What do you mean there aren't 50 cash-grab spin-offs of this world?!"));
			chat.Add(Language.GetTextValue("Keep your eyes peeled for any narrative tropes!"));
			chat.Add(Language.GetTextValue("Why don't I instantly recover my health while sleeping?"));
			if (Main.netMode == NetmodeID.SinglePlayer) chat.Add(Language.GetTextValue("You need to recruit some more party members, hero!", 2));
			if (NPC.downedMoonlord) {
				chat.Add(Language.GetTextValue("When I came to this world, HE followed me here... HE is my nemesis, after all."));
				chat.Add(Language.GetTextValue("Every day I fear HIS return... the moon seal didn't kill HIM after all."));
			}
			if (NPC.life < NPC.lifeMax / 3) {
				chat.Add(Language.GetTextValue("My health is critically low, but I don't hear any obnoxious beeping... must be a glitch."), 5);
				chat.Add(Language.GetTextValue("Quick! Somebody cast Healaga on me!"), 5);
				chat.Add(Language.GetTextValue("If I die, I won't receive any XP after the battle! Quick!"), 5);
            }
			if (Main.bloodMoon)
				chat.Add(Language.GetTextValue("It seems that every step I take, I encounter another enemy! Reminds me of my olden days."), 5);
			if (Main.slimeRain)
				chat.Add(Language.GetTextValue("Look at all these low-level slimes! I wonder if their boss will come as well!"), 5);
			
			//Add when PML content and killed someone important
			//chat.Add(Language.GetTextValue("You and I have both slain gods at some point, no?"), 3);
			//chat.Add(Language.GetTextValue("You remind myself of a younger me: killing abominations, swinging 20-meter swords, getting ladies... well, maybe not that last part."), 3);

			return chat;
		}
		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("Give Trophy");
		}

		public void AddTradeValues()
        {
			TradeValues.Clear();

			/*TradeValues.Add(ItemID.KingSlimeTrophy, ModContent.ItemType<Items.Spears.Kivasana>());
			TradeValues.Add(ItemID.BreakerBlade, ModContent.ItemType<Items.Spears.Kivasana>());
			TradeValues.Add(ItemID.Eggnog, ModContent.ItemType<Items.Spears.Kivasana>());
			TradeValues.Add(ItemID.AmanitaFungifin, ModContent.ItemType<Items.Spears.Kivasana>());*/
		}

		public override void OnChatButtonClicked(bool firstButton, ref string shopName) {
			if (firstButton) {
				if (TradeValues.Count() <= 0)
					AddTradeValues();
				List<int> KeyCollection = TradeValues.Keys.ToList();
				for (int Repeats = 0; Repeats < KeyCollection.Count(); Repeats++)
                {
					if (Main.LocalPlayer.HasItem(KeyCollection[Repeats]))
                    {
						Main.npcChatText = $"It's dangerous to go alone, take this gift of my gratitude.";
						int wantedItemIndex = Main.LocalPlayer.FindItem(KeyCollection[Repeats]);
						var entitySource = NPC.GetSource_GiftOrReward();
						Main.LocalPlayer.inventory[wantedItemIndex].stack -= 1;
						Main.LocalPlayer.QuickSpawnItem(entitySource, TradeValues[KeyCollection[Repeats]]);
						return;
                    }
				}
				Main.npcChatText = $"I'm afraid you don't have any trophies with you, son!";
			}
		}
		/*public override void ModifyNPCLoot(NPCLoot npcLoot) {
			if (NPC.GivenName == "Seth I. Roth")
			npcLoot.Add(ItemDropRule.Common(ItemID.Katana));
		}*/
		public override bool CanGoToStatue(bool toKingStatue) => true;
		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 13;
			knockback = 2f;
		}
		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 3;
			randExtraCooldown = 3;
		}
		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileID.Shuriken;
			attackDelay = 1;
		}
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 9f;
			randomOffset = 1f;
		}
	}
	public class WeaponsMasterProfile : ITownNPCProfile
	{
		public int RollVariation() => 0;
		public string GetNameForVariant(NPC npc) => npc.getNewNPCName();
		public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) {
			/*if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
				return ModContent.Request<Texture2D>("ExampleMod/Content/NPCs/ExamplePerson");

			if (npc.altTexture == 1)
				return ModContent.Request<Texture2D>("ExampleMod/Content/NPCs/ExamplePerson_Party");*/

			return ModContent.Request<Texture2D>("Zylon/NPCs/TownNPCs/WeaponsMaster");
		}
		public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("Zylon/NPCs/TownNPCs/WeaponsMaster_Head");
	}
}