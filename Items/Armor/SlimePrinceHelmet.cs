using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SlimePrinceHelmet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 10);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 1;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<SlimePrinceBreastplate>() && legs.type == ModContent.ItemType<SlimePrinceLeggings>();
		}
        public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Summon) += 0.03f;
        }
        public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.slimePrinceArmor = true;
			player.setBonus = "Summons a floating slime staff to volley slime at enemies";
			player.AddBuff(ModContent.BuffType<Buffs.Minions.RoyalSlime>(), 60);
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.RoyalSlime>()] < 1 && player.whoAmI == Main.myPlayer)
				Projectile.NewProjectile(new EntitySource_TileBreak((int)player.position.X, (int)player.position.Y), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Minions.RoyalSlime>(), 20, 1f, Main.myPlayer);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.SlimyCore>(), 5);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
	}
}