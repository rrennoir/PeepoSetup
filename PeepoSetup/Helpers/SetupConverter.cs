using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PeepoSetup.Models;
using PeepoSetup.Types;
using PeepoSetup.Types.AccSetup;
using PeepoSetup.Types.Exceptions;

namespace PeepoSetup.Helpers;

public static class SetupConverter
{
    private const string DataFolder = "./Data";
    private static readonly Dictionary<int, TrackBop> TrackBops = LoadTrackBops();
    private static readonly BopLimit BopLimits = LoadBopLimits();

    public static RealValueSetup LoadSetup(string path)
    {
        var setup = JsonHelper.LoadJson<Setup>(path);
        if (setup == default)
            throw new LoadSetupException();

        var converterData = JsonHelper.LoadJson<CarData>(Path.Combine(DataFolder, $"{setup.CarName}.json"));
        if (converterData == default)
            throw new CarDataNotFoundException();

        return ConvertSetup(converterData, setup);
    }

    private static RealValueSetup ConvertSetup(CarData carData, Setup setup)
    {
        TrackBop? bop = null;
        if (TrackBops.ContainsKey(setup.TrackBopType))
            bop = TrackBops[setup.TrackBopType];


        float camberOffsetFront;
        float camberOffsetRear;
        if (bop is not null && bop.Year >= 2020 && BopLimits.AffectedCars.Contains(setup.CarName))
        {
            camberOffsetFront = BopLimits.CamberFrontOffset;
            camberOffsetRear = BopLimits.CamberRearOffset;
        }
        else
        {
            camberOffsetFront = carData.CamberFrontOffset;
            camberOffsetRear = carData.CamberRearOffset;
        }

        var track = bop is null ? "Unknown" : bop.TrackName;
        var bopType = bop is null ? "-" : $"{bop.Bop} {bop.Year}";
        var multiTrackBop = false;
        var otherTracks = string.Empty;
        
        var tracks = track.Split("|");
        if (tracks.Length > 1)
        {
            track = tracks.First();
            multiTrackBop = true;
            otherTracks = $"This BOP is shared with: {string.Join(", ", tracks[1..])}";
        }

        var realSetup = new RealValueSetup
        {
            CarName = carData.CarName,
            Track = track,
            OtherTracks = otherTracks,
            IsMultiTrackBop = multiTrackBop,
            Bop = bopType,
            Toe = ConvertToe(setup, carData),
            Camber = ConvertCamber(setup, carData, camberOffsetFront, camberOffsetRear),
            BrakeBias = carData.BrakeBiasOffset + setup.AdvancedSetup.MechanicalBalance.BrakeBias * carData.BrakeBiasStep,
            Preload = carData.PreloadOffset + setup.AdvancedSetup.DriveTrain.Preload * carData.PreloadStep,
            WheelRate = ConvertWheelRate(setup, carData),
            SteerRatio = carData.SteerRatioOffset + setup.BasicSetup.Alignment.SteerRatio,
            BumpStopRate = ConvertBumpStopRate(setup, carData),
            BumpStopWindow = new WheelsInt(setup.AdvancedSetup.MechanicalBalance.BumpStopWindow),
            BrakeDuctFront = setup.AdvancedSetup.AreoBalance.BrakeDuct[0],
            BrakeDuctRear = setup.AdvancedSetup.AreoBalance.BrakeDuct[1],
            Tc1 = setup.BasicSetup.Electronics.Tc1,
            Tc2 = setup.BasicSetup.Electronics.Tc2,
            Abs = setup.BasicSetup.Electronics.Abs,
            Ecu = setup.BasicSetup.Electronics.EcuMap + carData.EcuOffset,
            BumpFast = ConvertDampers(setup.AdvancedSetup.Dampers.BumpFast, carData.FastBumpOffset),
            BumpSlow = ConvertDampers(setup.AdvancedSetup.Dampers.BumpSlow, carData.BumpOffset),
            ReboundFast = ConvertDampers(setup.AdvancedSetup.Dampers.ReboundFast, carData.FastReboundOffset),
            ReboundSlow = ConvertDampers(setup.AdvancedSetup.Dampers.ReboundSlow, carData.ReboundOffset),
            ArbFront = setup.AdvancedSetup.MechanicalBalance.ArbFront,
            ArbRear = setup.AdvancedSetup.MechanicalBalance.ArbRear,
            TyreCompound = setup.BasicSetup.Tyres.Compound == 1 ? "Wet" : "Dry",
            TyrePressures = new WheelsFloat(setup.BasicSetup.Tyres.Pressures, carData.PressureOffset, 0.1f),
            RideHeightFront = carData.RideHeightFrontOffset + setup.AdvancedSetup.AreoBalance.RideHeight[0],
            RideHeightRear = carData.RideHeightRearOffset + setup.AdvancedSetup.AreoBalance.RideHeight[2],
            BrakeTorque = carData.BrakeTorqueOffset + setup.AdvancedSetup.MechanicalBalance.BrakeTorque,
            RearWing = setup.AdvancedSetup.AreoBalance.RearWing + carData.RearWingOffset,
            Splitter = setup.AdvancedSetup.AreoBalance.Splitter + carData.SplitterOffset,
            CasterLeft = setup.BasicSetup.Alignment.CasterLeft,
            CasterRight = setup.BasicSetup.Alignment.CasterRight,
        };
        return realSetup;
    }

