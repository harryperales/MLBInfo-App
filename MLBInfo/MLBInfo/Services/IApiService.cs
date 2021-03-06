﻿using MLBInfo.Models;
using MLBPlayersApp.Models;
using MLBTeamsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MLBPlayersApp.Services
{
    public interface IApiService
    {
        Task<IList<Team>> GetTeamsList(string season);
        Task<List<Player>> GetPlayersList(string search);

        Task<PlayerData> GetPlayerData(string id);
        Task<IList<Row>> GetRowData(string teamId);

        Task<List<Game>> GetUpcomingGames();
    }
}
