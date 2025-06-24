using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using System;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace WarrantV
{
    public class Main : Script
    {
        public static bool debug = Config.Bools.debug;
        private static int[] TimesBusted = new int[3];
        private static int TickCounter = Game.GameTime;
        private static bool WasInCar, WasWanted;
        public static int[] Plates = new int[3];
        public static bool Even;
        public static int LastVehType = 0;
        public static bool OverrideMasked = false;
        public static int keyDownDelay;
        public static int DeadDelay;
        public Main()
        {
            if (!Directory.Exists(".\\scripts\\Okoniewitz\\WarrantsV\\")) Directory.CreateDirectory(".\\scripts\\Okoniewitz\\WarrantsV\\");
            TimesBusted[0] = -1;
            TimesBusted[1] = -1;
            TimesBusted[2] = -1;
            Config.Read();
            Tick += MainTick;
            Tick += EachTick.Graphics.WarrantPosters;
            Tick += EachTick.ChoiceMenus.Plates;
            Tick += Helpers.SaveTick;
            Tick += EachTick.ChoiceMenus.Phones;
            Tick += EachTick.MaskNerf;
            Tick += EachTick.IVChases;
            Tick += OnKeyEvents;
            Aborted += AbortedScript;
            Helpers.Load();
            if (Config.Bools.CrashAndEnterMessage)
            {
                string fileLoc = Environment.CurrentDirectory + "\\scripts\\WarrantV.net.dll";
                DateTime BuiltTime = File.GetLastWriteTime(fileLoc);
                Notification.PostTicker($"Loaded WarrantsV\nBuilt: {BuiltTime.ToShortTimeString()} - {BuiltTime.ToShortDateString()}", false);
            }
        }
        private static void OnKeyEvents(object sender, EventArgs e)
        {
            if (EachTick.ChoiceMenus.bribing && EachTick.BribingDelay<Game.GameTime)
            {
                if (Game.IsKeyPressed(Config.ETC.OpenMenuKey) || Game.IsControlJustPressed(GTA.Control.SelectWeapon))
                {
                    EachTick.ChoiceMenus.bribing = false;
                    Game.Player.SetControlState(true, SetPlayerControlFlags.LeaveCameraControlOn);
                    EachTick.ChoiceMenus.HelpMessagePhoneDelay = -(Game.GameTime + 200);

                    return;
                }
                if ((Game.IsKeyPressed(Config.ETC.MichaelMenuKey) || Game.IsControlJustPressed(Control.PhoneLeft)) && EachTick.RecognizedClothes[0].Item2 > 0)
                {
                    if (Game.Player.Money >= 300 * Math.Pow(EachTick.RecognizedClothes[0].Item2, 2) + 100)
                    {
                        EachTick.ChoiceMenus.bribing = false;
                        Game.Player.SetControlState(true, SetPlayerControlFlags.LeaveCameraControlOn);
                        Game.Player.Money -= (int)(300 * Math.Pow(EachTick.RecognizedClothes[0].Item2, 2) + 100);
                        Helpers.ClearList(true, (true, 0), true);
                    }
                    else
                    {
                        EachTick.ChoiceMenus.bribing = false;
                        Game.Player.SetControlState(true, SetPlayerControlFlags.LeaveCameraControlOn);
                        EachTick.ChoiceMenus.HelpMessagePhoneDelay = Game.GameTime + 2500;
                    }
                }

                if ((Game.IsKeyPressed(Config.ETC.FranklinMenuKey) || Game.IsControlJustPressed(Control.PhoneUp)) && EachTick.RecognizedClothes[1].Item2 > 0)
                {
                    if (Game.Player.Money >= 300 * Math.Pow(EachTick.RecognizedClothes[1].Item2, 2) + 100)
                    {
                        EachTick.ChoiceMenus.bribing = false;
                        Game.Player.SetControlState(true, SetPlayerControlFlags.LeaveCameraControlOn);
                        Game.Player.Money -= (int)(300 * Math.Pow(EachTick.RecognizedClothes[1].Item2, 2) + 100);
                        Helpers.ClearList(true, (true, 1), true);
                    }
                    else
                    {
                        EachTick.ChoiceMenus.bribing = false;
                        Game.Player.SetControlState(true, SetPlayerControlFlags.LeaveCameraControlOn);
                        EachTick.ChoiceMenus.HelpMessagePhoneDelay = Game.GameTime + 2500;
                    }
                }
                if ((Game.IsKeyPressed(Config.ETC.TrevorMenuKey) || Game.IsControlJustPressed(Control.PhoneRight)) && EachTick.RecognizedClothes[2].Item2 > 0)
                {
                    if (Game.Player.Money >= 300 * Math.Pow(EachTick.RecognizedClothes[2].Item2, 2) + 100)
                    {
                        EachTick.ChoiceMenus.bribing = false;
                        Game.Player.SetControlState(true, SetPlayerControlFlags.LeaveCameraControlOn);
                        Game.Player.Money -= (int)(300 * Math.Pow(EachTick.RecognizedClothes[2].Item2, 2) + 100);
                        Helpers.ClearList(true, (true, 2), true);
                    }
                    else
                    {
                        EachTick.ChoiceMenus.bribing = false;
                        Game.Player.SetControlState(true, SetPlayerControlFlags.LeaveCameraControlOn);
                        EachTick.ChoiceMenus.HelpMessagePhoneDelay = Game.GameTime + 2500;
                    }
                }
            }
            if (keyDownDelay < Game.GameTime)
            {
                if (EachTick.ChoiceMenus.buying && Config.Bools.PlateChanging)
                {
                    if (Game.IsKeyPressed(Config.ETC.PlateBuyKey) || Game.IsControlPressed(Control.SelectWeapon))
                    {
                        keyDownDelay = Game.GameTime + 500;
                        if (Plates[Helpers.PlayerID()] < Config.Numeric.PlateMaxNum)
                        {
                            if (Game.Player.Money >= Config.Numeric.PlatePrice)
                            {
                                Game.Player.Money -= Config.Numeric.PlatePrice;
                                Plates[Helpers.PlayerID()]++;
                            }
                            else EachTick.ChoiceMenus.HelpMessageSellerDelay = -(Game.GameTime + 2500);
                        }
                        else EachTick.ChoiceMenus.HelpMessageSellerDelay = Game.GameTime + 2500;
                    }
                }
                if (EachTick.ChoiceMenus.PlateChangeAble && Config.Bools.PlateChanging)
                {
                    if (Game.IsKeyPressed(Config.ETC.PlateChange) || Game.IsControlPressed(Control.SelectWeapon))
                    {
                        keyDownDelay = Game.GameTime + 500;
                        Plates[Helpers.PlayerID()]--;
                        EachTick.ChoiceMenus.ClosestVeh.Mods.LicensePlateStyle = (LicensePlateStyle)new Random().Next(0, 5);
                        EachTick.ChoiceMenus.ClosestVeh.Mods.LicensePlate = $"{Helpers.random.Next(10, 99)}{Helpers.RandomString(3)}{Helpers.random.Next(100, 999)}";
                    }
                }
            }
        }


        private static void MainTick(object sender, EventArgs e)
        {
            if (Game.GameTime >= TickCounter + 50)
            {
                if (debug && !Game.Player.Character.IsInVehicle() && Game.IsKeyPressed(System.Windows.Forms.Keys.E)) GTA.UI.Screen.ShowSubtitle(World.GetClosestProp(Game.Player.Character.Position, 5f).Model.Hash.ToString());
                if (debug && Game.Player.Character.IsInVehicle()) GTA.UI.Screen.ShowSubtitle(Game.Player.Character.CurrentVehicle.DisplayName);
                Even = !Even;
                Game.Player.Character.CanWearHelmet = !Helpers.Masked().Item2;
                if (Config.Strings.PhoneUse.Contains("ERROR")) Config.Read();
                foreach (Tuple<Ped, Blip, float[], int[], Vector3> CopInList in Helpers.CopsList)
                {
                    if (CopInList.Item1.IsDead || !CopInList.Item1.Exists()) CopInList.Item2.Delete();
                }
                if (Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS))
                {
                    Helpers.ClearList(true, (false, 0), true);
                    LastVehType = 0;
                }
                EachTick.AnyCopRecog = false;
                TickCounter = Game.GameTime;
                string[] ID = new string[3];
                if (Game.Player.WantedLevel > 0) WasWanted = true;
                if (Game.Player.WantedLevel == 0 && WasWanted) { WasWanted = false; Helpers.ClearList(true, (false, 0), true); }
                if (Game.Player.Character.IsDead || ((Helpers.GetStat("BUSTED", true) > TimesBusted[Helpers.PlayerID()]) && TimesBusted[Helpers.PlayerID()] != -1))
                {
                    DeadDelay = Game.GameTime + 30000;
                    Helpers.ClearList(true, (true, Helpers.PlayerID()), true);
                }
                Ped[] peds = World.GetAllPeds(Config.CopModels);
                Vehicle[] vehs = World.GetAllVehicles();
                if (Helpers.CompareArrays(EachTick.RecognizedClothes[Helpers.PlayerID()].Item1, Helpers.GetPlayerClothes(), Config.Numeric.ClothesDifferencesToClearWarrant, true).Item1 && EachTick.WarrantLevel[Helpers.PlayerID()] != EachTick.RecognizedClothes[Helpers.PlayerID()].Item2)
                {
                    EachTick.WarrantLevel[Helpers.PlayerID()] = EachTick.RecognizedClothes[Helpers.PlayerID()].Item2;
                    if (EachTick.StarsEvaded[Helpers.PlayerID()] == Helpers.GetStat("STARS_EVADED", true)) { EachTick.Recognized[0] = true; }
                }
                if (!Helpers.CompareArrays(EachTick.RecognizedClothes[Helpers.PlayerID()].Item1, Helpers.GetPlayerClothes(), Config.Numeric.ClothesDifferencesToClearWarrant, true).Item1)
                {
                    EachTick.WarrantLevel[Helpers.PlayerID()] = 0;
                    EachTick.Recognized[0] = false;
                }
                if (Config.Bools.FixWLicensePlates)
                {
                    foreach (Vehicle veh in vehs)
                    {
                        if (veh.Mods.LicensePlate.Contains("W")) veh.Mods.LicensePlate = veh.Mods.LicensePlate.Replace("W", "V");
                    }
                }
                Ped[] AllPeds = World.GetAllPeds();
                if (Config.Bools.CopBlipCone)
                {
                    foreach (Ped ped in AllPeds)
                    {
                        if (ped.AttachedBlip != null && ped.AttachedBlip.Exists())
                        {
                            bool EnableCone = ((Config.Bools.CopBlipCone && !Config.Bools.CopBlipOnlyWhenInvisible) || (Config.Bools.CopBlipCone && Config.Bools.CopBlipOnlyWhenInvisible && !Helpers.IsPlayerVisible()));
                            Function.Call(Hash.SHOW_HEADING_INDICATOR_ON_BLIP, ped.AttachedBlip, EnableCone);
                        }
                    }
                }
                foreach (Ped ped in peds)
                {
                    EachTick.Ped(ped);
                }

                int VehicleIndex = -1;
                int CacheWanted = 0;
                if (!Game.Player.Character.IsInVehicle())
                {
                    EachTick.Recognized[1] = false;
                    EachTick.WarrantLevelVeh = 0;
                    OverrideMasked = false;
                    WasInCar = false;
                    Vehicle lastCar = Game.Player.Character.LastVehicle;
                    if (Config.Bools.WantedNearCar && lastCar != null && lastCar.Exists())
                    {
                        ID = new string[]
                        {
                            lastCar.Model.ToString(),
                            lastCar.Mods.LicensePlate,
                            lastCar.Mods.PrimaryColor.ToString()
                        };
                        int vehID = -1;
                        if (EachTick.VehList.Any(c => c.Item1.SequenceEqual(ID)))
                        {
                            vehID = EachTick.VehList.FindIndex(c => c.Item1.SequenceEqual(ID));
                            if (lastCar.Position.DistanceTo(Game.Player.Character.Position) < Config.Numeric.WantedNearCarMaxDist && EachTick.VehList[vehID].Item2[0] > 0 && Game.Player.WantedLevel == 0 && EachTick.WarrantLevel[Helpers.PlayerID()] == 0 && !Game.Player.Character.IsEnteringVehicle)
                            {
                                OverrideMasked = true;
                            }
                        }
                    }
                }
                else
                {
                    OverrideMasked = false;
                    LastVehType = (int)Game.Player.Character.CurrentVehicle.ClassType;
                    ID = new string[]
                        {
                    Game.Player.Character.CurrentVehicle.Model.ToString(),
                    Game.Player.Character.CurrentVehicle.Mods.LicensePlate,
                    Game.Player.Character.CurrentVehicle.Mods.PrimaryColor.ToString()
                        };
                    if (Config.Bools.WantedPoliceVehs || Config.Bools.WantedRandomVehs)
                    {
                        if (!WasInCar)
                        {
                            WasInCar = true;
                            if (!EachTick.VehList.Any(c => c.Item1.SequenceEqual(ID)))
                            {
                                if (Config.Bools.WantedPoliceVehs && Config.PoliceVehs.Contains(Game.Player.Character.CurrentVehicle.Model))
                                {
                                    EachTick.VehList.Add(new Tuple<string[], int[]>(ID, new int[] { 2, -1 }));
                                }
                                if (Config.Bools.WantedRandomVehs && !Config.PoliceVehs.Contains(Game.Player.Character.CurrentVehicle.Model) && World.GetNearbyVehicles(Game.Player.Character.CurrentVehicle.Position, 15f, Config.PoliceVehs).Length == 0 && !Game.Player.Character.CurrentVehicle.PreviouslyOwnedByPlayer)
                                {
                                    int[] rnd = new int[] { Helpers.random.Next(0, 10), Helpers.random.Next(0, 3) };
                                    if (rnd[0] <= Config.Numeric.RandomWantedCarChance) EachTick.VehList.Add(new Tuple<string[], int[]>(ID, new int[] { rnd[1], -1 }));
                                }
                            }
                        }
                    }
                    if (EachTick.VehList.Any(c => c.Item1.SequenceEqual(ID)))
                    {
                        VehicleIndex = EachTick.VehList.FindIndex(c => c.Item1.SequenceEqual(ID));
                        EachTick.WarrantLevelVeh = EachTick.VehList[VehicleIndex].Item2[0];
                        CacheWanted = EachTick.WarrantLevelVeh;
                        if (EachTick.VehList[VehicleIndex].Item2[1] == Helpers.GetStat("STARS_EVADED", true) && !EachTick.Recognized[1]) EachTick.Recognized[1] = true;
                    }
                    else
                    {
                        EachTick.WarrantLevelVeh = 0;
                        EachTick.Recognized[1] = false;
                    }
                }

                if (EachTick.Recognized[1])
                {
                    if (EachTick.VehList[VehicleIndex].Item2[0] > Game.Player.WantedLevel)
                    {
                        Game.Player.WantedLevel = EachTick.VehList[VehicleIndex].Item2[0];
                    }
                    if (EachTick.VehList[VehicleIndex].Item2[0] < Game.Player.WantedLevel)
                    {
                        CacheWanted = Game.Player.WantedLevel;
                    }
                    EachTick.VehList[VehicleIndex].Item2[1] = Helpers.GetStat("STARS_EVADED", true);
                }
                if (EachTick.Recognized[0])
                {
                    if (EachTick.WarrantLevel[Helpers.PlayerID()] > Game.Player.WantedLevel)
                    {
                        Game.Player.WantedLevel = EachTick.WarrantLevel[Helpers.PlayerID()];
                        if (EachTick.Recognized[1] && EachTick.VehList[VehicleIndex].Item2[0] < EachTick.WarrantLevel[Helpers.PlayerID()])
                        {
                            CacheWanted = EachTick.WarrantLevel[Helpers.PlayerID()];
                        }
                    }
                    if (EachTick.WarrantLevel[Helpers.PlayerID()] < Game.Player.WantedLevel)
                    {
                        EachTick.WarrantLevel[Helpers.PlayerID()] = Game.Player.WantedLevel;
                        EachTick.RecognizedClothes[Helpers.PlayerID()].Item2 = Game.Player.WantedLevel;
                    }
                }

                if (Game.Player.WantedLevel == 0) { EachTick.Recognized[0] = false; EachTick.Recognized[1] = false; }
                if (VehicleIndex != -1)
                {
                    EachTick.VehList[VehicleIndex] = new Tuple<string[], int[]>(ID, new int[] { CacheWanted, EachTick.VehList[VehicleIndex].Item2[1] });
                }
                TimesBusted[Helpers.PlayerID()] = Helpers.GetStat("BUSTED", true);
                if (Helpers.CopsList.Count() > Config.Numeric.CopsToClearList && !EachTick.AnyCopRecog) if (!EachTick.AnyCopRecog) Helpers.ClearList(false, (false, 0), true);
            }
            if (debug)
            {
                if (Game.Player.Character.IsInVehicle())
                {
                    new TextElement($" Petrol: {Game.Player.Character.CurrentVehicle.FuelLevel}/{Game.Player.Character.CurrentVehicle.PetrolTankVolume}", new PointF(50, 220), 0.5f).Draw();

                }
                new TextElement(Helpers.JoinArrays(Helpers.GetPlayerClothes()) + " Masked:" + Helpers.Masked().ToString(), new PointF(200, 150), 0.5f).Draw();
                new TextElement($"Polices: {Helpers.CopsList.Count()} Recognized Cars: {EachTick.VehList.Count()} Clothes Diffs {Helpers.CompareArrays(EachTick.RecognizedClothes[Helpers.PlayerID()].Item1, Helpers.GetPlayerClothes(), 2, true).Item2}", new PointF(50, 120), 0.5f).Draw();
                new TextElement($"{EachTick.WarrantLevel[Helpers.PlayerID()]}", new PointF(300, 580), 0.5f).Draw();
                new TextElement($"{EachTick.WarrantLevelVeh}", new PointF(300, 650), 0.5f).Draw();
                new TextElement($"M:{EachTick.RecognizedClothes[0].Item2} F:{EachTick.RecognizedClothes[1].Item2} T:{EachTick.RecognizedClothes[2].Item2}", new PointF(500, 50), 0.5f).Draw();
            }
        }

        private static void AbortedScript(object sender, EventArgs e)
        {
            if (Config.Bools.CrashAndEnterMessage) Notification.PostTicker("Press F to WarrantsV, it crashed", true);
            foreach (Tuple<Ped, Blip, float[], int[], Vector3> CopsList in Helpers.CopsList)
            {
                CopsList.Item2.Delete();
            }
            EachTick.LastCopsPositionBlip.Delete();
            EachTick.ChoiceMenus.ClosestPhoneBoothBlip.Delete();
        }
    }
}
