using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Cyanix
{
    public class SuperCyanixBoost : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Super Cyanix Boost");
            Description.SetDefault("Major increases to all stats\nDefense and regen are lowered from the pill's illegal chemicals\nStrength: 10");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.endurance -= 0.1f; //-0.01 x S
			player.lifeRegen -= 5; //0.5 x S, then round down
			player.magicCrit += 20; //2 x S
			player.magicDamage += 0.5f; //0.05 x S
			player.manaCost -= 0.2f; //-0.02 x S
			player.manaRegen -= 5; //0.5 x S, then round down
			player.maxRunSpeed += 4f; //0.4 x S
			player.meleeCrit += 20; //2 x S
			player.meleeDamage += 0.5f; //0.05 x S
			player.meleeSpeed += 0.2f; //0.02 x S
			player.minionDamage += 0.5f; //0.05 x S
			player.minionKB += 2.5f; //0.25 x S
			player.pickSpeed -= 0.1f; //-0.01 x S
			player.rangedCrit += 20; //2 x S
			player.rangedDamage += 0.5f; //0.05 x S
			player.statDefense -= 40; //depends on strength
			player.thrownCrit += 20; //2 x S
			player.thrownDamage += 0.5f; //0.05 x S
			player.wingTimeMax += 150; //15 x S
        }
    }
}