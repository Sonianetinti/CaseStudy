using CarWashBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashBackEnd.Repository
{
    internal interface IPackageRepository<TEntity>
    {
        IEnumerable<TEntity> Get();

        Package GetById(int id);

        void Add(TEntity user);

        void Delete(int Id);

        void Update(int Id, Package package);
        void SaveChanges();
    }
}
