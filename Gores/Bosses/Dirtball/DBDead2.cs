using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Dirtball
{
	public class DBDead2 : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Dirtball/DBDead2";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}