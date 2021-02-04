using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModelController : MonoBehaviour
{
    public Dictionary<PanelUI, ViewModel> RegisterListViewModel = new Dictionary<PanelUI, ViewModel>();
    private static ViewModelController instance = null;

    public void RegisterViewModel(ViewModel model)
    {
        RegisterListViewModel.Add(model.Id, model);
        Debug.Log(model.Id.ToString());
        Debug.Log(RegisterListViewModel.Count);
    }
    public static ViewModelController Instance
    {
        get => instance;
    }
    void Awake()
    {
        instance = this;
        Debug.Log(instance.name);
    }
    public ViewModel getViewModel(PanelUI id)
    {

        if (RegisterListViewModel.TryGetValue(id, out ViewModel value))
        {
            return value;

        }
        return null;
    }
}
