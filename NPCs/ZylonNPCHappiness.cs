using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs
{
	public class ZylonNPCHappiness : GlobalNPC
	{
		public override void SetStaticDefaults() {
			int hitmanType = ModContent.NPCType<TownNPCs.Hitman>();

			var partyGirlHappiness = NPCHappiness.Get(NPCID.PartyGirl);
			var taxCollectorHappiness = NPCHappiness.Get(NPCID.TaxCollector);

			partyGirlHappiness.SetNPCAffection(hitmanType, AffectionLevel.Dislike);
			taxCollectorHappiness.SetNPCAffection(hitmanType, AffectionLevel.Love);
		}
	}
}