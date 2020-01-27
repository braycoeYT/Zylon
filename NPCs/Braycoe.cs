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
			name = "Human";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Braycoe");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 200;
			npc.defense = 999999999;
			npc.lifeMax = 20000000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {

			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					if (NPC.downedMoonlord)
					return true;
				}
				return false;
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

			chat.Add("'Let's dance, you and me...'", 0.3);

			chat.Add("Don't tell Yharim I'm here, I barely escaped him the last time.", 0.1);
			
			chat.Add("I know the Zylonians pretty well...", 1.1);
			
			chat.Add("My job? My job is to be awesome.", 1.2);
			
			chat.Add("Oh, you want me to defend you now. Do you want me to bake cookies too?", 0.75);
			
			chat.Add("Have you seen Kitty 7 anywhere?", 0.75);
			
			chat.Add("Have you seen Nilog anywhere?", 0.75);
			
			chat.Add("Kitty 7 is totally obsessed with dragons. But she is, well, kinda one, so I guess it doesn't count.", 0.5);
			
			chat.Add("Destroy the Dark Power of this world!", 0.4);
			
			chat.Add("I don't care what you say, I like to sell random things!", 0.6);
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
			shop.item[nextSlot].SetDefaults(ItemType<DreamYarnBall>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<StickWand2>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<TacticalNucleusStaff>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<SuspiciousLookingDisc>());
			nextSlot++;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 200;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 5;
			randExtraCooldown = 5;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileType<DiscusThrowProj>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}