    private static WheelsFloat ConvertToe(Setup setup, CarData carData)
    {
        return new WheelsFloat
        {
            FrontLeft = setup.BasicSetup.Alignment.Toe[0] * carData.ToeStep + carData.ToeFrontOffset,
            FrontRight = setup.BasicSetup.Alignment.Toe[1] * carData.ToeStep + carData.ToeFrontOffset,
            RearLeft = setup.BasicSetup.Alignment.Toe[2] * carData.ToeStep + carData.ToeRearOffset,
            RearRight = setup.BasicSetup.Alignment.Toe[3] * carData.ToeStep + carData.ToeRearOffset,
        };
    }

    private static WheelsFloat ConvertCamber(Setup setup, CarData carData, float frontOffset, float rearOffset)
    {
        var camber = setup.BasicSetup.Alignment.Camber;
        return new WheelsFloat
        {
            FrontLeft = camber[0] * carData.ToeStep + frontOffset,
            FrontRight = camber[1] * carData.ToeStep + frontOffset,
            RearLeft = camber[2] * carData.ToeStep + rearOffset,
            RearRight = camber[3] * carData.ToeStep + rearOffset,
        };
    }

    private static WheelsInt ConvertWheelRate(Setup setup, CarData carData)
    {
        return new WheelsInt
        {
            FrontLeft = carData.WheelRatesFront[setup.AdvancedSetup.MechanicalBalance.WheelRate[0]],
            FrontRight = carData.WheelRatesFront[setup.AdvancedSetup.MechanicalBalance.WheelRate[1]],
            RearLeft = carData.WheelRatesRear[setup.AdvancedSetup.MechanicalBalance.WheelRate[2]],
            RearRight = carData.WheelRatesRear[setup.AdvancedSetup.MechanicalBalance.WheelRate[3]],
        };
    }

    private static WheelsInt ConvertBumpStopRate(Setup setup, CarData carData)
    {
        var bumpStopRate = setup.AdvancedSetup.MechanicalBalance.BumpStopRateUp;
        return new WheelsInt
        {
            FrontLeft = bumpStopRate[0] * carData.BumpStopRateStep + carData.BumpStopRateOffset,
            FrontRight = bumpStopRate[1] * carData.BumpStopRateStep + carData.BumpStopRateOffset,
            RearLeft = bumpStopRate[2] * carData.BumpStopRateStep + carData.BumpStopRateOffset,
            RearRight = bumpStopRate[3] * carData.BumpStopRateStep + carData.BumpStopRateOffset,
        };
    }
    
    private static WheelsInt ConvertDampers(IReadOnlyList<int> dampers, int offset)
    {
        return new WheelsInt
        {
            FrontLeft = dampers[0] + offset,
            FrontRight = dampers[1] + offset,
            RearLeft = dampers[2] + offset,
            RearRight = dampers[3] + offset,
        };
    }

    private static Dictionary<int, TrackBop> LoadTrackBops()
    {
        var trackBops = JsonHelper.LoadJson<Dictionary<int, TrackBop>>(Path.Combine(DataFolder, "TrackBop.json"));
        if (trackBops is null)
            throw new Exception("Failed to load track bop");

        return trackBops;
    }

    private static BopLimit LoadBopLimits()
    {
        var bopLimit = JsonHelper.LoadJson<BopLimit>(Path.Combine(DataFolder, "2020Bop.json"));
        if (bopLimit == default)
            throw new Exception("Failed to load track bops");

        return bopLimit;
    }
}