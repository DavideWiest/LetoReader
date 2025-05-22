using System;
using System.Threading; // For Interlocked

namespace Reader.Modules
{
    public class LoadingStateService
    {
        private int _loadingTasksCount = 0;
        public bool IsLoading => _loadingTasksCount > 0;
        public string? CurrentTaskDescription { get; private set; }

        public event Action? OnLoadingStateChanged;

        public void ShowLoading(string? taskDescription = null)
        {
            Interlocked.Increment(ref _loadingTasksCount);
            CurrentTaskDescription = taskDescription ?? "Loading..."; // Default message
            OnLoadingStateChanged?.Invoke();
        }

        public void HideLoading()
        {
            if (Interlocked.Decrement(ref _loadingTasksCount) <= 0)
            {
                _loadingTasksCount = 0; // Ensure it doesn't go negative
                CurrentTaskDescription = null;
                OnLoadingStateChanged?.Invoke();
            }
        }
    }
}
