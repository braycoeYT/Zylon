using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class DiskiteAgility : ModBuff
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Diskbringer: Agility");
            Description.SetDefault("Increases your run acceleration and deceleration by 10%, move speed by 20%, increases the power of sprinting boots, and max jump speed");
            Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = false;
            Main.buffDoubleApply[Type] = false;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.runAcceleration += 0.1f;
			player.runSlowdown += 0.1f;
            player.moveSpeed += 0.2f;
            if (player.accRunSpeed > 0)
				player.accRunSpeed += 1f;
			player.jumpSpeedBoost += 1f;
		}
    }
}