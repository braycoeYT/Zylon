using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class HeavyMetalHammer : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 27;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 16;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 7.75f;
			Item.value = Item.sellPrice(0, 0, 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.hammer = 59;
		}
		int boostNum;
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			if (target.type != NPCID.TargetDummy) {
				boostCheck = 0;
				boostNum = 7;
				Item.useTime = 6;
				Item.useAnimation = 20;
			}
        }
        public override void UseAnimation(Player player) {
            boostNum--;
			if (boostNum <= 0) {
				Item.useTime = 16;
				Item.useAnimation = 40;
			}
        }
		int boostCheck;
        public override void UpdateInventory(Player player) {
            if (boostNum > 0) {
				boostCheck++;
				if (boostCheck > 120) {
					boostCheck = 0;
					boostNum = 0;
					Item.useTime = 16;
					Item.useAnimation = 40;
				}
			}
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronHammer);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(ItemID.Chain, 10);
			recipe.AddRecipeGroup("Zylon:AnyShadowScale", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LeadHammer);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(ItemID.Chain, 10);
			recipe.AddRecipeGroup("Zylon:AnyShadowScale", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}