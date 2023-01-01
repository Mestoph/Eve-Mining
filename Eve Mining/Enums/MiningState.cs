namespace Eve_Mining.Enums
{
    internal enum MiningState : int
    {
        Idle = 0,
        Undocking = 1,
        Warping_to_belt = 2,
        Selecting_target = 3,
        Approaching = 4,
        Locking_target = 5,
        Fiering_lasers = 6,
        Mining = 7,
        Warping_to_station = 8,
        Docking = 9,
        Unloading = 10,
        Cleaning_interface = 11,
        Warping_to_portal = 12,
        Compressing_ores = 13,
        Droping_compressed_ores = 14,
    }
}
