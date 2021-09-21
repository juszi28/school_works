using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace zh_i7p4uq.Persistence
{
    interface IPersistence
    {
        Task<State> LoadAsync(string path);
        Task SaveAsync(string path, State table);
    }
}
