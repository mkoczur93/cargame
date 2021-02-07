namespace RacingMap
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using MainProject.UI;

    public class LapsSystem : MonoBehaviour
    {
        private int idTrigger = 0;
        private bool triggerPassed = false;
        

        CheckPointLaps[] array = null;
        private List<LapsSystem> checkpoints = null;
        private static LapsSystem instance = null;
        private List<int> failedTriggers = null;
        private string Player = null;

        public static LapsSystem Instance { get => instance; set => instance = value; }


        private void Awake()
        {
            instance = this;
            
        }

        void Start()
        {
            checkpoints = new List<LapsSystem>();
            array = GetComponentsInChildren<CheckPointLaps>();
            failedTriggers = new List<int>();
            Player = ObjectTagData.ObjectTagData.Player;
            

            for (int i = 0; i < array.Length; i++)
            {
                checkpoints.Add(new LapsSystem(array[i].GetInstanceID(), false));

            }



        }



        public LapsSystem(int id, bool passed)
        {
            idTrigger = id;
            triggerPassed = passed;
        }


        public void CheckTheCheckpoint(int id)
        {
            int index = 0;
            foreach (var checkpoint in checkpoints)
            {

                if (checkpoint.idTrigger == id)
                {
                    
                    for (int i = 0; i < index; i++)
                    {
                        if (checkpoints[i].triggerPassed == false)
                            if (failedTriggers.Count == 0)
                            {
                                {

                                    foreach (var item in checkpoints)
                                    {
                                        item.triggerPassed = false;
                                        
                                    }

                                    failedTriggers.Add(checkpoint.idTrigger);                                    

                                    return;
                                }
                            }


                            else if (failedTriggers[failedTriggers.Count - 1] == checkpoint.idTrigger)
                            {
                                failedTriggers.RemoveAt(failedTriggers.Count - 1);     
                                return;
                            }

                            else
                            {

                                failedTriggers.Add(checkpoint.idTrigger);
                                return;

                            }

           


                    }

                    if (checkpoint.triggerPassed == false)
                    {

                        if (failedTriggers.Count == 0)
                        {
                            checkpoint.triggerPassed = true;
                            return;
                        }

                        else
                        {

                            if (failedTriggers[failedTriggers.Count - 1] == checkpoint.idTrigger)
                            {
                                failedTriggers.RemoveAt(failedTriggers.Count - 1);                                
                            }

                            else
                            {
                                failedTriggers.Add(checkpoint.idTrigger);                                
                            }

                        }


                    }
                    else
                    {
                        checkpoint.triggerPassed = false;
                        return;
                    }
                }
                index++;

            }

        }




        void OnTriggerEnter2D(Collider2D col)
        {
           
            if (col.CompareTag(Player))
            {
                
                foreach (var checkpoint in checkpoints)
                {
                    if (checkpoint.triggerPassed == false)
                        return;

                }
                foreach (var checkpoint in checkpoints)
                {
                    checkpoint.triggerPassed = false;                  

                }
                                
                GameGUIViewModel.Instance.CounterLaps += 1;
                

            }
        }
    }
}