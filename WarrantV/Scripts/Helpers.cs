using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;

namespace WarrantV
{
    public static class Helpers
    {
        public static ScriptSettings Inifile;
        private static int[] SavesMade = new int[3];
        private static int LastSaved = Game.GameTime;
        public static int[] wanted = new int[3];
        public static List<Tuple<Ped, Blip, float[], int[], Vector3>> CopsList = new List<Tuple<Ped, Blip, float[], int[], Vector3>>();
        public static Color PlateTextColor;

        public static readonly Model[] CopModels =
        {
            "s_m_y_ranger_01",
            "s_m_y_sheriff_01",
            "s_m_y_cop_01",
            "s_f_y_sheriff_01",
            "s_f_y_cop_01",
            "s_m_y_hwaycop_01",
            "ig_lccop_01",
            "ig_lccop_02",
            "ig_lccop_coat_01",
            "ig_lccop_coat_02",
            "ig_lccop_vest_01",
            "ig_lccop_vest_02",
            "ig_lcfatcop",
            "ig_lcfatcop_coat",
            "ig_lcfatcop_vest",
            "ig_lccop_traffic"
        };
        public static readonly Model[] PoliceVehs = new Model[]
        {
            "police",
            "police2",
            "police3",
            "police4",
            "sheriff",
            "sheriff2",
            "policet",
            "riot",
            "polmav",
            "predator",
            "policeold2",
            "policeold1",
            "policeb",
            "pranger",
            "rhino",
            "pbus",
            "stockade",
            "hydra",
            "fbi",
            "fbi2",
            "barracks",
            "barracks3",
            "apc",
            "annihilator",
            "lazer",
            "lcpdpatriot",
            "lcpd",
            "lcpd2",
            "lcpd3",
            "lcpd4",
            "lcpd5",
            "lcpd6",
            "lcpd7",
            "lcpdb",
            "lcpdyo",
            "lcpdtru",
            "lcpdalamo",
            "lcpdspeedo",
            "lcpdbob",
            "lcpdboxville",
            "lcpdimpaler",
            "lcpdimpaler2",
            "lcpdmav",
            "lcpdold",
            "lcpdpanto",
            "lcpdpigeon",
            "lcpdpredator",
            "lcpdriata",
            "lcpdsand",
            "lcpdscout",
            "lcpdshark",
            "lcpdsparrow",
            "lcpdspeedo",
            "lcpdstockade",
            "lcpdtow",
            "lcpdtruck",
            "napc",
            "nstockade",
            "npatriot",
            "ncar",
        };
        public static readonly int[][] MasksTrev =
        {
            new int[] { 2, 14, 15, 16, 17, 18, 19, 20, 27 },
            new int[] { 0, 4 },
            new int[] {5,6,7},
            new int[] {2}
        };
        public static readonly int[][] MasksMichael =
        {
            new int[] { 2,11, 14, 15, 16, 17, 18, 19, 20, 25,28 },
            new int[] { 1,2 },
            new int[] {8},
            new int[] {5}
        };
        public static readonly int[][] MasksFrank =
        {
            new int[] { 0,8,9,10,11,12,13,14,21 },
            new int[] { 0 },
            new int[] {5}
        };
        public static readonly Model[] PhoneModelsList = new Model[]
        {
            "p_phonebox_02_s",
            "prop_phonebox_01a",
            "prop_phonebox_01b",
            "prop_phonebox_01c",
            "prop_phonebox_02",
            "prop_phonebox_03",
            "prop_phonebox_04",
            "cj_ny_phone_1",
            "cj_ny_phone_2", //podwojny telefon plecami do siebie
            "cj_ny_phone_3", //poczworny telefon
            "cj_ny_phone_4", //duzy podwojny telefon plecami do siebie

            //modele sa w liberty_city/dlc1/x64/levels/gta5/liberty_city/props/street/amenitie.rpf
        };
        public static readonly Vector3[] PayAndSprayLocations = new Vector3[]
        {
            new Vector3(-354.6f,-128.15f,39.43f),
        };

