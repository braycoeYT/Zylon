using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class TatteredHat : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'It seems to be decades due for a restitching'\nDecreases mana usage by 5%\nIncreases magic critical strike chance and damage by 4%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 75);
			Item.rare = ItemRarityID.Green;
			Item.defense = 1;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<TatteredRobe>() && legs.type == ModContent.ItemType<TatteredBoots>();
		}
        public override void UpdateEquip(Player player) {
			player.manaCost -= 0.05f;
			player.GetCritChance(DamageClass.Magic) += 4;
			player.GetDamage(DamageClass.Magic) += 0.04f;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = "Double tap down to activate a 10 second Tattered Blitz, decreasing mana usage by 33%\nThis has a cooldown of 30 seconds";
			if (player.controlDown && player.releaseDown && player.doubleTapCardinalTimer[0] < 15 && !player.HasBuff(ModContent.BuffType<Buffs.Armor.TatteredBlitz>()) && !player.HasBuff(ModContent.BuffType<Buffs.Armor.TatteredBlitzCooldown>()) && !player.HasBuff(ModContent.BuffType<Buffs.Armor.ShadowstitchedBlitz>()) && !player.HasBuff(ModContent.BuffType<Buffs.Armor.ShadowstitchedBlitzCooldown>())) { //D=0, U=1, R=2, L=3
				player.AddBuff(ModContent.BuffType<Buffs.Armor.TatteredBlitz>(), 600);
				for (int i = 0; i < 36; i++) {
					Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.Bone);
					dust.noGravity = true;
					dust.velocity = new Vector2(0, 4).RotatedBy(MathHelper.ToRadians(i*10));
					dust.scale = 3f;
                }
				SoundEngine.PlaySound(SoundID.Item93, player.position);
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TatteredCloth, 9);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 6);
			recipe.AddIngredient(ItemID.Silk, 5);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}