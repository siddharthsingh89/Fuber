using CommunityToolkit.Mvvm.Input;
using FuberApp.Models;

namespace FuberApp.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}