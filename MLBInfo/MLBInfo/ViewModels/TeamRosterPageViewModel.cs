﻿using MLBPlayersApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace MLBInfo.ViewModels
{
    public class TeamRosterPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public string Start_Seasson { get; set; }
        public string End_Seasson { get; set; }
        public string Team_ID { get; set; }

        public DelegateCommand GetTeamInformationCommand { get; set; }
        public TeamRosterPageViewModel(INavigationService navigationService, IApiService apiService, PageDialogService pagedialogservice, INavigationParameters navigationParameter) :base(navigationService, apiService, pagedialogservice, navigationParameter)
        {

            GetTeamInformationCommand = new DelegateCommand(async () =>
            {
                await GetRosterData();
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;

        async Task GetRosterData() {

            if (await this.HasInternet())
            {

            }
        
        
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("StarSeasson"))
            {
                Start_Seasson = parameters["Name"].ToString();
            }


            if (parameters.ContainsKey("EndSeasson"))
            {
                End_Seasson = parameters["LastName"].ToString();
            }

            if (parameters.ContainsKey("TeamID"))
            {
                Team_ID = parameters["LastName"].ToString();
            }
        }
    }
}
