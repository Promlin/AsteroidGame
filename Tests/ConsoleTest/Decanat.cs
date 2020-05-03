
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class Decanat : EntityStorage<Student>
    {

    }

    internal abstract class EntityStorage<TEntity> : Storage<TEntity> 
        where TEntity : IEntity
    {
        private int _MaxId = 1;
        public override void Add(TEntity item)
        {
            item.Id = _MaxId++;
            base.Add(item);
        }
    }
}
