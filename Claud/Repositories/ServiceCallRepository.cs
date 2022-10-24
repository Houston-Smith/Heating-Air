using Microsoft.Extensions.Configuration;
using Claud.Models;
using Claud.Utils;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Claud.Repositories
{
    public class ServiceCallRepository : BaseRepository, IServiceCallRepository
    {
        public ServiceCallRepository(IConfiguration configuration) : base(configuration) { }


        public List<ServiceCall> GetAllServiceCalls()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, LocationName, LocationAddress, DateScheduled, DateService, 
                        Notes, UserProfileId

                        FROM ServiceCall
                         ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var ServiceCalls = new List<ServiceCall>();
                        while (reader.Read())
                        {
                            var ServiceCallId = DbUtils.GetInt(reader, "Id");

                            var existingServiceCall = ServiceCalls.FirstOrDefault(p => p.Id == ServiceCallId);
                            if (existingServiceCall == null)
                            {
                                existingServiceCall = new ServiceCall()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    LocationName = DbUtils.GetString(reader, "LocationName"),
                                    LocationAddress = DbUtils.GetString(reader, "LocationAddress"),
                                    DateScheduled = DbUtils.GetDateTime(reader, "DateScheduled"),
                                    DateService = DbUtils.GetDateTime(reader, "DateService"),
                                    Notes = DbUtils.GetString(reader, "Notes"),
                                    UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                };
                                ServiceCalls.Add(existingServiceCall);
                            }
                        }
                        return ServiceCalls;
                    }
                }
            }
        }


        public ServiceCall GetServiceCallById(int serviceCallId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, LocationName, LocationAddress, DateScheduled, DateService, 
                        Notes, UserProfileId

                        FROM ServiceCall

                        WHERE r.Id = @Id
                        ";

                    cmd.Parameters.AddWithValue("@Id", serviceCallId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ServiceCall serviceCall = null;
                        if (reader.Read())
                        {
                            serviceCall = new ServiceCall()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                LocationName = DbUtils.GetString(reader, "LocationName"),
                                LocationAddress = DbUtils.GetString(reader, "LocationAddress"),
                                DateScheduled = DbUtils.GetDateTime(reader, "DateScheduled"),
                                DateService = DbUtils.GetDateTime(reader, "DateService"),
                                Notes = DbUtils.GetString(reader, "Notes"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                            };

                            return serviceCall;
                        }

                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }


        public List<ServiceCall> GetServiceCallsByUserId(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, LocationName, LocationAddress, DateScheduled, DateService, 
                        Notes, UserProfileId

                        FROM ServiceCall

                        WHERE UserProfileId = @UserProfileId
                    ";

                    cmd.Parameters.AddWithValue("@UserProfileId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var ServiceCalls = new List<ServiceCall>();
                        while (reader.Read())
                        {
                            var ServiceCallId = DbUtils.GetInt(reader, "Id");

                            var existingServiceCall = ServiceCalls.FirstOrDefault(p => p.Id == ServiceCallId);
                            if (existingServiceCall == null)
                            {
                                existingServiceCall = new ServiceCall()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    LocationName = DbUtils.GetString(reader, "LocationName"),
                                    LocationAddress = DbUtils.GetString(reader, "LocationAddress"),
                                    DateScheduled = DbUtils.GetDateTime(reader, "DateScheduled"),
                                    DateService = DbUtils.GetDateTime(reader, "DateService"),
                                    Notes = DbUtils.GetString(reader, "Notes"),
                                    UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                };
                                ServiceCalls.Add(existingServiceCall);
                            }
                        }
                        return ServiceCalls;
                    }
                }
            }
        }


        public void Add(ServiceCall serviceCall)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO ServiceCall (LocationName, LocationAddress, DateScheduled, DateService, Notes, UserProfileId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@LocationName, @LocationAddress, @DateScheduled, @DateService, @Notes, @UserProfileId)";

                    DbUtils.AddParameter(cmd, "@LocationName", serviceCall.LocationName);
                    DbUtils.AddParameter(cmd, "@LocationAddress", serviceCall.LocationAddress);
                    DbUtils.AddParameter(cmd, "@DateScheduled", serviceCall.DateScheduled);
                    DbUtils.AddParameter(cmd, "@DateService", serviceCall.DateService);
                    DbUtils.AddParameter(cmd, "@Notes", serviceCall.Notes);
                    DbUtils.AddParameter(cmd, "@UserProfileId", serviceCall.UserProfileId);

                    serviceCall.Id = (int)cmd.ExecuteScalar();
                }
            }
        }


        public void Update(ServiceCall serviceCall)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE ServiceCall
                            SET LocationName = @LocationName, LocationAddress = @LocationAddress, DateScheduled = @DateScheduled, 
                                DateService = @DateService, Notes = @Notes
                        WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@Id", serviceCall.Id);
                    DbUtils.AddParameter(cmd, "@LocationName", serviceCall.LocationName);
                    DbUtils.AddParameter(cmd, "@LocationAddress", serviceCall.LocationAddress);
                    DbUtils.AddParameter(cmd, "@DateScheduled", serviceCall.DateScheduled);
                    DbUtils.AddParameter(cmd, "@DateService", serviceCall.DateService);
                    DbUtils.AddParameter(cmd, "@Notes", serviceCall.Notes);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM ServiceCall WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }


    }
}
    
