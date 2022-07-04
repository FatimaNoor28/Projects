#include <iostream>
#include <iomanip>
#include <fstream>
#include <string>
using namespace std;
class Flower_Pack{
public:
	string fname;
	string gift;
	int price;
	string color;
	Flower_Pack(){
	}
	Flower_Pack(string fname, string gift, string color, int price){
        	this->fname=fname;
        	this->gift=gift;
        	this->color=color;
        	this->price = price;
    	}
	void SetFlowerPack(string fname, string gift, string color, int price){
	        this->fname=fname;
	        this->gift=gift;
	        this->color=color;
            this->price = price;
	}
friend ostream& operator << (ostream &out,const Flower_Pack &f);
friend istream& operator >> (istream &in, Flower_Pack &f);
};
ostream& operator << (ostream &out,const Flower_Pack &f){
        out<<setw(15)<<left<<f.fname<<setw(15)<<left<<f.gift<<setw(15)<<left<<f.color<<setw(15)<<left<<f.price<<"\n";
        return out;
}
istream& operator >> (istream &in, Flower_Pack &f){
        cout<<"Flower Name:";
        in>>f.fname;
        cout<<"gift:";
        in>>f.gift;
        cout<<"Color:";
        in>>f.color;
        cout<<"price:";
        in>>f.price;
        return in;
}


