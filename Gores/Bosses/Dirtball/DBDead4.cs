using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Dirtball
{
	public class DBDead4 : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Dirtball/DBDead4";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}