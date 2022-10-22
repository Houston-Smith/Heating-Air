﻿using Microsoft.Extensions.Configuration;
using Claud.Models;
using Claud.Utils;
using System.Collections.Generic;

namespace Claud.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }


        public UserProfile GetByFirebaseUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, FirebaseUserId, Username, FirstName, LastName, 
                               Email, ServiceDate, CreateDate
                          FROM UserProfile
                         WHERE FirebaseUserId = @FirebaseuserId";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    UserProfile userProfile = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        userProfile = new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            Username = DbUtils.GetString(reader, "Username"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            ServiceDate = DbUtils.GetDateTime(reader, "ServiceDate"),
                            CreateDate = DbUtils.GetDateTime(reader, "CreateDate"),
                        };
                    }
                    reader.Close();

                    return userProfile;
                }
            }
        }


        public void Add(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserProfile (FirebaseUserId, Username, FirstName, LastName, 
                                                                 Email, ServiceDate, CreateDate)
                                        OUTPUT INSERTED.ID
                                        VALUES (@FirebaseUserId, @Username, @FirstName, @LastName, 
                                                @Email, @ServiceDate, @CreateDate)";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", userProfile.FirebaseUserId);
                    DbUtils.AddParameter(cmd, "@Username", userProfile.Username);
                    DbUtils.AddParameter(cmd, "@FirstName", userProfile.FirstName);
                    DbUtils.AddParameter(cmd, "@LastName", userProfile.LastName);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "@ServiceDate", userProfile.ServiceDate);
                    DbUtils.AddParameter(cmd, "@CreateDate", userProfile.CreateDate);

                    userProfile.Id = (int)cmd.ExecuteScalar();
                }
            }
        }


        public List<UserProfile> GetAllUsers()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         SELECT Id, Username, FirebaseUserId, FirstName, LastName, Email, ServiceDate, CreateDate
                         FROM UserProfile
                         ORDER BY FirstName";
                    var reader = cmd.ExecuteReader();
                    var users = new List<UserProfile>();

                    while(reader.Read())
                    {
                        users.Add(new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            Username = DbUtils.GetString(reader, "Username"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            ServiceDate = DbUtils.GetDateTime(reader, "ServiceDate"),
                            CreateDate = DbUtils.GetDateTime(reader, "CreateDate"),                                                    
                        });
                    }

                    reader.Close();
                    return users;
                }
            }
        }


        public UserProfile GetByUserId(int userId)
        {
            using (var conn = Connection )
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Username, FirstName, LastName, Email, ServiceDate, CreateDate
                        FROM UserProfile
                        WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", userId);
                    var reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        UserProfile profile = new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "UserId"),
                            Username = DbUtils.GetString(reader, "Username"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            Email = DbUtils.GetString(reader, "email"),
                            ServiceDate = DbUtils.GetDateTime(reader, "ServiceDate"),
                            CreateDate = DbUtils.GetDateTime(reader, "CreateDate"),
                        };
                        reader.Close();
                        return profile;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }


        public void UpdateUserProfile (UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE UserProfile
                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", userProfile.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }




        /*
        public UserProfile GetByFirebaseUserId(string firebaseUserId)
        {
            return _context.UserProfile
                       .Include(up => up.UserType) 
                       .FirstOrDefault(up => up.FirebaseUserId == firebaseUserId);
        }

        public void Add(UserProfile userProfile)
        {
            _context.Add(userProfile);
            _context.SaveChanges();
        }
        */
    }
}
