using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBrakeTrack
{

    
    TrailRenderer GetPooledObject();    
    void StartCorutinePutItBackInPooledObjects(TrailRenderer PooledObject);
    void Init();
    void NewGameInit();



}
