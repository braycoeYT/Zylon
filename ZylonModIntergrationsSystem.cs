using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;

namespace Zylon
{
	public class ZylonModIntegrationsSystem : ModSystem {
        public override void PostSetupContent() {
			DoBossChecklistIntegration();
		}
		private void DoBossChecklistIntegration() {
			// The mods homepage links to its own wiki where the calls are explained: https://github.com/JavidPack/BossChecklist/wiki/Support-using-Mod-Call
			// If we navigate the wiki, we can find the "AddBoss" method, which we want in this case

			if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod)) {
				return;
			}

			// For some messages, mods might not have them at release, so we need to verify when the last iteration of the method variation was first added to the mod, in this case 1.3.1
			// Usually mods either provide that information themselves in some way, or it's found on the github through commit history/blame
			if (bossChecklistMod.Version < new Version(1, 3, 1)) {
				return;
			}

			// The "AddBoss" method requires many parameters, defined separately below:

			// The name used for the title of the page
			string bossName = "Eldritch Jellyfish";

			// The NPC type of the boss
			int bossType = ModContent.NPCType<NPCs.Bosses.Jelly.EldritchJellyfish>();

			// Value inferred from boss progression, see the wiki for details
			float weight = 6.5f;

			// Used for tracking checklist progress
			Func<bool> downed = () => ZylonWorldCheckSystem.downedJelly;

			// If the boss should show up on the checklist in the first place and when (here, always)
			Func<bool> available = () => true;

			// "collectibles" like relic, trophy, mask, pet
			List<int> collection = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.JellyRelic>(),
				ModContent.ItemType<Items.Pets.EldritchGland>(),
				ModContent.ItemType<Items.Placeables.Trophies.JellyTrophy>(),
				ModContent.ItemType<Items.Vanity.JellyMask>()
			};

			// The item used to summon the boss with (if available)
			int summonItem = ModContent.ItemType<Items.BossSummons.EldritchBell>();

			// Information for the player so he knows how to encounter the boss
			string spawnInfo = $"Use a [i:{summonItem}] in the ocean";

			// The boss does not have a custom despawn message, so we omit it
			string despawnInfo = null;

			// By default, it draws the first frame of the boss, omit if you don't need custom drawing
			// But we want to draw the bestiary texture instead, so we create the code for that to draw centered on the intended location
			var customBossPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Jelly/EldritchJellyfish").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};
			bossChecklistMod.Call(
				"AddBoss",
				Mod,
				bossName,
				bossType,
				weight,
				downed,
				available,
				collection,
				summonItem,
				spawnInfo,
				despawnInfo
				//customBossPortrait
			);
			/*bossName = "Ancient Diskite Director";
			bossType = ModContent.NPCType<NPCs.Bosses.ADD.ADD_Center>();
			weight = 2.5f;
			downed = () => ZylonWorldCheckSystem.downedADD;
			available = () => true;
			collection = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.ADDRelic>(),
				ModContent.ItemType<Items.Pets.DiskiteDrive>(),
				ModContent.ItemType<Items.Placeables.Trophies.ADDTrophy>(),
				ModContent.ItemType<Items.Vanity.ADDMask>(),
				ModContent.ItemType<Items.Vanity.PolandballMask>()
			};
			summonItem = ModContent.ItemType<Items.BossSummons.EnchantedEye>();
			spawnInfo = $"Use a [i:{summonItem}] in the desert at night";
			despawnInfo = null;
			customBossPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ADD/ADD_Bestiary").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};*/
			bossChecklistMod.Call(
				"AddBoss",
				Mod,
				bossName,
				bossType,
				weight,
				downed,
				available,
				collection,
				summonItem,
				spawnInfo,
				despawnInfo,
				customBossPortrait
			);
			bossName = "Dirtball";
			bossType = ModContent.NPCType<NPCs.Bosses.Dirtball.Dirtball>();
			weight = 0.75f;
			downed = () => ZylonWorldCheckSystem.downedDirtball;
			available = () => true;
			collection = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.DirtballRelic>(),
				ModContent.ItemType<Items.Pets.DS_91Controller>(),
				ModContent.ItemType<Items.Placeables.Trophies.DirtballTrophy>(),
				ModContent.ItemType<Items.Vanity.DirtballMask>(),
			};
			summonItem = ModContent.ItemType<Items.BossSummons.CreepyMud>();
			spawnInfo = $"Use a [i:{summonItem}]";
			despawnInfo = null;
			customBossPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Dirtball/Dirtball").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};
			bossChecklistMod.Call(
				"AddBoss",
				Mod,
				bossName,
				bossType,
				weight,
				downed,
				available,
				collection,
				summonItem,
				spawnInfo,
				despawnInfo,
				customBossPortrait
			);
			bossName = "Metelord";
			bossType = ModContent.NPCType<NPCs.Bosses.Metelord.MetelordHead>();
			weight = 3.5f;
			downed = () => ZylonWorldCheckSystem.downedMetelord;
			available = () => true;
			collection = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.MetelordRelic>(),
				ModContent.ItemType<Items.Pets.PlasticDinoFigurine>(),
				ModContent.ItemType<Items.Placeables.Trophies.MetelordTrophy>(),
				ModContent.ItemType<Items.Vanity.MetelordMask>(),
			};
			summonItem = ModContent.ItemType<Items.BossSummons.StarstruckMeteorChunk>();
			spawnInfo = $"Use a [i:{summonItem}] in the Meteorite biome";
			despawnInfo = null;
			customBossPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Metelord/Metelord_Bestiary").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};
			bossChecklistMod.Call(
				"AddBoss",
				Mod,
				bossName,
				bossType,
				weight,
				downed,
				available,
				collection,
				summonItem,
				spawnInfo,
				despawnInfo,
				customBossPortrait
			);
		}
    }
}