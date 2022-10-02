using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class BrainFreeze : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Brain Freeze");
            Description.SetDefault("Agahah! I HATE COLD HEADACHES!!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.velocity *= 0.93f;
        }
        bool safe;
        Color safeColor;
        public override void Update(NPC npc, ref int buffIndex) {
            if (safe) {
                safeColor = npc.color;
                safe = false;
            }
            npc.velocity *= 0.93f;
            npc.color = Color.LightSkyBlue;
            if (npc.buffTime[buffIndex] < 5)
                npc.color = safeColor;
        }
    }
}