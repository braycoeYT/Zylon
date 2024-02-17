using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Accessories
{
	public class GraniteEnergyBoost : ModBuff
	{
		public override void SetStaticDefaults() {
			Main.buffNoSave[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.manaRegen += 2;
			player.manaRegenBonus += 1;
		}
	}
}