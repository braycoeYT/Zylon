using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class Sick : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sick");
            Description.SetDefault("Infected with viruses, damage decreased by 20%");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage -= 0.2f;
            for (int i = 0; i < 3; i++)
            {
                int dustType = 80;
                int dustIndex = Dust.NewDust(player.position, player.width, player.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }
        }
        public override void Update(NPC npc, ref int buffIndex) {
            npc.damage /= 5;
            for (int i = 0; i < 3; i++)
            {
                int dustType = 80;
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }
            npc.color = Color.DarkCyan;
            if (npc.buffTime[buffIndex] < 10)
                npc.color = Color.Transparent;
        }
    }
}