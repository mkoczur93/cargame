using Car;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

public class LoadJSON : IInitializable
{
    [Inject]
    CarPlayerData.Settings m_carPlayerSettings = null;
    public void Initialize()
    {
        
        Debug.Log("LoadJSON");       
        var text = File.ReadAllText(Application.dataPath + "/CarPlayerSettings.json",System.Text.Encoding.UTF8);        
        CarPlayerData.Settings json = JsonConvert.DeserializeObject<CarPlayerData.Settings>(text);        
        m_carPlayerSettings.Cars = json.Cars;
       

    }

    //var item = JsonUtility.ToJson(m_carPlayerSettings);
    //File.WriteAllText(Application.dataPath + "/CarPlayerSettings.json",item);
    //JsonUtility.FromJsonOverwrite(Application.dataPath + "/CarPlayerSettings.json",m_carPlayerSettings);
}
