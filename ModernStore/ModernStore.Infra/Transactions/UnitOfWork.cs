using ModernStore.Infra.Contexts;
using System;

namespace ModernStore.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ModernStoreDataContext _context;

        public UnitOfWork(ModernStoreDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //faz nada, o EF ja deixa a transaction morrer
        }
    }
}
