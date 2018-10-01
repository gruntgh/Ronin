using System;
using System.Collections.Generic;
using System.Text;

namespace Ronin.Data
{
    public interface IDataModel<TObject, TId>
    {
        void Add(TObject item);
        IEnumerable<TObject> Get();
        TObject Get(TId id);
        TObject Update(TObject item);
        void Delete(TObject item);
    }
}
