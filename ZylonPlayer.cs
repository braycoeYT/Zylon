using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Zylon
{
	public class ZylonPlayer : ModPlayer
	{	
		
		public bool ZoneOblivion;
		public bool ZoneMicrobiome;
		public bool MarblePet;
		public bool UpgradeMeatball;
		public bool SlimyCore;
		public bool BraycoeSlimePet;
		public bool CyanixLong;
		public bool gemstoneSpikes;
		public bool gemstoneManaBullet;
		public bool gemstoneRain;
		public bool empressSpikes;
		public bool darkstarFall;
		public bool hurtHeal;
		public bool redJavelance;
		public bool electricField;
		public bool eyeCandy;
		public bool hyperCell;
		public bool magentiteBonus;
		public bool bloodJavelance;
		public bool cyanixShort;
		public bool cytocellPet;
		public bool mineralExpert;
		public bool xenicAcid;
		public bool xenicExpert;
		public bool gemstoneMelee;
		public bool gemstoneRanged;
		public bool gemstoneMagic;
		public bool gemstoneSummon;
		public bool trueMelee35;
		public bool microDelusion;
		int numberShot = 0;
		public int upgradeHearts;
		public int upgradeStars;
		public int playerTimer;
		public int healHurt;
		public override void ResetEffects()
		{
			MarblePet = false;
			UpgradeMeatball = false;
			SlimyCore = false;
			BraycoeSlimePet = false;
			CyanixLong = false;
			gemstoneSpikes = false;
			gemstoneRanged = false;
			gemstoneManaBullet = false;
			gemstoneRain = false;
			empressSpikes = false;
			darkstarFall = false;
			hurtHeal = false;
			redJavelance = false;
			electricField = false;
			eyeCandy = false;
			hyperCell = false;
			magentiteBonus = false;
			bloodJavelance = false;
			cytocellPet = false;
			mineralExpert = false;
			xenicAcid = false;
			xenicExpert = false;
			gemstoneMelee = false;
			gemstoneMagic = false;
			gemstoneSummon = false;
			trueMelee35 = false;
			microDelusion = false;
			player.statLifeMax2 += upgradeHearts * 25;
			player.statManaMax2 += upgradeStars * 50;
			playerTimer = 0;
			healHurt = 0;
		}
		public override void UpdateDead() {
			xenicAcid = false;
			microDelusion = false;
		}
		int badRegenTimer;
		public override void UpdateBadLifeRegen() {
			badRegenTimer++;
			if (xenicAcid) {
				if (player.lifeRegen > 0 && !xenicExpert) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				if (!xenicExpert)
				if (mineralExpert)
				player.lifeRegen -= 12;
				else
				player.lifeRegen -= 16;

				if (xenicExpert && badRegenTimer % 10 == 0)
				{
					player.statLife += 1;
					player.HealEffect(1, true);
				}
			}
			if (microDelusion) {
				if (player.lifeRegen > 0 && !xenicExpert) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 6;
			}
			if (healHurt > 0) {
				if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 120 * healHurt;
			}
		}
		public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
			if (xenicAcid) {
				if (Main.rand.NextBool(4) && drawInfo.shadow == 0f) {
					int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 193, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 0, default(Color), 2f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					Main.playerDrawDust.Add(dust);
				}
				r *= 0.1f;
				g *= 0.5f;
				b *= 0.1f;
				fullBright = true;
			}
		}
		public override TagCompound Save()
		{
			return new TagCompound {
		{"upgradeHearts", upgradeHearts},
		{"upgradeStars", upgradeStars},
	};
		}
		public override void Load(TagCompound tag)
		{
			upgradeHearts = tag.GetInt("upgradeHearts");
			upgradeStars = tag.GetInt("upgradeStars");
		}
		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
		{
			Item item = new Item();
			item.SetDefaults(ItemID.Seed);
			item.stack = 500;
			items.Add(item);
		}
		public override void UpdateBiomes()
		{
			if (Main.player[(int)Player.FindClosest(player.position, player.width, player.height)].ZoneSkyHeight)
			ZoneMicrobiome = ZylonWorld.microbiomeTiles > 140;
			else
			ZoneMicrobiome = ZylonWorld.microbiomeTiles > 200;
			if (ZoneMicrobiome)
			{
				player.AddBuff(mod.BuffType(""), 5, true);
			}
		}
		
		public override bool CustomBiomesMatch(Player other) 
		{
			ZylonPlayer modOther = other.GetModPlayer<ZylonPlayer>();
			return ZoneMicrobiome == modOther.ZoneMicrobiome;
		}
		
		public override void CopyCustomBiomesTo(Player other)
		{
			ZylonPlayer modOther = other.GetModPlayer<ZylonPlayer>();
			modOther.ZoneMicrobiome = ZoneMicrobiome;
		}

		public override void SendCustomBiomes(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = ZoneMicrobiome;
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			ZoneMicrobiome = flags[0];
		}

		public override Texture2D GetMapBackgroundImage()
		{
			if (ZoneMicrobiome)
			{
				return mod.GetTexture("MicrobiomeMapBackground");
			}
			return null;
		}
		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
		{
			if (Main.player[(int)Player.FindClosest(player.position, player.width, player.height)].GetModPlayer<ZylonPlayer>().ZoneMicrobiome)
			{
				if (player.cratePotion)
				{
					if (liquidType == 0 && Main.rand.NextFloat() < .2f)
					{
						if (Main.hardMode)
						{
							caughtType = mod.ItemType("PlaguedCrate");
						}
						else
						{
							caughtType = mod.ItemType("BacterialCrate");
						}
					}
				}
				else
				{
					if (liquidType == 0 && Main.rand.NextFloat() < .1f)
					{
						if (Main.hardMode)
						{
							caughtType = mod.ItemType("PlaguedCrate");
						}
						else
						{
							caughtType = mod.ItemType("BacterialCrate");
						}
					}
				}
			}
			if (Main.player[(int)Player.FindClosest(player.position, player.width, player.height)].ZoneOverworldHeight || Main.player[(int)Player.FindClosest(player.position, player.width, player.height)].ZoneDirtLayerHeight)
			{
				if (Main.hardMode)
				{
					if (player.cratePotion)
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .025f)
						{
							caughtType = mod.ItemType("MushroomCrate");
						}
					}
					else
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .005f)
						{
							caughtType = mod.ItemType("MushroomCrate");
						}
					}
				}
				else
				{
					if (player.cratePotion)
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .05f)
						{
							caughtType = mod.ItemType("MushroomCrate");
						}
					}
					else
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .01f)
						{
							caughtType = mod.ItemType("MushroomCrate");
						}
					}
				}
			}
			if (Main.player[(int)Player.FindClosest(player.position, player.width, player.height)].ZoneGlowshroom)
			{
				if (Main.hardMode)
				{
					if (player.cratePotion)
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .1f)
						{
							caughtType = mod.ItemType("GlowingMushroomCrate");
						}
					}
					else
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .05f)
						{
							caughtType = mod.ItemType("GlowingMushroomCrate");
						}
					}
				}
				else if (NPC.downedBoss1)
				{
					if (player.cratePotion)
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .2f)
						{
							caughtType = mod.ItemType("GlowingMushroomCrate");
						}
					}
					else
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .1f)
						{
							caughtType = mod.ItemType("GlowingMushroomCrate");
						}
					}
				}
				if (player.cratePotion)
				{
					if (liquidType == 0 && Main.rand.NextFloat() < .02f)
					{
						caughtType = mod.ItemType("MushroomCrate");
					}
				}
				else
				{
					if (liquidType == 0 && Main.rand.NextFloat() < .01f)
					{
						caughtType = mod.ItemType("MushroomCrate");
					}
				}
			}
			if (Main.player[(int)Player.FindClosest(player.position, player.width, player.height)].ZoneRockLayerHeight)
			{
				if (Main.hardMode)
				{
					if (player.cratePotion)
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .08f)
						{
							caughtType = mod.ItemType("SedimentaryCrate");
						}
					}
					else
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .04f)
						{
							caughtType = mod.ItemType("SedimentaryCrate");
						}
					}
				}
				else if (!Main.hardMode)
				{
					if (player.cratePotion)
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .08f)
						{
							caughtType = mod.ItemType("CaveCrate");
						}
					}
					else
					{
						if (liquidType == 0 && Main.rand.NextFloat() < .04f)
						{
							caughtType = mod.ItemType("CaveCrate");
						}
					}
				}
			}
		}
		public override void OnHitAnything(float x, float y, Entity victim)
		{
			if (gemstoneManaBullet)
			{
				if (Main.rand.Next(5) == 0)
				Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.Next(-3, 3), Main.rand.Next(-4, -2), mod.ProjectileType("ManaSpike"), 40, 2, Main.myPlayer);
			}
			if (hyperCell)
				player.AddBuff(mod.BuffType("CellBoost"), 60, false);
		}
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (gemstoneSpikes)
            {
				float numberProjectiles = Main.rand.Next(3, 13);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.Next(-6, 6), Main.rand.Next(-17, -3), mod.ProjectileType("GemstoneSpike"), 100, 2, Main.myPlayer);
				}
			}
			if (empressSpikes)
			{
				float numberProjectiles = Main.rand.Next(3, 9);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Projectile.NewProjectile(player.Center, new Vector2(0, 4).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressSpikePassive"), 75, 1, Main.myPlayer);
				}
			}
			if (darkstarFall)
			{
				float numberProjectiles = Main.rand.Next(1, 4);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Projectile.NewProjectile(player.Center.X - Main.rand.Next(-200, 201), player.Center.Y - 600, Main.rand.Next(-5, 5), 35, mod.ProjectileType("Darkstar"), 85, 2, Main.myPlayer);
				}
			}
			if (hurtHeal)
			{
				player.statLife += 1;
				player.HealEffect(1, true);
			}
			if (electricField)
			{
				if (damage >= 40)
				Projectile.NewProjectile(player.Center.X - 90, player.Center.Y + 90, 0, 0, mod.ProjectileType("ElectricField"), 12, 0, Main.myPlayer);
			}
			if (eyeCandy)
			{
				player.AddBuff(mod.BuffType("EyeCandy"), 60);
			}
			if (gemstoneRain)
			{
				if (Main.rand.Next(4) == 0)
				{
					float numberProjectiles = Main.rand.Next(10, 26);
					for (int i = 0; i < numberProjectiles; i++)
					{
						Projectile.NewProjectile(player.Center.X + Main.rand.Next(-250, 250), player.Center.Y - 400, 0, Main.rand.Next(-6, -3), mod.ProjectileType("GemstoneSpikeRain"), 95, 2f, Main.myPlayer);
					}
				}
			}
			if (gemstoneMelee)
			{
				if (Main.rand.NextFloat() < .25f)
				player.AddBuff(mod.BuffType("Encased"), Main.rand.Next(240, 601));
			}
		}
		public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			numberShot += 1;
			if (gemstoneRanged && item.ranged == true)
            {
				if (numberShot % 5 == 0)
                {
					Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 25, mod.ProjectileType("GemstoneHeal"), 100, 10, Main.myPlayer);
				}
            }
			if (player.HeldItem.type == ItemID.Blowpipe)
			{
				player.AddBuff(mod.BuffType("OutOfBreath"), 45, false);
			}
			if (player.HeldItem.type == ItemID.Blowgun)
			{
				player.AddBuff(mod.BuffType("OutOfBreath"), 35, false);
			}
			return true;
        }
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) {
			if (xenicExpert && Main.rand.NextFloat() < .25f) {
				target.AddBuff(mod.BuffType("XenicAcid"), 60 * Main.rand.Next(3, 11), false);
			}
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
			if (xenicExpert && Main.rand.NextFloat() < .25f) {
				target.AddBuff(mod.BuffType("XenicAcid"), 60 * Main.rand.Next(3, 11), false);
			}
		}
		public override void PostUpdateBuffs()
		{
			if (player.HasBuff(BuffID.ChaosState) && NPC.CountNPCS(ModContent.NPCType<NPCs.Minibosses.XenicAcidpumper>()) > 0)
			player.KillMe(PlayerDeathReason.ByCustomReason(player.name + "'s mind melted."), 9999, 0, false);
			if (gemstoneMagic)
			{
				if (player.statLife / 4 < player.statLifeMax2)
					player.manaCost -= 0.75f;
			}
		}
		public override void PreUpdateBuffs()
		{
			if (gemstoneSummon)
			{
				player.AddBuff(mod.BuffType("Ubercabochon"), 2);
			}
		}
		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) {	
			if (trueMelee35)
			damage += (int)(damage * .35f);
		}
	}
}