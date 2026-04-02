using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace Zylon
{
	public class ZylonModIntegrationsSystem : ModSystem {
        public override void PostSetupContent() {
			DoBossChecklistIntegration(); //https://github.com/JavidPack/BossChecklist/wiki/Boss-Progression-Values
		}
		private void DoBossChecklistIntegration() {
			if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod)) {
				return;
			}

			if (bossChecklistMod.Version < new Version(1, 6)) {
				return;
			}

			string internalName = "Dirtball";
			float weight = 0.99f;
			Func<bool> downed = () => ZylonWorldCheckSystem.downedDirtball;
			int bossType = ModContent.NPCType<NPCs.Bosses.Dirtball.Dirtball>();
			int spawnItem = ModContent.ItemType<Items.BossSummons.CreepyMud>();
			List<int> collectibles = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.DirtballRelic>(),
				ModContent.ItemType<Items.Pets.DS_91Controller>(),
				ModContent.ItemType<Items.Placeables.Trophies.DirtballTrophy>(),
				ModContent.ItemType<Items.Vanity.BossMask.DirtballMask>()
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


			/*internalName = "MetelordHead";
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
			);*/


			internalName = "Adeneb";
			weight = 4.5f;
			downed = () => ZylonWorldCheckSystem.downedAdeneb;
			bossType = ModContent.NPCType<NPCs.Bosses.Adeneb.Adeneb>();
			spawnItem = ModContent.ItemType<Items.BossSummons.EnchantedEye>();
			collectibles = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.AdenebRelic>(),
				ModContent.ItemType<Items.Pets.DiskDrive>(),
				ModContent.ItemType<Items.Placeables.Trophies.AdenebTrophy>(),
				ModContent.ItemType<Items.Vanity.BossMask.AdenebMask>(),
				ModContent.ItemType<Items.Vanity.PolandballMask>()
			};
			customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_Bestiary").Value;
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
			weight = 6.25f;
			downed = () => ZylonWorldCheckSystem.downedJelly;
			bossType = ModContent.NPCType<NPCs.Bosses.Jelly.EldritchJellyfish>();
			spawnItem = ModContent.ItemType<Items.BossSummons.EldritchBell>();
			collectibles = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.JellyRelic>(),
				ModContent.ItemType<Items.Pets.EldritchGland>(),
				ModContent.ItemType<Items.Placeables.Trophies.JellyTrophy>(),
				ModContent.ItemType<Items.Vanity.BossMask.JellyMask>()
			};
			customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Jelly/EldritchJellyfish_Bestiary").Value;
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

			internalName = "MatrixScavenger";
			weight = 11.49f;
			downed = () => ZylonWorldCheckSystem.downedJelly;
			bossType = ModContent.NPCType<NPCs.Bosses.Scavenger.MatrixScavenger>();
			spawnItem = ModContent.ItemType<Items.BossSummons.CompromisedFlashDrive>();
			collectibles = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.ScavengerRelic>(),
				ModContent.ItemType<Items.Pets.OldFashionedComputer>(),
				ModContent.ItemType<Items.Placeables.Trophies.ScavengerTrophy>(),
				ModContent.ItemType<Items.Vanity.BossMask.ScavengerMask>()
			};
			customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Scavenger/MatrixScavenger_Bestiary").Value;
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


			internalName = "SaburRex";
			weight = 19f;
			downed = () => ZylonWorldCheckSystem.downedSabur;
			bossType = ModContent.NPCType<NPCs.Bosses.SaburRex.SaburRex>();
			spawnItem = ModContent.ItemType<Items.BossSummons.AwakenedRiftCalibrator>();
			collectibles = new List<int>()
			{
				ModContent.ItemType<Items.Placeables.Relics.SaburRelic>(),
				ModContent.ItemType<Items.Pets.AncientGameController>(),
				ModContent.ItemType<Items.Placeables.Trophies.SaburTrophy>(),
				ModContent.ItemType<Items.Vanity.BossMask.SaburMask>(),
				ModContent.ItemType<Items.Swords.Excalipoor>()
			};
			customPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_Bestiary").Value;
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