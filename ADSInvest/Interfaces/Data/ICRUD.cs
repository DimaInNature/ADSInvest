using System.Collections.Generic;

namespace ADSInvest.Interfaces.Data
{
    public interface ICRUD<T>
    {
       bool Create(T obj);

       IEnumerable<T> ReadAll();

       bool Update(T obj);

       bool Delete(int id);
    }
}
