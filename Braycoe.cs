using System;
using Zylon.Items;
using Zylon.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs
{
	[AutoloadHead]
	public class Braycoe : ModNPC
	{
		public override string Texture => "Zylon/NPCs/Braycoe";
		public override bool Autoload(ref string name)
		{
			name = "Slime Master";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Master");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
			if (NPC.downedMoonlord)
			{
			NPCID.Sets.DangerDetectRange[npc.type] = 600;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 50;
			NPCID.Sets.AttackAverageChance[npc.type] = 50;
			}
			else if (Main.hardMode)
			{
			NPCID.Sets.DangerDetectRange[npc.type] = 550;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 75;
			NPCID.Sets.AttackAverageChance[npc.type] = 40;
			}
			else
			{
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			}
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			animationType = NPCID.Guide;
			if (NPC.downedMoonlord)
			{
			npc.damage = 130;
			npc.defense = 999999;
			npc.lifeMax = 75000;
			npc.knockBackResist = 0.3f;
			}
			else if (Main.hardMode)
			{
			npc.damage = 54;
			npc.defense = 55;
			npc.lifeMax = 1250;
			npc.knockBackResist = 0.4f;
			}
			else
			{
			npc.damage = 8;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.knockBackResist = 0.5f;
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (Main.dayTime)
			{
				if (numTownNPCs > 3)
				return true;
			}
			return false;
		}

		public override string TownNPCName()
		{
			return "Braycoe";
		}
		
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			
			chat.Add("No, I will NOT turn into a green slime for you.", 0.8);

			chat.Add("I can turn into any slime, name one and I could do it.", 1.2);

			chat.Add("What's goin' on!", 2.0);
			
			chat.Add("Sup!", 2.0);
			
			chat.Add("I always lose at Rock Paper Scissors and I don't know why.", 0.2);
			
			chat.Add("You won the lottery! No, not really.", 0.001);
			
			chat.Add("I'm cool, right? Just what I thought.", 0.6);
			
			chat.Add("Can my house be a bit bigger? Oh, never mind...", 0.8);

			chat.Add("What do you mean I look weird? I'm not from here...", 0.5);
			
			chat.Add("I know the Zylonians pretty well...", 1.1);
			
			chat.Add("My job? My job is to be awesome.", 1.2);
			
			chat.Add("Oh, you want me to defend you now. Do you want me to bake cookies too?", 0.75);
			
			chat.Add("Have you seen Kitty 7 anywhere?", 0.75);
			
			chat.Add("Have you seen Nilog anywhere?", 0.75);
			
			chat.Add("Kitty 7 is totally obsessed with dragons. But she is, well, kinda one, so I guess it doesn't count.", 0.5);
			
			chat.Add("Destroy the Dark Power of this world!", 0.4);
			
			chat.Add("Get stronger and I will sell stronger items and reveal more of my power.", 2.2);
			
			if (Main.raining)
			chat.Add("Hey, since I generate slime a lot faster while its raining, I'll sell gel to you for a discount price! Buy some now!", 0.8);
		
		    if (WorldEdit.downedDiscus == true)
			chat.Add("I got some big amoeba in the back... want some?", 0.9);
		    if (NPC.downedSlimeKing == true)
			chat.Add("That King Slime is such a loser, thanks for breaking him into thousands of normal size slimes.", 1.0);
		    if (Main.hardMode == true)
			chat.Add("I feel something underground sucking my powers...", 1.9);
			if (WorldEdit.downedMineral == true)
			chat.Add("The Zylonians like to manipulate everything. Too bad that lead to the death of the Zylonian Mineral Extractor.", 1.3);
		
			return chat;
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
        }
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
			if (firstButton)
			{
			shop = true;
			}
			else
			{
				Main.playerInventory = true;
				Main.npcChatText = "";
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			if (WorldEdit.voidDream)
			{
				if (Main.moonPhase == 1)
				{
					if (NPC.downedBoss1)
					{
						shop.item[nextSlot].SetDefaults(ItemType<Items.VoidDream.StarNova>());
						nextSlot++;
					}
				}
			}
			shop.item[nextSlot].SetDefaults(ItemID.Gel);
			if (Main.raining)
			{
				shop.item[nextSlot].shopCustomPrice = 1;
			}
			else
			{
				shop.item[nextSlot].shopCustomPrice = 3;
			}
			nextSlot++;
			if (WorldEdit.downedDiscus == true)
			{
				shop.item[nextSlot].SetDefaults(ItemType<BraycoeSludge>());
			    nextSlot++;
			}
			if (NPC.downedSlimeKing == true)
			{
				shop.item[nextSlot].SetDefaults(ItemID.SlimeCrown);
				shop.item[nextSlot].shopCustomPrice = 19000;
			    nextSlot++;
			}
			if (NPC.downedBoss1 == true)
			{
				shop.item[nextSlot].SetDefaults(ItemID.Lens);
			    nextSlot++;
			}
			if (NPC.downedBoss2 == true)
			{
				if (!WorldGen.crimson)
				{
				shop.item[nextSlot].SetDefaults(ItemID.VilePowder);
			    nextSlot++;
				}
				else
				{
				shop.item[nextSlot].SetDefaults(ItemID.ViciousPowder);
			    nextSlot++;
				}
			}
			if (NPC.downedQueenBee == true)
			{
				shop.item[nextSlot].SetDefaults(ItemID.JungleSpores);
			    nextSlot++;
			}
			if (NPC.downedBoss3 == true)
			{
				shop.item[nextSlot].SetDefaults(ItemID.WaterBolt);
			    nextSlot++;
			}
			if (Main.hardMode == true)
			{
				shop.item[nextSlot].SetDefaults(ItemType<Items.Accessories.EyeThemed.KaizoMedal>());
				shop.item[nextSlot].shopCustomPrice = 100000;
			    nextSlot++;
			}
			if (NPC.downedGolemBoss == true)
			{
				shop.item[nextSlot].SetDefaults(ItemType<Items.BluePotion>());
				nextSlot++;
			}
			if (NPC.downedMoonlord == true)
			{
				shop.item[nextSlot].SetDefaults(ItemType<Items.BossSummon.MysteryBag>());
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			if (NPC.downedMoonlord)
			{
			damage = 319;
			knockback = 4f;
			}
			else if (Main.hardMode)
			{
			damage = 54;
			knockback = 3f;
			}
			else
			{
			damage = 8;
			knockback = 2f;
			}
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			if (NPC.downedMoonlord)
			{
			cooldown = 8;
			randExtraCooldown = 6;
			}
			else if (Main.hardMode)
			{
			cooldown = 10;
			randExtraCooldown = 5;
			}
			else
			{
			cooldown = 12;
			randExtraCooldown = 5;
			}
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			if (WorldEdit.downedMineral)
			{
				projType = ProjectileType<BraycoeProjMineral>();
				attackDelay = 1;
			}
			else
			{
				projType = ProjectileType<BraycoeProjDiscus>();
				attackDelay = 1;
			}
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			if (NPC.downedMoonlord)
			{
			multiplier = 21f;
			randomOffset = 4f;
			}
			else if (Main.hardMode)
			{
			multiplier = 16f;
			randomOffset = 3f;
			}
			else
			{
			multiplier = 12f;
			randomOffset = 2f;
			}
		}
	}
}