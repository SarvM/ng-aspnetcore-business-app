
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using ng_core_api.Entities;


namespace ng_core_api.Services
{
    public class TourManagementRepository : ITourManagementRepository
    {
        private string _connectionString;
        public TourManagementRepository(IConfiguration configuration){
            _connectionString = configuration.GetConnectionString("ManagementDB");
        }
        public async Task<IEnumerable<Band>> GetBands()
        {
            IEnumerable<Band> bands = null;

            try{

                using(var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var query = @"select BandId, Name, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn from Bands with(nolock)";
                    bands = await connection.QueryAsync<Band>(query);
                }
            }
            catch(Exception)
            {
                //Console.WriteLine(ex.Message);
            }

            return bands;
        }

        public async Task<IEnumerable<Manager>> GetManagers()
        {
            IEnumerable<Manager> managers = null;

            try
            {
                using(var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var query = @"select ManagerId, [Name], CreatedOn, CreatedBy, UpdatedOn, UpdatedBy from Managers with(nolock)";
                    managers = await connection.QueryAsync<Manager>(query);
                }
            }
            catch(Exception)
            {
                
            }

            return managers;
        }

        public async Task<IEnumerable<Tour>> GetTours()
        {
            IEnumerable<Tour> tours = null;

            try
            {
                using(var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var query = @"SELECT 
                                    T.TourId, T.BandId, T.Title, T.[Description], T.StartDate, T.EndDate, T.EstimatedProfits,
                                    T.ManagerId, T.CreatedOn, T.CreatedBy, T.UpdatedOn, T.UpdatedBy,
                                    M.ManagerId, M.Name, B.BandId, B.Name 
                                FROM 
                                    Tours T 
                                    INNER JOIN Managers M ON M.ManagerId = T.ManagerId
                                    INNER JOIN Bands B ON B.BandId = T.BandId";

                    tours = await connection.QueryAsync<Tour, Manager, Band, Tour>(query, 
                                            (tour, manager, band) => {
                                                tour.Manager = manager;
                                                tour.Band = band;
                                                return tour;
                                            }, splitOn: "ManagerId, BandId");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return tours;
        }

        public async Task<Tour> GetTour(string tourId)
        {
            Tour tour = null;
            
            try
            {
                using(var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var query = @"SELECT 
                        T.TourId, T.BandId, T.Title, T.[Description], T.StartDate, T.EndDate, T.EstimatedProfits,
                        T.ManagerId, T.CreatedOn, T.CreatedBy, T.UpdatedOn, T.UpdatedBy,
                        M.ManagerId, M.Name, B.BandId, B.Name 
                    FROM 
                        Tours T 
                        INNER JOIN Managers M ON M.ManagerId = T.ManagerId
                        INNER JOIN Bands B ON B.BandId = T.BandId WHERE T.TourId = @tourId";

                    var result = await connection.QueryAsync<Tour, Manager, Band, Tour>(query, 
                        (t, m, b) => {
                            t.Manager = m;
                            t.Band = b;
                            return t;
                        }, new { @tourId = tourId }, splitOn: "ManagerId, BandId");

                    tour = result.AsList().ToArray()[0];
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return tour;
        }
    }
}