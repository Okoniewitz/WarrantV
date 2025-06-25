using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using GTA;

namespace WarrantV
{
    public static class Config
    {
        public static class Strings
        {
            public static string WarrantsVSaved = "WarrantsV Saved";


            public static string PhoneBlipName = "Phone";
            public static string PhoneNoMoney = $"You dont have enough money.";
            public static string PhoneLeave = "Press ~INPUT_PICKUP~ to leave the telephone";
            public static string PhoneUse = "Press ~INPUT_PICKUP~ to use the telephone.";
            public static string PhoneBroken = "This phone is broken.";
            public static string PhoneButtonMichael = "INPUT_CELLPHONE_LEFT";
            public static string PhoneButtonFranklin = "INPUT_CELLPHONE_UP";
            public static string PhoneButtonTrevor = "INPUT_CELLPHONE_RIGHT";
            public static string PhoneToBribeCops = "to bribe cops";
            public static string PhoneToBribeCopsMichael = "to bribe cops for M";
            public static string PhoneToBribeCopsFranklin = "to bribe cops for F";
            public static string PhoneToBribeCopsTrevor = "to bribe cops for T";

            public static string PlateChange = "Press ~INPUT_PICKUP~ to change license plate.";
            public static string PlateNoMore = "You dont have any license plates.";
            public static string PlateBuy = "Press ~INPUT_PICKUP~ to buy plate for";
            public static string PlateBuyInfo = "You have";
            public static string PlateBuyInfo2 = "plates.";
            public static string PlateNoMoney = $"You dont have enough money.";
            public static string PlateMaxAmnt = $"You already have max amount of plates.";
            public static string PlateWanted = "WANTED";
            public static string PlateRecognized = "RCGNIZED";


            public static string CopStateRegular = "Cop";
            public static string CopStateBike = "Cop Bike";
            public static string CopStateHeli = "Cop Heli";
            public static string CopStateBoat = "Cop Boat";
            public static string CopStateCar = "Cop Car";
            public static string CopBlipFace = "Face";
            public static string CopBlipVeh = "Veh";
        }
        public static class Bools
        {
            public static bool debug = false;
            public static bool FixWLicensePlates = true;
            public static bool WantedPoliceVehs = true;
            public static bool WantedRandomVehs = false;
            public static bool CrashAndEnterMessage = true;
            public static bool WantedWhenMasked = true;
            public static bool OnlyPassangerCanCall = true;
            public static bool RecognitionScreenFX = true;
            public static bool DisableAllCopBlips = false;
            public static bool PhoneBlipsEnabled = true;
            public static bool AlwaysShowPlate = false;
            public static bool CopBlipHeadingIndicator = true;
            public static bool CopBlipCone = true;
            public static bool CopBlipOnlyWhenInvisible = true;
            public static bool CopsDoTasks = true;
            public static bool NotUselessArmorCompability = true;
            public static bool CopCallAnim = true;
            public static bool MaskNerf = true;
            public static bool WantedNearCar = true;
            public static bool IVChases = true;
            public static bool PlateChanging = true;
            public static bool ExtraBlipIndicators = true;
        }
        public static class Numeric
        {
            public static int RememberNewClothesWhenAlmostRecognizedNumber = 70;
            public static int ClothesDifferencesToClearWarrant = 3;
            public static int CopsToClearList = 30;
            public static int ScreenEffectID = 12;
            public static int RandomWantedCarChance = 3;
            public static float WantedNearCarMaxDist = 12f;

            public static float CopsFOV = 110f;
            public static float CopsFOVinVeh = 110f;
            public static int CopsVisibleDistance = 50;

            public static int TimeToLoseInterest = 9000;
            public static int TimeToForgetFace = 3000;
            public static int FaceForgetPerTick = 4;
            public static int PlateForgetPerTick = 4;

            public static int BaseTimeToCall = 3000;
            public static int AddedRandomTimeToCallMin = 3;
            public static int AddedRandomTimeToCallMax = 6;
            public static int CallTime = 5000;
            public static float MinDistToCall = 15f;