        public static string GetVehPlate(Vehicle car)
        {
            if (car.Mods.LicensePlateStyle == LicensePlateStyle.BlueOnWhite1) { PlateTextColor = Color.FromArgb(76, 78, 94); return "plate04"; }
            if (car.Mods.LicensePlateStyle == LicensePlateStyle.BlueOnWhite2) { PlateTextColor = Color.FromArgb(76, 78, 94); return "plate01"; }
            if (car.Mods.LicensePlateStyle == LicensePlateStyle.BlueOnWhite3) { PlateTextColor = Color.FromArgb(76, 78, 94); return "plate05"; }
            if (car.Mods.LicensePlateStyle == LicensePlateStyle.NorthYankton) { PlateTextColor = Color.FromArgb(76, 78, 94); return "yankton_plate"; }
            if (car.Mods.LicensePlateStyle == LicensePlateStyle.YellowOnBlack) { PlateTextColor = Color.FromArgb(202, 171, 1); return "plate02"; }
            if (car.Mods.LicensePlateStyle == (LicensePlateStyle)8) { PlateTextColor = Color.FromArgb(76, 78, 94); return "plate06"; }
            if (car.Mods.LicensePlateStyle ==(LicensePlateStyle)13) { PlateTextColor = Color.FromArgb(76, 78, 94); return "plate06"; }
            if (car.Mods.LicensePlateStyle == (LicensePlateStyle)15) { PlateTextColor = Color.FromArgb(76, 78, 94); return "plate08"; }
            if (car.Mods.LicensePlateStyle == (LicensePlateStyle)16) { PlateTextColor = Color.FromArgb(76, 78, 94); return "plate09"; }
            if (car.Mods.LicensePlateStyle == (LicensePlateStyle)22) { PlateTextColor = Color.FromArgb(76, 78, 94); return "plate15"; }
            if (car.Mods.LicensePlateStyle == (LicensePlateStyle)41) { PlateTextColor = Color.FromArgb(76, 78, 94); return "plate33"; }
            else
            {
                PlateTextColor = Color.FromArgb(202, 171, 1);
                return "plate03";
            }
        }

