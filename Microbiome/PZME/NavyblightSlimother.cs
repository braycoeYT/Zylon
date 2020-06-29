using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome.PZME
{
	public class NavyblightSlimother : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Navyblight Slimother");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
		{
			npc.width = 45; //28
			npc.height = 43; //27
			npc.damage = 231;
			npc.defense = 31;
			npc.lifeMax = 23910;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 1500f;
			npc.aiStyle = 1;
			npc.knockBackResist = 0f;
			animationType = 1;
			npc.alpha = 50;
			npc.scale = 1.6f;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[mod.BuffType("Sick")] = true;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				float numberNPC = Main.rand.Next(2, 5);
				for (int i = 0; i < numberNPC; i++)
				{
					NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), mod.NPCType("NavyblightSlime"));
				}
			}
			else if (Main.rand.Next(0, 5) == 0)
			{
				NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), mod.NPCType("NavyblightSlime"));
			}
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 41857;
            npc.damage = 314;
        }
		
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				player.AddBuff(mod.BuffType("Sick"), 700, true);
			}
		}
		int Timer;
		public override void AI()
		{
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
			}
			Player target = Main.player[npc.target];
			Vector2 target2 = target.position;
			target2.X += Main.rand.Next(-60, 60);
			target2.Y += Main.rand.Next(-60, 60);
			Timer++;
			if (Timer % 120 == 0)
				Projectile.NewProjectile(npc.Center, (npc.DirectionTo(target2)) * 4, 83, 59, 1f, Main.myPlayer);
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (ZylonWorld.downedMineral)
			{
				return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome ? 0.14f : 0f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"));
			if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"));
		}
	}
}