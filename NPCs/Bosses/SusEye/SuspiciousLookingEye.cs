using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Chat;
using Terraria.Audio;

namespace Zylon.NPCs.Bosses.SusEye
{
	[AutoloadBossHead]
	public class SuspiciousLookingEye : ModNPC
	{
		public override void SetStaticDefaults() {
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			// DisplayName.SetDefault("Suspicious Looking Eye");
			Main.npcFrameCount[NPC.type] = 2;
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}
        public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DemonEye);
			//NPC.value = 0f;
			//NPC.aiStyle = NPCID.DemonEye;
			AnimationType = 1;
			NPC.lifeMax = 100000;
			NPC.damage = 298;
			NPC.defense = 60;
			NPC.noTileCollide = true;
			//NPC.color = Color.Aqua;
			NPC.boss = true;
			NPC.knockBackResist = 0f;
			NPC.value = 42069;
        }
		public override void OnHitByItem(Player player, Item item, NPC.HitInfo hit, int damageDone) {
			if (damageDone > 99999) {
				NPC.life += damageDone;
				CombatText.NewText(NPC.getRect(), Color.LimeGreen, damageDone);
				if (NPC.life < 1)
					NPC.life = NPC.lifeMax;
			}
			if (NPC.life < 1 && (Main.netMode == NetmodeID.Server || Main.netMode == NetmodeID.SinglePlayer)) NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<SupremeLookingEyeHead>());
		}
        public override void OnHitByProjectile(Projectile projectile, NPC.HitInfo hit, int damageDone) {
            if (projectile.type == ProjectileID.FinalFractal) damageDone /= 2;
			if (damageDone > 99999) {
				NPC.life += damageDone;
				CombatText.NewText(NPC.getRect(), Color.LimeGreen, damageDone);
				if (NPC.life < 1)
					NPC.life = NPC.lifeMax;
			}
			if (NPC.life < 1 && (Main.netMode == NetmodeID.Server || Main.netMode == NetmodeID.SinglePlayer)) NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<SupremeLookingEyeHead>());
        }
        /*public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(mod.BuffType("Scared"), Main.rand.Next(1, 4) * 60, true);
		}*/
        int Timer;
		int animationTimer;
		int attackTimer;
		bool movement = true;
		float shieldValue = 1f;
		int flee = 0;
		int attack = 1;
		bool attackDone = true;
		Player target;
		int difficultyBonus;
		float num321;
		float num322;
		bool dashDone = true;
		int dashTimer = 0;

		bool children = true;
		bool children2 = true;
		bool children3 = true;

		bool chat1 = true;
		bool chat2 = true;
		bool chat3 = true;
		bool chat4 = true;
		bool chat5 = true;
		bool chat6 = true;
		bool chat7 = true;
		bool chat8 = true;
		bool chat9 = true;
		bool chat10 = true;
		bool chat11 = true;
		bool chat12 = true;
		bool chat13 = true;
		bool chat14 = true;
		bool chat15 = true;
		bool chat16 = true;
		bool chat17 = true;
		bool chat18 = true;
		bool chat19 = true;
		bool chat20 = true;
		bool chat21 = true;
		bool chat22 = true;
		bool chat23 = true;
		bool chat24 = true;
		bool chat25 = true;
		bool chat26 = true;
		bool chat27 = true;
		bool chat28 = true;
		bool chat29 = true;
		bool chat30 = true;
		bool chat31 = true;
		bool chat32 = true;
		bool chat33 = true;
		bool chat34 = true;
		bool chat35 = true;
		bool chat36 = true;
		bool chat37 = true;
		bool chat38 = true;
		bool chat39 = true;
		bool chat40 = true;
		bool chat41 = true;
		bool chat42 = true;
		bool chat43 = true;
		bool chat44 = true;
		bool chat45 = true;
		bool chat46 = true;
		bool chat47 = true;
		bool chat48 = true;
		bool chat49 = true;
		bool chat50 = true;
		bool chat51 = true;
		bool chat52 = true;
		bool chat53 = true;
		bool chat54 = true;
		bool chat55 = true;
		bool chat56 = true;
		bool chat57 = true;
		bool chat58 = true;
		bool chat59 = true;
		bool chat60 = true;

		float attackTime;

		public override void AI() {
			NPC.color = Main.DiscoColor;
			Timer++;

            if (!Main.zenithWorld) { 
				Color messageColor = Color.DarkRed;
					string chat = "GET FIXED BOI!!!!!!!!!!!!!!!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				NPC.active = false;
			}

			if (NPC.CountNPCS(ModContent.NPCType<Mechatutubutt>()) > 0 || NPC.CountNPCS(ModContent.NPCType<TerrarrarriaGod>()) > 0 || NPC.CountNPCS(ModContent.NPCType<SupremeRetinaspazafascismDeluxe3D>()) > 0 || NPC.CountNPCS(ModContent.NPCType<GenericWormofEdginessHead>()) > 0) {
				NPC.dontTakeDamage = true;
            }
			else NPC.dontTakeDamage = false;

            if ((double)(NPC.life) < (double)(NPC.lifeMax * 1f))
				if (chat1)
				{
					Color messageColor = Color.DarkRed;
					string chat = "I am GOING to KILL you!?!?!?1/1/1/1";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat1 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.99f))
				if (chat2)
				{
					Color messageColor = Color.DarkRed;
					string chat = "And I am GOING to EAT your FREAKING DOG!!!(!(@(#R&*$(#&";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat2 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.98f))
				if (chat3)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Now let me tell you my backstory because u stpid";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat3 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.96f))
				if (chat4)
				{
					Color messageColor = Color.DarkRed;
					string chat = "I was a small child a long time agoooooooooooooooooooooooooooooooooooo";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat4 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.94f))
				if (chat5)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Then my best friend TIMMMMY was killed by the edgiest eye of edginess";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat5 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.92f))
				if (chat6)
				{
					Color messageColor = Color.DarkRed;
					string chat = "and I cried and commited cannibalism";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat6 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.90f))
				if (chat7)
				{
					Color messageColor = Color.DarkRed;
					string chat = "and then I cried and commited cannibalism AGIAN";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat7 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.88f))
				if (chat8)
				{
					Color messageColor = Color.DarkRed;
					string chat = "then IIIIII was so sadddd I did it again and again and then I killed all my friends for no reason";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat8 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.86f))
				if (chat9)
				{
					Color messageColor = Color.DarkRed;
					string chat = "then I traveleeld acrossss the universe and bullyyedd my  parents because they called me a winner";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat9 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.84f))
				if (chat10)
				{
					Color messageColor = Color.DarkRed;
					string chat = "then I murdered a big boi worm because he accidentally went within 101010100101 light years of meee";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat10 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.82f))
				if (chat11)
				{
					Color messageColor = Color.DarkRed;
					string chat = "then I became the most powerful eye in the UNIVERSE!(!*))@*(#$???!?!?!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat11 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.8f))
				if (chat12)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Even more than the edgiest eye of edginess!?*&@^#%&7658!!!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat12 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.75f))
				if (chat13)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Here are my children!??!?!?! They will eat your kids!)(@I)#";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat13 = false;
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - 600, ModContent.NPCType<Mechatutubutt>());
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - 600, ModContent.NPCType<TerrarrarriaGod>());
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - 600, ModContent.NPCType<SupremeRetinaspazafascismDeluxe3D>());
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.72f))
				if (chat14)
				{
					Color messageColor = Color.DarkRed;
					string chat = "im GONNA GET YUUUUUUU!!UU!!UU!!(@)#*&(@$(&#";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat14 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.66f))
				if (chat15)
				{
					Color messageColor = Color.DarkRed;
					string chat = "HOW AERE YOU STILL A LIVE!)!)!)!_@_)#$*#()$*&";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat15 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.63f))
				if (chat16)
				{
					Color messageColor = Color.DarkRed;
					string chat = "ALRIGHT YOUR ASKING FOR THIS#";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat16 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.6f))
				if (chat17)
				{
					Color messageColor = Color.DarkRed;
					string chat = "JK I will wait a bit so I look more edgy and coooollll!@*&(@)#)";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat17 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.55f))
				if (chat18)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Ok u are startin to git very annoying";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat18 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.53f))
				if (chat19)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Get ready n00b...";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat19 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.5f))
				if (chat20)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Here are my GRANDCHILDREN!?!?!?!?!?!?! U DONT STAND A CHANCE!!?!?!?! MWHSAHSHQHAHAHAHAHAHAHSUIDYhgaewfiukashrgfk";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat20 = false;
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - 600, ModContent.NPCType<GenericWormofEdginessHead>());
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.45f))
				if (chat21)
				{
					Color messageColor = Color.DarkRed;
					string chat = "o no my hp is gone";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat21 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.435f))
				if (chat22)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Im about to DIE!?!?!?!?!??!!??! SOMEONE LIKE ME!?!?!??!?! U MUST B CHEATING!!?!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat22 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.415f))
				if (chat23)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Welllll guess WAT!?!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat23 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.4f))
				if (chat24)
				{
					Color messageColor = Color.DarkRed;
					string chat = "It isn't over yet, kiddo child bob joe poophead!!!!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat24 = false;
					for (int i = 0; i < 60; i++) {
						NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - Main.rand.Next(-600, 601), NPCID.GreenSlime);
					}
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.38f))
				if (chat25)
				{
					Color messageColor = Color.DarkRed;
					string chat = "OH YEAHH!H!!!H!H!! FLAMETHROWERS!!!?!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat25 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.36f))
				if (chat26)
				{
					Color messageColor = Color.DarkRed;
					string chat = "I'm gonnnna spank ur butt so freaking hard it will go to space!?!?!?!??!?!!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat26 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.34f))
				if (chat27)
				{
					Color messageColor = Color.DarkRed;
					string chat = "O NO HOW IN THE WORLD ARE YOU BEATING ME YOU STINKHEADq?";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat27 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.32f))
				if (chat28)
				{
					Color messageColor = Color.DarkRed;
					string chat = "WE're NO strangers 32 loveosss?!?!?!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat28 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.3f))
				if (chat29)
				{
					Color messageColor = Color.DarkRed;
					string chat = "WE're NO strangers 32 loveosss?!?!?!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat29 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.28f))
				if (chat30)
				{
					Color messageColor = Color.DarkRed;
					string chat = "OH SORRYRYRYRY, I WAS thinking of my GIRLFRIEND";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat30 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.27f))
				if (chat31)
				{
					Color messageColor = Color.DarkRed;
					string chat = "She died in a CAR CRASH the day after I married her........... oh poor Ajfiuarfharieluf the Fourth////";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat31 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.25f))
				if (chat32)
				{
					Color messageColor = Color.DarkRed;
					string chat = "YOU KNOW WHAT FIGHT MY GREAT GREAT GRANDCHILDREN YOU DUM IDOT STICK!!?!?!?!?@#34";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat32 = false;
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - 600, ModContent.NPCType<Mechatutubutt>());
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - 600, ModContent.NPCType<TerrarrarriaGod>());
                    NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - 600, ModContent.NPCType<SupremeRetinaspazafascismDeluxe3D>());
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - 600, ModContent.NPCType<GenericWormofEdginessHead>());

                }
            if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.23f))
				if (chat33)
				{
					Color messageColor = Color.DarkRed;
					string chat = "O NO I AM DYING!?!?!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat33 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.21f))
				if (chat34)
				{
					Color messageColor = Color.DarkRed;
					string chat = "That doesn't mak any SENSE!? YOU MUST BE CHEATING!?!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat34 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.19f))
				if (chat35)
				{
					Color messageColor = Color.DarkRed;
					string chat = "You, a human!? Defeating ME!?!?!?!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat35 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.17f))
				if (chat36)
				{
					Color messageColor = Color.DarkRed;
					string chat = "U NO WHAT!? COME AND GET ME YOU CHEATING CHICHIN@!?";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat36 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.16f))
				if (chat37)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Let me tell you a story.";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat37 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.15f))
				if (chat38)
				{
					Color messageColor = Color.DarkRed;
					string chat = "After I killed all my friends for no reason, an evil universe takeover man asked me to join him on his EVIL plans.";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat38 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.14f))
				if (chat39)
				{
					Color messageColor = Color.DarkRed;
					string chat = "I said NO YOU STINKY CRAPHOLE, YOUR MOMS SO FAT-";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat39 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.13f))
				if (chat40)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Then HE KILLED my PARENTS!>!>?";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat40 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.12f))
				if (chat41)
				{
					Color messageColor = Color.DarkRed;
					string chat = "I got so angery I slapped him so HARD he went into a BLACK HOEL!?!?!*@$&)^RT#*YEGFUWK";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat41 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.11f))
				if (chat42)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Then I was so powerful I reviedsd them and now they are OK!?";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat42 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.1f))
				if (chat43)
				{
					Color messageColor = Color.DarkRed;
					string chat = "IN FACT, HERE they are NOW!!??!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat43 = false;
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - 600, NPCID.Harpy);
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - 600, NPCID.Everscream);
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.09f))
				if (chat44)
				{
					Color messageColor = Color.DarkRed;
					string chat = "...";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat44 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.08f))
				if (chat45)
				{
					Color messageColor = Color.DarkRed;
					string chat = "...";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat45 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.07f))
				if (chat46)
				{
					Color messageColor = Color.DarkRed;
					string chat = "It appears that the current time, which is one of suffering, is continuing, despite the severe injuries the both of us, I suffering extreme, irreversible damage, and I, a being of supreme evil, feel the urge, caused by my state of cockiness, a mask I hide behind to hide the fear, to tell you, a homo sapien of admirable power and endurance, which I shall past this point, refer to as “kiddo”, as an insult.";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat46 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.06f))
				if (chat47)
				{
					Color messageColor = Color.DarkRed;
					string chat = "See I AM BIGGEST BRAIN!?! UNLIKE U NOOB!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat47 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.05f))
				if (chat48)
				{
					Color messageColor = Color.DarkRed;
					string chat = "To reach MAXIMUM EDGINESS, I will say a BAD BAD BAD wordd!?!?4387950";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat48 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.04f))
				if (chat49)
				{
					Color messageColor = Color.DarkRed;
					string chat = "3, 2, 1.... ****!?!?!? HAHAAH U AREW WETING YOUR PANTS AFTER Hearin THAT@>";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat49 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.03f))
				if (chat50)
				{
					Color messageColor = Color.DarkRed;
					string chat = "alright since I am about to die  I am going to spam my best friend's goldfish's child's son's daughter's best friend's sister's owner's father's murderer's son's child's best friends at U)(*&^%$#@!#$%^^^^??!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat50 = false;
					for (int x = 0; x < 25; x++) NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + Main.rand.Next(-600, 601), (int)NPC.position.Y - 600, NPCID.Gastropod);
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.025f))
				if (chat51)
				{
					Color messageColor = Color.DarkRed;
					string chat = "UWU";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat51 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.024f))
				if (chat52)
				{
					Color messageColor = Color.DarkRed;
					string chat = "CHAGNE WORLD< FINAL MESSAFEGE< GOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOODBYE YOU SUCKER BUTTHOLE PIECE OF CRAP!)(*&^%$#@";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat52 = false;
				}
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.023f))
				if (chat53)
				{
					Color messageColor = Color.DarkRed;
					string chat = "SEARCH 'SONIC INFLATION' TO LEARN MOAR!!!!!!!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat53 = false;
				}
			attackTime += 4f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.875f))
				attackTime += 0.4f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.75f))
				attackTime += 0.4f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.625f))
				attackTime += 0.4f;	
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.5f))
				attackTime += 0.4f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.325f))
				attackTime += 0.4f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.25f))
				attackTime += 0.4f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.125f))
				attackTime += 0.4f;
			if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
									{
										NPC.TargetClosest(true);
									}
									bool dead2 = Main.player[NPC.target].dead;
									float num376 = NPC.position.X + (float)(NPC.width / 2) - Main.player[NPC.target].position.X - (float)(Main.player[NPC.target].width / 2);
									float num377 = NPC.position.Y + (float)NPC.height - 59f - Main.player[NPC.target].position.Y - (float)(Main.player[NPC.target].height / 2);
									float num378 = (float)Math.Atan2((double)num377, (double)num376) + 1.57f;
									if (num378 < 0f)
									{
										num378 += 6.283f;
									}
									else if ((double)num378 > 6.283)
									{
										num378 -= 6.283f;
									}
									float num379 = 0.1f;
									if (NPC.rotation < num378)
									{
										if ((double)(num378 - NPC.rotation) > 3.1415)
										{
											NPC.rotation -= num379;
										}
										else
										{
											NPC.rotation += num379;
										}
									}
									else if (NPC.rotation > num378)
									{
										if ((double)(NPC.rotation - num378) > 3.1415)
										{
											NPC.rotation += num379;
										}
										else
										{
											NPC.rotation -= num379;
										}
									}
									if (NPC.rotation > num378 - num379 && NPC.rotation < num378 + num379)
									{
										NPC.rotation = num378;
									}
									if (NPC.rotation < 0f)
									{
										NPC.rotation += 6.283f;
									}
									else if ((double)NPC.rotation > 6.283)
									{
										NPC.rotation -= 6.283f;
									}
									if (NPC.rotation > num378 - num379 && NPC.rotation < num378 + num379)
									{
										NPC.rotation = num378;
									}
									if (Main.rand.NextBool(5))
									{
										int num380 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + (float)NPC.height * 0.25f), NPC.width, (int)((float)NPC.height * 0.5f), DustID.Blood, NPC.velocity.X, 2f, 0, default(Color), 1f);
										Dust var_9_131D1_cp_0_cp_0 = Main.dust[num380];
										var_9_131D1_cp_0_cp_0.velocity.X = var_9_131D1_cp_0_cp_0.velocity.X * 0.5f;
										Dust var_9_131F5_cp_0_cp_0 = Main.dust[num380];
										var_9_131F5_cp_0_cp_0.velocity.Y = var_9_131F5_cp_0_cp_0.velocity.Y * 0.1f;
									}
									if (Main.netMode != NetmodeID.MultiplayerClient && !dead2 && NPC.timeLeft < 10)
									{
										int num;
										for (int num381 = 0; num381 < 200; num381 = num + 1)
										{
											if (num381 != NPC.whoAmI && Main.npc[num381].active && (Main.npc[num381].type == NPCID.Retinazer || Main.npc[num381].type == NPCID.Spazmatism) && Main.npc[num381].timeLeft - 1 > NPC.timeLeft)
											{
												NPC.timeLeft = Main.npc[num381].timeLeft - 1;
											}
											num = num381;
										}
									}
									if (dead2)
									{
										NPC.velocity.Y = NPC.velocity.Y - 0.04f;
										if (NPC.timeLeft > 10)
										{
											NPC.timeLeft = 10;
											return;
										}
									}
									else if (NPC.ai[0] == 0f)
									{
										if (NPC.ai[1] == 0f)
										{
											float num382 = 7f;
											float num383 = 0.1f;
											if (Main.expertMode)
											{
												num382 = 8.25f;
												num383 = 0.115f;
											}
											int num384 = 1;
											if (NPC.position.X + (float)(NPC.width / 2) < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
											{
												num384 = -1;
											}
											Vector2 vector40 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num385 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) + (float)(num384 * 300) - vector40.X;
											float num386 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - 300f - vector40.Y;
											float num387 = (float)Math.Sqrt((double)(num385 * num385 + num386 * num386));
											float num388 = num387;
											num387 = num382 / num387;
											num385 *= num387;
											num386 *= num387;
											if (NPC.velocity.X < num385)
											{
												NPC.velocity.X = NPC.velocity.X + num383;
												if (NPC.velocity.X < 0f && num385 > 0f)
												{
													NPC.velocity.X = NPC.velocity.X + num383;
												}
											}
											else if (NPC.velocity.X > num385)
											{
												NPC.velocity.X = NPC.velocity.X - num383;
												if (NPC.velocity.X > 0f && num385 < 0f)
												{
													NPC.velocity.X = NPC.velocity.X - num383;
												}
											}
											if (NPC.velocity.Y < num386)
											{
												NPC.velocity.Y = NPC.velocity.Y + num383;
												if (NPC.velocity.Y < 0f && num386 > 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y + num383;
												}
											}
											else if (NPC.velocity.Y > num386)
											{
												NPC.velocity.Y = NPC.velocity.Y - num383;
												if (NPC.velocity.Y > 0f && num386 < 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y - num383;
												}
											}
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 600f)
											{
												NPC.ai[1] = 1f;
												NPC.ai[2] = 0f;
												NPC.ai[3] = 0f;
												NPC.target = 255;
												NPC.netUpdate = true;
											}
											else if (NPC.position.Y + (float)NPC.height < Main.player[NPC.target].position.Y && num388 < 400f)
											{
												if (!Main.player[NPC.target].dead)
												{
													NPC.ai[3] += 1f;
													if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.9)
													{
														NPC.ai[3] += 0.3f;
													}
													if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.8)
													{
														NPC.ai[3] += 0.3f;
													}
													if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.7)
													{
														NPC.ai[3] += 0.3f;
													}
													if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.6)
													{
														NPC.ai[3] += 0.3f;
													}
												}
												
											}
										}
										else if (NPC.ai[1] == 1f)
										{
											NPC.rotation = num378;
											float num393 = 12f;
											if (Main.expertMode)
											{
												num393 = 15f;
											}
											Vector2 vector41 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num394 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector41.X;
											float num395 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector41.Y;
											float num396 = (float)Math.Sqrt((double)(num394 * num394 + num395 * num395));
											num396 = num393 / num396;
											NPC.velocity.X = num394 * num396;
											NPC.velocity.Y = num395 * num396;
											NPC.ai[1] = 2f;
										}
										else if (NPC.ai[1] == 2f)
										{
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 25f)
											{
												NPC.velocity.X = NPC.velocity.X * 0.96f;
												NPC.velocity.Y = NPC.velocity.Y * 0.96f;
												if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
												{
													NPC.velocity.X = 0f;
												}
												if ((double)NPC.velocity.Y > -0.1 && (double)NPC.velocity.Y < 0.1)
												{
													NPC.velocity.Y = 0f;
												}
											}
											else
											{
												NPC.rotation = (float)Math.Atan2((double)NPC.velocity.Y, (double)NPC.velocity.X) - 1.57f;
											}
											if (NPC.ai[2] >= 70f)
											{
												NPC.ai[3] += 1f;
												NPC.ai[2] = 0f;
												NPC.target = 255;
												NPC.rotation = num378;
												if (NPC.ai[3] >= 4f)
												{
													NPC.ai[1] = 0f;
													NPC.ai[3] = 0f;
												}
												else
												{
													NPC.ai[1] = 1f;
												}
											}
										}
										if ((double)NPC.life < (double)NPC.lifeMax * 0.4)
										{
											NPC.ai[0] = 1f;
											NPC.ai[1] = 0f;
											NPC.ai[2] = 0f;
											NPC.ai[3] = 0f;
											NPC.netUpdate = true;
											return;
										}
									}
									else if (NPC.ai[0] == 1f || NPC.ai[0] == 2f)
									{
										if (NPC.ai[0] == 1f)
										{
											NPC.ai[2] += 0.005f;
											if ((double)NPC.ai[2] > 0.5)
											{
												NPC.ai[2] = 0.5f;
											}
										}
										else
										{
											NPC.ai[2] -= 0.005f;
											if (NPC.ai[2] < 0f)
											{
												NPC.ai[2] = 0f;
											}
										}
										NPC.rotation += NPC.ai[2];
										NPC.ai[1] += 1f;
										if (NPC.ai[1] == 100f)
										{
											NPC.ai[0] += 1f;
											NPC.ai[1] = 0f;
											if (NPC.ai[0] == 3f)
											{
												NPC.ai[2] = 0f;
											}
											else
											{
												SoundEngine.PlaySound(SoundID.Item16, NPC.position);
												int num;
												for (int num397 = 0; num397 < 2; num397 = num + 1)
												{
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 143, 1f);
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
													num = num397;
												}
												for (int num398 = 0; num398 < 20; num398 = num + 1)
												{
													Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
													num = num398;
												}
												SoundEngine.PlaySound(SoundID.Item16, NPC.position);
											}
										}
										Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
										NPC.velocity.X = NPC.velocity.X * 0.98f;
										NPC.velocity.Y = NPC.velocity.Y * 0.98f;
										if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
										{
											NPC.velocity.X = 0f;
										}
										if ((double)NPC.velocity.Y > -0.1 && (double)NPC.velocity.Y < 0.1)
										{
											NPC.velocity.Y = 0f;
											return;
										}
									}
									else
									{
										NPC.damage = (int)((double)NPC.defDamage * 1.5);
										NPC.defense = NPC.defDefense + 10;
										NPC.HitSound = SoundID.NPCHit4;
										if (NPC.ai[1] == 0f)
										{
											float num399 = 8f;
											float num400 = 0.15f;
											if (Main.expertMode)
											{
												num399 = 9.5f;
												num400 = 0.175f;
											}
											Vector2 vector42 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num401 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector42.X;
											float num402 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - 300f - vector42.Y;
											float num403 = (float)Math.Sqrt((double)(num401 * num401 + num402 * num402));
											num403 = num399 / num403;
											num401 *= num403;
											num402 *= num403;
											if (NPC.velocity.X < num401)
											{
												NPC.velocity.X = NPC.velocity.X + num400;
												if (NPC.velocity.X < 0f && num401 > 0f)
												{
													NPC.velocity.X = NPC.velocity.X + num400;
												}
											}
											else if (NPC.velocity.X > num401)
											{
												NPC.velocity.X = NPC.velocity.X - num400;
												if (NPC.velocity.X > 0f && num401 < 0f)
												{
													NPC.velocity.X = NPC.velocity.X - num400;
												}
											}
											if (NPC.velocity.Y < num402)
											{
												NPC.velocity.Y = NPC.velocity.Y + num400;
												if (NPC.velocity.Y < 0f && num402 > 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y + num400;
												}
											}
											else if (NPC.velocity.Y > num402)
											{
												NPC.velocity.Y = NPC.velocity.Y - num400;
												if (NPC.velocity.Y > 0f && num402 < 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y - num400;
												}
											}
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 300f)
											{
												NPC.ai[1] = 1f;
												NPC.ai[2] = 0f;
												NPC.ai[3] = 0f;
												NPC.TargetClosest(true);
												NPC.netUpdate = true;
											}
											vector42 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											num401 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector42.X;
											num402 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector42.Y;
											NPC.rotation = (float)Math.Atan2((double)num402, (double)num401) - 1.57f;
											if (Main.netMode != NetmodeID.MultiplayerClient)
											{
												NPC.localAI[1] += 1f;
												if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
												{
													NPC.localAI[1] += 1f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
												{
													NPC.localAI[1] += 1f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
												{
													NPC.localAI[1] += 1f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.1)
												{
													NPC.localAI[1] += 2f;
												}
												if (NPC.localAI[1] > 250f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
												{
													NPC.localAI[1] = 0f;
													float num404 = 8.5f;
													int num405 = 50; //25
													int num406 = 100;
													if (Main.expertMode)
													{
														num404 = 10f;
														num405 = 46; //46
													}
													num403 = (float)Math.Sqrt((double)(num401 * num401 + num402 * num402));
													num403 = num404 / num403;
													num401 *= num403;
													num402 *= num403;
													vector42.X += num401 * 15f;
													vector42.Y += num402 * 15f;
							int num407;
													if (Main.rand.NextBool(8) && Main.netMode != NetmodeID.MultiplayerClient) num407 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector42.X, vector42.Y, num401, num402, num406, num405, 0f, Main.myPlayer, 0f, 0f);
													return;
												}
											}
										}
										else
										{
											int num408 = 1;
											if (NPC.position.X + (float)(NPC.width / 2) < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
											{
												num408 = -1;
											}
											float num409 = 8f;
											float num410 = 0.2f;
											if (Main.expertMode)
											{
												num409 = 9.5f;
												num410 = 0.25f;
											}
											Vector2 vector43 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num411 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) + (float)(num408 * 340) - vector43.X;
											float num412 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector43.Y;
											float num413 = (float)Math.Sqrt((double)(num411 * num411 + num412 * num412));
											num413 = num409 / num413;
											num411 *= num413;
											num412 *= num413;
											if (NPC.velocity.X < num411)
											{
												NPC.velocity.X = NPC.velocity.X + num410;
												if (NPC.velocity.X < 0f && num411 > 0f)
												{
													NPC.velocity.X = NPC.velocity.X + num410;
												}
											}
											else if (NPC.velocity.X > num411)
											{
												NPC.velocity.X = NPC.velocity.X - num410;
												if (NPC.velocity.X > 0f && num411 < 0f)
												{
													NPC.velocity.X = NPC.velocity.X - num410;
												}
											}
											if (NPC.velocity.Y < num412)
											{
												NPC.velocity.Y = NPC.velocity.Y + num410;
												if (NPC.velocity.Y < 0f && num412 > 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y + num410;
												}
											}
											else if (NPC.velocity.Y > num412)
											{
												NPC.velocity.Y = NPC.velocity.Y - num410;
												if (NPC.velocity.Y > 0f && num412 < 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y - num410;
												}
											}
											vector43 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											num411 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector43.X;
											num412 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector43.Y;
											NPC.rotation = (float)Math.Atan2((double)num412, (double)num411) - 1.57f;
											if (Main.netMode != NetmodeID.MultiplayerClient)
											{
												NPC.localAI[1] += 1f;
												if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
												{
													NPC.localAI[1] += 0.5f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
												{
													NPC.localAI[1] += 0.75f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
												{
													NPC.localAI[1] += 1f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.1)
												{
													NPC.localAI[1] += 1.5f;
												}
												if (Main.expertMode)
												{
													NPC.localAI[1] += 1.5f;
												}
												if (NPC.localAI[1] > 300f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
												{
													NPC.localAI[1] = 0f;
													float num414 = 9f;
													int num415 = 36; //18
													int num416 = 100;
													if (Main.expertMode)
													{
														num415 = 34; //17
													}
													num413 = (float)Math.Sqrt((double)(num411 * num411 + num412 * num412));
													num413 = num414 / num413;
													num411 *= num413;
													num412 *= num413;
													vector43.X += num411 * 15f;
													vector43.Y += num412 * 15f;
							int num417;
													if (Main.rand.NextBool(8) && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), vector43.X, vector43.Y, num411, num412, num416, num415, 0f, Main.myPlayer, 0f, 0f);
												}
											}
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 180f)
											{
												NPC.ai[1] = 0f;
												NPC.ai[2] = 0f;
												NPC.ai[3] = 0f;
												NPC.TargetClosest(true);
												NPC.netUpdate = true;
												return;
											}
										}
									}
									if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
									{
										NPC.TargetClosest(true);
									}
									bool dead3 = Main.player[NPC.target].dead;
									float num418 = NPC.position.X + (float)(NPC.width / 2) - Main.player[NPC.target].position.X - (float)(Main.player[NPC.target].width / 2);
									float num419 = NPC.position.Y + (float)NPC.height - 59f - Main.player[NPC.target].position.Y - (float)(Main.player[NPC.target].height / 2);
									float num420 = (float)Math.Atan2((double)num419, (double)num418) + 1.57f;
									if (num420 < 0f)
									{
										num420 += 6.283f;
									}
									else if ((double)num420 > 6.283)
									{
										num420 -= 6.283f;
									}
									float num421 = 0.15f;
									if (NPC.rotation < num420)
									{
										if ((double)(num420 - NPC.rotation) > 3.1415)
										{
											NPC.rotation -= num421;
										}
										else
										{
											NPC.rotation += num421;
										}
									}
									else if (NPC.rotation > num420)
									{
										if ((double)(NPC.rotation - num420) > 3.1415)
										{
											NPC.rotation += num421;
										}
										else
										{
											NPC.rotation -= num421;
										}
									}
									if (NPC.rotation > num420 - num421 && NPC.rotation < num420 + num421)
									{
										NPC.rotation = num420;
									}
									if (NPC.rotation < 0f)
									{
										NPC.rotation += 6.283f;
									}
									else if ((double)NPC.rotation > 6.283)
									{
										NPC.rotation -= 6.283f;
									}
									if (NPC.rotation > num420 - num421 && NPC.rotation < num420 + num421)
									{
										NPC.rotation = num420;
									}
									if (Main.rand.NextBool(5))
									{
										int num422 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + (float)NPC.height * 0.25f), NPC.width, (int)((float)NPC.height * 0.5f), DustID.Blood, NPC.velocity.X, 2f, 0, default(Color), 1f);
										Dust var_9_15364_cp_0_cp_0 = Main.dust[num422];
										var_9_15364_cp_0_cp_0.velocity.X = var_9_15364_cp_0_cp_0.velocity.X * 0.5f;
										Dust var_9_15388_cp_0_cp_0 = Main.dust[num422];
										var_9_15388_cp_0_cp_0.velocity.Y = var_9_15388_cp_0_cp_0.velocity.Y * 0.1f;
									}
									if (Main.netMode != NetmodeID.MultiplayerClient && !dead3 && NPC.timeLeft < 10)
									{
										int num;
										for (int num423 = 0; num423 < 200; num423 = num + 1)
										{
											if (num423 != NPC.whoAmI && Main.npc[num423].active && (Main.npc[num423].type == NPCID.Retinazer || Main.npc[num423].type == NPCID.Spazmatism) && Main.npc[num423].timeLeft - 1 > NPC.timeLeft)
											{
												NPC.timeLeft = Main.npc[num423].timeLeft - 1;
											}
											num = num423;
										}
									}
									if (dead3)
									{
										NPC.velocity.Y = NPC.velocity.Y - 0.04f;
										if (NPC.timeLeft > 10)
										{
											NPC.timeLeft = 10;
											return;
										}
									}
									else if (NPC.ai[0] == 0f)
									{
										if (NPC.ai[1] == 0f)
										{
											NPC.TargetClosest(true);
											float num424 = 12f;
											float num425 = 0.4f;
											int num426 = 1;
											if (NPC.position.X + (float)(NPC.width / 2) < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
											{
												num426 = -1;
											}
											Vector2 vector44 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num427 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) + (float)(num426 * 400) - vector44.X;
											float num428 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector44.Y;
											float num429 = (float)Math.Sqrt((double)(num427 * num427 + num428 * num428));
											num429 = num424 / num429;
											num427 *= num429;
											num428 *= num429;
											if (NPC.velocity.X < num427)
											{
												NPC.velocity.X = NPC.velocity.X + num425;
												if (NPC.velocity.X < 0f && num427 > 0f)
												{
													NPC.velocity.X = NPC.velocity.X + num425;
												}
											}
											else if (NPC.velocity.X > num427)
											{
												NPC.velocity.X = NPC.velocity.X - num425;
												if (NPC.velocity.X > 0f && num427 < 0f)
												{
													NPC.velocity.X = NPC.velocity.X - num425;
												}
											}
											if (NPC.velocity.Y < num428)
											{
												NPC.velocity.Y = NPC.velocity.Y + num425;
												if (NPC.velocity.Y < 0f && num428 > 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y + num425;
												}
											}
											else if (NPC.velocity.Y > num428)
											{
												NPC.velocity.Y = NPC.velocity.Y - num425;
												if (NPC.velocity.Y > 0f && num428 < 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y - num425;
												}
											}
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 600f)
											{
												NPC.ai[1] = 1f;
												NPC.ai[2] = 0f;
												NPC.ai[3] = 0f;
												NPC.target = 255;
												NPC.netUpdate = true;
											}
											else
											{
												if (!Main.player[NPC.target].dead)
												{
													NPC.ai[3] += 1f;
													if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.8)
													{
														NPC.ai[3] += 0.6f;
													}
												}
											}
										}
										else if (NPC.ai[1] == 1f)
										{
											NPC.rotation = num420;
											float num434 = 13f;
											if (Main.expertMode)
											{
												if ((double)NPC.life < (double)NPC.lifeMax * 0.9)
												{
													num434 += 0.5f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.8)
												{
													num434 += 0.5f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.7)
												{
													num434 += 0.55f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.6)
												{
													num434 += 0.6f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
												{
													num434 += 0.65f;
												}
											}
											Vector2 vector45 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num435 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector45.X;
											float num436 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector45.Y;
											float num437 = (float)Math.Sqrt((double)(num435 * num435 + num436 * num436));
											num437 = num434 / num437;
											NPC.velocity.X = num435 * num437;
											NPC.velocity.Y = num436 * num437;
											NPC.ai[1] = 2f;
										}
										else if (NPC.ai[1] == 2f)
										{
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 8f)
											{
												NPC.velocity.X = NPC.velocity.X * 0.9f;
												NPC.velocity.Y = NPC.velocity.Y * 0.9f;
												if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
												{
													NPC.velocity.X = 0f;
												}
												if ((double)NPC.velocity.Y > -0.1 && (double)NPC.velocity.Y < 0.1)
												{
													NPC.velocity.Y = 0f;
												}
											}
											else
											{
												NPC.rotation = (float)Math.Atan2((double)NPC.velocity.Y, (double)NPC.velocity.X) - 1.57f;
											}
											if (NPC.ai[2] >= 42f)
											{
												NPC.ai[3] += 1f;
												NPC.ai[2] = 0f;
												NPC.target = 255;
												NPC.rotation = num420;
												if (NPC.ai[3] >= 10f)
												{
													NPC.ai[1] = 0f;
													NPC.ai[3] = 0f;
												}
												else
												{
													NPC.ai[1] = 1f;
												}
											}
										}
										if ((double)NPC.life < (double)NPC.lifeMax * 0.4)
										{
											NPC.ai[0] = 1f;
											NPC.ai[1] = 0f;
											NPC.ai[2] = 0f;
											NPC.ai[3] = 0f;
											NPC.netUpdate = true;
											return;
										}
									}
									else if (NPC.ai[0] == 1f || NPC.ai[0] == 2f)
									{
										if (NPC.ai[0] == 1f)
										{
											NPC.ai[2] += 0.005f;
											if ((double)NPC.ai[2] > 0.5)
											{
												NPC.ai[2] = 0.5f;
											}
										}
										else
										{
											NPC.ai[2] -= 0.005f;
											if (NPC.ai[2] < 0f)
											{
												NPC.ai[2] = 0f;
											}
										}
										NPC.rotation += NPC.ai[2];
										NPC.ai[1] += 1f;
										if (NPC.ai[1] == 100f)
										{
											NPC.ai[0] += 1f;
											NPC.ai[1] = 0f;
											if (NPC.ai[0] == 3f)
											{
												NPC.ai[2] = 0f;
											}
											else
											{
												SoundEngine.PlaySound(SoundID.Item16, NPC.position);
												int num;
												for (int num438 = 0; num438 < 2; num438 = num + 1)
												{
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 144, 1f);
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
													num = num438;
												}
												for (int num439 = 0; num439 < 20; num439 = num + 1)
												{
													Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
													num = num439;
												}
												SoundEngine.PlaySound(SoundID.Item16, NPC.position);
											}
										}
										Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
										NPC.velocity.X = NPC.velocity.X * 0.98f;
										NPC.velocity.Y = NPC.velocity.Y * 0.98f;
										if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
										{
											NPC.velocity.X = 0f;
										}
										if ((double)NPC.velocity.Y > -0.1 && (double)NPC.velocity.Y < 0.1)
										{
											NPC.velocity.Y = 0f;
											return;
										}
									}
									else
									{
										NPC.HitSound = SoundID.NPCHit4;
										NPC.damage = (int)((double)NPC.defDamage * 1.5);
										NPC.defense = NPC.defDefense + 18;
										if (NPC.ai[1] == 0f)
										{
											float num440 = 4f;
											float num441 = 0.1f;
											int num442 = 1;
											if (NPC.position.X + (float)(NPC.width / 2) < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
											{
												num442 = -1;
											}
											Vector2 vector46 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num443 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) + (float)(num442 * 180) - vector46.X;
											float num444 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector46.Y;
											float num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
											if (Main.expertMode)
											{
												if (num445 > 300f)
												{
													num440 += 0.5f;
												}
												if (num445 > 400f)
												{
													num440 += 0.5f;
												}
												if (num445 > 500f)
												{
													num440 += 0.55f;
												}
												if (num445 > 600f)
												{
													num440 += 0.55f;
												}
												if (num445 > 700f)
												{
													num440 += 0.6f;
												}
												if (num445 > 800f)
												{
													num440 += 0.6f;
												}
											}
											num445 = num440 / num445;
											num443 *= num445;
											num444 *= num445;
											if (NPC.velocity.X < num443)
											{
												NPC.velocity.X = NPC.velocity.X + num441;
												if (NPC.velocity.X < 0f && num443 > 0f)
												{
													NPC.velocity.X = NPC.velocity.X + num441;
												}
											}
											else if (NPC.velocity.X > num443)
											{
												NPC.velocity.X = NPC.velocity.X - num441;
												if (NPC.velocity.X > 0f && num443 < 0f)
												{
													NPC.velocity.X = NPC.velocity.X - num441;
												}
											}
											if (NPC.velocity.Y < num444)
											{
												NPC.velocity.Y = NPC.velocity.Y + num441;
												if (NPC.velocity.Y < 0f && num444 > 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y + num441;
												}
											}
											else if (NPC.velocity.Y > num444)
											{
												NPC.velocity.Y = NPC.velocity.Y - num441;
												if (NPC.velocity.Y > 0f && num444 < 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y - num441;
												}
											}
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 400f)
											{
												NPC.ai[1] = 1f;
												NPC.ai[2] = 0f;
												NPC.ai[3] = 0f;
												NPC.target = 255;
												NPC.netUpdate = true;
											}
											if (Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
											{
												NPC.localAI[2] += 1f;
												if (NPC.localAI[2] > 22f)
												{
													NPC.localAI[2] = 0f;
													SoundEngine.PlaySound(SoundID.Item34, NPC.position);
												}
												if (Main.netMode != NetmodeID.MultiplayerClient)
												{
													NPC.localAI[1] += 1f;
													if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
													{
														NPC.localAI[1] += 1f;
													}
													if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
													{
														NPC.localAI[1] += 1f;
													}
													if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
													{
														NPC.localAI[1] += 1f;
													}
													if ((double)NPC.life < (double)NPC.lifeMax * 0.1)
													{
														NPC.localAI[1] += 2f;
													}
													if (NPC.localAI[1] > 200f)
													{
														NPC.localAI[1] = 0f;
														float num446 = 6f;
														int num447 = 60; //30
														if (Main.expertMode)
														{
															num447 = 54; //27
														}
														int num448 = 101;
														vector46 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
														num443 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector46.X;
														num444 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector46.Y;
														num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
														num445 = num446 / num445;
														num443 *= num445;
														num444 *= num445;
														num444 += (float)Main.rand.Next(-40, 41) * 0.01f;
														num443 += (float)Main.rand.Next(-40, 41) * 0.01f;
														num444 += NPC.velocity.Y * 0.5f;
														num443 += NPC.velocity.X * 0.5f;
														vector46.X -= num443 * 1f;
														vector46.Y -= num444 * 1f;
								int num449;
														if (Main.rand.NextBool(8) && Main.netMode != NetmodeID.MultiplayerClient) num449 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector46.X, vector46.Y, num443, num444, num448, num447, 0f, Main.myPlayer, 0f, 0f);
														return;
													}
												}
											}
										}
										else
										{
											if (NPC.ai[1] == 1f)
											{
												SoundEngine.PlaySound(SoundID.Item16, NPC.position);
												NPC.rotation = num420;
												float num450 = 14f;
												if (Main.expertMode)
												{
													num450 += 2.5f;
												}
												Vector2 vector47 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
												float num451 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector47.X;
												float num452 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector47.Y;
												float num453 = (float)Math.Sqrt((double)(num451 * num451 + num452 * num452));
												num453 = num450 / num453;
												NPC.velocity.X = num451 * num453;
												NPC.velocity.Y = num452 * num453;
												NPC.ai[1] = 2f;
												return;
											}
											if (NPC.ai[1] == 2f)
											{
												NPC.ai[2] += 1f;
												if (Main.expertMode)
												{
													NPC.ai[2] += 0.5f;
												}
												if (NPC.ai[2] >= 50f)
												{
													NPC.velocity.X = NPC.velocity.X * 0.93f;
													NPC.velocity.Y = NPC.velocity.Y * 0.93f;
													if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
													{
														NPC.velocity.X = 0f;
													}
													if ((double)NPC.velocity.Y > -0.1 && (double)NPC.velocity.Y < 0.1)
													{
														NPC.velocity.Y = 0f;
													}
												}
												else
												{
													NPC.rotation = (float)Math.Atan2((double)NPC.velocity.Y, (double)NPC.velocity.X) - 1.57f;
												}
												if (NPC.ai[2] >= 80f)
												{
													NPC.ai[3] += 1f;
													NPC.ai[2] = 0f;
													NPC.target = 255;
													NPC.rotation = num420;
													if (NPC.ai[3] >= 6f)
													{
														NPC.ai[1] = 0f;
														NPC.ai[3] = 0f;
														return;
													}
													NPC.ai[1] = 1f;
													return;
												}
											}
										}
										
									}
									if (attackTime >= 60f)
												{
													attackTime = 0f;
													Vector2 vector40 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
													float num385 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector40.X;
													float num386 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector40.Y;
														float num389 = 9f;
														int num390 = 40; //20
														int num391 = 83;
														if (Main.expertMode)
														{
															num389 = 10.5f;
															num390 = 38; //19
														}
														float num387 = (float)Math.Sqrt((double)(num385 * num385 + num386 * num386));
														num387 = num389 / num387;
														num385 *= num387;
														num386 *= num387;
														num385 += (float)Main.rand.Next(-40, 41) * 0.08f;
														num386 += (float)Main.rand.Next(-40, 41) * 0.08f;
														vector40.X += num385 * 15f;
														vector40.Y += num386 * 15f;
													if (Main.rand.NextBool(8) && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), vector40.X, vector40.Y, num385, num386, num391, num390, 0f, Main.myPlayer, 0f, 0f);
													NPC.ai[3] = 0f;
													Vector2 vector44 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
													float num427 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector44.X;
													float num428 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector44.Y;
													if (Main.netMode != NetmodeID.MultiplayerClient)
													{
														float num430 = 8f;
														int num431 = 50; //25
														int num432 = 96;
														if (Main.expertMode)
														{
															num430 = 9f;
															num431 = 44; //22
														}
														float num429 = (float)Math.Sqrt((double)(num427 * num427 + num428 * num428));
														num429 = num430 / num429;
														num427 *= num429;
														num428 *= num429;
														num427 += (float)Main.rand.Next(-40, 41) * 0.05f;
														num428 += (float)Main.rand.Next(-40, 41) * 0.05f;
														vector44.X += num427 * 4f;
														vector44.Y += num428 * 4f;
														if (Main.rand.NextBool(8) && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), vector44.X, vector44.Y, num427, num428, num432, num431, 0f, Main.myPlayer, 0f, 0f);
													}
												}
		}
		public override void HitEffect(NPC.HitInfo hit) {
			for (int i = 0; i < 2; i++) {
				int dustType = 0;
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}