using ADSInvest.Data;
using ADSInvest.Models;
using ADSInvest.Services.Command;
using ADSInvest.ViewModels.Base;
using ADSInvest.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ADSInvest.ViewModels
{
    public sealed class AdminMainViewModel : BaseViewModel
    {
        public AdminMainViewModel()
        {
            InitialCommands();
            InititalDataCollections();
        }

        #region Properties

        #region CRUD

        private readonly ConstructionWorkCRUD _constructionworkCRUD = new ConstructionWorkCRUD();

        private readonly WorkerCRUD _workerCRUD = new WorkerCRUD();

        private readonly ClientCRUD _clientCRUD = new ClientCRUD();

        private readonly ProductCRUD _productCRUD = new ProductCRUD();

        #endregion

        #region Data Collections

        public List<ConstructionWorkModel> ConstructionWorks
        {
            get => _constructionWorks;
            set
            {
                if (value != null)
                {
                    _constructionWorks = value;
                    OnPropertyChanged("ConstructionWorks");
                }
            }
        }

        private List<ConstructionWorkModel> _constructionWorks;

        public List<WorkerModel> Workers
        {
            get => _workers;
            set
            {
                if (value != null)
                {
                    _workers = value;
                    OnPropertyChanged("Workers");
                }
            }
        }

        private List<WorkerModel> _workers;

        public List<ClientModel> Clients
        {
            get => _clients;
            set
            {
                if (value != null)
                {
                    _clients = value;
                    OnPropertyChanged("Clients");
                }
            }

        }

        private List<ClientModel> _clients;

        public List<ProductModel> Products
        {
            get => _products;
            set
            {
                if (value != null)
                {
                    _products = value;
                    OnPropertyChanged("Products");
                }
            }
        }

        private List<ProductModel> _products;

        public List<WorkerModel> WorkersInConstructionWorks
        {
            get => _workersInConstructionWorks;
            set
            {
                if (value != null)
                {
                    _workersInConstructionWorks = value;
                    OnPropertyChanged("WorkersInConstructionWorks");
                }
            }
        }

        private List<WorkerModel> _workersInConstructionWorks;

        #endregion

        #region Commands

        public ICommand LogoutButtonClickCommand { get; private set; }

        public ICommand ShutdownButtonClickCommand { get; private set; }

        public ICommand CreateConstructionWorkButtonClickCommand { get; private set; }

        public ICommand UpdateConstructionWorkButtonClickCommand { get; private set; }

        public ICommand DeleteConstructionWorkButtonClickCommand { get; private set; }

        public ICommand CreateWorkerButtonClickCommand { get; private set; }

        public ICommand DeleteWorkerButtonClickCommand { get; private set; }

        public ICommand CreateProductButtonClickCommand { get; private set; }

        public ICommand DeleteProductButtonClickCommand { get; private set; }

        public ICommand ViewConstuctionWorksListBoxItemMouseLeftButtonUpCommand { get; set; }

        public ICommand CreateClientButtonClickCommand { get; private set; }

        public ICommand DeleteClientButtonClickCommand { get; private set; }

        #endregion

        #region Create

        #region Construction Work

        public string ConstructionWorkName
        {
            get => _constructionWorkName;
            set
            {
                if (value != string.Empty)
                {
                    _constructionWorkName = value;
                    OnPropertyChanged("ConstructionWorkName");
                }
            }
        }

        private string _constructionWorkName = string.Empty;

        public string ConstructionWorkStatus
        {
            get => _constructionWorkStatus;
            set
            {
                if (value != string.Empty)
                {
                    _constructionWorkStatus = value;
                    OnPropertyChanged("ConstructionWorkStatus");
                }
            }
        }

        private string _constructionWorkStatus = string.Empty;

        public DateTime ConstructionWorkEndDate
        {
            get => _constructionWorkEndDate;
            set
            {
                _constructionWorkEndDate = value;
                OnPropertyChanged("ConstructionWorkEndDate");
            }
        }

        private DateTime _constructionWorkEndDate = new DateTime(DateTime.UtcNow.Year,
            DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0, DateTimeKind.Utc);

        public string ConstructionWorkAddress
        {
            get => _constructionWorkAddress;
            set
            {
                if (value != string.Empty)
                {
                    _constructionWorkAddress = value;
                    OnPropertyChanged("ConstructionWorkAddress");
                }
            }
        }

        private string _constructionWorkAddress = string.Empty;

        #endregion

        #region Worker

        public string WorkerName
        {
            get => _workerName;
            set
            {
                if (value != string.Empty)
                {
                    _workerName = value;
                    OnPropertyChanged("WorkerName");
                }
            }
        }

        private string _workerName = string.Empty;

        public string WorkerSurname
        {
            get => _workerSurname;
            set
            {
                if (value != string.Empty)
                {
                    _workerSurname = value;
                    OnPropertyChanged("WorkerSurname");
                }
            }
        }

        private string _workerSurname = string.Empty;

        public string WorkerPatronymic
        {
            get => _workerPatronymic;
            set
            {
                if (value != string.Empty)
                {
                    _workerPatronymic = value;
                    OnPropertyChanged("WorkerPatronymic");
                }
            }
        }

        private string _workerPatronymic = string.Empty;

        public string WorkerSpecialization
        {
            get => _workerSpecialization;
            set
            {
                if (value != string.Empty)
                {
                    _workerSpecialization = value;
                    OnPropertyChanged("WorkerSpecialization");
                }
            }
        }

        private string _workerSpecialization = string.Empty;

        public string WorkerContactInformation
        {
            get => _workerContactInformation;
            set
            {
                if (value != string.Empty)
                {
                    _workerContactInformation = value;
                    OnPropertyChanged("WorkerContactInformation");
                }
            }
        }

        private string _workerContactInformation = string.Empty;

        #endregion

        #region Client

        public string ClientName
        {
            get => _clientName;
            set
            {
                if(value != string.Empty)
                {
                    _clientName = value;
                    OnPropertyChanged("ClientName");
                }
            }
        }

        private string _clientName = string.Empty;

        public string ClientSurname
        {
            get => _clientSurname;
            set
            {
                if(value != string.Empty)
                {
                    _clientSurname = value;
                    OnPropertyChanged("ClientSurname");
                }
            }
        }

        private string _clientSurname = string.Empty;

        public string ClientPatronymic
        {
            get => _clientPatronymic;
            set
            {
                if(value != string.Empty)
                {
                    _clientPatronymic = value;
                    OnPropertyChanged("ClientPatronymic");
                }
            }
        }

        private string _clientPatronymic = string.Empty;

        public string ClientPhone
        {
            get => _clientPhone;
            set
            {
                if(value != string.Empty)
                {
                    _clientPhone = value;
                    OnPropertyChanged("ClientPhone");
                }
            }
        }

        private string _clientPhone = string.Empty;

        #endregion

        #region Product

        public string ProductName
        {
            get => _productName;
            set
            {
                if (value != string.Empty)
                {
                    _productName = value;
                    OnPropertyChanged("ProductName");
                }
            }
        }

        private string _productName = string.Empty;

        public string ProductUnitOfMeasurement
        {
            get => _productUnitOfMeasurement;
            set
            {
                if (value != string.Empty)
                {
                    _productUnitOfMeasurement = value;
                    OnPropertyChanged("ProductUnitOfMeasurement");
                }
            }
        }

        private string _productUnitOfMeasurement = string.Empty;

        public double ProductPricePerUnit
        {
            get => _productPricePerUnit;
            set
            {
                if (value > 0)
                {
                    _productPricePerUnit = value;
                }
            }
        }

        private double _productPricePerUnit = 0;

        public int ProductQuantity
        {
            get => _productQuantity;
            set
            {
                if (value > 0)
                {
                    _productQuantity = value;
                }
            }
        }

        private int _productQuantity = 0;

        #endregion

        #endregion

        #region Selected Items

        public ProductModel DeleteProductSelectedItem
        {
            get => _deleteProductSelectedItem;
            set
            {
                if (value != null)
                {
                    _deleteProductSelectedItem = value;
                    OnPropertyChanged("DeleteProductSelectedItem");
                }
            }
        }

        private ProductModel _deleteProductSelectedItem;

        public ConstructionWorkModel CreateWorkerConstructionWorkSelectedItem
        {
            get => _createWorkerConstructionWorkSelectedItem;
            set
            {
                if (value != null)
                {
                    _createWorkerConstructionWorkSelectedItem = value;
                    OnPropertyChanged("CreateWorkerConstructionWorkSelectedItem");
                }
            }
        }

        private ConstructionWorkModel _createWorkerConstructionWorkSelectedItem;

        public WorkerModel DeleteWorkerSelectedItem
        {
            get => _deleteWorkerSelectedItem;
            set
            {
                if (value != null)
                {
                    _deleteWorkerSelectedItem = value;
                    OnPropertyChanged("DeleteWorkerSelectedItem");
                }
            }
        }

        private WorkerModel _deleteWorkerSelectedItem;

        public ClientModel CreateConstructionWorkClientSelectedItem
        {
            get => _createConstructionWorkClientSelectedItem;
            set
            {
                if (value != null)
                {
                    _createConstructionWorkClientSelectedItem = value;
                    OnPropertyChanged("CreateConstructionWorkClientSelectedItem");
                }
            }
        }

        private ClientModel _createConstructionWorkClientSelectedItem;

        public ConstructionWorkModel DeleteConstructionWorkSelectedItem
        {
            get => _deleteConstructionWorkSelectedItem;
            set
            {
                if (value != null)
                {
                    _deleteConstructionWorkSelectedItem = value;
                    OnPropertyChanged("DeleteConstructionWorkSelectedItem");
                }
            }
        }

        private ConstructionWorkModel _deleteConstructionWorkSelectedItem;

        public ConstructionWorkModel UpdateConstructionWorkSelectedItem
        {
            get => _updateConstructionWorkSelectedItem;
            set
            {
                if (value != null)
                {
                    _updateConstructionWorkSelectedItem = value;
                    OnPropertyChanged("UpdateConstructionWorkSelectedItem");
                }
            }
        }

        private ConstructionWorkModel _updateConstructionWorkSelectedItem;

        public ConstructionWorkModel ViewConstructionWorkSelectedItem
        {
            get => _viewConstructionWorkSelectedItem;
            set
            {
                if (value != null)
                {
                    _viewConstructionWorkSelectedItem = value;
                    OnPropertyChanged("ViewConstructionWorkSelectedItem");
                }
            }
        }

        private ConstructionWorkModel _viewConstructionWorkSelectedItem;

        public ClientModel DeleteClientSelectedItem
        {
            get => _deleteClientSelectedItem;
            set
            {
                if(value != null)
                {
                    _deleteClientSelectedItem = value;
                    OnPropertyChanged("DeleteClientSelectedItem");
                }
            }
        }

        private ClientModel _deleteClientSelectedItem;

        #endregion

        #endregion

        #region Methods

        #region Commands

        private void LogoutButtonClick(object obj)
        {
            var view = obj as AdminMainView;

            var displayRootRegistry = (Application.Current as Application).DisplayWindow;

            displayRootRegistry.Show(new AuthorizationViewModel());

            view.Close();
        }

        private void ShutdownButtonClick(object obj) => Application.Current.Shutdown();

        private void CreateConstructionWorkButtonClick(object obj)
        {
            if (CreateConstructionWorkIsNotEmpty())
            {
                var newConstructionWork = new ConstructionWorkModel()
                {
                    Name = ConstructionWorkName,
                    Address = ConstructionWorkAddress,
                    EndDate = ConstructionWorkEndDate,
                    Status = "В работе",
                    IdClient = CreateConstructionWorkClientSelectedItem.Id
                };

                if (_constructionworkCRUD.Create(newConstructionWork))
                {
                    _constructionWorks = _constructionworkCRUD.ReadAll().ToList();
                    OnPropertyChanged("ConstructionWorks");

                    ClearFields();

                    MessageBox.Show("Строительная работа успешно создана", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Строительная работа не была создана", "Ошибка создания", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateConstructionWorkButtonClick(object obj)
        {
            if (UpdateConstructionWorkSelectedItem != null)
            {
                if (ConstructionWorkStatus != string.Empty)
                {
                    var newConstructionWork = new ConstructionWorkModel()
                    {
                        Id = UpdateConstructionWorkSelectedItem.Id,
                        Address = UpdateConstructionWorkSelectedItem.Address,
                        EndDate = UpdateConstructionWorkSelectedItem.EndDate,
                        Name = UpdateConstructionWorkSelectedItem.Name,
                        IdClient = UpdateConstructionWorkSelectedItem.IdClient,
                        Status = ConstructionWorkStatus
                    };

                    if (_constructionworkCRUD.Update(newConstructionWork))
                    {
                        _constructionWorks = _constructionworkCRUD.ReadAll().ToList();
                        OnPropertyChanged("ConstructionWorks");

                        ClearFields();

                        MessageBox.Show("Строительная работа была изменена", "Успех", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Строительная работа не была изменена", "Ошибка обновления данных",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Поле не было заполнено", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Строительная работа не выбрана", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteConstructionWorkButtonClick(object obj)
        {
            if (DeleteConstructionWorkSelectedItem != null)
            {
                if (_constructionworkCRUD.Delete(DeleteConstructionWorkSelectedItem.Id))
                {
                    _workerCRUD.DeleteByIdConstructionWork(DeleteConstructionWorkSelectedItem.Id);

                    _workers = _workerCRUD.ReadAll().ToList();
                    OnPropertyChanged("Workers");

                    _constructionWorks = _constructionworkCRUD.ReadAll().ToList();
                    OnPropertyChanged("ConstructionWorks");

                    ClearFields();

                    MessageBox.Show("Строительная работа была удалёна", "Успех",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Строительная работа не выбрана", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateWorkerButtonClick(object obj)
        {
            if (CreateWorkerFieldsIsNotEmpty())
            {
                var newWorker = new WorkerModel()
                {
                    Name = WorkerName,
                    Surname = WorkerSurname,
                    Patronymic = WorkerPatronymic,
                    Specialization = WorkerSpecialization,
                    ContactInformation = WorkerContactInformation,
                    IdConstructionWork = CreateWorkerConstructionWorkSelectedItem.Id
                };

                if (_workerCRUD.Create(newWorker))
                {
                    _workers = _workerCRUD.ReadAll().ToList();
                    OnPropertyChanged("Workers");

                    ClearFields();

                    MessageBox.Show("Рабочий успешно создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Рабочий не был создан", "Ошибка создания", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteWorkerButtonClick(object obj)
        {
            if (DeleteWorkerSelectedItem != null)
            {
                if (_workerCRUD.Delete(DeleteWorkerSelectedItem.Id))
                {
                    _workers = _workerCRUD.ReadAll().ToList();
                    OnPropertyChanged("Workers");

                    ClearFields();

                    MessageBox.Show("Рабочий был удалён", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Рабочий не был удалён", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Рабочий не выбран не выбран", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateProductButtonClick(object obj)
        {
            if (CreateProductFieldsIsNotEmpty())
            {
                var newProduct = new ProductModel()
                {
                    Name = ProductName,
                    PricePerUnit = ProductPricePerUnit,
                    Quantity = ProductQuantity,
                    UnitOfMeasurement = ProductUnitOfMeasurement
                };

                if (_productCRUD.Create(newProduct))
                {
                    _products = _productCRUD.ReadAll().ToList();
                    OnPropertyChanged("Products");

                    ClearFields();

                    MessageBox.Show("Материал успешно создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Материал не был создан", "Ошибка создания", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteProductButtonClick(object obj)
        {
            if (DeleteProductSelectedItem != null)
            {
                if (_productCRUD.Delete(DeleteProductSelectedItem.Id))
                {
                    _products = _productCRUD.ReadAll().ToList();
                    OnPropertyChanged("Products");

                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Материал не был удалён", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Материал не выбран", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ViewConstuctionWorksListBoxItemMouseLeftButtonUp(object obj)
        {
            if (ViewConstructionWorkSelectedItem != null)
            {
                _workersInConstructionWorks = _workerCRUD.ReadAllByIdConstructionWork(ViewConstructionWorkSelectedItem.Id).ToList();
                OnPropertyChanged("WorkersInConstructionWorks");
            }
        }

        private void CreateClientButtonClick(object obj)
        {
            if (CreateClientFieldsIsNotEmpty())
            {
                var newClient = new ClientModel() 
                { 
                    Name = ClientName,
                    Surname = ClientSurname,
                    Patronymic = ClientPatronymic,
                    Phone = ClientPhone
                };

                if (_clientCRUD.Create(newClient))
                {
                    _clients = _clientCRUD.ReadAll().ToList();
                    OnPropertyChanged("Clients");

                    ClearFields();

                    MessageBox.Show("Клиент успешно создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Материал не был создан", "Ошибка создания", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteClientButtonClick(object obj)
        {
            if(DeleteClientSelectedItem != null)
            {
                if (_clientCRUD.Delete(DeleteClientSelectedItem.Id))
                {
                    _clients = _clientCRUD.ReadAll().ToList();
                    OnPropertyChanged("Clients");

                    _constructionworkCRUD.DeleteByIdClient(DeleteClientSelectedItem.Id);
                    _constructionWorks = _constructionworkCRUD.ReadAll().ToList();
                    OnPropertyChanged("ConstructionWorks");

                    ClearFields();

                    MessageBox.Show("Клиент успешно удалён", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Клиент не был удалён", "Ошибка создания", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Клиент не был выбран", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        private void InitialCommands()
        {
            LogoutButtonClickCommand = new DelegateCommandService(LogoutButtonClick);
            ShutdownButtonClickCommand = new DelegateCommandService(ShutdownButtonClick);

            CreateConstructionWorkButtonClickCommand = new DelegateCommandService(CreateConstructionWorkButtonClick);
            UpdateConstructionWorkButtonClickCommand = new DelegateCommandService(UpdateConstructionWorkButtonClick);
            DeleteConstructionWorkButtonClickCommand = new DelegateCommandService(DeleteConstructionWorkButtonClick);

            CreateWorkerButtonClickCommand = new DelegateCommandService(CreateWorkerButtonClick);
            DeleteWorkerButtonClickCommand = new DelegateCommandService(DeleteWorkerButtonClick);

            CreateProductButtonClickCommand = new DelegateCommandService(CreateProductButtonClick);
            DeleteProductButtonClickCommand = new DelegateCommandService(DeleteProductButtonClick);

            CreateClientButtonClickCommand = new DelegateCommandService(CreateClientButtonClick);
            DeleteClientButtonClickCommand = new DelegateCommandService(DeleteClientButtonClick);

            ViewConstuctionWorksListBoxItemMouseLeftButtonUpCommand = new DelegateCommandService(ViewConstuctionWorksListBoxItemMouseLeftButtonUp);
        }

        private void InititalDataCollections()
        {
            _constructionWorks = _constructionworkCRUD.ReadAll().ToList();
            _workers = _workerCRUD.ReadAll().ToList();
            _products = _productCRUD.ReadAll().ToList();
            _clients = _clientCRUD.ReadAll().ToList();
        }

        private bool CreateProductFieldsIsNotEmpty() => ProductName != string.Empty && ProductPricePerUnit > 0
                && ProductQuantity > 0 && ProductUnitOfMeasurement != string.Empty;

        private bool CreateWorkerFieldsIsNotEmpty() => WorkerName != string.Empty && WorkerSurname != string.Empty
                && WorkerPatronymic != string.Empty && WorkerSpecialization != string.Empty
                && WorkerContactInformation != string.Empty && CreateWorkerConstructionWorkSelectedItem != null;

        private bool CreateConstructionWorkIsNotEmpty() => ConstructionWorkName != string.Empty
                && ConstructionWorkAddress != string.Empty && CreateConstructionWorkClientSelectedItem != null;

        private bool CreateClientFieldsIsNotEmpty() => ClientName != string.Empty && ClientSurname != string.Empty
            && ClientPatronymic != string.Empty && ClientPhone != string.Empty;

        private void ClearFields()
        {
            _deleteProductSelectedItem = null;
            OnPropertyChanged("DeleteProductSelectedItem");

            _createWorkerConstructionWorkSelectedItem = null;
            OnPropertyChanged("CreateWorkerConstructionWorkSelectedItem");

            _deleteWorkerSelectedItem = null;
            OnPropertyChanged("DeleteWorkerSelectedItem");

            _createConstructionWorkClientSelectedItem = null;
            OnPropertyChanged("CreateConstructionWorkClientSelectedItem");

            _deleteConstructionWorkSelectedItem = null;
            OnPropertyChanged("DeleteConstructionWorkSelectedItem");

            _updateConstructionWorkSelectedItem = null;
            OnPropertyChanged("UpdateConstructionWorkSelectedItem");

            _viewConstructionWorkSelectedItem = null;
            OnPropertyChanged("ViewConstructionWorkSelectedItem");

            _workersInConstructionWorks = null;
            OnPropertyChanged("WorkersInConstructionWorks");

            _deleteClientSelectedItem = null;
            OnPropertyChanged("DeleteClientSelectedItem");
        }

        #endregion
    }
}