        public static (bool, bool) Masked()
        {
            bool Mask = false;
            int a = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 0);
            int b = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, 1);
            int c = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 9);
            int d = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 6);
            int e = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, 2);//frank
            if (PlayerID() == 2) Mask = (MasksTrev[0].Contains(a) || MasksTrev[1].Contains(b) || MasksTrev[2].Contains(c) || MasksTrev[3].Contains(d));
            if (PlayerID() == 0)
            {
                if (MasksMichael[0].Contains(a))
                {
                    if (a == 11 && ((Game.Player.Character.IsInVehicle() && Game.Player.Character.CurrentVehicle.ClassType == VehicleClass.Motorcycles) || Main.LastVehType == 8)) Mask = false; else Mask = true;
                }
                if (MasksMichael[1].Contains(b) || MasksMichael[2].Contains(c) || MasksMichael[3].Contains(d))
                {
                    Mask = true;
                }
            }
            if (PlayerID() == 1) Mask = (MasksFrank[0].Contains(a) || MasksFrank[1].Contains(b) || MasksFrank[2].Contains(c) || MasksFrank[2].Contains(e));
            if (Main.DeadDelay > Game.GameTime) return (false, false);
            return (Main.OverrideMasked || Mask, Mask);
        }

        public static string JoinArrays(Array ar)
        {
            string output = "";
            foreach (int s in ar)
            {
                output += $" {s.ToString()}";
            }
            return output;
        }

        private static string CopState(Ped cop)
        {
            string state = Config.Strings.CopStateRegular;//"Cop"
            if (cop.IsInVehicle())
            {
                if (cop.CurrentVehicle.ClassType == VehicleClass.Boats) { state = Config.Strings.CopStateBoat; goto endif; }//"Cop Boat"
                if (cop.CurrentVehicle.ClassType == VehicleClass.Helicopters) { state = Config.Strings.CopStateHeli; goto endif; }//"Cop Heli"
                if (cop.CurrentVehicle.ClassType == VehicleClass.Motorcycles) { state = Config.Strings.CopStateBike; goto endif; }//"Cop Bike"
                state = Config.Strings.CopStateCar;//"Cop Car"
            endif:;
            }
            return state;
        }
        private static string CopRecogState(Ped cop, float[] Recog)
        {
            string[] RecString = new string[2];
            #region Ped
            if (Masked().Item1) if (Game.Player.WantedLevel > 0) RecString[0] = ""; else RecString[0] = $"{Config.Strings.CopBlipFace}:{Math.Floor(Recog[0])}%";
            else if (EachTick.Recognized[0]) RecString[0] = ""; else if (EachTick.WarrantLevel[PlayerID()] > 0 || Game.Player.WantedLevel > 0) RecString[0] = $"{Config.Strings.CopBlipFace}:{Math.Floor(Recog[0])}%";
            #endregion
            #region Vehicle
            if (Game.Player.Character.IsInVehicle())
            {
                if (EachTick.Recognized[1]) RecString[1] = ""; else if (EachTick.WarrantLevelVeh > 0 || Game.Player.WantedLevel > 0) RecString[1] = $" {Config.Strings.CopBlipVeh}:{Math.Floor(Recog[1])}%";
            }
            #endregion
            return RecString[0] + RecString[1];
        }

        public static int BlipHandle(Ped cop, Blip blip, float[] Recog, int TaskType, Vector3 LastSeen, bool PlayerVisible)
        {
            int ReturnTaskType = TaskType;

            if (blip != null)
            {
                blip.Scale = Config.Numeric.CopBlipScale;
                blip.Priority = 10;
                blip.IsShortRange = false;
                blip.ShowsCrewIndicator = false;
                blip.ShowsFriendIndicator = false;
                switch(PlayerID())
                {
                    case 0:
                        blip.SecondaryColor = Color.FromArgb(255, 109,184,215);
                        break;
                    case 1:
                        blip.SecondaryColor = Color.FromArgb(255, 176,238,175);
                        break;
                    case 2:
                        blip.SecondaryColor = Color.FromArgb(255,255,167,95);
                        break;
                    default:
                        blip.SecondaryColor = Color.White;
                        break;
                }
                
                if (CopState(cop) == Config.Strings.CopStateHeli)
                {
                    if (blip.Sprite != BlipSprite.HelicopterAnimated) blip.Sprite = BlipSprite.HelicopterAnimated;
                    Function.Call(Hash.SHOW_HEADING_INDICATOR_ON_BLIP, blip, false);
                }
                else
                {
                    blip.Sprite = (BlipSprite)1;
                    bool EnableCone = ((Config.Bools.CopBlipCone && !Config.Bools.CopBlipOnlyWhenInvisible) || (Config.Bools.CopBlipCone && Config.Bools.CopBlipOnlyWhenInvisible && !Helpers.IsPlayerVisible()));
                    Function.Call(Hash.SHOW_HEADING_INDICATOR_ON_BLIP, blip, Config.Bools.CopBlipHeadingIndicator);
                    Function.Call(Hash.SET_BLIP_SHOW_CONE, blip, EnableCone, 11);
                }
                
                if ((cop.IsDead || !cop.Exists()) && cop.AttachedBlip != null) { blip.Delete(); return 0; }
                
                if (cop.IsInVehicle())
                {
                    if ((cop.CurrentVehicle.GetPedOnSeat(VehicleSeat.Driver) == cop && cop.IsAlive) && !cop.CurrentVehicle.IsSeatFree(VehicleSeat.Passenger))
                    {
                        if (CopsList.Any(c => c.Item1 == cop.CurrentVehicle.GetPedOnSeat(VehicleSeat.Passenger)))
                        {
                            int Index = CopsList.FindIndex(c => c.Item1 == cop.CurrentVehicle.GetPedOnSeat(VehicleSeat.Passenger));
                            if (CopsList[Index].Item3[0] > Recog[0]) Recog[0] = CopsList[Index].Item3[0];
                            if (CopsList[Index].Item3[1] > Recog[1]) Recog[1] = CopsList[Index].Item3[1];
                        }
                    }
                    if (cop.CurrentVehicle.GetPedOnSeat(VehicleSeat.Driver) != cop && !cop.CurrentVehicle.IsSeatFree(VehicleSeat.Driver) || Config.Bools.DisableAllCopBlips)
                    {
                        blip.Alpha = 0;
                    }
                    
                    blip.Scale = Config.Numeric.CopBlipVehScale;
                }
                else blip.Alpha = 255;
                
                blip.Name = $"{CopState(cop)} {CopRecogState(cop, Recog)}";
                
            }
            
            
            if (Recog[0] <= 20 || Recog[1] <= 20)
            {
                if (!Config.Bools.DisableAllCopBlips)
                {
                    blip.Color = BlipColor.Green;
                }
                    
                if (Game.Player.WantedLevel == 0 && TaskType == 0 && PlayerVisible && Config.Bools.CopsDoTasks)
                {
                    cop.Task.LookAt(Game.Player.Character, 300);
                }
            }
            if (Recog[0] > 20 || Recog[1] > 20)
            {
                if (!Config.Bools.DisableAllCopBlips)
                {
                    blip.Color = BlipColor.GreenDark;
                    blip.Priority = 11;
                }
                
                if (Game.Player.WantedLevel == 0 && !cop.IsInVehicle() && TaskType == 0 && PlayerVisible && Config.Bools.CopsDoTasks)
                {
                    cop.Task.LookAt(Game.Player.Character, 300);
                }
            }
            if (Recog[0] > 40 || Recog[1] > 40)
            {
                if (!Config.Bools.DisableAllCopBlips)
                {
                    blip.Color = BlipColor.Yellow;
                    blip.Priority = 12;
                }
                
                if (Game.Player.WantedLevel == 0 && !cop.IsInVehicle() && TaskType == 0 && PlayerVisible && Config.Bools.CopsDoTasks)
                {
                    cop.Task.TurnTo(Game.Player.Character, 100);
                }
            }
            if (LastSeen.DistanceTo2D(cop.Position) <= 5F)
            {
                //LastSeen = new Vector3();
            }
            if (LastSeen.DistanceTo2D(cop.Position) <= 5F)
            {
                //LastSeen = new Vector3();
            }
            if (Recog[0] > 60 || Recog[1] > 60)
            {
                if (!Config.Bools.DisableAllCopBlips)
                {
                    blip.Color = BlipColor.Orange;
                    blip.Priority = 13;
                }
                
                if (TaskType <= 1 && Game.Player.WantedLevel == 0 && Config.Bools.CopsDoTasks)
                {
                    if (!cop.IsInVehicle())
                        cop.Task.GoStraightTo(LastSeen, -1, PedMoveBlendRatio.Walk, 0, 1f);
                    else
                        cop.Task.DriveTo(cop.CurrentVehicle, LastSeen, 40, VehicleDrivingFlags.SteerAroundPeds, 2f);
                    if (LastSeen.DistanceTo(cop.Position) <= 3) 
                        ReturnTaskType = 0;
                    else 
                        ReturnTaskType = 2;
                    cop.KeepTaskWhenMarkedAsNoLongerNeeded = true;
                }
            }
            if (Recog[0] > 80 || Recog[1] > 80)
            {
                if (!Config.Bools.DisableAllCopBlips)
                {
                    blip.Color = BlipColor.Red;
                    blip.Priority = 14;
                }
                
                if (TaskType <= 2 && Game.Player.WantedLevel == 0 && Config.Bools.CopsDoTasks)
                {
                    if (!cop.IsInVehicle()) 
                        cop.Task.GoStraightTo(LastSeen, -1, PedMoveBlendRatio.Run, 0, 1f);
                    else
                        cop.Task.DriveTo(cop.CurrentVehicle, LastSeen, 70, VehicleDrivingFlags.DrivingModeAvoidVehiclesReckless, 2f);

                    if 
                        (LastSeen.DistanceTo2D(cop.Position) <= 1) ReturnTaskType = 0;
                    else
                        ReturnTaskType = 3;
                    cop.KeepTaskWhenMarkedAsNoLongerNeeded = true;
                }
                
            }
            /*if (Recog[0] > 60 || Recog[1] > 60 && Game.Player.WantedLevel==0 && Config.Bools.CopsDoTasks) 
            {fd
                if (!cop.IsInVehicle())
                {
                    if (Recog[0] < 80)
                    {
                        cop.Task.GoStraightTo(LastSeen, -1, PedMoveBlendRatio.Walk,0, 1f);
                    }
                    else
                    {
                        cop.Task.GoStraightTo(LastSeen,-1,PedMoveBlendRatio.Run,0,1f);
                    }
                }
                else
                {
                    if (Recog[1] < 80)
                        cop.Task.DriveTo(cop.CurrentVehicle, LastSeen, 20, VehicleDrivingFlags.DrivingModeAvoidVehiclesReckless, 2f);
                    else
                        cop.Task.DriveTo(cop.CurrentVehicle, LastSeen, 40, VehicleDrivingFlags.DrivingModeAvoidVehiclesReckless, 2f);
                }
            }*/
            if (Recog[0] >= 100 || Recog[1] >= 100)
            {
                ReturnTaskType = 4;
                
                if (!Config.Bools.DisableAllCopBlips)
                {
                    blip.Color = BlipColor.RedDark;
                    blip.Priority = 15;
                    
                    if (Config.Bools.ExtraBlipIndicators)
                    {
                        if (Recog[0] >= 100) blip.ShowsCrewIndicator = true;
                        if (Recog[1] >= 100) blip.ShowsFriendIndicator = true;
                    }
                }
            }
            return ReturnTaskType;
        }

        public static bool IsPlayerVisible()
        {
            //Blip playerBlip = Function.Call<Blip>(Hash.GET_MAIN_PLAYER_BLIP_ID);
            return (!Function.Call<bool>(Hash.ARE_PLAYER_STARS_GREYED_OUT, Game.Player));
            //return !(playerBlip.Color.ToString() == "GreyDark");
        }


        public static void Save()
        {
            string SaveFile = ".\\scripts\\Okoniewitz\\WarrantsV\\Save.ini";
            string saveString = "";
            foreach ((int[], int) clothes in EachTick.RecognizedClothes)
            {
                foreach (int cloth in clothes.Item1)
                {
                    saveString += cloth + "|";
                }
                saveString += clothes.Item2 + "|" + EachTick.StarsEvaded[PlayerID()] + "|" + Environment.NewLine;
            }
            saveString += Main.Plates[0] + "|" + Main.Plates[1] + "|" + Main.Plates[2] + Environment.NewLine;
            foreach (Tuple<string[], int[]> Car in EachTick.VehList)
            {
                saveString += Car.Item1[0] + "|";
                saveString += Car.Item1[1] + "|";
                saveString += Car.Item1[2] + "|";
                saveString += Car.Item2[0] + "|";
                saveString += Car.Item2[1] + "|";
                saveString += Environment.NewLine;
            }
            File.WriteAllText(SaveFile, saveString);
            if (Config.Bools.CrashAndEnterMessage) GTA.UI.Notification.PostTicker(Config.Strings.WarrantsVSaved,false);//"WarrantsV Saved"
        }
        public static void Load()
        {
            if (!File.Exists(".\\scripts\\Okoniewitz\\WarrantsV\\Wanted.png"))
            {
                File.WriteAllBytes(".\\scripts\\Okoniewitz\\WarrantsV\\Wanted.png", ImageToByte(Properties.Resources.Wanted));
                File.WriteAllBytes(".\\scripts\\Okoniewitz\\WarrantsV\\Wanted0.png", ImageToByte(Properties.Resources.Wanted0));
                File.WriteAllBytes(".\\scripts\\Okoniewitz\\WarrantsV\\Wanted1.png", ImageToByte(Properties.Resources.Wanted1));
                File.WriteAllBytes(".\\scripts\\Okoniewitz\\WarrantsV\\Wanted2.png", ImageToByte(Properties.Resources.Wanted2));
                File.WriteAllBytes(".\\scripts\\Okoniewitz\\WarrantsV\\NearWanted.png", ImageToByte(Properties.Resources.NearWanted));
                File.WriteAllBytes(".\\scripts\\Okoniewitz\\WarrantsV\\Masked.png", ImageToByte(Properties.Resources.Masked));
                if (Main.debug) File.WriteAllBytes(".\\scripts\\Okoniewitz\\WarrantsV\\WantedTemplate.xcf", Properties.Resources.WantedTemplate);
            }
            string SaveFile = ".\\scripts\\Okoniewitz\\WarrantsV\\Save.ini";
            if (!File.Exists(SaveFile) || File.ReadAllLines(SaveFile).Length == 0) Save();
            string[] SaveStrings = File.ReadAllLines(SaveFile);
            for (int ii = 0; ii < 3; ii++)
            {
                string curs = SaveStrings[ii];
                int[] clothes = new int[30];
                for (int i = 0; i < 30; i++)
                {
                    clothes[i] = int.Parse(curs.Substring(0, curs.IndexOf("|", 0)));
                    curs = curs.Substring(curs.IndexOf("|", 0) + 1);
                }
                wanted[ii] = int.Parse(curs.Substring(0, curs.IndexOf("|", 0)));
                EachTick.RecognizedClothes[ii] = (clothes, int.Parse(curs.Substring(0, curs.IndexOf("|", 0))));
                curs = curs.Substring(curs.IndexOf("|", 0) + 1);
                EachTick.StarsEvaded[ii] = int.Parse(curs.Substring(0, curs.IndexOf("|")));
            }

            string PlatesString = SaveStrings[3];
            Main.Plates[0] = int.Parse(PlatesString.Substring(0, PlatesString.IndexOf("|")));
            PlatesString = PlatesString.Substring(PlatesString.IndexOf("|") + 1);
            Main.Plates[1] = int.Parse(PlatesString.Substring(0, PlatesString.IndexOf("|")));
            PlatesString = PlatesString.Substring(PlatesString.IndexOf("|") + 1);
            Main.Plates[2] = int.Parse(PlatesString);

            EachTick.VehList.Clear();
            for (int ii = 4; ii < SaveStrings.Length; ii++)
            {
                string curs = SaveStrings[ii];
                string[] VehID = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    VehID[i] = curs.Substring(0, curs.IndexOf("|", 0));
                    curs = curs.Substring(curs.IndexOf("|", 0) + 1);
                }
                int wanted = int.Parse(curs.Substring(0, curs.IndexOf("|")));
                curs = curs.Substring(curs.IndexOf("|", 0) + 1);
                EachTick.VehList.Add(new Tuple<string[], int[]>(VehID, new int[2] { wanted, int.Parse(curs.Substring(0, curs.IndexOf("|", 0))) }));

            }
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static void SaveTick(object sender, EventArgs e)
        {
            if ((GetStat("MANUAL_SAVED", true) > SavesMade[PlayerID()] && SavesMade[PlayerID()] != 0) || (Function.Call<bool>(Hash.IS_AUTO_SAVE_IN_PROGRESS) && LastSaved + 2000 <= Game.GameTime))
            {
                LastSaved = Game.GameTime;
                Save();
            }
            SavesMade[PlayerID()] = GetStat("MANUAL_SAVED", true);
        }

        public static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static float RecognitionAdd(Ped byWhom)
        {
            float distance = byWhom.Position.DistanceTo(Game.Player.Character.Position);
            float runnig = 0, rainy = 0, facing = 0, incar = 0, knownClothes = 0, night = 0, armor = 0;
            if (Game.Player.Character.IsSprinting)
            {
                runnig = Config.Numeric.RecognitionAddSprint;
            }
            else
            {
                if (Game.Player.Character.IsRunning)
                {
                    runnig = Config.Numeric.RecognitionAddRun;
                }
            }
            if (EachTick.WarrantLevel[PlayerID()] > 0 && !Masked().Item1)
            {
                knownClothes = Helpers.CompareArrays(EachTick.RecognizedClothes[Helpers.PlayerID()].Item1, Helpers.GetPlayerClothes(), 2, true).Item2 * Config.Numeric.RecognitionAddPerKnownClothes;
            }
            if (World.Weather == Weather.Blizzard || World.Weather == Weather.Christmas || World.Weather == Weather.Foggy || World.Weather == Weather.Raining || World.Weather == Weather.Snowing || World.Weather == Weather.ThunderStorm || World.Weather == Weather.Halloween)
            {
                rainy = Config.Numeric.RecognitionAddBadWeather;
            }
            if (GTA.Chrono.GameClock.Hour >= 22 || GTA.Chrono.GameClock.Hour < 5) night = Config.Numeric.RecognitionAddNight;
            if (Game.Player.Character.IsInVehicle())
            {
                if (!Function.Call<bool>(Hash.IS_PED_FACING_PED, Game.Player.Character, byWhom, 110f) && Game.Player.Character.CurrentVehicle.ClassType != VehicleClass.Boats && Game.Player.Character.CurrentVehicle.ClassType != VehicleClass.Cycles && Game.Player.Character.CurrentVehicle.ClassType != VehicleClass.Motorcycles && Game.Player.Character.CurrentVehicle.ClassType != VehicleClass.OffRoad) return 0;
                if (EachTick.WarrantLevel[1] > 0)
                {
                    incar = Config.Numeric.RecognitionAddInWantedCar;
                }
                else
                {
                    incar = Config.Numeric.RecognitionAddInCar;
                }
                if (Game.IsKeyPressed(System.Windows.Forms.Keys.X))
                {
                    incar = Config.Numeric.RecognitionAddInCarSneaking;
                }
                //if(Game.Player.Character.IsDucking)
                //{
                //    incar = Config.Numeric.RecognitionAddInCarSneaking;
                //}
            }


            if (Config.Bools.NotUselessArmorCompability)
            {
                if (Game.Player.WantedLevel == 0 && EachTick.WarrantLevel[PlayerID()] <= 1)
                {
                    switch (PlayerID())
                    {
                        case 0:
                            if (Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, Config.Numeric.ArmorMichaelComponentID) == Config.Numeric.ArmorMichaelDrawableID)
                            {
                                armor = Config.Numeric.RecognitionAddArmor;
                            }
                            break;
                        case 1:
                            if (Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, Config.Numeric.ArmorFranklinComponentID) == Config.Numeric.ArmorFranklinDrawableID)
                            {
                                armor = Config.Numeric.RecognitionAddArmor;
                            }
                            break;
                        case 2:
                            if (Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, Config.Numeric.ArmorTrevorComponentID) == Config.Numeric.ArmorTrevorDrawableID)
                            {
                                armor = Config.Numeric.RecognitionAddArmor;
                            }
                            break;
                    }
                }
            }

            if (Function.Call<bool>(Hash.IS_PED_FACING_PED, Game.Player.Character, byWhom, 90f) && distance <= Config.Numeric.RecognitionAddVisibleFaceMaxDist)
            {
                facing = Config.Numeric.RecognitionAddVisibleFace;
            }
            else facing = Config.Numeric.RecognitionAddNotVisibleFace;
            float nb = ((runnig + rainy + knownClothes + night + armor + facing + incar + (EachTick.WarrantLevel[PlayerID()] * Config.Numeric.RecognitionAddWarrantMultip) + Config.Numeric.RecognitionAddBase) * Config.Numeric.RecognitionAddMultip / (distance * Config.Numeric.RecognitionAddDistMultip)) / Config.Numeric.RecognitionAddDivider;
            if (nb > 0) return nb; else return 0;
        }
        public static float RecognitionAddCar(Ped byWhom)
        {
            if (Game.Player.Character.IsInVehicle())
            {
                float distance = byWhom.Position.DistanceTo(Game.Player.Character.Position);
                float rainy = 0, facing = 0, night = 0;
                if (World.Weather == Weather.Blizzard || World.Weather == Weather.Christmas || World.Weather == Weather.Foggy || World.Weather == Weather.Raining || World.Weather == Weather.Snowing || World.Weather == Weather.ThunderStorm || World.Weather == Weather.Halloween)
                {
                    rainy = Config.Numeric.VehRecognitionAddBadWeather;
                }
                if (GTA.Chrono.GameClock.Hour >= 22 || GTA.Chrono.GameClock.Hour < 5) night = Config.Numeric.VehRecognitionAddNight;
                if (distance <= Config.Numeric.VehRecognitionAddVisiblePlateMaxDist)
                {
                    if (Game.Player.Character.CurrentVehicle.Mods.LicensePlateType == LicensePlateType.FrontPlate && Function.Call<bool>(Hash.IS_PED_FACING_PED, Game.Player.Character, byWhom, 35f))
                    {
                        facing = Config.Numeric.VehRecognitionAddVisiblePlate;
                        if (Main.debug) new GTA.UI.TextElement("Facing", new PointF(0, 0), 0.8f).Draw();
                    }

                    if (Game.Player.Character.CurrentVehicle.Mods.LicensePlateType == LicensePlateType.RearPlate && !Function.Call<bool>(Hash.IS_PED_FACING_PED, Game.Player.Character, byWhom, 145f))
                    {
                        facing = Config.Numeric.VehRecognitionAddVisiblePlate;
                        if (Main.debug) new GTA.UI.TextElement("Facing", new PointF(0, 0), 0.8f).Draw();
                    }
                    if (Game.Player.Character.CurrentVehicle.Mods.LicensePlateType == LicensePlateType.FrontAndRearPlates && (!Function.Call<bool>(Hash.IS_PED_FACING_PED, Game.Player.Character, byWhom, 145f) || Function.Call<bool>(Hash.IS_PED_FACING_PED, Game.Player.Character, byWhom, 35f)))
                    {
                        facing = Config.Numeric.VehRecognitionAddVisiblePlate;
                        if (Main.debug) new GTA.UI.TextElement("Facing", new PointF(0, 0), 0.8f).Draw();
                    }
                }


                float nb = ((-(Math.Abs(Game.Player.Character.CurrentVehicle.Speed) / Config.Numeric.VehRecognitionAddSpeedDivider) + rainy + night + facing + (EachTick.WarrantLevelVeh * Config.Numeric.VehRecognitionAddWarrantMultip) + Config.Numeric.VehRecognitionAddBase) * Config.Numeric.VehRecognitionAddMultip / (distance * Config.Numeric.VehRecognitionAddDistMultip)) / Config.Numeric.VehRecognitionAddDivider;
                if (nb > 0) return nb; else return 0;
            }
            else
            {
                return 0;
            }
        }
        public static int[] GetPlayerClothes()
        {
            int[] ar = new int[30];
            for (int[] i = new int[] { 0, 0 }; i[1] < 12; i[0] += 2, i[1]++)
            {
                ar[i[0]] = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, i[1]);
                ar[i[0] + 1] = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character, i[1]);
            }
            for (int[] i = new int[] { 0, 0 }; i[1] < 3; i[0] += 2, i[1]++)
            {
                ar[i[0] + 24] = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character, i[1]);
                ar[i[0] + 1 + 24] = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character, i[1]);
            }
            return ar;
        }

        public static (bool, int) CompareArrays(int[] Array1, int[] Array2, int MaxDiff, bool Groupped = false)
        {
            if (Array1.Length != Array2.Length) return (false, MaxDiff + 1);
            int Diff = 0;
            if (!Groupped)
            {
                for (int i = 0; i < Array1.Length; i++)
                    if (Array1[i] != Array2[i])
                        Diff++;
            }


            if (Groupped)
            {
                for (int i = 0; i < Array1.Length; i = i + 2)
                {
                    if (!(Array1[i] == Array2[i] && Array1[i + 1] == Array2[i + 1]))
                        Diff++;
                }
            }
            if (Diff >= MaxDiff) return (false, Diff); else return (true, Diff);
        }

        public static bool ObjectBroken(Prop obj)
        {
            return Function.Call<bool>(Hash.HAS_OBJECT_BEEN_BROKEN, obj);
        }

        public static int PlayerID()
        {
            if (Game.Player.Character.Model.Hash == GetHashKey("PLAYER_TWO")) return 2;
            if (Game.Player.Character.Model.Hash == GetHashKey("PLAYER_ONE")) return 1;
            if (Game.Player.Character.Model.Hash == GetHashKey("PLAYER_ZERO")) return 0;
            return 3;
        }
        private static int GetHashKey(string value)
        {
            return Function.Call<int>(Hash.GET_HASH_KEY, value);
        }
        public static void ClearList(bool ResetRecognition, (bool, int) RemoveWarrants, bool RemoveCopsList)
        {
            if (RemoveWarrants.Item1)
            {
                EachTick.WarrantLevel[RemoveWarrants.Item2] = 0;
                EachTick.RecognizedClothes[RemoveWarrants.Item2].Item2 = 0;
            }
            if (ResetRecognition)
            {
                EachTick.Recognized[0] = false;
                EachTick.Recognized[1] = false;
            }
            if (RemoveCopsList)
            {
                foreach (Tuple<Ped, Blip, float[], int[], Vector3> CopsList in Helpers.CopsList)
                {
                    if (!Config.Bools.DisableAllCopBlips)
                    {
                        CopsList.Item2.Delete();
                    }
                }
                Helpers.CopsList = new List<Tuple<Ped, Blip, float[], int[], Vector3>>();
            }
        }

        public static bool Visible(Ped Who, Ped byWhom, float FieldOfView, int MaxDist, float InVehFov)
        {
            if (!Function.Call<bool>(Hash.ARE_PLAYER_STARS_GREYED_OUT, Game.Player))
            {
                if (!Who.IsInVehicle())
                {
                    if (Who.Position.DistanceTo(byWhom.Position) > MaxDist || !Function.Call<bool>(Hash.IS_PED_FACING_PED, byWhom, Who, FieldOfView)) return false;
                    Vector3 pos = World.Raycast(byWhom.Bones[Bone.SkelHead].Position, Who.Bones[Bone.SkelHead].Position, IntersectFlags.Everything).HitPosition;
                    bool CanSee = (pos.DistanceTo(Who.Position) <= 0.7f);
                    if (Main.debug)
                    {

                        if (CanSee)
                        {
                            Function.Call(Hash.DRAW_LINE, byWhom.Bones[Bone.SkelHead].Position.X, byWhom.Bones[Bone.SkelHead].Position.Y, byWhom.Bones[Bone.SkelHead].Position.Z, Who.Bones[Bone.SkelHead].Position.X, Who.Bones[Bone.SkelHead].Position.Y, Who.Bones[Bone.SkelHead].Position.Z, 255, 255, 255, 255);
                        }
                        else
                        {
                            Function.Call(Hash.DRAW_LINE, byWhom.Bones[Bone.SkelHead].Position.X, byWhom.Bones[Bone.SkelHead].Position.Y, byWhom.Bones[Bone.SkelHead].Position.Z, pos.X, pos.Y, pos.Z, 255, 0, 0, 255);
                        }
                    }
                    return (CanSee);
                }
                else
                {
                    return (Who.Position.DistanceTo(byWhom.Position) < MaxDist && Function.Call<bool>(Hash.HAS_ENTITY_CLEAR_LOS_TO_ENTITY, byWhom, Who, 17) && (Function.Call<bool>(Hash.IS_PED_FACING_PED, byWhom, Who, InVehFov) || (Function.Call<bool>(Hash.IS_PED_FACING_PED, byWhom, Who, 360) && Who.Position.DistanceTo(byWhom.Position) < 3)));
                }
            }
            else return false;
        }

        public static int GetStat(string stat, bool MultiChar)
        {
            string rStat = stat;
            if (MultiChar)
            {
                if (PlayerID() == 0) rStat = "SP0_" + stat;
                if (PlayerID() == 1) rStat = "SP1_" + stat;
                if (PlayerID() == 2) rStat = "SP2_" + stat;
            }
            OutputArgument outval = new OutputArgument();
            Function.Call(Hash.STAT_GET_INT, GetHashKey(rStat), outval, -1);
            return outval.GetResult<int>();
        }
    }
}
