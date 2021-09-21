#pragma once
#include <iostream>
#include <vector>

class SetOfInts{
public:
    enum Exceptions{ CONTAINS, NOTIN, EMPTY };

    SetOfInts() { std::vector<int> vec ; max = INT32_MIN; }

    void Add(int num);
    void Remove(int num);
    bool IsEmpty() const { return vec.size() == 0; };
    int MaxValue() const;
    int FindElement(int num);
    friend std::ostream& operator<< (std::ostream& os, const SetOfInts& a);

private:
    std::vector<int> vec;
    int max;
};