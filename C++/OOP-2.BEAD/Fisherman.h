#pragma once

#include<fstream>
#include<string>
#include<sstream>

struct Fisherman
{
    std::string name;
    std::string contest;
    bool hasCaughtCatfish;
};

class FishermanEnor
{
public:
    enum FileError{MissingInputFile};
    FishermanEnor(const std::string &filename);

    void First();
    void Next();
    Fisherman Current() const;
    bool End() const;
private:
    std::ifstream f;
    Fisherman curr;
    enum Status
    {
        norm,
        abnorm
    };
    Status sf;
};