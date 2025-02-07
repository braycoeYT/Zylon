using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class LihzahrdPlatingHelmet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 13;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<LihzahrdPlatingBreastplate>() && legs.type == ModContent.ItemType<LihzahrdPlatingLeggings>();
		}
        public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetDamage(DamageClass.Summon) += 0.07f;
			p.summonCritBoost += 0.07f;
			player.maxMinions += 1;
        }
		bool hasLasered;
		int Timer;
        public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.slimePrinceArmor = true;
			player.setBonus = Language.GetTextValue("Mods.Zylon.Items.LihzahrdPlatingHelmet.SetBonus");
			player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.5f-0.5f*((float)player.statLife/player.statLifeMax2);
			if (player.statLife < player.statLifeMax2/4) {
				Timer++;
				float shootMod = player.statLife/(player.statLifeMax2/4);
				if (Timer > 60+150*shootMod) {
					Timer = 0;
					hasLasered = false;

					for (int i = 0; i < Main.maxProjectiles; i++) {
						if (Main.projectile[i].minion) { // || Main.projectile[i].type == ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>()
				
				float distanceFromTarget = 480f;
				Vector2 targetCenter = Main.projectile[i].position;
				bool foundTarget = false;
					
				if (!foundTarget) {
					for (int j = 0; j < Main.maxNPCs; j++) {
						NPC npc = Main.npc[j];

						if (npc.CanBeChasedBy()) {
							float between = Vector2.Distance(npc.Center, Main.projectile[i].Center);
							bool closest = Vector2.Distance(Main.projectile[i].Center, targetCenter) > between;
							bool inRange = between < distanceFromTarget;
							bool lineOfSight = Collision.CanHitLine(Main.projectile[i].position, Main.projectile[i].width, Main.projectile[i].height, npc.position, npc.width, npc.height);
							bool closeThroughWall = false; //between < 100f;

							if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
								distanceFromTarget = between;
								targetCenter = npc.Center;
								foundTarget = true;
							}
						}
					}
				}
				if (foundTarget) {
					if (!hasLasered) {
									hasLasered = true;
									SoundEngine.PlaySound(SoundID.Item33);
								}
					Vector2 projDir = Vector2.Normalize(targetCenter - Main.projectile[i].Center) * 15f;
					ProjectileHelpers.NewNetProjectile(Main.projectile[i].GetSource_FromThis(), Main.projectile[i].Center, projDir, ModContent.ProjectileType<Projectiles.Armor.LihzahrdPlatingBeam>(), 75, 3f, Main.myPlayer);
                }
						
						}
					}
				}
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LihzahrdBrick, 25);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}