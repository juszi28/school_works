#include "setofints.hpp"
#include <iostream>

int SetOfInts::FindElement(int num) //gives back the index of the num
{
    unsigned int i = 0;
    while(i < vec.size() && num != vec[i])
        ++i;
    return (int)i;
}

void SetOfInts::Add(int num)
{
    if(FindElement(num) == (int)vec.size()) //check if the element is already in the set
    {
        if(num > max)
            max = num;
        vec.push_back(num);
    }
    else throw CONTAINS; // throw exception
}

void SetOfInts::Remove(int num)
{
    int index = FindElement(num);
    if(index != (int)vec.size()) //check if the element is in the set
    {
        if(num == max)
        {
            int tmpMax = INT32_MIN;
            for (unsigned int i = 0; i < vec.size(); i++)
            {
                if(vec[i] > tmpMax && vec[i] < max)
                {
                    tmpMax = vec[i];
                }
            }
            max = tmpMax;
        }
        vec.erase(vec.begin() + index);
    }
    else throw NOTIN;  //throw exception
}

int SetOfInts::MaxValue() const
{
    if(vec.size() != 0)
        return max;
    else throw EMPTY;
}

std::ostream& operator<<(std::ostream& os, const SetOfInts& a)
{
    for(unsigned int i=0; i< a.vec.size(); ++i){
        os << a.vec[i] << " ";
    }
    os << std::endl;
    return os;
}