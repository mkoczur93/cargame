using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFpsSystem
{
    int Fps { get ; }
    int FpsCounter();

}
