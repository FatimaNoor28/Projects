#include <iostream>
#include <iomanip>
#include "FlowerPack.cpp"
class Florist{
	Flower_Pack pack;
	static int count;
	string order_taker;
public:
	Florist(){
	    count++;
	}
	Florist(string order_taker,string fname, string gift, string color, int price){
	this->order_taker=order_taker;
	pack.SetFlowerPack(fname,gift,color,price);
	}
	void set(string order_taker,string fname, string gift, string color, int price){
        	pack.SetFlowerPack(fname,gift,color,price);
        	this->order_taker = order_taker;
    }
    void setFlower(string fname){
        this->pack.fname = fname;
    }
    void setGift(string gift){
        this->pack.gift = gift;
    }
    void setColor(string color){
        this->pack.color = color;
    }
    void setPrice(int price){
        this->pack.price = price;
    }
    string get_order_taker(){
        return order_taker;
    }
    string getFlowerName(){
        return pack.fname;
    }
    string getGift(){
        return pack.gift;
    }
    string getColor(){
        return pack.color;
    }
    int getPrice(){
        return pack.price;
    }
    int get_count(){
        return count;
    }
    ~Florist(){
        count--;
    }
friend void choices();
friend istream& operator >> (istream &in, Florist &ft);
friend ostream& operator << (ostream &out, const Florist &ft);
};
int Florist::count = 0;
istream& operator >> (istream &in, Florist &ft){
	cout<<"Order Taker's Name: ";
	in>>ft.order_taker;
	in>>ft.pack;
	return in;
}
ostream& operator << (ostream &out, const Florist &ft){
	out<<setw(15)<<left<<ft.order_taker;
	out<<ft.pack;
	return out;
}