            public static int PhoneBlipSrpite = 458;
            public static int PhoneBlipColor = 0;
            public static float PhoneBlipScale = 0.9f;
            public static float PhoneBlipDisplayDist = 50f;


            public static int PlatePrice = 500;
            public static int PlateMaxNum = 5;

            public static int CarPosterAnimStartLoc = 246;
            public static int PlayerPosterAnimStartLoc = 246;
            public static int CarPosterAnimFinalLoc = 210;
            public static int PlayerPosterAnimFinalLoc = 210;
            public static int PlayerPosterHeight = 580;
            public static int CarPosterHeight = 650;

            public static float CopBlipScale = 0.6f;
            public static float CopBlipVehScale = 0.9f;

            public static float RecognitionAddSprint = -12;
            public static float RecognitionAddRun = -12;
            public static float RecognitionAddPerKnownClothes = 12;
            public static float RecognitionAddBadWeather = -15;
            public static float RecognitionAddNight = -10;
            public static float RecognitionAddInWantedCar = 8;
            public static float RecognitionAddInCar = -10;
            public static float RecognitionAddInCarSneaking = -20;
            public static float RecognitionAddVisibleFaceMaxDist = 30;
            public static float RecognitionAddVisibleFace = 15;
            public static float RecognitionAddNotVisibleFace = -10;
            public static float RecognitionAddBase = 40;
            public static float RecognitionAddWarrantMultip = 5;
            public static float RecognitionAddMultip = 3;
            public static float RecognitionAddDistMultip = 1.6f;
            public static float RecognitionAddDivider = 3f;
            public static float RecognitionAddArmor = 15;

            public static float VehRecognitionAddBadWeather = -7;
            public static float VehRecognitionAddNight = -7;
            public static float VehRecognitionAddVisiblePlateMaxDist = 30;
            public static float VehRecognitionAddVisiblePlate = 15;
            public static float VehRecognitionAddSpeedDivider = 2;
            public static float VehRecognitionAddWarrantMultip = 5;
            public static float VehRecognitionAddBase = 40;
            public static float VehRecognitionAddMultip = 3;
            public static float VehRecognitionAddDistMultip = 1.7f;
            public static float VehRecognitionAddDivider = 2f;


            public static int ArmorMichaelComponentID = 8;
            public static int ArmorMichaelDrawableID = 17;

            public static int ArmorFranklinComponentID = 8;
            public static int ArmorFranklinDrawableID = 6;

            public static int ArmorTrevorComponentID = 8;
            public static int ArmorTrevorDrawableID = 8;

            public static float NerfSpeed = 0.8f;
            public static float NerfRegen = 0.4f;
            public static float NoNerfSpeed = 1f;
            public static float NoNerfRegen = 1f;
        }
        public static class ETC
        {
            public static Keys OpenMenuKey = Keys.E;
            public static Keys MichaelMenuKey = Keys.Left;
            public static Keys FranklinMenuKey = Keys.Up;
            public static Keys TrevorMenuKey = Keys.Right;
            public static Keys PlateBuyKey = Keys.E;
            public static Keys PlateChange = Keys.E;
        }

        private static ScriptSettings ConfigFile = ScriptSettings.Load("scripts\\Okoniewitz\\WarrantsV\\Config.ini");

