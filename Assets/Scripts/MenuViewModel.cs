using System.Collections;
using UnityEngine;
using UnityWeld.Binding;
using System.ComponentModel;
using UnityEngine.SceneManagement;


    [Binding]
public class MenuViewModel : MonoBehaviour, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [SerializeField]
        private CanvasGroup mainMenu = null;
        private bool paused = false;
        private string nameScene = string.Empty;
        // Start is called before the first frame update
        void Start()
        {
            mainMenu = mainMenu.GetComponent<CanvasGroup>();
        if (mainMenu != null)
        {
            mainMenu.alpha = 0;
            mainMenu.interactable = false;
            mainMenu.blocksRaycasts = false;
        }
        nameScene = SceneManager.GetActiveScene().name;
            
    }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
            if (paused == false)
            {
                Time.timeScale = 0f;
                paused = true;
            }
            else
            {
                Time.timeScale = 1f;
                paused = false;
            }
                if (mainMenu.alpha == 1f)
                    mainMenu.alpha = 0f;
                else
                    mainMenu.alpha = 1f;
                mainMenu.interactable = !mainMenu.interactable;
                mainMenu.blocksRaycasts = !mainMenu.blocksRaycasts;
                Cursor.visible = mainMenu.enabled;
                
            }
        }
        [Binding]
        public void buttonResume()
        {
            
            mainMenu.alpha = 0f;
            mainMenu.interactable = false;
            mainMenu.blocksRaycasts = false;
            Cursor.visible = mainMenu.enabled;
            Time.timeScale = 1f;
            paused = false;
            

        }

        [Binding]
        public void newGameButton()
        {
            SceneManager.LoadScene(nameScene);

         }

    }

