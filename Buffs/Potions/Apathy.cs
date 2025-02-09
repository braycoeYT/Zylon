using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Buffs.Accessories;
using Zylon.Buffs.Armor;
using Zylon.Buffs.Debuffs;

namespace Zylon.Buffs.Potions
{
    public class Apathy : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            p.bloodVial = true;
            for (int i = 0; i < 44; i++) {
                if (player.buffType[i] != ModContent.BuffType<Apathy>() && player.buffType[i] != ModContent.BuffType<Dishonored>() && player.buffType[i] != ModContent.BuffType<ManaRechargeCooldown>() && player.buffType[i] != ModContent.BuffType<Armor.BlackHoleCooldown>() && player.buffType[i] != ModContent.BuffType<BloodrainCooldown>() && player.buffType[i] != ModContent.BuffType<ShadowstitchedBlitzCooldown>() && player.buffType[i] != ModContent.BuffType<TatteredBlitzCooldown>() && player.buffType[i] != BuffID.NoBuilding)
                    player.DelBuff(i);
            }
        }
    }
}