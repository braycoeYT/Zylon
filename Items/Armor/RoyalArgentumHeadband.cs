using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RoyalArgentumHeadband : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 15);
			Item.rare = ModContent.RarityType<Magenta>();
			Item.defense = 1;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<RoyalArgentumChestpiece>() && legs.type == ModContent.ItemType<RoyalArgentumBoots>();
		}
        public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetDamage(DamageClass.Summon) += 0.12f;
			p.summonCrit += 12;
			player.GetKnockback(DamageClass.Summon) += 0.25f;
			player.maxMinions += 2;
			player.whipRangeMultiplier += 0.25f;
        }
        public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.setBonus = Language.GetTextValue("Mods.Zylon.Items.RoyalArgentumHeadband.SetBonus");
			p.argentumSetBonus = true;
			player.GetDamage(DamageClass.Summon) += 0.5f;
			player.maxMinions += 4;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Armor.ArgentumOrb>()] < 4 && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Armor.ArgentumOrb>(), 200, 4f, Main.myPlayer, player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Armor.ArgentumOrb>()]);
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SilverHelmet);
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>(), 4);
			recipe.AddIngredient(ItemID.FragmentStardust, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TungstenHelmet);
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>(), 4);
			recipe.AddIngredient(ItemID.FragmentStardust, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}