using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class OutOfBreath : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Out of Breath");
            Description.SetDefault("You can't breathe!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.wet)
            player.breath -= 1;
            else
            if (Main.GameUpdateCount % 2 == 0)
            player.breath -= 3;
            else
            player.breath -= 4;
            if (player.breath < 0)
            {
                player.breath = 0;
                if (Main.GameUpdateCount % 5 == 0)
                {
                    int hpHurt;
                    if (player.statLifeMax2 > 599)
                   hpHurt = 5;
                    else if (player.statLifeMax2 > 499)
                   hpHurt = 4;
                  else if (player.statLifeMax2 > 399)
                   hpHurt = 3;
                  else if (player.statLifeMax2 > 199)
                   hpHurt = 2;
                  else
                    hpHurt = 1;
                    player.statLife -= hpHurt;
                    CombatText.NewText(player.getRect(), Color.IndianRed, hpHurt); ;
                  if (player.lifeRegen > 0)
                        player.lifeRegen = 0;
                  if (player.statLife < 1)
                    {
                        int deathNum = Main.rand.Next(0, 3);
                        if (deathNum == 0)
                        {
                            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " ran out of air."), hpHurt, 0, false);
                        }
                        if (deathNum == 1)
                        {
                            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " became too tired."), hpHurt, 0, false);
                        }
                        if (deathNum == 2)
                        {
                            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " tried to treat a blowpipe like a kazoo."), hpHurt, 0, false);
                        }
                    }
                }
            }
        }
    }
}