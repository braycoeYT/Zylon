using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Cyanix
{
    public class CyanixBoost : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Cyanix Boost");
            Description.SetDefault("Minor increases to all stats\nDefense and regen are lowered from the pill's semidangerous chemicals\nStrength: 4");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex) {
			player.endurance -= 0.04f; //-0.01 x S
			player.lifeRegen -= 2; //0.5 x S, then round down
			player.magicCrit += 8; //2 x S
			player.magicDamage += 0.2f; //0.05 x S
			player.manaCost -= 0.08f; //-0.02 x S
			player.manaRegen -= 2; //0.5 x S, then round down
			player.maxRunSpeed += 1.6f; //0.4 x S
			player.meleeCrit += 8; //2 x S
			player.meleeDamage += 0.2f; //0.05 x S
			player.meleeSpeed += 0.08f; //0.02 x S
			player.minionDamage += 0.2f; //0.05 x S
			player.minionKB += 1f; //0.25 x S
			player.pickSpeed -= 0.04f; //-0.01 x S
			player.rangedCrit += 8; //2 x S
			player.rangedDamage += 0.2f; //0.05 x S
			player.statDefense -= 10; //depends on strength
			player.thrownCrit += 8; //2 x S
			player.thrownDamage += 0.2f; //0.05 x S
			player.wingTimeMax += 60; //15 x S
        }
    }
}