using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Buffs.Minions
{
    public class GoldenAutumnSpirit : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Golden Autumn Spirit");
			Description.SetDefault("The Golden Force of Nature will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.GoldenAutumn.GoldenAutumnSpirit>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}