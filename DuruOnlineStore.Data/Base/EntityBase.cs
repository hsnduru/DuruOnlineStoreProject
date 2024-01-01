using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Base
{

    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
    }

    public interface IEntityBase : IEntityBase<int> { }


    public class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }

    public class EntityBase : EntityBase<int> { }

    public interface INameEntity : IEntityBase
    {
        string Name { get; set; }
    }
}
