// 4410InternShipStudy.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std; 


vector<uint8_t> vectorBits(uint16_t val) {
	vector<uint8_t> temp; 
	temp.push_back(val & 0xff); 
	temp.push_back(val >> 8);
	return temp; 
}
uint16_t backTo16Bits(vector <uint8_t> vect) {
	 uint16_t final = ((uint16_t)vect[1] << 8) | vect[0];
	 return final; 
}

int main()
{
	uint16_t val = 65000;
	cout << backTo16Bits(vectorBits(val));
}

