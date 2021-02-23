using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILapTimeSystem
{
    float CurrentTime { get; }
    void SetCurrentTime(float CurrentTime);
    void AddLapTime();
    List<string> GetAllLapTimes();
    void ClearAllLapTimes();
    string SetActualTime();
}
