using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Items.Accessories;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items
{
	public class ZylonGlobalItem : GlobalItem
	{
		public override bool InstancePerEntity => true;
		public static Item GetItem(int type, int stack = 1)
        {
            Item item = new Item();
            item.SetDefaults(type);
            item.stack = stack;
            return item;
        }
        public static Item GetItem(short type, int stack = 1)
        {
            Item item = new Item();
            item.SetDefaults(type);
            item.stack = stack;
            return item;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            if ((item.DamageType == DamageClass.Summon || item.DamageType == DamageClass.SummonMeleeSpeed) && p.summonCrit > 0f) {
				int index = 0;
				bool cont = true;
				foreach (var line2 in tooltips) { //For some reason there's no easy way to grab the index.
					if (cont) index++;
					if (line2.Mod == "Terraria" && line2.Name == "Damage") cont = false;

					if (line2.Mod == "Terraria" && line2.Name == "PrefixCritChance") line2.Hide(); //idk how to add weapon crit to summon weapons yet :/
				}
				String txt = Math.Round(p.summonCrit*100f) + "% critical strike chance";
				TooltipLine line = new TooltipLine(Mod, "SummonCrit", txt);
				tooltips.Insert(index, line);
			}
			if (GetInstance<ZylonConfig>().bandBuffs) {
				if (item.type == ItemID.BandofRegeneration || item.type == ItemID.CharmofMyths) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Increases the potency of regeneration potions");
					tooltips.Add(line);
				}
				if (item.type == ItemID.BandofStarpower || item.type == ItemID.ManaRegenerationBand || item.type == ItemID.MagicCuffs || item.type == ItemID.CelestialCuffs) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Increases the potency of magic power potions");
					tooltips.Add(line);
				}
				if (item.type == ItemID.ManaRegenerationBand) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Increases the potency of mana regeneration potions");
					tooltips.Add(line);
				}
            }
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
				if (item.type == ItemID.MagicPowerPotion) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip1", "This effect decreases to 5% as the player reaches max health\nDecreases mana regeneration rate");
					tooltips.Add(line);
				}
				if (item.type == ItemID.AdamantiteBreastplate) {
					foreach (var line2 in tooltips) {
						if (line2.Mod == "Terraria" && line2.Name == "Tooltip0") {
							line2.Text = "8% increased damage\nIncreases minion knockback by 15%";
						}
					}
				}
				if (item.type == ItemID.TitaniumBreastplate) {
					foreach (var line2 in tooltips) {
						if (line2.Mod == "Terraria" && line2.Name == "Tooltip1") {
							line2.Text = "3% increased critical strike chance\nIncreases minion knockback by 23%";
						}
					}
				}
				if (item.type == ItemID.BoneArrow) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Has a low chance to explode into piercing bones on impact");
					tooltips.Add(line);
				}
				if (item.type == ItemID.WaterGun || item.type == ItemID.SlimeGun) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Squirt most slimes with this to make them grow");
					tooltips.Add(line);
				}
				if (item.type == ItemID.EyeoftheGolem) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Increases critical strike damage by 25%\nCritical strikes rain Lihzahrd Beams from above");
					tooltips.Add(line);
				}
				/*if (item.type == ItemID.RestorationPotion) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip1", "No mana sickness");
					tooltips.Add(line);
				}*/
            }
			/*if (item.type == ItemID.TungstenPickaxe) {
				foreach (var line2 in tooltips) {
					if (line2.Mod == "Terraria" && line2.Name == "Tooltip0") {
						line2.Text = "Can mine Meteorite and Cerussite";
					}
				}
			}
			if (item.type == ItemID.SilverPickaxe) {
				TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Can mine Cerussite");
				tooltips.Add(line);
			}*/
			if (item.type == ItemID.ShinyRedBalloon || item.type == ItemID.BalloonPufferfish) {
				TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Increases blowpipe charge speed by 4/s (does not stack with other balloons)");
				tooltips.Add(line);
			}
			if (item.type == ItemID.BlizzardinaBalloon || item.type == ItemID.CloudinaBalloon || item.type == ItemID.FartInABalloon || item.type == ItemID.SandstorminaBalloon || item.type == ItemID.SharkronBalloon || item.type == ItemID.HoneyBalloon) {
				TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Increases blowpipe charge speed by 6/s (does not stack with other balloons)");
				tooltips.Add(line);
			}
			if (item.type == ItemID.BalloonHorseshoeFart || item.type == ItemID.BalloonHorseshoeHoney || item.type == ItemID.BalloonHorseshoeSharkron || item.type == ItemID.BlueHorseshoeBalloon || item.type == ItemID.WhiteHorseshoeBalloon || item.type == ItemID.YellowHorseshoeBalloon) {
				TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Increases blowpipe charge speed by 8/s (does not stack with other balloons)");
				tooltips.Add(line);
			}
			if (item.type == ItemID.BundleofBalloons || item.type == ItemID.HorseshoeBundle) {
				TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Increases blowpipe charge speed by 10/s (does not stack with other balloons)");
				tooltips.Add(line);
			}
			/*if (item.type == ItemID.Minishark || item.type == ItemID.Shotgun || item.type == ItemID.PainterPaintballGun) {
				TooltipLine line = new TooltipLine(Mod, "Tooltip1", "Slightly weakened until Eater of Worlds or Brain of Cthulhu is defeated");
				tooltips.Add(line);
			}*/
        }
        public override void SetDefaults(Item item) {
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
				if (item.type == ItemID.PoisonDart)
					item.damage = 7;
				if (item.type == ItemID.BoneArrow)
					item.damage = 10;
				if (item.type == ItemID.CookedMarshmallow)
					item.buffTime = 7200;
				if (item.type == ItemID.Coal || item.type == ItemID.SnowGlobe || item.type == ItemID.GoldCrown || item.type == ItemID.PlatinumCrown) 
					item.maxStack = 999;
				if (item.type == ItemID.LaserDrill)
					item.pick = 220;
				if (item.type == ItemID.FlareGun)
					item.damage = 15;
				if (item.type == ItemID.Zenith)
					item.damage = 63;
				if (item.type == ItemID.Flare || item.type == ItemID.BlueFlare || item.type == ItemID.SpelunkerFlare || item.type == ItemID.ShimmerFlare)
					item.damage = 7;
				if (item.type == ItemID.CursedFlare)
					item.damage = 13;
				if (item.type == ItemID.RainbowFlare)
					item.damage = 22;
				if (item.type == ItemID.PulseBow)
					item.damage = 61;
				if (item.type == ItemID.SDMG) {
					item.damage = 84;
					item.useTime = 7;
					item.useAnimation = 7;
				}
				if (item.type == ItemID.AcornAxe) {
					item.axe = 20;
					item.useTime = 25;
				}
				if (item.type == ItemID.RestorationPotion) {
					item.healMana = 90;
                }
			}
			if (!GetInstance<ZylonConfig>().dirtAmmoFix) {
				if (item.type == ItemID.DirtBlock) {
					item.consumable = true;
					item.ammo = ItemType<Misc.Dirtthrower>();
					item.notAmmo = true;
                }
            }
		}
        /* public override void UpdateInventory(Item item, Player player) {
             if (item.type == ItemID.Minishark) {
                 item.useTime = 12;
                 item.useAnimation = 12;
                 if (NPC.downedBoss2) {
                     item.useTime = 8;
                     item.useAnimation = 8;
                 }
             }
             if (item.type == ItemID.Boomstick) {
                 item.damage = 7;
                 if (NPC.downedBoss2)
                     item.damage = 14;
             }
             if (item.type == ItemID.PainterPaintballGun) {
                 item.damage = 8;
                 if (NPC.downedBoss2)
                     item.damage = 12;
             }
         }*/
        public override void UpdateAccessory(Item item, Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
				if (item.type == ItemID.EyeoftheGolem) {
					p.critExtraDmg += 0.25f;
					p.golemEyeEffect = true;
				}
			}
			if (GetInstance<ZylonConfig>().bandBuffs) {
				if (item.type == ItemID.BandofRegeneration || item.type == ItemID.CharmofMyths) {
					p.bandofRegen = true;
				}
				if (item.type == ItemID.BandofStarpower || item.type == ItemID.ManaRegenerationBand || item.type == ItemID.MagicCuffs || item.type == ItemID.CelestialCuffs) {
					p.bandofStarpower = true;
				}
				if (item.type == ItemID.ManaRegenerationBand) {
					p.bandofMagicRegen = true;
				}
            }
			if (item.type == ItemID.SharkToothNecklace) {
				if (p.CHECK_SharkToothNecklace) { 
					player.GetArmorPenetration(DamageClass.Generic) -= 5;
				}
				p.CHECK_SharkToothNecklace = true;
            }
			if (item.type == ItemID.ShinyRedBalloon || item.type == ItemID.BalloonPufferfish) {
				if (!p.CHECK_Balloon) { 
					p.blowpipeChargeInc += 0.1333333333f;
				}
				p.CHECK_Balloon = true;
			}
			if (item.type == ItemID.BlizzardinaBalloon || item.type == ItemID.CloudinaBalloon || item.type == ItemID.FartInABalloon || item.type == ItemID.SandstorminaBalloon || item.type == ItemID.SharkronBalloon || item.type == ItemID.HoneyBalloon) {
				if (!p.CHECK_Balloon) { 
					p.blowpipeChargeInc += 0.2f;
				}
				p.CHECK_Balloon = true;
			}
			if (item.type == ItemID.BalloonHorseshoeFart || item.type == ItemID.BalloonHorseshoeHoney || item.type == ItemID.BalloonHorseshoeSharkron || item.type == ItemID.BlueHorseshoeBalloon || item.type == ItemID.WhiteHorseshoeBalloon || item.type == ItemID.YellowHorseshoeBalloon) {
				if (!p.CHECK_Balloon) { 
					p.blowpipeChargeInc += 0.2666666666f;
				}
				p.CHECK_Balloon = true;
			}
			if (item.type == ItemID.BundleofBalloons || item.type == ItemID.HorseshoeBundle) {
				if (!p.CHECK_Balloon) { 
					p.blowpipeChargeInc += 0.3333333333f;
				}
				p.CHECK_Balloon = true;
			}
			if (item.type == ItemID.FleshKnuckles) {
				if (p.CHECK_FleshKnuckles) player.statDefense -= 8;
				p.CHECK_FleshKnuckles = true;
            }
			if (item.type == ItemID.ManaFlower || item.type == ItemID.MagnetFlower || item.type == ItemID.ManaCloak || item.type == ItemID.ArcaneFlower) {
				if (p.CHECK_ManaBlossom) player.manaCost += 0.08f;
				p.CHECK_ManaBlossom = true;
			}
		}
        public override void RightClick(Item item, Player player) {
            if (item.type == ItemID.KingSlimeBossBag) {
				if (Main.rand.NextBool(3)) player.QuickSpawnItem(item.GetSource_FromThis(), ItemID.GoldCrown);
				if (Main.rand.NextBool(3)) player.QuickSpawnItem(item.GetSource_FromThis(), ItemType<SlimyShell>());
				player.QuickSpawnItem(item.GetSource_FromThis(), ItemID.Gel, Main.rand.Next(15, 36));
				player.QuickSpawnItem(item.GetSource_FromThis(), ItemType<Materials.SlimyCore>(), Main.rand.Next(10, 16));
            }
			if (item.type == ItemID.EyeOfCthulhuBossBag) {
				if (Main.rand.NextBool(3)) player.QuickSpawnItem(item.GetSource_FromThis(), ItemType<Yoyos.Insomnia>());
				if (Main.rand.NextBool(3)) player.QuickSpawnItem(item.GetSource_FromThis(), ItemType<Whips.EyeLash>());
				player.QuickSpawnItem(item.GetSource_FromThis(), ItemID.Lens, Main.rand.Next(4, 7));
				if (WorldGen.crimson) player.QuickSpawnItem(item.GetSource_FromThis(), ItemType<Ammo.BloodiedArrow>(), Main.rand.Next(20, 51));
            }
			if (item.type == ItemID.QueenBeeBossBag) {
				if (Main.rand.NextBool(3)) player.QuickSpawnItem(item.GetSource_FromThis(), ItemType<Blowpipes.Beepipe>());
				player.QuickSpawnItem(item.GetSource_FromThis(), ItemID.Stinger, Main.rand.Next(4, 8));
            }
			if (item.type == ItemID.SkeletronBossBag) {
				if (Main.rand.NextBool(5)) player.QuickSpawnItem(item.GetSource_FromThis(), ItemType<RuneofMultiplicity>());
				player.QuickSpawnItem(item.GetSource_FromThis(), ItemID.Bone, Main.rand.Next(15, 21));
            }
			/*if (item.type == ItemID.WallOfFleshBossBag) {
				player.QuickSpawnItem(item.GetSource_FromThis(), ItemID.Bone, Main.rand.Next(20, 31));
            }*/
			if (item.type == ItemID.TwinsBossBag) {
				if (Main.rand.NextBool(3)) player.QuickSpawnItem(item.GetSource_FromThis(), ItemType<Minions.SpazmaticScythe>());
            }
			if (item.type == ItemID.PlanteraBossBag) {
				if (Main.rand.NextBool(3)) player.QuickSpawnItem(item.GetSource_FromThis(), ItemID.JungleRose);
				if (Main.rand.NextBool(3)) player.QuickSpawnItem(item.GetSource_FromThis(), ItemID.NaturesGift);
				if (Main.rand.NextBool(3)) player.QuickSpawnItem(item.GetSource_FromThis(), ItemType<SucculentSap>());
				player.QuickSpawnItem(item.GetSource_FromThis(), ItemID.ChlorophyteOre, Main.rand.Next(30, 41));
            }
			if (item.type == ItemID.GolemBossBag) {
				if (Main.rand.NextBool(3)) player.QuickSpawnItem(item.GetSource_FromThis(), ItemType<Spears.LihzahrdLance>());
            }
        }
        public override string IsArmorSet(Item head, Item body, Item legs) {
			if (head.type == ItemID.MagicHat && body.type == ItemType<Armor.JadeRobe>())
				return "JadeRobe1";
			if (head.type == ItemID.WizardHat && body.type == ItemType<Armor.JadeRobe>())
				return "JadeRobe2";
			return "";
		}
		public override void UpdateArmorSet(Player player, string set) {
			if (set == "JadeRobe1") {
				player.setBonus = "Increases max mana by 60";
				player.statManaMax2 += 60;		
			}
			if (set == "JadeRobe2") {
				player.setBonus = "10% increased magic critical strike chance";
				player.GetCritChance(DamageClass.Magic) += 10;
            }
		}
        public override void UpdateEquip(Item item, Player player) {
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
				if (item.type == ItemID.AdamantiteBreastplate) player.GetKnockback(DamageClass.Summon) += 0.15f;
				if (item.type == ItemID.TitaniumBreastplate) player.GetKnockback(DamageClass.Summon) += 0.23f;
            }
        }
        int shootCount;
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.gooeySetBonus && item.DamageType != DamageClass.Summon && shootCount % 3 == 0 && !(item.useAmmo == AmmoID.Dart && item.useTime < 3))
				Projectile.NewProjectile(source, position, velocity, ProjectileType<Projectiles.ExplosiveMarshmallow>(), (int)(item.damage * 1.25f), 2f, Main.myPlayer);
            return true;
        }
        public override bool PreDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            if (item.type == ItemID.LivingLoom) {
				Texture2D texture = TextureAssets.Item[item.type].Value;
				if (WorldGen.currentWorldSeed.ToLower() == "autumn") texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Placeables/LivingLoom_Autumn");
				spriteBatch.Draw(texture, position, frame, drawColor, 0f, origin, scale, SpriteEffects.None, 0);
				return false;
			}
			return true;
        }
        public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            if (item.type == ItemID.LivingLoom) {
				Texture2D texture = TextureAssets.Item[item.type].Value;
				if (WorldGen.currentWorldSeed.ToLower() == "autumn") texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Placeables/LivingLoom_Autumn");
				Rectangle frame = texture.Frame();
				Vector2 frameOrigin = frame.Size() / 2f;
				Vector2 offset = new Vector2(item.width / 2 - frameOrigin.X, item.height - frame.Height);
				Vector2 drawPos = item.position - Main.screenPosition + frameOrigin + offset;
				spriteBatch.Draw(texture, drawPos, null, lightColor, rotation, frameOrigin, scale, SpriteEffects.None, 0);
				return false;
			}
			return true;
        }
    }
}