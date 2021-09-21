#include "Fisherman.h"
#include "AllContest.h"
#include <iostream>

int countTheRows(const std::string &name)
{
    FishermanEnor fishE(name);
    int count = 0;
    for(fishE.First(); !fishE.End(); fishE.Next())
    {
        if(fishE.Current().hasCaughtCatfish)
            ++count;
    }
    return count;
}

bool searchForAllContest(const std::string &name, std::string &fishermanname)
{
    FishermanContestEnor fishCE(name);
    bool wasThere = false;
    for(fishCE.First(); !wasThere && !fishCE.End(); fishCE.Next())
    {
        wasThere = fishCE.Current().allContest;
        fishermanname = fishCE.Current().name;
    }
    return wasThere;
}

//#define NORMAL_MODE
#ifdef NORMAL_MODE

int main()
{
    std::string filename;
    std::cout << "Enter the name of the input file: "; std::cin >> filename;

    //First task
    std::cout << "First task\n";
    try{
        int count = countTheRows(filename);
        std::cout << "There was " << count << " lines that contained \"Harcsa\"" << std::endl;
    } catch(FishermanEnor::FileError e){
        std::cerr << "Can't find an input file like this: " << filename << std::endl;
    }

    //Second task
    std::cout << "Second task\n";
    try{
        std::string id;
        if(searchForAllContest(filename, id)) 
            std::cout << "There was a fisherman who fished \"Harcsa\" in every contest: " << id << std::endl;
        else
            std::cout << "There wasn't a fisherman who could fish \"Harcsa\" in every contest." << std::endl;  
    } catch(FishermanEnor::FileError e){
        std::cerr << "Can't find an input file like this: " << filename << std::endl;
    }
}

#else
#define CATCH_CONFIG_MAIN
#include "catch.hpp"

//count first task

TEST_CASE("first task empty file", "tf0.txt")
{
    REQUIRE(countTheRows("tf0.txt") == 0);
}

TEST_CASE("first task 1 fisherman, no catfish", "tf1.txt")
{
    REQUIRE(countTheRows("tf1.txt") == 0);
}

TEST_CASE("first task 1 fisherman, fished catfish", "tf2.txt")
{
    REQUIRE(countTheRows("tf2.txt") == 1);
}

TEST_CASE("first task more fishermen one competition, 0 catfish", "tf3.txt")
{
    REQUIRE(countTheRows("tf3.txt") == 0);
}

TEST_CASE("first task more fishermen one competition, only 1 catfish(first)", "tf4.txt")
{
    REQUIRE(countTheRows("tf4.txt") == 1);
}

TEST_CASE("first task more fishermen one competition, only 1 catfish(last)", "tf4.txt")
{
    REQUIRE(countTheRows("tf4.txt") == 1);
}

TEST_CASE("first task more fishermen one competition, everybody fished catfish", "tf5.txt")
{
    REQUIRE(countTheRows("tf5.txt") == 4);
}

TEST_CASE("first task more fishermen more competition, nobody fished catfish", "tf6.txt")
{
    REQUIRE(countTheRows("tf6.txt") == 0);
}

TEST_CASE("first task more fishermen more competition, everybody fished catfish", "tf7.txt")
{
    REQUIRE(countTheRows("tf7.txt") == 6);
}

//testing hasCaughtCatFish

TEST_CASE("empty file", "tf0.txt")
{
    FishermanEnor fe("tf0.txt");
    fe.First();
    REQUIRE_FALSE(fe.Current().hasCaughtCatfish);
}

TEST_CASE("no catfish caught", "tf1.txt")
{
    FishermanEnor fe("tf1.txt");
    fe.First();
    REQUIRE_FALSE(fe.Current().hasCaughtCatfish);
}

TEST_CASE("catfish caught", "tf2.txt")
{
    FishermanEnor fe("tf2.txt");
    fe.First();
    REQUIRE(fe.Current().hasCaughtCatfish);
}

//linear search second task

TEST_CASE("second task empty file", "tf0.txt")
{
    std::string id;
    REQUIRE_FALSE(searchForAllContest("tf0.txt",id));
}

TEST_CASE("second task 1 fisherman 1 competition, no catfish", "tf1.txt")
{
    std::string id;
    REQUIRE_FALSE(searchForAllContest("tf1.txt", id));
}

TEST_CASE("second task 1 fisherman 1 competition, catfish", "tf2.txt")
{
    std::string id;
    REQUIRE(searchForAllContest("tf2.txt", id));
    REQUIRE(id == "JANIBA");
}

TEST_CASE("second task more fishermen 1 competition, no catfish", "tf3.txt")
{
    std::string id;
    REQUIRE_FALSE(searchForAllContest("tf3.txt", id));
}

TEST_CASE("second task more fishermen 1 competition, but only one caught catfish, the first", "tf4.txt")
{
    std::string id;
    REQUIRE(searchForAllContest("tf4.txt", id));
    REQUIRE(id == "JANIBA");
}

TEST_CASE("second task more fishermen 1 competition, but only one caught catfish, the last", "tf8.txt")
{
    std::string id;
    REQUIRE(searchForAllContest("tf8.txt", id));
    REQUIRE(id == "ZSOLTI");
}

TEST_CASE("second task more fishermen more competition, nobody caught catfish", "tf6.txt")
{
    std::string id;
    REQUIRE_FALSE(searchForAllContest("tf6.txt", id));
}

TEST_CASE("second task more fishermen more competition, nobody caught catfish in every competition", "tf9.txt")
{
    std::string id;
    REQUIRE_FALSE(searchForAllContest("tf9.txt", id));
}

TEST_CASE("second task more fishermen more competition, the first caught catfish in every competition", "tf10.txt")
{
    std::string id;
    REQUIRE(searchForAllContest("tf10.txt", id));
    REQUIRE(id == "JANIBA");
}

TEST_CASE("second task more fishermen more competition, the last caught catfish in every competition", "tf11.txt")
{
    std::string id;
    REQUIRE(searchForAllContest("tf11.txt", id));
    REQUIRE(id == "ZSOLTI");
}

TEST_CASE("second task more fishermen more competition, more men caught catfish in every competition", "tf12.txt")
{
    std::string id;
    REQUIRE(searchForAllContest("tf12.txt", id));
    REQUIRE(id == "POTTER");
}

//optimist linear search

TEST_CASE("no contest", "tf0.txt")
{
    FishermanContestEnor fce("tf0.txt");
    fce.First();
    REQUIRE_FALSE(fce.Current().allContest);
}

TEST_CASE("1 fisherman, 1 contest, no catfish", "tf1.txt")
{
    FishermanContestEnor fce("tf1.txt");
    fce.First();
    REQUIRE_FALSE(fce.Current().allContest);
}

TEST_CASE("1 fisherman, 1 contest, caught catfish", "tf2.txt")
{
    FishermanContestEnor fce("tf2.txt");
    fce.First();
    REQUIRE(fce.Current().allContest);
}

TEST_CASE("1 fisherman, more contest, no catfish at all", "tf13.txt")
{
    FishermanContestEnor fce("tf13.txt");
    fce.First();
    REQUIRE_FALSE(fce.Current().allContest);
}

TEST_CASE("1 fisherman, more contest, has caught catfish but not in all", "tf14.txt")
{
    FishermanContestEnor fce("tf14.txt");
    fce.First();
    REQUIRE_FALSE(fce.Current().allContest);
}

TEST_CASE("1 fisherman, more contest, has caught catfish in all", "tf15.txt")
{
    FishermanContestEnor fce("tf15.txt");
    fce.First();
    REQUIRE(fce.Current().allContest);
}

#endif