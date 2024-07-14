using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Accessories
{
	public class DoublePluggedCord : ModBuff
	{
		public override void SetStaticDefaults() {
			Main.buffNoSave[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.GetDamage(DamageClass.Magic) += 0.25f;
		}
	}
}