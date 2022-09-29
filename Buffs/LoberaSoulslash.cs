using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class LoberaSoulslash : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lobera's Soulslash");
            Description.SetDefault("Your soul has been pierced by a sword of great virtue");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.statDefense = (int)(player.statDefense * 0.5f);
            for (int i = 0; i < 3; i++) {
                int dustType = ModContent.DustType<Dusts.LoberaDust>();
                int dustIndex = Dust.NewDust(player.position, player.width, player.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
            }
        }
        bool safe;
        Color safeColor;
        public override void Update(NPC npc, ref int buffIndex) {
            if (safe) {
                safeColor = npc.color;
                safe = false;
            }
            npc.defense = (int)(npc.defense * 0.5f);
            for (int i = 0; i < 3; i++) {
                int dustType = ModContent.DustType<Dusts.LoberaDust>();
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
            }
            npc.color = Color.LightGoldenrodYellow;
            if (npc.buffTime[buffIndex] < 5)
                npc.color = safeColor;
        }
    }
}