namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using MainProject.UI;
    using System;
    using ObjectTagData;

    public class LapsSystem : MonoBehaviour
    {
       
        LapCheckpoint[] baseCheckpoints = null;
        private List<Checkpoint> checkpoints = null;
        private static LapsSystem instance = null;
        private List<int> failedTriggers = null;      
        private Action OnCheckPointReached = null;
       


        public static LapsSystem Instance { get => instance; set => instance = value; }


        private void Awake()
        {
            instance = this;
            
        }

        void Start()
        {
            checkpoints = new List<Checkpoint>();
            baseCheckpoints = GetComponentsInChildren<LapCheckpoint>();
            failedTriggers = new List<int>();
            
            

            for (int i = 0; i < baseCheckpoints.Length; i++)
            {
                checkpoints.Add(new Checkpoint(baseCheckpoints[i].GetInstanceID(), false));

            }

            

        }



        

        public void CheckTheCheckpoint(int id)
        {
            int index = 0;
            foreach (var checkpoint in checkpoints)
            {

                if (checkpoint.IdTrigger == id)
                {
                    
                    for (int i = 0; i < index; i++)
                    {
                        if (checkpoints[i].TriggerPassed == false)
                            if (failedTriggers.Count == 0)
                            {
                                {

                                    foreach (var item in checkpoints)
                                    {
                                        item.TriggerPassed = false;
                                        
                                    }

                                    failedTriggers.Add(checkpoint.IdTrigger);
                                    Debug.Log("FT: " + failedTriggers.Count);

                                    return;
                                }
                            }


                            else if (failedTriggers[failedTriggers.Count - 1] == checkpoint.IdTrigger)
                            {
                                failedTriggers.RemoveAt(failedTriggers.Count - 1);
                                Debug.Log("FT: " + failedTriggers.Count);
                                return;
                            }

                            else
                            {

                                failedTriggers.Add(checkpoint.IdTrigger);
                                Debug.Log("FT: " + failedTriggers.Count);
                                return;

                            }

           


                    }

                    if (checkpoint.TriggerPassed == false)
                    {

                        if (failedTriggers.Count == 0)
                        {
                            checkpoint.TriggerPassed = true;
                            return;
                        }

                        else
                        {

                            if (failedTriggers[failedTriggers.Count - 1] == checkpoint.IdTrigger)
                            {
                                failedTriggers.RemoveAt(failedTriggers.Count - 1);
                                Debug.Log("FT: " + failedTriggers.Count);
                            }

                            else
                            {
                                failedTriggers.Add(checkpoint.IdTrigger);
                                Debug.Log("FT: " + failedTriggers.Count);
                            }

                        }


                    }
                    else
                    {
                        checkpoint.TriggerPassed = false;
                        return;
                    }
                }
                index++;

            }

        }


        public void SubscribeOnCheckPointReached(Action action)
        {
            OnCheckPointReached += action;
        }
        public void UnSubscribeOnCheckPointReached(Action action)
        {
            OnCheckPointReached -= action;
        }



        void OnTriggerEnter2D(Collider2D col)
        {
           
            if (col.CompareTag(ObjectTagData.Player))
            {
                
                foreach (var checkpoint in checkpoints)
                {
                    if (checkpoint.TriggerPassed == false)
                    {
                        foreach (var checkpoints in checkpoints)
                        {
                            checkpoints.TriggerPassed = false;
                           // Debug.Log(checkpoints.TriggerPassed + " " + checkpoints.IdTrigger);

                        }
                        return;
                    }

                }
                    
                foreach (var checkpoint in checkpoints)
                {
                    checkpoint.TriggerPassed = false;
                    //Debug.Log(checkpoint.TriggerPassed + " " + checkpoint.IdTrigger);

                }
                
                LapTimeSystem.Instance.AddLapTime();
                
                //GameGUIViewModel.Instance.CounterLaps += 1;
                OnCheckPointReached?.Invoke();
                
                
                



            }
        }
    }
}