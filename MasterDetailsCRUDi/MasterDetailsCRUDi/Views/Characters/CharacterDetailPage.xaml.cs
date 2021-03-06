﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MasterDetailsCRUDi.Models;
using MasterDetailsCRUDi.ViewModels;
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable RedundantExtendsListEntry

namespace MasterDetailsCRUDi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDetailPage : ContentPage
    {
        private CharacterDetailViewModel _viewModel;

        public CharacterDetailPage(CharacterDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

        public CharacterDetailPage()
        {
            InitializeComponent();

            var data = new Character
            {
                Name = "Doug",
                Description = "This is an item description.",
                Age = 20
            };

            _viewModel = new CharacterDetailViewModel(data);
            BindingContext = _viewModel;
        }


        public async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCharacterPage(_viewModel));
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCharacterPage(_viewModel));
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}