using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Dirtball
{
	public class DBDead1 : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Dirtball/DBDead1";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}