using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherStory
{
	public class MysteriousConversation : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mysterious Conversation, Part 1");
			Tooltip.SetDefault("'Note: An --- means unknown.\n1: Finally you're back.\n2: I am almost done with the testing.\n1: You said that --- --- ago.\n2: Yes, honey, I know that. The --- is very cooperative.\n1: What are you even doing to that --- ---, ---?\n2: My testing is almost complete. I can show you the ---...\nAn unknown time later...\n1: ---, what you're doing is... unethical!\n2: That doesn't matter.\n1: Our --- barely even --- you anymore!\n2: Yes, but the benefits are so ---, we could --- it all, don't you ---?!\n1: Do you even care anymore?!\n2: ...\n1: Your sanity, your ---, your happiness...\n2: ...\n1: Do...you even...care...\n2: I do! That's why I'm doing this...\n1: What your doing is ---...\n2: What do you mean by that?\n1: Doing this would slowly kill you...\n2: The --- aren't on me, they're on him...\n1: I mean ---! If you continue this...if...you...'");
			ItemID.Sets.ItemNoGravity[item.type] = true;
			//3, month, boy, poor, boy, Toxeye, prototypes, Toxeye, son, knows, great, own, understand, son, unhealthy, experiments, mentally
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 0;
			item.rare = ItemRarityID.Pink;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
		}
	}
}