using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModel : MonoBehaviour
{
    [SerializeField]
    private PanelUI id;
    public PanelUI Id
    {
        get => id;
    }

    public void Start()
    {
        ViewModelController.Instance.RegisterViewModel(this);
    }
    public void showPanel()
    {
        CanvasGroup Canvas = GetComponent<CanvasGroup>();
        if (Canvas != null)
        {
            Canvas.alpha = 1;
            Canvas.interactable = true;
            Canvas.blocksRaycasts = true;
            Cursor.visible = !Canvas.enabled;
            Time.timeScale = 0f;
        }
    }

    public void hidePanel()
    {

        CanvasGroup Canvas = GetComponent<CanvasGroup>();
        if (Canvas != null)
        {
            Canvas.alpha = 0f;
            Canvas.interactable = false;
            Canvas.blocksRaycasts = false;
            Cursor.visible = Canvas.enabled;
            Time.timeScale = 1f;
        }
    }
}
