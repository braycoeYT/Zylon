using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon
{
	public class Zylon : Mod
	{
		public static bool hasFoughtSabur;
		public static bool noHitSabur;
		public static void ZylonVanity(Player player, bool hM = false, bool pML = false) {
			int who = 0;

			switch (who) {
				case 0:
					player.QuickSpawnItem(player.GetSource_FromThis(), ModContent.ItemType<Items.Vanity.Dev.BraycoeHead>());
					player.QuickSpawnItem(player.GetSource_FromThis(), ModContent.ItemType<Items.Vanity.Dev.BraycoeBody>());
					player.QuickSpawnItem(player.GetSource_FromThis(), ModContent.ItemType<Items.Vanity.Dev.BraycoeLegs>());
				break;
			}

			if (hM) switch (who) {
				case 0:
					player.QuickSpawnItem(player.GetSource_FromThis(), ModContent.ItemType<Items.LightPets.MysticFurball>());
				break;
			}
		}
    }
}