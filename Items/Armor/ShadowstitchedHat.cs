using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ShadowstitchedHat : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 6;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<ShadowstitchedRobe>() && legs.type == ModContent.ItemType<ShadowstitchedBoots>();
		}
        public override void UpdateEquip(Player player) {
			player.manaCost -= 0.06f;
			player.GetCritChance(DamageClass.Magic) += 7;
			player.GetDamage(DamageClass.Magic) += 0.07f;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = "Double tap down to activate a 10 second Shadowstitched Blitz.\nThis decreases mana usage by 42%, makes all magic attacks inflict shadowflame, and increases magic critical strike chance by 10\nThe blitz has a cooldown of 40 seconds";
			if (player.controlDown && player.releaseDown && player.doubleTapCardinalTimer[0] < 15 && !player.HasBuff(ModContent.BuffType<Buffs.Armor.TatteredBlitz>()) && !player.HasBuff(ModContent.BuffType<Buffs.Armor.TatteredBlitzCooldown>()) && !player.HasBuff(ModContent.BuffType<Buffs.Armor.ShadowstitchedBlitz>()) && !player.HasBuff(ModContent.BuffType<Buffs.Armor.ShadowstitchedBlitzCooldown>())) { //D=0, U=1, R=2, L=3
				player.AddBuff(ModContent.BuffType<Buffs.Armor.ShadowstitchedBlitz>(), 600);
				for (int i = 0; i < 36; i++) {
					Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.Shadowflame);
					dust.noGravity = true;
					dust.velocity = new Vector2(0, 4).RotatedBy(MathHelper.ToRadians(i*10));
					dust.scale = 3f;
                }
				SoundEngine.PlaySound(SoundID.Item93, player.position);
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TatteredHat>());
			recipe.AddIngredient(ModContent.ItemType<Materials.TabooEssence>(), 8);
			recipe.AddRecipeGroup("Zylon:AnyAdamantiteBar", 4);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}