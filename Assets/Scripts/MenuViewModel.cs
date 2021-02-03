using System.Collections;
using UnityEngine;
using UnityWeld.Binding;
using System.ComponentModel;

[Binding]
public class MenuViewModel : MonoBehaviour, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    [SerializeField]
    private Canvas mainMenu = null;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu = mainMenu.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.enabled = !mainMenu.enabled;
            Cursor.visible = mainMenu.enabled;
        }
    }
    [Binding]
    public void buttonResume()
    {
        mainMenu.enabled = !mainMenu.enabled;
        Cursor.visible = mainMenu.enabled;

    }
}

