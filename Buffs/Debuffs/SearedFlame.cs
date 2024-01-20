using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Debuffs
{
    public class SearedFlame : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ZylonPlayer>().searedFlame = true;
            for (int x = 0; x < Main.rand.Next(1, 3); x++) {
                int dustType = DustID.Torch;
                int dustIndex = Dust.NewDust(player.position, player.width, player.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1.5f + Main.rand.Next(-30, 31) * 0.01f;
            }
		}
    }
}