﻿using MasterDetailsCRUDi.Models;
using MasterDetailsCRUDi.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetailsCRUDi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeleteScorePage : ContentPage
	{
	    // ReSharper disable once NotAccessedField.Local
	    private ScoreDetailViewModel _viewModel;

        public Score Data { get; set; }

        public DeleteScorePage (ScoreDetailViewModel viewModel)
        {
            // Save off the item
            Data = viewModel.Data;
            viewModel.Title = "Delete " + viewModel.Title;

            InitializeComponent();

            // Set the data binding for the page
            BindingContext = _viewModel = viewModel;
        }

	    private async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteData", Data);

            // Remove Item Details Page manualy
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

            await Navigation.PopAsync();
        }

	    private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}