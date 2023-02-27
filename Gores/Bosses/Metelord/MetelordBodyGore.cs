using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Metelord
{
	public class MetelordBodyGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Metelord/MetelordBodyGore";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}