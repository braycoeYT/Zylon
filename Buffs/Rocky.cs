using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
    public class Rocky : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rocky");
            Description.SetDefault("Gain 12 defense at the cost of attack and movement speed");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 12;
			player.maxRunSpeed -= player.maxRunSpeed * 0.1f;
			player.runAcceleration -= player.runAcceleration * 0.1f;
			player.moveSpeed -= player.moveSpeed * 0.1f;
			player.meleeDamage -= 0.05f;
			player.rangedDamage -= 0.05f;
			player.magicDamage -= 0.05f;
			player.thrownDamage -= 0.05f;
        }
    }
}