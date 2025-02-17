﻿using System;
using System.Collections.Generic;
using AssettoServer.Server.Configuration;

namespace AssettoServer.Server;

public class SessionState
{
    public SessionConfiguration Configuration { get; init; }
    public int EndTime { get; set; } // TODO
    public DateTime StartTime { get; set; }
    public long StartTimeTicks { get; set; }
    public TimeSpan TimeLeft => StartTime.AddMinutes(Configuration.Time) - DateTime.Now;
    public TimeSpan SessionTime => DateTime.Now - StartTime;
    public int SessionTimeTicks => (int)(Environment.TickCount64 - StartTimeTicks);
    public int TargetLap { get; set; } = 0;
    public int LeaderLapCount { get; set; } = 0;
    public bool LeaderHasCompletedLastLap { get; set; } = false;
    public bool SessionOverFlag { get; set; } = false;
    public Dictionary<byte, EntryCarResult>? Results { get; set; }
    public IEnumerable<EntryCar>? Grid { get; set; }

    public SessionState(SessionConfiguration configuration)
    {
        Configuration = configuration;
    }
}

public class EntryCarResult
{
    public int BestLap { get; set; } = 999999999;
    public int NumLaps { get; set; } = 0;
    public int TotalTime { get; set; } = 0;
    public int LastLap { get; set; } = 999999999;
    public bool HasCompletedLastLap { get; set; } = false;
}