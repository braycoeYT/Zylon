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
	public class KittySeven : ModNPC
	{
		public override string Texture => "Zylon/NPCs/KittySeven";
		public override bool Autoload(ref string name)
		{
			name = "Dragon-Human";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kitty 7");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 101;
			npc.defense = 89999;
			npc.lifeMax = 2000000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.9f;
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
			return "Kitty 7";
		}
		
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			
			chat.Add("Hi!", 1.2);
			chat.Add("Wanna battle me?", 0.7);
			chat.Add("Where's the television?", 0.4);
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
			shop.item[nextSlot].SetDefaults(ItemType<PyrotechFencingBlade>());
			nextSlot++;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 101;
			knockback = 8f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 2;
			randExtraCooldown = 2;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileType<K7Pyroball>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}