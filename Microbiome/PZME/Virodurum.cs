using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome.PZME
{
	public class Virodurum : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Virodurum");
			Main.npcFrameCount[npc.type] = 4;
		}
        public override void SetDefaults() {
			npc.width = 78;
			npc.height = 74;
			npc.damage = 172;
			npc.defense = 79;
			npc.lifeMax = 6948;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 900f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
			animationType = 82;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 12738;
            npc.damage = 289;
			npc.defense = 91;
        }
		public override void OnHitPlayer(Player player, int damage, bool crit) {
			if (Main.rand.NextBool(2)) {
				player.AddBuff(mod.BuffType("Sick"), 700, true);
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = mod.DustType("MicrobiomeDust");
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		int Timer;
		public override void AI()
		{
			if (Main.player[npc.target].statLife < 1) {
				npc.TargetClosest(true);
			}
			Player target = Main.player[npc.target];
			Timer++;
			if (Timer % 120 == 0) {
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, 257, 59, 1f, Main.myPlayer);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, 257, 59, 1f, Main.myPlayer);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, 257, 59, 1f, Main.myPlayer);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, 257, 59, 1f, Main.myPlayer);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (ZylonWorld.downedMineral)
				return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome ? 0.2f : 0f;
			return 0f;
		}
		public override void NPCLoot() {
			if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("InfectedOnyx"));
			if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"));
			if (Main.rand.Next(4) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("NucleusShard"));
		}
	}
}