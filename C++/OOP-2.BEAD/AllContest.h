#pragma once
#include "Fisherman.h"
#include<string>

struct FishermanContest
{
    std::string name;
    bool allContest;
};

class FishermanContestEnor
{
public:
    FishermanContestEnor(const std::string &filename);
    void First();
    void Next();
    FishermanContest Current() const;
    bool End() const;
private:
    FishermanContest curr;
    FishermanEnor actFM;
    bool end;
};