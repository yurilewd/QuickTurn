using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using QuickTurn.Patches;
using Reptile;
using UnityEngine;

namespace QuickTurn
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class QuickTurnPlugin : BaseUnityPlugin
    {
        private const string MyGUID = "com.yuril.QuickTurn";
        private const string PluginName = "QuickTurn";
        private const string VersionString = "1.0.0";

        public enum Direction
        {
            Forward,
            Backward
        }

        //CONFIG
        public static ConfigEntry<float> abilitySpeed;

        public static ConfigEntry<Direction> jumpDirection;
        public static ConfigEntry<float> turnAngleJump;
        public static ConfigEntry<float> returnedSpeedJump;

        public static ConfigEntry<Direction> slideDirection;
        public static ConfigEntry<float> turnAngleSlide;
        public static ConfigEntry<float> returnedSpeedSlide;

        public static ConfigEntry<Direction> trickDirection;
        public static ConfigEntry<float> turnAngleTrick;
        public static ConfigEntry<float> returnedSpeedTrick;

        public static ConfigEntry<Direction> boostTrickDirection;
        public static ConfigEntry<float> turnAngleBoostTrick;
        public static ConfigEntry<float> returnedSpeedBoostTrick;

        public static ConfigEntry<float> sens;

        public static ConfigEntry<float> cooldown;
        public static ConfigEntry<float> delay;
        public static ConfigEntry<float> minimumSpeed;
        //

        private Harmony harmony;
        public static Player player;

        private void Awake()
        {
            harmony = new Harmony(MyGUID);
            harmony.PatchAll(typeof(PlayerPatch));

            jumpDirection = Config.Bind("1:Jump", "Direction Jump", Direction.Backward, "");
            turnAngleJump = Config.Bind("1:Jump", "Angle Jump", 45f, new ConfigDescription("", new AcceptableValueRange<float>(0f, 180f)));
            returnedSpeedJump = Config.Bind("1:Jump", "Speed Jump", 0.7f, "");

            slideDirection = Config.Bind("2:Slide", "Direction Slide", Direction.Forward, "");
            turnAngleSlide = Config.Bind("2:Slide", "Angle Slide", 75f, new ConfigDescription("", new AcceptableValueRange<float>(0f, 180f)));
            returnedSpeedSlide = Config.Bind("2:Slide", "Speed Slide", 0.95f, "");

            trickDirection = Config.Bind("3:Trick", "Direction Trick", Direction.Forward, "");
            turnAngleTrick = Config.Bind("3:Trick", "Angle Trick", 180f, new ConfigDescription("", new AcceptableValueRange<float>(0f, 180f)));
            returnedSpeedTrick = Config.Bind("3:Trick", "Speed Trick", 0.5f, "");

            boostTrickDirection = Config.Bind("4:Boost Trick", "Direction Boost Trick", Direction.Forward, "");
            turnAngleBoostTrick = Config.Bind("4:Boost Trick", "Angle Boost Trick", 180f, new ConfigDescription("", new AcceptableValueRange<float>(0f, 180f)));
            returnedSpeedBoostTrick = Config.Bind("4:Boost Trick", "Speed Boost Trick", 0.9f, "");

            sens = Config.Bind("0:General", "Sensitivity", 0.6f, new ConfigDescription("", new AcceptableValueRange<float>(0f, 1f)));
            abilitySpeed = Config.Bind("0:General", "Speed During Ability", 0.4f, "");
            cooldown = Config.Bind("0:General", "Cooldown", 0.5f, "");
            delay = Config.Bind("0:General", "Delay", 0.1f, "");
            minimumSpeed = Config.Bind("0:General", "Minimum Speed", 2f, "");
        }
    }
}
