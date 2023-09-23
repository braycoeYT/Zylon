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

			if (bossChecklistMod.Version < new Version(1, 6)) {
				return;
			}

			string internalName = "Dirtball";
			float weight = 0.75f;
			Func<bool> downed = () => ZylonWorldCheckSystem.downedDirtball;
			int bossType = ModContent.NPCType<NPCs.Bosses.Dirtball.Dirtball>();
			int spawnItem = ModContent.ItemType<Items.BossSummons.CreepyMud>();
			List<int> collectibles = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.DirtballRelic>(),
				ModContent.ItemType<Items.Pets.DS_91Controller>(),
				ModContent.ItemType<Items.Accessories.EnchantedDirtClump>(),
				ModContent.ItemType<Items.Placeables.Trophies.DirtballTrophy>(),
				ModContent.ItemType<Items.Vanity.DirtballMask>()
			};
			var customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => { //ignore
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Dirtball/Dirtball").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};
			bossChecklistMod.Call(
				"LogBoss",
				Mod,
				internalName,
				weight,
				downed,
				bossType,
				new Dictionary<string, object>() {
					["spawnItems"] = spawnItem,
					["collectibles"] = collectibles,
					//["customPortrait"] = customPortrait
				}
			);


			internalName = "MetelordHead";
			weight = 3.5f;
			downed = () => ZylonWorldCheckSystem.downedMetelord;
			bossType = ModContent.NPCType<NPCs.Bosses.Metelord.MetelordHead>();
			spawnItem = ModContent.ItemType<Items.BossSummons.StarstruckMeteorChunk>();
			collectibles = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.MetelordRelic>(),
				ModContent.ItemType<Items.Pets.PlasticDinoFigurine>(),
				ModContent.ItemType<Items.Accessories.Metecore>(),
				ModContent.ItemType<Items.Placeables.Trophies.MetelordTrophy>(),
				ModContent.ItemType<Items.Vanity.MetelordMask>(),
			};
			customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Metelord/Metelord_Bestiary").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};
			bossChecklistMod.Call(
				"LogBoss",
				Mod,
				internalName,
				weight,
				downed,
				bossType,
				new Dictionary<string, object>() {
					["spawnItems"] = spawnItem,
					["collectibles"] = collectibles,
					["customPortrait"] = customPortrait
				}
			);


			internalName = "ADD_Main";
			weight = 4.5f;
			downed = () => ZylonWorldCheckSystem.downedADD;
			bossType = ModContent.NPCType<NPCs.Bosses.ADD.ADD_Main>();
			spawnItem = ModContent.ItemType<Items.BossSummons.EnchantedEye>();
			collectibles = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.ADDRelic>(),
				ModContent.ItemType<Items.Pets.DiskiteDrive>(),
				//ModContent.ItemType<Items.Accessories.>(),
				//ModContent.ItemType<Items.Placeables.Trophies.ADDTrophy>(),
				ModContent.ItemType<Items.Vanity.ADDMask>(),
				ModContent.ItemType<Items.Vanity.PolandballMask>()
			};
			customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/ADD/ADD_Bestiary").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};
			bossChecklistMod.Call(
				"LogBoss",
				Mod,
				internalName,
				weight,
				downed,
				bossType,
				new Dictionary<string, object>() {
					["spawnItems"] = spawnItem,
					["collectibles"] = collectibles,
					["customPortrait"] = customPortrait
				}
			);


			internalName = "EldritchJellyfish";
			weight = 6.5f;
			downed = () => ZylonWorldCheckSystem.downedJelly;
			bossType = ModContent.NPCType<NPCs.Bosses.Jelly.EldritchJellyfish>();
			spawnItem = ModContent.ItemType<Items.BossSummons.EldritchBell>();
			collectibles = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.JellyRelic>(),
				ModContent.ItemType<Items.Pets.EldritchGland>(),
				ModContent.ItemType<Items.Accessories.Wings.EldritchTentacles>(),
				ModContent.ItemType<Items.Placeables.Trophies.JellyTrophy>(),
				ModContent.ItemType<Items.Vanity.JellyMask>()
			};
			customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Jelly/EldritchJellyfish").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};
			bossChecklistMod.Call(
				"LogBoss",
				Mod,
				internalName,
				weight,
				downed,
				bossType,
				new Dictionary<string, object>() {
					["spawnItems"] = spawnItem,
					["collectibles"] = collectibles,
					["customPortrait"] = customPortrait
				}
			);
		}
    }
}