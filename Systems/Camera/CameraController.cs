using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Systems.Camera
{
	public class CameraController : ModSystem
	{
        public static int ScreenshakeAmount = 0;

        public static void ScreenshakePoints(float ScreenshakeValue, float DistanceMax, Vector2 PointOne, Vector2 PointTwo, float Multiplier = 1f)
        {
            float FakeAmount;
            FakeAmount = (DistanceMax - (PointOne - PointTwo).Length()) / DistanceMax * ScreenshakeValue;
            FakeAmount *= Multiplier;

            if (FakeAmount < 0)
                FakeAmount = 0;

            ScreenshakeAmount += (int)FakeAmount;
        }
        public override void ModifyScreenPosition()
        {

            if (ScreenshakeAmount > 0)
            {
                float AccessibilityValue = ModContent.GetInstance<ZylonConfig>().ScreenshakeAccessibilityMulti;
                float ActualShakeValue;
                ActualShakeValue = (ScreenshakeAmount * 0.75f) * AccessibilityValue;


                Main.screenPosition += Main.rand.NextVector2Circular(ActualShakeValue, ActualShakeValue);
                ScreenshakeAmount--;
            }

            base.ModifyScreenPosition();
        }
    }   
}