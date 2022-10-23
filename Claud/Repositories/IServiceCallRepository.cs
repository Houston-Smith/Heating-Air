using Claud.Models;
using System.Collections.Generic;

namespace Claud.Repositories
{
    public interface IServiceCallRepository
    {
        void Add(ServiceCall serviceCall);
        void Delete(int id);
        List<ServiceCall> GetAllServiceCalls();
        ServiceCall GetServiceCallById(int serviceCallId);
        List<ServiceCall> GetServiceCallsByUserId(int userId);
        void Update(ServiceCall serviceCall);
    }
}
