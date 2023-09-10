using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.Menu
{
    // This is a WIP thing and probably won't be usable for a while
	public class ZylonMenu : ModMenu
	{

        public override bool IsAvailable => false;

        public override string DisplayName => "Zylon";

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/JellyTheme");

        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            Texture2D Logo = (Texture2D)ModContent.Request<Texture2D>("Zylon/Menu/ZylonLogo");

            Vector2 DrawOrigin = Logo.Size() * 0.5f;

            spriteBatch.Draw(Logo, logoDrawCenter, null, drawColor, logoRotation, DrawOrigin, logoScale, SpriteEffects.None, 0f);
            return false;
        }

    }
}