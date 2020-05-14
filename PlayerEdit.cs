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
	public class PlayerEdit : ModPlayer
	{	
		
		public bool ZoneOblivion;
		public bool MarblePet;
		public bool UpgradeMeatball;
		public bool SlimyCore;
		public bool BraycoeSlimePet;
		public bool CyanixLong;
		public bool gemstoneSpikes;
		public bool gemstoneHealBullet;
		public bool gemstoneManaBullet;
		public bool gemstoneKill;
		public bool empressSpikes;
		public bool darkstarFall;
		int numberShot = 0;

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
			gemstoneKill = false;
			empressSpikes = false;
			darkstarFall = false;
		}

		public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
		{
			if (gemstoneKill)
			{
				float numberProjectiles = Main.rand.Next(50, 76);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Projectile.NewProjectile(player.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("GemstoneSpike"), 160, 2, Main.myPlayer);
				}
			}
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
			
			if (Main.expertMode)
			{
				item = new Item();
				item.SetDefaults(ItemType<Items.VoidDream.NeozylsWrath>());
				item.stack = 1;
				items.Add(item);
			}
		}
		public override void UpdateBiomes()
		{
			ZoneOblivion = WorldEdit.oblivionTiles > 200;
		}
		
		public override bool CustomBiomesMatch(Player other) 
		{
			PlayerEdit modOther = other.GetModPlayer<PlayerEdit>();
			return ZoneOblivion == modOther.ZoneOblivion;
		}
		
		public override void CopyCustomBiomesTo(Player other)
		{
			PlayerEdit modOther = other.GetModPlayer<PlayerEdit>();
			modOther.ZoneOblivion = ZoneOblivion;
		}

		public override void SendCustomBiomes(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = ZoneOblivion;
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			ZoneOblivion = flags[0];
		}

		public override Texture2D GetMapBackgroundImage()
		{
			if (ZoneOblivion)
			{
				return mod.GetTexture("OblivionMapBackground");
			}
			return null;
		}
		public override void OnHitAnything(float x, float y, Entity victim)
		{
			if (gemstoneManaBullet)
			{
				if (Main.rand.Next(7) == 0)
				Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.Next(-3, 3), Main.rand.Next(-4, -2), mod.ProjectileType("ManaSpike"), 40, 2, Main.myPlayer);
			}
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
			if (gemstoneKill)
			{
				player.AddBuff(63, 120);
			}
			if (darkstarFall)
			{
				float numberProjectiles = Main.rand.Next(1, 4);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Projectile.NewProjectile(player.Center.X - Main.rand.Next(-200, 201), player.Center.Y - 600, Main.rand.Next(-5, 5), 35, mod.ProjectileType("Darkstar"), 85, 2, Main.myPlayer);
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
			if (gemstoneKill)
			{
				player.AddBuff(63, 120);
			}
			if (darkstarFall)
			{
				float numberProjectiles = Main.rand.Next(1, 4);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Projectile.NewProjectile(player.Center.X - Main.rand.Next(-200, 201), player.Center.Y - 600, Main.rand.Next(-5, 5), 35, mod.ProjectileType("Darkstar"), 85, 2, Main.myPlayer);
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
		public override void ModifyNursePrice(NPC nurse, int health, bool removeDebuffs, ref int price)
		{
			if (WorldEdit.voidDream)
			price *= 4;
		}
	}
}