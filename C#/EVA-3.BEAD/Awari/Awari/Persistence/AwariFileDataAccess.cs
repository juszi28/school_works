using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Awari.Persistence
{
    public class AwariFileDataAccess : IAwariDataAccess
    {
        public async Task<(int, int, bool, int, int[])> LoadAsync(string path)
        {
            try
            {
                using(StreamReader reader = new StreamReader(path))
                {
                    String line = await reader.ReadLineAsync();
                    String[] parts = line.Split(' ');
                    int binNumber = int.Parse(parts[0]);
                    int currentPlayer = int.Parse(parts[1]);
                    bool secondturn = (int.Parse(parts[2]) == 1) ? true : false;
                    int lastplayer = int.Parse(parts[3]);
                    int[] table = new int[binNumber + 2];

                    for(int i = 0; i < table.Length; ++i)
                    {
                        table[i] = int.Parse(parts[i + 4]);
                    }

                    return (binNumber, currentPlayer, secondturn, lastplayer, table);
                }
            }
            catch
            {
                throw new AwariDataException();
            }
        }

        public async Task SaveAsync(string path, int[] table, int currentplayer, int secondturn, int lastplayer)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(path))
                {
                    int binNumber = (table.Length - 2); 
                    await sw.WriteAsync(binNumber + " " + currentplayer + " " + secondturn + " " + lastplayer); //kiírjuk a tálkák számát és a soron következő játékost és hogy második köre ez valakinek
                    for (int i = 0; i < table.Length; ++i)
                    {
                        await sw.WriteAsync(" " + table[i]); //kiírjuk az aktuális állást
                    }
                }
            }
            catch 
            {
                throw new AwariDataException();
            }
        }
    }
}
