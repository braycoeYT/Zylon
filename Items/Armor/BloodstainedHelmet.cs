using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BloodstainedHelmet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 2;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<BloodstainedChestplate>() && legs.type == ModContent.ItemType<BloodstainedLeggings>();
		}
        public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.summonCritBoost += 0.03f;
        }
        public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.setBonus = "Double tap down to gain the 'Bloodrain' buff for 10 seconds\nWhile the buff is active, all minions gain lifesteal\n45 second cooldown";
			if (player.controlDown && player.releaseDown && player.doubleTapCardinalTimer[0] < 15 && !player.HasBuff(ModContent.BuffType<Buffs.Armor.Bloodrain>()) && !player.HasBuff(ModContent.BuffType<Buffs.Armor.BloodrainCooldown>())) { //D=0, U=1, R=2, L=3
				player.AddBuff(ModContent.BuffType<Buffs.Armor.Bloodrain>(), 600);
				for (int i = 0; i < 30; i++) {
					Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.Blood);
					dust.noGravity = true;
					dust.velocity = new Vector2(0, 4).RotatedBy(MathHelper.ToRadians(i*12));
					dust.scale = 2.5f;
                }
				SoundEngine.PlaySound(SoundID.NPCDeath13, player.position);
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 8);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}