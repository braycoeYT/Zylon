using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Metelord
{
	public class MetelordHeadGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Metelord/MetelordHeadGore";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}