        public static void Read()
        {
            ConfigFile = ScriptSettings.Load("scripts\\Okoniewitz\\WarrantsV\\Config.ini");
            string[] ConfigLines =
            {
                "[FEATURES]",
                "debug = false",
                "FixWLicensePlates = true",
                "WantedPoliceVehs = true",
                "WantedRandomVehs = true",
                "CrashAndEnterMessage = true",
                "WantedWhenMasked = true",
                "OnlyPassangerCanCall = true",
                "RecognitionScreenFX = true",
                "DisableAllCopBlips = false",
                "PhoneBlipsEnabled = true",
                "AlwaysShowPlate = false",
                "CopBlipHeadingIndicator = true",
                "CopBlipCone = true",
                "CopBlipOnlyWhenInvisible = true",
                "CopsDoTasks = true",
                "NotUselessArmorCompability = true",
                "CopCallAnim = true",
                "MaskNerf = true",
                "WantedNearCar = true",
                "IVChases = true",
                "PlateChanging = true",
                "ExtraBlipIndicators = true",
                "",
                "[KEYBINDS]",
                "OpenMenuKey = Keys.E",
                "MichaelMenuKey = Keys.Left",
                "FranklinMenuKey = Keys.Up",
                "TrevorMenuKey = Keys.Right",
                "PlateBuyKey = Keys.E",
                "PlateChange = Keys.E",
                "",
                "[SETTINGS]",
                "RememberNewClothesWhenAlmostRecognizedNumber = 70",
                "ClothesDifferencesToClearWarrant = 3",
                "CopsToClearList = 30",
                "ScreenEffectID = 12",
                "RandomWantedCarChance = 3",
                "WantedNearCarMaxDist = 12f",
                "",
                "CopsFOV = 110f",
                "CopsFOVinVeh = 110f",
                "CopsVisibleDistance = 50",
                "",
                "NerfRegen = 0,4f",
                "NerfSpeed = 0,8f",
                "NoNerfRegen = 1f",
                "NoNerfSpeed = 1f",
                "",
                "TimeToLoseInterest = 9000",
                "TimeToForgetFace = 3000",
                "FaceForgetPerTick = 4",
                "PlateForgetPerTick = 4",
                "",
                "BaseTimeToCall = 3000",
                "AddedRandomTimeToCallMin = 3",
                "AddedRandomTimeToCallMax = 6",
                "CallTime = 5000",
                "MinDistToCall = 15f",
                "",
                "PhoneBlipSrpite = 458",
                "PhoneBlipColor = 0",
                "PhoneBlipScale = 0,9f",
                "PhoneBlipDisplayDist = 50f",
                "",
                "PlatePrice = 500",
                "PlateMaxNum = 5",
                "",
                "CarPosterAnimStartLoc = 246",
                "PlayerPosterAnimStartLoc = 246",
                "CarPosterAnimFinalLoc = 210",
                "PlayerPosterAnimFinalLoc = 210",
                "PlayerPosterHeight = 580",
                "CarPosterHeight = 650",
                "",
                "CopBlipScale = 0,6f",
                "CopBlipVehScale = 0,9f",
                "",
                "RecognitionAddSprint = -12f",
                "RecognitionAddRun = -12f",
                "RecognitionAddPerKnownClothes = 12f",
                "RecognitionAddBadWeather = -15f",
                "RecognitionAddNight = -10f",
                "RecognitionAddInWantedCar = 8f",
                "RecognitionAddInCar = -10f",
                "RecognitionAddInCarSneaking = -20f",
                "RecognitionAddVisibleFaceMaxDist = 30f",
                "RecognitionAddVisibleFace = 15f",
                "RecognitionAddNotVisibleFace = -10f",
                "RecognitionAddBase = 40f",
                "RecognitionAddWarrantMultip = 5f",
                "RecognitionAddMultip = 3f",
                "RecognitionAddDistMultip = 1,6f",
                "RecognitionAddDivider = 3f",
                "RecognitionAddArmor = 15f",
                "",
                "VehRecognitionAddBadWeather = -7f",
                "VehRecognitionAddNight = -7f",
                "VehRecognitionAddVisiblePlateMaxDist = 30f",
                "VehRecognitionAddVisiblePlate = 15f",
                "VehRecognitionAddSpeedDivider = 2f",
                "VehRecognitionAddWarrantMultip = 5f",
                "VehRecognitionAddBase = 40f",
                "VehRecognitionAddMultip = 3f",
                "VehRecognitionAddDistMultip = 1,7f",
                "VehRecognitionAddDivider = 2f",
                "",
                "ArmorMichaelComponentID = 8",
                "ArmorMichaelDrawableID = 17",
                "ArmorFranklinComponentID = 8",
                "ArmorFranklinDrawableID = 6",
                "ArmorTrevorComponentID = 8",
                "ArmorTrevorDrawableID = 8",
                "",
                "[LOCALISATION]",
                "WarrantsVSaved = \"WarrantsV Saved\"",
                "PhoneBlipName = \"Phone\"",
                "PhoneNoMoney = \"You dont have enough money.\"",
                "PhoneLeave = \"Press ~INPUT_PICKUP~ to leave the telephone\"",
                "PhoneUse = \"Press ~INPUT_PICKUP~ to use the telephone.\"",
                "PhoneBroken = \"This phone is broken.\"",
                "PhoneButtonMichael = \"INPUT_CELLPHONE_LEFT\"",
                "PhoneButtonFranklin = \"INPUT_CELLPHONE_UP\"",
                "PhoneButtonTrevor = \"INPUT_CELLPHONE_RIGHT\"",
                "PhoneToBribeCops = \"to bribe cops\"",
                "PhoneToBribeCopsMichael = \"to bribe cops for M\"",
                "PhoneToBribeCopsFranklin = \"to bribe cops for F\"",
                "PhoneToBribeCopsTrevor = \"to bribe cops for T\"",
                "PlateChange = \"Press ~INPUT_PICKUP~ to change license plate.\"",
                "PlateNoMore = \"You dont have any license plates.\"",
                "PlateBuy = \"Press ~INPUT_PICKUP~ to buy plate for",
                "PlateBuyInfo = \"You have\"",
                "PlateBuyInfo2 = \"plates.\"",
                "PlateNoMoney = \"You dont have enough money.\"",
                "PlateMaxAmnt = \"You already have max amount of plates.\"",
                "PlateWanted = \"WANTED\"",
                "PlateRecognized = \"RCGNIZED\"",
                "CopStateRegular = \"Cop\"",
                "CopStateBike = \"Cop Bike\"",
                "CopStateHeli = \"Cop Heli\"",
                "CopStateBoat = \"Cop Boat\"",
                "CopStateCar = \"Cop Car\"",
                "CopBlipFace = \"Face\"",
                "CopBlipVeh = \"Veh\"",
            };

            if (!File.Exists("scripts\\Okoniewitz\\WarrantsV\\Config.ini"))
                File.WriteAllLines("scripts\\Okoniewitz\\WarrantsV\\Config.ini", ConfigLines);
            #region Strings;
            Config.Strings.WarrantsVSaved = ConfigFile.GetValue<string>("LOCALISATION", "WarrantsVSaved", "ERROR");

            Config.Strings.PhoneBlipName = ConfigFile.GetValue<string>("LOCALISATION", "PhoneBlipName", "ERROR");
            Config.Strings.PhoneNoMoney = ConfigFile.GetValue<string>("LOCALISATION", "PhoneNoMoney", "ERROR");
            Config.Strings.PhoneLeave = ConfigFile.GetValue<string>("LOCALISATION", "PhoneLeave", "ERROR");
            Config.Strings.PhoneUse = ConfigFile.GetValue<string>("LOCALISATION", "PhoneUse", "ERROR");
            Config.Strings.PhoneBroken = ConfigFile.GetValue<string>("LOCALISATION", "PhoneBroken", "ERROR");
            Config.Strings.PhoneButtonMichael = ConfigFile.GetValue<string>("LOCALISATION", "PhoneButtonMichael", "ERROR");
            Config.Strings.PhoneButtonFranklin = ConfigFile.GetValue<string>("LOCALISATION", "PhoneButtonFranklin", "ERROR");
            Config.Strings.PhoneButtonTrevor = ConfigFile.GetValue<string>("LOCALISATION", "PhoneButtonTrevor", "ERROR");
            Config.Strings.PhoneToBribeCops = ConfigFile.GetValue<string>("LOCALISATION", "PhoneToBribeCops", "ERROR");
            Config.Strings.PhoneToBribeCopsMichael = ConfigFile.GetValue<string>("LOCALISATION", "PhoneToBribeCopsMichael", "ERROR");
            Config.Strings.PhoneToBribeCopsFranklin = ConfigFile.GetValue<string>("LOCALISATION", "PhoneToBribeCopsFranklin", "ERROR");
            Config.Strings.PhoneToBribeCopsTrevor = ConfigFile.GetValue<string>("LOCALISATION", "PhoneToBribeCopsTrevor", "ERROR");

            Config.Strings.PlateChange = ConfigFile.GetValue<string>("LOCALISATION", "PlateChange", "ERROR");
            Config.Strings.PlateNoMore = ConfigFile.GetValue<string>("LOCALISATION", "PlateNoMore", "ERROR");
            Config.Strings.PlateBuy = ConfigFile.GetValue<string>("LOCALISATION", "PlateBuy", "ERROR");
            Config.Strings.PlateBuyInfo = ConfigFile.GetValue<string>("LOCALISATION", "PlateBuyInfo", "ERROR");
            Config.Strings.PlateNoMoney = ConfigFile.GetValue<string>("LOCALISATION", "PlateNoMoney", "ERROR");
            Config.Strings.PlateMaxAmnt = ConfigFile.GetValue<string>("LOCALISATION", "PlateMaxAmnt", "ERROR");
            Config.Strings.PlateWanted = ConfigFile.GetValue<string>("LOCALISATION", "PlateWanted", "ERROR");
            Config.Strings.PlateRecognized = ConfigFile.GetValue<string>("LOCALISATION", "PlateRecognized", "ERROR");

            Config.Strings.CopStateRegular = ConfigFile.GetValue<string>("LOCALISATION", "CopStateRegular", "ERROR");
            Config.Strings.CopStateBike = ConfigFile.GetValue<string>("LOCALISATION", "CopStateBike", "ERROR");
            Config.Strings.CopStateHeli = ConfigFile.GetValue<string>("LOCALISATION", "CopStateHeli", "ERROR");
            Config.Strings.CopStateBoat = ConfigFile.GetValue<string>("LOCALISATION", "CopStateBoat", "ERROR");
            Config.Strings.CopStateCar = ConfigFile.GetValue<string>("LOCALISATION", "CopStateCar", "ERROR");
            Config.Strings.CopBlipFace = ConfigFile.GetValue<string>("LOCALISATION", "CopBlipFace", "ERROR");
            Config.Strings.CopBlipVeh = ConfigFile.GetValue<string>("LOCALISATION", "CopBlipVeh", "ERROR");
            #endregion;
            #region bools;
            Config.Bools.debug = ConfigFile.GetValue<bool>("FEATURES", "debug", false);
            Config.Bools.FixWLicensePlates = ConfigFile.GetValue<bool>("FEATURES", "FixWLicensePlates", true);
            Config.Bools.WantedPoliceVehs = ConfigFile.GetValue<bool>("FEATURES", "WantedPoliceVehs", true);
            Config.Bools.WantedRandomVehs = ConfigFile.GetValue<bool>("FEATURES", "WantedRandomVehs", true);
            Config.Bools.CrashAndEnterMessage = ConfigFile.GetValue<bool>("FEATURES", "CrashAndEnterMessage", true);
            Config.Bools.WantedWhenMasked = ConfigFile.GetValue<bool>("FEATURES", "WantedWhenMasked", true);
            Config.Bools.OnlyPassangerCanCall = ConfigFile.GetValue<bool>("FEATURES", "OnlyPassangerCanCall", true);
            Config.Bools.RecognitionScreenFX = ConfigFile.GetValue<bool>("FEATURES", "RecognitionScreenFX", true);
            Config.Bools.DisableAllCopBlips = ConfigFile.GetValue<bool>("FEATURES", "DisableAllCopBlips", false);
            Config.Bools.PhoneBlipsEnabled = ConfigFile.GetValue<bool>("FEATURES", "PhoneBlipsEnabled", true);
            Config.Bools.AlwaysShowPlate = ConfigFile.GetValue<bool>("FEATURES", "AlwaysShowPlate", false);
            Config.Bools.CopBlipHeadingIndicator = ConfigFile.GetValue<bool>("FEATURES", "CopBlipHeadingIndicator", true);
            Config.Bools.CopBlipCone = ConfigFile.GetValue<bool>("FEATURES", "CopBlipCone", true);
            Config.Bools.CopBlipOnlyWhenInvisible = ConfigFile.GetValue<bool>("FEATURES", "CopBlipOnlyWhenInvisible", true);
            Config.Bools.CopsDoTasks = ConfigFile.GetValue<bool>("FEATURES", "CopsDoTasks", true);
            Config.Bools.NotUselessArmorCompability = ConfigFile.GetValue<bool>("FEATURES", "NotUselessArmorCompability", true);
            Config.Bools.CopCallAnim = ConfigFile.GetValue<bool>("FEATURES", "CopCallAnim", true);
            Config.Bools.MaskNerf = ConfigFile.GetValue<bool>("FEATURES", "MaskNerf", true);
            Config.Bools.WantedNearCar = ConfigFile.GetValue<bool>("FEATURES", "WantedNearCar", true);
            Config.Bools.IVChases = ConfigFile.GetValue<bool>("FEATURES", "IVChases", true);
            Config.Bools.PlateChanging = ConfigFile.GetValue<bool>("FEATURES", "PlateChanging", true);
            Config.Bools.ExtraBlipIndicators = ConfigFile.GetValue<bool>("FEATURES", "ExtraBlipIndicators", true);
            #endregion;
            #region Binds;
            Config.ETC.OpenMenuKey = ConfigFile.GetValue<Keys>("KEYBINDS", "OpenMenuKey", Keys.E);
            Config.ETC.MichaelMenuKey = ConfigFile.GetValue<Keys>("KEYBINDS", "MichaelMenuKey", Keys.Left);
            Config.ETC.FranklinMenuKey = ConfigFile.GetValue<Keys>("KEYBINDS", "FranklinMenuKey", Keys.Up);
            Config.ETC.TrevorMenuKey = ConfigFile.GetValue<Keys>("KEYBINDS", "TrevorMenuKey", Keys.Right);
            Config.ETC.PlateBuyKey = ConfigFile.GetValue<Keys>("KEYBINDS", "PlateBuyKey", Keys.E);
            Config.ETC.PlateChange = ConfigFile.GetValue<Keys>("KEYBINDS", "PlateChange", Keys.E);
            #endregion;
            #region Numeric;
            Config.Numeric.RememberNewClothesWhenAlmostRecognizedNumber = ConfigFile.GetValue<int>("SETTINGS", "RememberNewClothesWhenAlmostRecognizedNumber", 70);
            Config.Numeric.ClothesDifferencesToClearWarrant = ConfigFile.GetValue<int>("SETTINGS", "ClothesDifferencesToClearWarrant", 3);
            Config.Numeric.CopsToClearList = ConfigFile.GetValue<int>("SETTINGS", "CopsToClearList", 30);
            Config.Numeric.ScreenEffectID = ConfigFile.GetValue<int>("SETTINGS", "ScreenEffectID", 12);
            Config.Numeric.RandomWantedCarChance = ConfigFile.GetValue<int>("SETTINGS", "RandomWantedCarChance", 3);
            Config.Numeric.WantedNearCarMaxDist = ConfigFile.GetValue<float>("SETTINGS", "WantedNearCarMaxDist", 12f);
            Config.Numeric.CopsFOV = ConfigFile.GetValue<float>("SETTINGS", "CopsFOV", 110f);
            Config.Numeric.CopsFOVinVeh = ConfigFile.GetValue<float>("SETTINGS", "CopsFOVinVeh", 110f);
            Config.Numeric.CopsVisibleDistance = ConfigFile.GetValue<int>("SETTINGS", "CopsVisibleDistance", 50);
            Config.Numeric.TimeToLoseInterest = ConfigFile.GetValue<int>("SETTINGS", "TimeToLoseInterest", 9000);
            Config.Numeric.TimeToForgetFace = ConfigFile.GetValue<int>("SETTINGS", "TimeToForgetFace", 3000);
            Config.Numeric.FaceForgetPerTick = ConfigFile.GetValue<int>("SETTINGS", "FaceForgetPerTick", 4);
            Config.Numeric.PlateForgetPerTick = ConfigFile.GetValue<int>("SETTINGS", "PlateForgetPerTick", 4);
            Config.Numeric.BaseTimeToCall = ConfigFile.GetValue<int>("SETTINGS", "BaseTimeToCall", 3000);
            Config.Numeric.AddedRandomTimeToCallMin = ConfigFile.GetValue<int>("SETTINGS", "AddedRandomTimeToCallMin", 3);
            Config.Numeric.AddedRandomTimeToCallMax = ConfigFile.GetValue<int>("SETTINGS", "AddedRandomTimeToCallMax", 6);
            Config.Numeric.CallTime = ConfigFile.GetValue<int>("SETTINGS", "CallTime", 5000);
            Config.Numeric.MinDistToCall = ConfigFile.GetValue<float>("SETTINGS", "MinDistToCall", 15f);
            Config.Numeric.PhoneBlipSrpite = ConfigFile.GetValue<int>("SETTINGS", "PhoneBlipSrpite", 458);
            Config.Numeric.PhoneBlipColor = ConfigFile.GetValue<int>("SETTINGS", "PhoneBlipColor", 0);
            Config.Numeric.PhoneBlipScale = ConfigFile.GetValue<float>("SETTINGS", "PhoneBlipScale", 0.9f);
            Config.Numeric.PhoneBlipDisplayDist = ConfigFile.GetValue<float>("SETTINGS", "PhoneBlipDisplayDist", 50f);
            Config.Numeric.PlatePrice = ConfigFile.GetValue<int>("SETTINGS", "PlatePrice", 500);
            Config.Numeric.PlateMaxNum = ConfigFile.GetValue<int>("SETTINGS", "PlateMaxNum", 5);
            Config.Numeric.CarPosterAnimStartLoc = ConfigFile.GetValue<int>("SETTINGS", "CarPosterAnimStartLoc", 246);
            Config.Numeric.PlayerPosterAnimStartLoc = ConfigFile.GetValue<int>("SETTINGS", "PlayerPosterAnimStartLoc", 246);
            Config.Numeric.CarPosterAnimFinalLoc = ConfigFile.GetValue<int>("SETTINGS", "CarPosterAnimFinalLoc", 210);
            Config.Numeric.PlayerPosterAnimFinalLoc = ConfigFile.GetValue<int>("SETTINGS", "PlayerPosterAnimFinalLoc", 210);
            Config.Numeric.PlayerPosterHeight = ConfigFile.GetValue<int>("SETTINGS", "PlayerPosterHeight", 580);
            Config.Numeric.CarPosterHeight = ConfigFile.GetValue<int>("SETTINGS", "CarPosterHeight", 650);
            Config.Numeric.CopBlipScale = ConfigFile.GetValue<float>("SETTINGS", "CopBlipScale", 0.6f);
            Config.Numeric.CopBlipVehScale = ConfigFile.GetValue<float>("SETTINGS", "CopBlipVehScale", 0.9f);
            Config.Numeric.RecognitionAddSprint = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddSprint", -12);
            Config.Numeric.RecognitionAddRun = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddRun", -12);
            Config.Numeric.RecognitionAddPerKnownClothes = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddPerKnownClothes", 12);
            Config.Numeric.RecognitionAddBadWeather = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddBadWeather", -15);
            Config.Numeric.RecognitionAddNight = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddNight", -10);
            Config.Numeric.RecognitionAddInWantedCar = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddInWantedCar", 8);
            Config.Numeric.RecognitionAddInCar = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddInCar", -10);
            Config.Numeric.RecognitionAddInCarSneaking = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddInCarSneaking", -20);
            Config.Numeric.RecognitionAddVisibleFaceMaxDist = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddVisibleFaceMaxDist", 30);
            Config.Numeric.RecognitionAddVisibleFace = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddVisibleFace", 15);
            Config.Numeric.RecognitionAddNotVisibleFace = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddVisibleFace", -10);
            Config.Numeric.RecognitionAddBase = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddBase", 40);
            Config.Numeric.RecognitionAddWarrantMultip = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddWarrantMultip", 5);
            Config.Numeric.RecognitionAddMultip = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddMultip", 3);
            Config.Numeric.RecognitionAddDistMultip = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddDistMultip", 1.6f);
            Config.Numeric.RecognitionAddDivider = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddDivider", 3f);
            Config.Numeric.RecognitionAddArmor = ConfigFile.GetValue<float>("SETTINGS", "RecognitionAddArmor", 15);
            Config.Numeric.VehRecognitionAddBadWeather = ConfigFile.GetValue<float>("SETTINGS", "VehRecognitionAddBadWeather", -7);
            Config.Numeric.VehRecognitionAddNight = ConfigFile.GetValue<float>("SETTINGS", "VehRecognitionAddNight", -7);
            Config.Numeric.VehRecognitionAddVisiblePlateMaxDist = ConfigFile.GetValue<float>("SETTINGS", "VehRecognitionAddVisiblePlateMaxDist", 30);
            Config.Numeric.VehRecognitionAddVisiblePlate = ConfigFile.GetValue<float>("SETTINGS", "VehRecognitionAddVisiblePlate", 15);
            Config.Numeric.VehRecognitionAddSpeedDivider = ConfigFile.GetValue<float>("SETTINGS", "VehRecognitionAddSpeedDivider", 2);
            Config.Numeric.VehRecognitionAddWarrantMultip = ConfigFile.GetValue<float>("SETTINGS", "VehRecognitionAddWarrantMultip", 5);
            Config.Numeric.VehRecognitionAddBase = ConfigFile.GetValue<float>("SETTINGS", "VehRecognitionAddBase", 40);
            Config.Numeric.VehRecognitionAddMultip = ConfigFile.GetValue<float>("SETTINGS", "VehRecognitionAddMultip", 3);
            Config.Numeric.VehRecognitionAddDistMultip = ConfigFile.GetValue<float>("SETTINGS", "VehRecognitionAddDistMultip", 1.7f);
            Config.Numeric.VehRecognitionAddDivider = ConfigFile.GetValue<float>("SETTINGS", "VehRecognitionAddDivider", 2f);
            Config.Numeric.ArmorMichaelComponentID = ConfigFile.GetValue<int>("SETTINGS", "ArmorMichaelComponentID", 8);
            Config.Numeric.ArmorMichaelDrawableID = ConfigFile.GetValue<int>("SETTINGS", "ArmorMichaelDrawableID", 17);
            Config.Numeric.ArmorFranklinComponentID = ConfigFile.GetValue<int>("SETTINGS", "ArmorFranklinComponentID", 8);
            Config.Numeric.ArmorFranklinDrawableID = ConfigFile.GetValue<int>("SETTINGS", "ArmorFranklinDrawableID", 6);
            Config.Numeric.ArmorTrevorComponentID = ConfigFile.GetValue<int>("SETTINGS", "ArmorTrevorComponentID", 8);
            Config.Numeric.ArmorTrevorDrawableID = ConfigFile.GetValue<int>("SETTINGS", "ArmorTrevorDrawableID", 8);
            Config.Numeric.NerfRegen = ConfigFile.GetValue<float>("SETTINGS", "NerfRegen", 0.4f);
            Config.Numeric.NerfSpeed = ConfigFile.GetValue<float>("SETTINGS", "NerfSpeed", 0.8f);
            Config.Numeric.NoNerfRegen = ConfigFile.GetValue<float>("SETTINGS", "NoNerfRegen", 1f);
            Config.Numeric.NoNerfSpeed = ConfigFile.GetValue<float>("SETTINGS", "NoNerfSpeed", 1f);
            #endregion;
        }
    }
}


