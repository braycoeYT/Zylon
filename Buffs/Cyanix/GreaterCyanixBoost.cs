using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Cyanix
{
    public class GreaterCyanixBoost : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Greater Cyanix Boost");
            Description.SetDefault("Major increases to all stats\nDefense and regen are lowered from the pill's insane chemicals\nStrength: 7");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.endurance -= 0.07f; //-0.01 x S
			player.lifeRegen -= 3; //0.5 x S, then round down
			player.magicCrit += 14; //2 x S
			player.magicDamage += 0.35f; //0.05 x S
			player.manaCost -= 0.14f; //-0.02 x S
			player.manaRegen -= 3; //0.5 x S, then round down
			player.maxRunSpeed += 2.8f; //0.4 x S
			player.meleeCrit += 14; //2 x S
			player.meleeDamage += 0.35f; //0.05 x S
			player.meleeSpeed += 0.14f; //0.02 x S
			player.minionDamage += 0.35f; //0.05 x S
			player.minionKB += 1.75f; //0.25 x S
			player.pickSpeed -= 0.07f; //-0.01 x S
			player.rangedCrit += 14; //2 x S
			player.rangedDamage += 0.35f; //0.05 x S
			player.statDefense -= 20; //depends on strength
			player.thrownCrit += 14; //2 x S
			player.thrownDamage += 0.35f; //0.05 x S
			player.wingTimeMax += 105; //15 x S
        }
    }
}