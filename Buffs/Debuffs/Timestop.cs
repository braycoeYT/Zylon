using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class Timestop : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Timestop");
            // Description.SetDefault("ZA WARUDO!");
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        bool setup;
        Vector2 stay = new Vector2();
        public override void Update(Player player, ref int buffIndex) {
			player.velocity = Vector2.Zero;
            if (!setup) {
                stay = player.position;
                setup = true;
            }
            player.position = stay;
            if (Main.rand.NextBool(3)) {
                int dustType = ModContent.DustType<Dusts.MiniClockDust>();
                int dustIndex = Dust.NewDust(player.position, player.width, player.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
            }
		}
        public override void Update(NPC npc, ref int buffIndex) {
            npc.GetGlobalNPC<NPCs.ZylonGlobalNPCDebuff>().timestop = true;
            if (Main.rand.NextBool(3) && npc.boss == false && npc.type != NPCID.GolemHead) {
                int dustType = ModContent.DustType<Dusts.MiniClockDust>();
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
            }
		}
    }
}