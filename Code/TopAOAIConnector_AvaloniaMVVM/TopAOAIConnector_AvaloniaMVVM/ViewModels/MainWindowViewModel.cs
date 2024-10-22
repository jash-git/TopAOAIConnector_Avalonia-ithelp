using Avalonia.Collections;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace TopAOAIConnector_AvaloniaMVVM.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static
        public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

        [ObservableProperty]
        private ViewModelBase? _currentViewModel = new ChatPageViewModel();

        [ObservableProperty]
        private ListItemTemplate? _selectedListItem;

        public ObservableCollection<ListItemTemplate> Items { get; } =
        [
            new ListItemTemplate(typeof(ChatPageViewModel)),
            new ListItemTemplate(typeof(SettingPageViewModel))
        ];
        


        [ObservableProperty]
        private bool _isPaneOpen;

        [RelayCommand]
        private void MenuButton()
        {
            IsPaneOpen=!_isPaneOpen;
        }
    }

    public class ListItemTemplate(Type modelType)
    {
        public string Name { get; } = modelType.Name.Replace("PageViewModel", "");
        public Type ModelType { get; } = modelType;
    }
}
