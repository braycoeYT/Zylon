using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Cyanix
{
    public class LesserCyanixBoost : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lesser Cyanix Boost");
            Description.SetDefault("Minor increases to all stats\nDefense and regen are lowered from the pill's chemicals\nStrength: 2");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.endurance -= 0.02f; //-0.01 x S
			player.lifeRegen -= 1; //0.5 x S, then round down
			player.magicCrit += 4; //2 x S
			player.magicDamage += 0.1f; //0.05 x S
			player.manaCost -= 0.04f; //-0.02 x S
			player.manaRegen -= 1; //0.5 x S, then round down
			player.maxRunSpeed += 0.8f; //0.4 x S
			player.meleeCrit += 4; //2 x S
			player.meleeDamage += 0.1f; //0.05 x S
			player.meleeSpeed += 0.04f; //0.02 x S
			player.minionDamage += 0.1f; //0.05 x S
			player.minionKB += 0.5f; //0.25 x S
			player.pickSpeed -= 0.02f; //-0.01 x S
			player.rangedCrit += 4; //2 x S
			player.rangedDamage += 0.1f; //0.05 x S
			player.statDefense -= 5; //depends on strength
			player.thrownCrit += 4; //2 x S
			player.thrownDamage += 0.1f; //0.05 x S
			player.wingTimeMax += 30; //15 x S
        }
    }
}