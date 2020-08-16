using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class Encased : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Encased");
            Description.SetDefault("Increases defense by 40");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 40;
        }
    }
}