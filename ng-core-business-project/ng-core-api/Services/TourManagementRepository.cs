
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
        public async Task<IEnumerable<Band>> GetBands(){
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
    }
}