namespace MainProject.UI
{

    using MainProject.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ViewModelController : IViewModelController
    {
        private Dictionary<PanelUI, ViewModel> RegisterListViewModel = new Dictionary<PanelUI, ViewModel>();        
        private static bool hiddenAllMenuPanel = true;

        public bool HiddenAllMenuPanel
        {
            get => hiddenAllMenuPanel;
            set => hiddenAllMenuPanel = value;

        }
 
        public void RegisterViewModel(ViewModel model)
        {
            RegisterListViewModel.Add(model.Id, model);
           // Debug.Log(model.Id);
            //Debug.Log(model);
           // Debug.Log(RegisterListViewModel);


        }
  
        
       
        public ViewModel getViewModel(PanelUI id)
        {

            if (RegisterListViewModel.TryGetValue(id, out ViewModel value))
            {
                
                return value;

            }
            return null;
        }

        public List<ViewModel> GetOpenedPanels()
        {
            var models = new List<ViewModel>();
            foreach (var item in RegisterListViewModel.Values)
            {
                if (item.canvas.alpha == 1)
                {
                    models.Add(item);
                }
            }
            return models;
        }
        public bool IsModelOpened(PanelUI id)
        {
            var panel = getViewModel(id);
            return panel.canvas.alpha == 1;
        }

    }
}