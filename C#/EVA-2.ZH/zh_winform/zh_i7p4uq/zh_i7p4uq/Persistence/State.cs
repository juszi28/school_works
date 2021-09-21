using System.Collections.Generic;

namespace zh_i7p4uq.Persistence
{
    public class State
    {
        public int CastleHP { get; set; }
        public int ElapsedTime { get; set; }
        public int EnemyHitCount { get; set; }
        public int SoldierCount { get; set; }
        public List<(int, int)> Enemies { get; set; }
        public int[,] Map { get; set; }

        public State(int castleHP, int elapsedTime, int enemyHitCount, int soldierCount, List<(int, int)> enemies, int[,] map)
        {
            CastleHP = castleHP;
            ElapsedTime = elapsedTime;
            EnemyHitCount = enemyHitCount;
            SoldierCount = soldierCount;
            Enemies = enemies;
            Map = map;
        }
    }
}