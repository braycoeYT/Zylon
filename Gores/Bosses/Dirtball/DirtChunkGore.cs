using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Gores.Bosses.Dirtball
{
	public class DirtChunkGore : ModGore
	{
		public override string Texture => "Zylon/Gores/Bosses/Dirtball/DirtChunkGore";
		public override void SetStaticDefaults() {
			GoreID.Sets.SpecialAI[Type] = 0;
		}
    }
}