using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer GetByDocument(string document);
        Customer GetByUserId(Guid id);
        void Update(Customer customer);
        void Save(Customer customer);
        bool DocumentExists(string document);
    }
}
