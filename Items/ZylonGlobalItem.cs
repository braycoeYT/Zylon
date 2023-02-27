using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
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
            if (item.type == ItemID.GillsPotion) {
				TooltipLine line = new TooltipLine(Mod, "Tooltip#1", "Stops blowpipe breath loss while in water");
				tooltips.Add(line);
			}
			if (GetInstance<ZylonConfig>().bandBuffs) {
				if (item.type == ItemID.BandofRegeneration || item.type == ItemID.CharmofMyths) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip#1", "Increases the potency of regeneration potions");
					tooltips.Add(line);
				}
				if (item.type == ItemID.BandofStarpower || item.type == ItemID.ManaRegenerationBand || item.type == ItemID.MagicCuffs || item.type == ItemID.CelestialCuffs) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip#1", "Increases the potency of magic power potions");
					tooltips.Add(line);
				}
				if (item.type == ItemID.ManaRegenerationBand) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip#1", "Increases the potency of mana regeneration potions");
					tooltips.Add(line);
				}
            }
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
				if (item.type == ItemID.MagicPowerPotion) {
					TooltipLine line = new TooltipLine(Mod, "Tooltip#1", "This effect decreases to 5% as the player reaches max health\nDecreases mana regeneration rate");
					tooltips.Add(line);
				}
            }
			/*if (item.type == ItemID.Minishark || item.type == ItemID.Shotgun || item.type == ItemID.PainterPaintballGun) {
				TooltipLine line = new TooltipLine(Mod, "Tooltip#1", "Slightly weakened until Eater of Worlds or Brain of Cthulhu is defeated");
				tooltips.Add(line);
			}*/
        }
        public override void SetDefaults(Item item) {
			if (item.type == ItemID.PoisonDart)
				item.damage = 7;
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
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
					item.damage = 84;
				if (item.type == ItemID.Flare || item.type == ItemID.BlueFlare)
					item.damage = 7;
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
			if (item.type == ItemID.RoyalGel) {
				player.npcTypeNoAggro[NPCType<NPCs.Dungeon.BoneSlime>()] = true;
				player.npcTypeNoAggro[NPCType<NPCs.Forest.DirtSlime>()] = true;
				player.npcTypeNoAggro[NPCType<NPCs.Forest.MechanicalSlime>()] = true;
				player.npcTypeNoAggro[NPCType<NPCs.Forest.OrangeSlime>()] = true;
				player.npcTypeNoAggro[NPCType<NPCs.Ocean.CyanSlime>()] = true;
				player.npcTypeNoAggro[NPCType<NPCs.Sky.StarpackSlime>()] = true;
				player.npcTypeNoAggro[NPCType<NPCs.Snow.LivingMarshmallow>()] = true;
				player.npcTypeNoAggro[NPCType<NPCs.Snow.RoastedLivingMarshmallow>()] = true;
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
				if (p.stncheck) { 
					player.GetArmorPenetration(DamageClass.Generic) -= 5;
				}
				p.stncheck = true;
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
		int shootCount;
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.gooeySetBonus && item.DamageType != DamageClass.Summon && shootCount % 3 == 0 && !(item.useAmmo == AmmoID.Dart && item.useTime < 3))
				Projectile.NewProjectile(source, position, velocity, ProjectileType<Projectiles.ExplosiveMarshmallow>(), (int)(item.damage * 1.25f), 2f, Main.myPlayer);
            return true;
        }
    }
}