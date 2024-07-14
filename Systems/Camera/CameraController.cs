using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Graphics;

namespace Zylon.Systems.Camera
{
	public class CameraController : ModSystem
	{
        public static int ScreenshakeAmount = 0;
        public static Vector2 PanLocation = Vector2.Zero;
        public static int PanReturn = 0;
        public static float PanReturnMax = 0f;
        public static bool SlowPan = false;
        public static void ScreenshakePoints(float ScreenshakeValue, float DistanceMax, Vector2 PointOne, Vector2 PointTwo, float Multiplier = 1f)
        {
            float FakeAmount;
            FakeAmount = (DistanceMax - (PointOne - PointTwo).Length()) / DistanceMax * ScreenshakeValue;
            FakeAmount *= Multiplier;

            if (FakeAmount < 0)
                FakeAmount = 0;

            ScreenshakeAmount += (int)FakeAmount;
        }

        public static void ManualPanFunction(Vector2 PointOne, Vector2 PointTwo, float Progress)
        {
            if (PanLocation != Vector2.Zero && (PanLocation.Distance(Vector2.SmoothStep(PointOne, PointTwo, Progress)) >= 40f || SlowPan))
            {
                SlowPan = true;
                PanLocation = Vector2.SmoothStep(PanLocation, Vector2.SmoothStep(PointOne, PointTwo, Progress), 0.25f);
                if (SlowPan && PanLocation.Distance(Vector2.SmoothStep(PointOne, PointTwo, Progress)) <= 2.5f)
                {
                    SlowPan = false;
                }

            } else
            {
                PanLocation = Vector2.SmoothStep(PointOne, PointTwo, Progress);
            }
        }

        public static void ReturnCamera(int Returntime)
        {
            if (PanLocation != Vector2.Zero && PanReturn <= 0)
            {
                PanReturn = Returntime;
                PanReturnMax = Returntime;
            }
        }

        public override void ModifyScreenPosition()
        {
            if (PanLocation != Vector2.Zero)
            {
                Vector2 centerVector = (new Vector2(-Main.screenWidth, -Main.screenHeight) / 2f);
                if (PanReturn > 0)
                {
                    PanReturn--;
                    Main.screenPosition = Vector2.SmoothStep(PanLocation + centerVector, Main.LocalPlayer.Center + centerVector, 1f - (PanReturn/PanReturnMax));
                    if (PanReturn == 0)
                    {
                        PanLocation = Vector2.Zero;
                        PanReturnMax = 0f;
                    }
                } else
                {
                    Main.screenPosition = (PanLocation + centerVector);
                }
            }
            if (ScreenshakeAmount > 0)
            {
                float AccessibilityValue = (ModContent.GetInstance<ZylonConfig>().ScreenshakeAccessibilityMulti) / 100f;
                float ActualShakeValue;
                ActualShakeValue = (ScreenshakeAmount * 0.75f) * AccessibilityValue;


                Main.screenPosition += Main.rand.NextVector2Circular(ActualShakeValue, ActualShakeValue);
                ScreenshakeAmount--;
            }

            base.ModifyScreenPosition();
        }

    }   
}