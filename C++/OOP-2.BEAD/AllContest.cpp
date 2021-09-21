#include "AllContest.h"
#include <iostream>

FishermanContestEnor::FishermanContestEnor(const std::string &filename) : actFM(filename)
{
}

void FishermanContestEnor::First()
{
    actFM.First();
    Next();
}

void FishermanContestEnor::Next()
{
    if(!(end = actFM.End()))
    {
        curr.name = actFM.Current().name;
        curr.allContest = true;
        while(!actFM.End() && actFM.Current().name == curr.name)
        {
            if(actFM.Current().hasCaughtCatfish != true)
                curr.allContest = false;
            actFM.Next();
        }
    }
}

FishermanContest FishermanContestEnor::Current() const
{
    return curr;
}

bool FishermanContestEnor::End() const
{
    return end;
}