using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class BloodDrop : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blood Drop");
            Description.SetDefault("6% chance of any javelance to leech health from enemies");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            p.bloodJavelance = true;
        }
    }
}