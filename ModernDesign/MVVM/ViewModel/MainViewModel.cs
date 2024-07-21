using ModernDesign.Core;


namespace ModernDesign.MVVM.ViewModel
{
    class MainViewModel : ObservebleObject
    {


        public RelayCommand StockviewCommand { get; set; }

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand PageviewCommand {  get; set; }
        public RelayCommand รร3viewcommand { get; set; }
        public RelayCommand รร4viewcommand { get; set; }
        


        public HomeViewModel HomeVm { get; set; }
        public DiscoveryViewModel DiscoveryVm { get; set; }
        public StockViewModel Stockvm { get; set; }

        public รร3ViewModel รร3vm { get; set; }
        public รร4ViewModel รร4vm { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                onPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            DiscoveryVm = new DiscoveryViewModel();
            Stockvm = new StockViewModel();
            รร3vm = new รร3ViewModel();   
            รร4vm = new รร4ViewModel();   



            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(x =>
            {
                CurrentView = HomeVm;
            });
            DiscoveryViewCommand = new RelayCommand(x =>
            {
                CurrentView = DiscoveryVm;

            });

            รร3viewcommand = new RelayCommand(o =>
            {
                CurrentView = รร3vm;

            });
            รร4viewcommand = new RelayCommand(o =>
            {
                CurrentView = รร4vm;

            });

        }
    }
}
