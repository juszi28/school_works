using System;
using System.Threading.Tasks;

namespace Awari.Persistence
{
    public interface IAwariDataAccess
    {
        Task<(int, int, bool, int, int[])> LoadAsync(string path);
        Task SaveAsync(string path, int[] table, int currentPlayer, int secondturn, int lastplayer);
    }
}
