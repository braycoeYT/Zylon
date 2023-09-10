using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs
{
	public class LeafBracer : ModBuff
	{
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			DisplayName.SetDefault("Leaf Bracer");
			Description.SetDefault("You are granted protection through the power of nature");
=======
			// DisplayName.SetDefault("Leaf Bracer");
			// Description.SetDefault("You are granted protection through the power of nature");
>>>>>>> ProjectClash
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.immune = true;
		}
	}
}