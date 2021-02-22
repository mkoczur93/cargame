using MainProject.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IViewModelController
{
    bool HiddenAllMenuPanel { get; set; }
    void RegisterViewModel(ViewModel model);
    ViewModel getViewModel(PanelUI id);
    List<ViewModel> GetOpenedPanels();
    bool IsModelOpened(PanelUI id);

}
