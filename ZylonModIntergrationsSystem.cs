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
			if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod)) {
				return;
			}

			if (bossChecklistMod.Version < new Version(1, 3, 1)) {
				return;
			}

			string bossName = "Eldritch Jellyfish";
			int bossType = ModContent.NPCType<NPCs.Bosses.Jelly.EldritchJellyfish>();
			float weight = 6.5f;
			Func<bool> downed = () => ZylonWorldCheckSystem.downedJelly;
			Func<bool> available = () => true;
			List<int> collection = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.JellyRelic>(),
				ModContent.ItemType<Items.Pets.EldritchGland>(),
				ModContent.ItemType<Items.Placeables.Trophies.JellyTrophy>(),
				ModContent.ItemType<Items.Vanity.JellyMask>()
			};
			int summonItem = ModContent.ItemType<Items.BossSummons.EldritchBell>();
			string spawnInfo = $"Use a [i:{summonItem}] in the ocean";
			string despawnInfo = null;
			var customBossPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Jelly/EldritchJellyfish").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};
			bossChecklistMod.Call(
				"LogBoss",
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
			bossName = "Ancient Diskite Director";
			bossType = ModContent.NPCType<NPCs.Bosses.ADD.ADD_Main>();
			weight = 4.5f;
			downed = () => ZylonWorldCheckSystem.downedADD;
			available = () => true;
			collection = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.ADDRelic>(),
				ModContent.ItemType<Items.Pets.DiskiteDrive>(),
				//ModContent.ItemType<Items.Placeables.Trophies.ADDTrophy>(),
				ModContent.ItemType<Items.Vanity.ADDMask>(),
				ModContent.ItemType<Items.Vanity.PolandballMask>()
			};
			summonItem = ModContent.ItemType<Items.BossSummons.EnchantedEye>();
			spawnInfo = $"Use a [i:{summonItem}] in the desert";
			despawnInfo = null;
			customBossPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ADD/ADD_Bestiary").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};
			bossChecklistMod.Call(
				"LogBoss",
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
				"LogBoss",
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
				"LogBoss",
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