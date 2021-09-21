#include "Fisherman.h"

FishermanEnor::FishermanEnor(const std::string &filename)
{
    f.open(filename);
    if(f.fail()) throw MissingInputFile;
}

void FishermanEnor::First()
{
    Next();
}

void FishermanEnor::Next()
{
    std::string line;
    if(std::getline(f,line))
    {
        sf = norm;
        std::stringstream s(line);
        s >> curr.name >> curr.contest;

        bool hasCaught = false;
        std::string fishName;
        double fishSize;

        while(!hasCaught && s >> fishName >> fishSize)
        {
            if(fishName == "Harcsa")
                hasCaught = true;
        }
        curr.hasCaughtCatfish = hasCaught;
    }
    else
    {
        sf = abnorm;
    }
    
}

Fisherman FishermanEnor::Current() const
{
    return curr;
}

bool FishermanEnor::End() const
{
    return sf == abnorm;
}