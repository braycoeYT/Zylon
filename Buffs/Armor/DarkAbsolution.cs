using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Armor
{
    public class DarkAbsolution : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ZylonPlayer>().darkAbsolution = true;
		}
    }
}