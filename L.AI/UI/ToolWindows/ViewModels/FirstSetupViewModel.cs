using L_AI.Options;
using L_AI.TextGeneration;
using L_AI.UI.Impl;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Threading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace L_AI.UI.ToolWindows.ViewModels
{
    public enum ConnectionStatusEnum
    {
        Unchecked,
        Success,
        Failure,
    }

    public class FirstSetupViewModel : ObservableObject
    {
        private readonly Dictionary<int, Action> _backActions;
        private bool _isKobold;
        private bool _isOoga;
        private bool _isBusy;
        private int _currentStep;
        private readonly GeneralOptions _options;
        private const int MaxSteps = 2;

        public FirstSetupViewModel()
        {
            _options = GeneralOptions.Instance.CreateCopy();
            _backActions = new Dictionary<int, Action>()
            {
                { 0, null },
                {
                    1, () => {
                        IsBusy = false;
                        ConnectionStatus = ConnectionStatusEnum.Unchecked;
                    }
                },
                { 2, null },
            };
        }

        public GeneralOptions Options => _options;
        public bool CanNavigateBack => CurrentStep > 0;
        public bool ShouldShowButton => ConnectionStatus != ConnectionStatusEnum.Success && !IsBusy;

        #region General

        public ICommand GoBackCommand => new RelayCommand(() =>
        {
            _backActions[CurrentStep]?.Invoke();
            CurrentStep--;
            NotifyPropertyChanged(nameof(CanNavigate));
        });
        public ICommand ContinueCommand => new RelayCommand(() =>
        {
            CurrentStep++;
            NotifyPropertyChanged(nameof(CanNavigate));
        });      
        
        public int CurrentStep
        {
            get => _currentStep;
            set
            {
                SetProperty(ref _currentStep, value);
                NotifyPropertyChanged(nameof(CanNavigateBack));
                NotifyPropertyChanged(nameof(CanNavigate));
            }
        }

        public bool CanNavigate
        {
            get
            {
                switch (CurrentStep)
                {
                    case 0:
                        return (_isOoga || _isKobold) && CurrentStep < MaxSteps;
                    case 1:
                        return ConnectionStatus == ConnectionStatusEnum.Success && CurrentStep < MaxSteps;
                    default:
                        return false;
                }
            }

        }

        #endregion

        #region Step 0

        public bool IsKobold
        {
            get => _isKobold;
            set
            {
                SetProperty(ref _isKobold, value);
                NotifyPropertyChanged(nameof(CanNavigate));
                Options.ApiProvider = GenerationProviderType.Kobold;
            }
        }
        
        public bool IsOoga
        {
            get => _isOoga;
            set
            {
                SetProperty(ref _isOoga, value);
                NotifyPropertyChanged(nameof(CanNavigate));
                Options.ApiProvider = GenerationProviderType.OogaBooga;
            }
        }

        public ICommand SelectKoboldCommand => new RelayCommand(() => IsKobold = true);
        public ICommand SelectOogaCommand => new RelayCommand(() => IsOoga = true);

        #endregion

        #region Step 1

        public ICommand TestConnectionCommand => new RelayCommand(() => Task.Run(TestConnectionAsync).Forget());

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                SetProperty(ref _isBusy, value);
                NotifyPropertyChanged(nameof(ShouldShowButton));
            }
        }

        private ConnectionStatusEnum _connectionStatus;
        public ConnectionStatusEnum ConnectionStatus
        {
            get => _connectionStatus;
            set
             {
                SetProperty(ref _connectionStatus, value);
                NotifyPropertyChanged(nameof(ShouldShowButton));
             }
        }

        private async Task TestConnectionAsync()
        {
            ConnectionStatus = ConnectionStatusEnum.Unchecked;
            IsBusy = true;
            await Task.Delay(300);
            var canConnect = await GenerationManager.TestConnection(Options);
            ConnectionStatus = canConnect ? ConnectionStatusEnum.Success : ConnectionStatusEnum.Failure;
            IsBusy = false;
            NotifyPropertyChanged(nameof(CanNavigate));
        }

        #endregion
    }
}
