using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Dirtball
{
	public class DS17GoreRight : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Dirtball/DS17GoreRight";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}