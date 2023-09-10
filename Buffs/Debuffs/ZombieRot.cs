using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class ZombieRot : ModBuff
    {
        public override void SetStaticDefaults() {
            // Description.SetDefault("Your limbs feel like falling off...");
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        /*public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ZylonPlayer>().zombieRot = true;
            for (int i = 0; i < 2; i++) {
                int dustIndex = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.ZombieRotDust>());
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
            }
		}*/
        int Timer;
  		public override void Update(NPC npc, ref int buffIndex) {
            Timer++;
            /*if (Timer > 600) {
                npc.DelBuff(buffIndex);
				buffIndex--;
            }*/
            if (npc.buffTime[buffIndex] <= 20) return;
			npc.GetGlobalNPC<NPCs.ZylonGlobalNPCDebuff>().zombieRot = true;
            for (int i = 0; i < 2; i++) {
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.ZombieRotDust>());
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
            }
		}
    }
}