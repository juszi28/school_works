namespace zh_i7p4uq.Model
{
    public class RefreshArgs
    {
        public int CastleHP { get; set; }
        public int SoldierCount { get; set; }
        public int[,] Map { get; set; }
        public int ElapsedTime { get; set; }
        public RefreshArgs(int castleHP, int soldierCount, int[,] map, int elapsedTime)
        {
            CastleHP = castleHP;
            SoldierCount = soldierCount;
            Map = map;
            ElapsedTime = elapsedTime;
        }
    }
}