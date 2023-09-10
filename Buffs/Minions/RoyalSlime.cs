using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Buffs.Minions
{
	public class RoyalSlime : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Floating Slime Staff");
			// Description.SetDefault("The Floating Slime Staff will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.RoyalSlime>()] > 0 && player.head == ItemType<Items.Armor.SlimePrinceHelmet>() && player.body == ItemType<Items.Armor.SlimePrinceBreastplate>() && player.legs == ItemType<Items.Armor.SlimePrinceLeggings>()){
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}