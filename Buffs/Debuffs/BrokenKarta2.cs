using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
	public class BrokenKarta2 : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Broken Karta");
			Description.SetDefault("Your Karta is broken!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.HasBuff(ModContent.BuffType<Heartdaze>()))
				player.buffTime[buffIndex] = 0;
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			if (npc.HasBuff(ModContent.BuffType<Heartdaze>()))
				npc.buffTime[buffIndex] = 0;
		}
	}
}