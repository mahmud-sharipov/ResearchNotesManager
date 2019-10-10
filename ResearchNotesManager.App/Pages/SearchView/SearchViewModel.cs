﻿using ResearchNotesManager.App.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.App.Pages.SearchView
{
    public class SearchViewModel : BaseViewModel
    {
        public SearchViewModel()
        {
            DataProvider = new Model.DataProvider();
            Products = new ObservableCollection<Model.Entities.Product>(DataProvider.GetEntities<Model.Entities.Product>().ToList());
        }

        private ObservableCollection<Model.Entities.Product> products;

        public ObservableCollection<Model.Entities.Product> Products
        {
            get { return products; }
            set { products = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Model.Entities.Product> filtredProducts = new ObservableCollection<Model.Entities.Product>();

        public ObservableCollection<Model.Entities.Product> FilteredProducts
        {
            get { return filtredProducts; }
            //set { filtredProducts = value; RaisePropertyChanged(); }
        }

        public void FiterProducts(string value)
        {
            FilteredProducts.Clear();
            if (!string.IsNullOrEmpty(value))
                Products.Where(p => p.Name.ToLower().StartsWith(value.ToLower())).ToList().ForEach(p => FilteredProducts.Add(p));
        }

        public void OpenEntityPage(object entity)
        {
            if (entity is Model.Entities.Product product)
                OpenEntityPage(product);
        }

        public void OpenEntityPage(Model.Entities.Product product)
        {
            var pageId = "Product:" + product.Guid;
            if (UIManager.PageManager.IsPageAlreadyOpened(pageId))
                UIManager.PageManager.SetCurrentPage(pageId);
            else
                ;// UIManager.PageManager.AddPage(new ProductPage(new ProductViewModel(DataProvider, product)));
        }

        public override Command DiscardChanges => new Command(p => { });

        public Command UpdateProductList => new Command(p =>
        {
            Products = new ObservableCollection<Model.Entities.Product>(DataProvider.GetEntities<Model.Entities.Product>().ToList());
        });

        public override bool CanClose() => true;
    }
}
