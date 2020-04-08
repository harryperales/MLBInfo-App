﻿using MLBApp;
using MLBInfo.Models;
using MLBPlayersApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MLBInfo.ViewModels
{
    public class PlayerInfoPageViewModel: BaseViewModel, INotifyPropertyChanged, IInitialize
    {
        public PlayerData Player { get; set; } = new PlayerData();

        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand ViewTeamRosterCommand { get; set; }
        public PlayerInfoPageViewModel(INavigationService navigationService, IApiService apiService, PageDialogService pagedialogservice) : base(navigationService, apiService, pagedialogservice)
        {
            ViewTeamRosterCommand = new DelegateCommand(async () =>
            {
                if (!string.IsNullOrEmpty(Player.TeamId)) await GoToTeamRosterPage();
            });
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Name")) this.Player.NameDisplayFirstLast = $"{parameters["Name"]}";
            if (parameters.ContainsKey("TeamName")) this.Player.TeamName = $"{parameters["TeamName"]}";
            if (parameters.ContainsKey("PrimaryPosition")) this.Player.PrimaryPosition = $"{parameters["PrimaryPosition"]}";
            if (parameters.ContainsKey("JerseyNumber")) this.Player.JerseyNumber = $"{parameters["JerseyNumber"]}";
            if (parameters.ContainsKey("Weight")) this.Player.Weight = $"{parameters["Weight"]}";
            if (parameters.ContainsKey("Age")) this.Player.Age = $"{parameters["Age"]}";
            if (parameters.ContainsKey("BirthCountry")) this.Player.BirthCountry = $"{parameters["BirthCountry"]}";
            if (parameters.ContainsKey("Status")) this.Player.Status = $"{parameters["Status"]}";
            if (parameters.ContainsKey("TeamId")) this.Player.TeamId = $"{parameters["TeamId"]}";
            if (parameters.ContainsKey("Twitter")) this.Player.TwitterId = $"{parameters["Twitter"]}";
            if (parameters.ContainsKey("Picture")) this.Player.PlayerPicture = $"{parameters["Picture"]}";
        }
        public async Task GoToTeamRosterPage()
        {

            try
            {
                var nav = new NavigationParameters();
                nav.Add("TeamID", this.Player.TeamId);
                await NavigationService.NavigateAsync(NavConstants.TeamRoster, nav);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API EXCEPTION {ex}");
            }

        }
    }
}
