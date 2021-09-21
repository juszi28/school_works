using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace zh_i7p4uq.Persistence
{
    class FilePersistence : IPersistence
    {
        public async Task<State> LoadAsync(string path)
        {
            try
            {
                using(StreamReader reader = new StreamReader(path))
                {
                    String line = await reader.ReadLineAsync();
                    String[] parts = line.Split(' ');
                    int castleHP = int.Parse(parts[0]);

                    line = await reader.ReadLineAsync();
                    parts = line.Split(' ');
                    int elapsedTime = int.Parse(parts[0]);

                    line = await reader.ReadLineAsync();
                    parts = line.Split(' ');
                    int enemyHitCount = int.Parse(parts[0]);

                    line = await reader.ReadLineAsync();
                    parts = line.Split(' ');
                    int soldierCount = int.Parse(parts[0]);

                    line = await reader.ReadLineAsync();
                    parts = line.Split(' ');
                    int enemiesCount = int.Parse(parts[0]);

                    List<(int, int)> enemies = new List<(int, int)>();

                    for (int i = 0; i < enemiesCount; ++i)
                    {
                        line = await reader.ReadLineAsync();
                        parts = line.Split(' ');
                        enemies.Add((int.Parse(parts[0]), int.Parse(parts[1])));
                    }

                    int[,] map = new int[10, 10];

                    for (int i = 0; i < 10; i++)
                    {
                        line = await reader.ReadLineAsync();
                        parts = line.Split(' ');
                        for (int j = 0; j < 10; j++)
                        {
                            map.SetValue(int.Parse(parts[j]), i, j);
                        }
                    }
                    return new State(castleHP, elapsedTime, enemyHitCount, soldierCount, enemies, map);
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task SaveAsync(string path, State table)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    await writer.WriteLineAsync(table.CastleHP.ToString());
                    await writer.WriteLineAsync(table.ElapsedTime.ToString());
                    await writer.WriteLineAsync(table.EnemyHitCount.ToString());
                    await writer.WriteLineAsync(table.SoldierCount.ToString());
                    await writer.WriteLineAsync(table.Enemies.Count.ToString());

                    for(int i = 0; i < table.Enemies.Count; ++i)
                    {
                        await writer.WriteLineAsync(table.Enemies[i].Item1 + " " + table.Enemies[i].Item2);
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            await writer.WriteAsync(table.Map[i, j].ToString() + " ");
                        }
                        await writer.WriteLineAsync();
                    }
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
