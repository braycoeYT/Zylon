using Zylon;
using Zylon.Items;
using Zylon.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

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
		public bool gemstoneHealBullet;
		public bool gemstoneManaBullet;
		public bool gemstoneRain;
		public bool empressSpikes;
		public bool darkstarFall;
		public bool hurtHeal;
		public bool redJavelance;
		public bool electricField;
		public bool eyeCandy;
		public bool hyperCell;
		int numberShot = 0;
		public int upgradeHearts;
		public int upgradeStars;
		public int playerTimer;

		public override void ResetEffects()
		{
			MarblePet = false;
			UpgradeMeatball = false;
			SlimyCore = false;
			BraycoeSlimePet = false;
			CyanixLong = false;
			gemstoneSpikes = false;
			gemstoneHealBullet = false;
			gemstoneManaBullet = false;
			gemstoneRain = false;
			empressSpikes = false;
			darkstarFall = false;
			hurtHeal = false;
			redJavelance = false;
			electricField = false;
			eyeCandy = false;
			hyperCell = false;
			player.statLifeMax2 += upgradeHearts * 25;
			player.statManaMax2 += upgradeStars * 50;
			playerTimer = 0;
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
			item.SetDefaults(ItemType<Items.OtherSlappys.PHOres.CopperSlappy>());
			item.stack = 1;
			items.Add(item);
			
			item = new Item();
			item.SetDefaults(ItemType<Items.Accessories.EyeThemed.KaizoMedal>());
			item.stack = 1;
			items.Add(item);
		}
		public override void UpdateBiomes()
		{
			ZoneOblivion = ZylonWorld.oblivionTiles > 200;
			ZoneMicrobiome = ZylonWorld.microbiomeTiles > 200;
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
		/*public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
		{

		}*/
		public override void OnHitAnything(float x, float y, Entity victim)
		{
			if (gemstoneManaBullet)
			{
				if (Main.rand.Next(7) == 0)
				Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.Next(-3, 3), Main.rand.Next(-4, -2), mod.ProjectileType("ManaSpike"), 40, 2, Main.myPlayer);
			}
			if (hyperCell)
				player.AddBuff(mod.BuffType("CellBoost"), 80, false);
		}
		public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
			if (gemstoneSpikes)
			{
				float numberProjectiles = Main.rand.Next(5, 8);
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
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("ElectricField"), 17, 0, Main.myPlayer);
			}
			if (eyeCandy)
			{
				player.AddBuff(mod.BuffType("EyeCandy"), 60);
			}
			if (gemstoneRain)
			{
				if (Main.rand.Next(7) == 0)
				{
					float numberProjectiles = Main.rand.Next(10, 36);
					for (int i = 0; i < numberProjectiles; i++)
					{
						Projectile.NewProjectile(player.Center.X + Main.rand.Next(-800, 800), player.Center.Y - 500, 0, Main.rand.Next(2, 9), mod.ProjectileType("GemstoneSpikeRain"), 95, 2f, Main.myPlayer);
					}
				}
			}
		}
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            if (gemstoneSpikes)
            {
				float numberProjectiles = Main.rand.Next(3, 7);
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
		}
		public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			numberShot += 1;
			if (gemstoneHealBullet)
            {
				if (numberShot % 10 == 0)
                {
					Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 25, mod.ProjectileType("GemstoneHeal"), 100, 10, Main.myPlayer);
				}
            }
			return true;
        }
	}
}