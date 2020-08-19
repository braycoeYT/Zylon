using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.NPCs.Minibosses
{
	[AutoloadBossHead]
	public class XenicAcidpumperGood : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Xenic Acidpumper");
			Main.npcFrameCount[npc.type] = 12;
		}

        public override void SetDefaults()
		{
			npc.width = 84;
			npc.height = 136;
			npc.damage = 0;
			npc.defense = 750000;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.boss = false;
			npc.netAlways = true;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
			npc.buffImmune[BuffID.Venom] = false;
			npc.noTileCollide = true;
			npc.lavaImmune = true;
        }
		int Timer;
		int animationTimer;
		bool Chat1 = true;
		Vector2 targetPlayer;
		public override void AI()
		{
			Timer++;
			if (Timer % 3 == 0)
			{
				animationTimer++;
			}
			if (animationTimer > 11)
			animationTimer = 0;
			npc.TargetClosest(true);

			Player target = Main.player[npc.target];
			targetPlayer = Main.player[npc.target].Center;
				if (Chat1)
				{
					Color messageColor = Color.Pink;
					string chat = "A Xenic Acidpumper has landed nearby!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					Chat1 = false;
				}
			npc.frame.Y = animationTimer * 142;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (ZylonWorld.downedMineral && (!(NPC.CountNPCS(mod.NPCType("XenicAcidpumper")) > 0)))
			return SpawnCondition.Sky.Chance * 0.02f;
			return 0f;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 163;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (npc.life <= 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("XenicAcidpumper"));
				Color messageColor = Color.Pink;
				string chat = "Activating offensive mode...";
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				}
				else if (Main.netMode == NetmodeID.SinglePlayer)
				{
					Main.NewText(Language.GetTextValue(chat), messageColor);
				}
			}
		}
	}
}