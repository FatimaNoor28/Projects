#include <iostream>
#include <fstream>
#include <iomanip>
#include <string>

using namespace std;
/*  This assembler program gives the binary of three types of assembly instructions:
    1)  computation ; jump
    2)  destination = computation
    3)  destination = computation ; jump
    Moreover, this program does not generate error message in case of any other instruction or error
    It removes the comments, the spaces in an instruction, removes empty lines
    and generate binary of the assembly instruction
*/

ifstream(file1);
ofstream(file2);
// the remove_comment function removes the comments part as soon as it finds "//" in the instruction
string remove_comment(string line){
    if(!line.empty())
    if(line.find("//")!=string::npos)
    line.erase(line.find("//"),line.length());
    return line;
}
// the decToBinary function generates the binary of the integer in case of @integer instruction
void decToBinary(int n){
    int binaryNum[15]={0};
    int i = 0;
    while (n > 0) {
        binaryNum[i] = n % 2;
        n = n / 2;
        i++;
    }
    for (int i = 14; i >= 0; i--)
        file2 << binaryNum[i];
    file2<<"\n";
}
//the removeSpaces function removes the empty spaces in a string
string removeSpaces(string line){
    int i = 0, j = 0;
    for(i=0;i<line.size();i++){
        if (line[i] == ' ')
            line.erase(line.begin()+i);
        line[j++] = line[i];
    }
    line[j] = '\0';
    return line;
}
// a_check checks if an instruction is A or M.
// It returns true if the comp contains any of the A instructions otherwise it returns false
bool a_check(string p2){
    if((p2=="M") || (p2=="!M") || (p2=="-M") || (p2=="M+1") || (p2=="M-1") || (p2=="D+M") || (p2=="D-M") || (p2=="M-D") || (p2=="D&M") || (p2=="D|M"))
        return true;
    return false;
}
// d_check checks the destination part of the instruction
void d_check(string part1){
    if(part1=="M")          file2<<"001";
    else if(part1=="D")     file2<<"010";
    else if(part1=="MD")    file2<<"011";
    else if(part1=="A")     file2<<"100";
    else if(part1=="AM")    file2<<"101";
    else if(part1=="AD")    file2<<"110";
    else if(part1=="AMD")   file2<<"111";
    else file2<<"000";
}
//c_check checks the computation part and generates binary according to it
void c_check(string part2){
    if(part2=="0")                               file2<<"101010";
    else if(part2=="1")                          file2<<"111111";
    else if(part2=="-1")                         file2<<"111010";
    else if(part2=="D")                          file2<<"001100";
    else if((part2=="A")    || (part2=="M"))     file2<<"110000";
    else if(part2=="!D")                         file2<<"001101";
    else if((part2=="!A")   || (part2=="!M"))    file2<<"110001";
    else if(part2=="-D")                         file2<<"001111";
    else if((part2=="-A")   || (part2=="-M"))    file2<<"110011";
    else if(part2=="D+1")                        file2<<"011111";
    else if((part2=="A+1")  || (part2=="M+1"))   file2<<"110111";
    else if(part2=="D-1")                        file2<<"001110";
    else if((part2=="A-1")  || (part2=="M-1"))   file2<<"110010";
    else if((part2=="D+A")  || (part2=="D+M"))   file2<<"000010";
    else if((part2=="D-A")  || (part2=="D-M"))   file2<<"010011";
    else if((part2=="A-D")  || (part2=="M-D"))   file2<<"000111";
    else if((part2=="D&A")  || (part2=="D&M"))   file2<<"000000";
    else if((part2=="D|A")  || (part2=="D|M"))   file2<<"010101";
}
//j_check checks the jump part of the instruction and generates its 3 digit binary according to it
void j_check(string part3){
    if(part3=="JGT")        file2<<"001";
    else if(part3=="JEQ")   file2<<"010";
    else if(part3=="JGE")   file2<<"011";
    else if(part3=="JLT")   file2<<"100";
    else if(part3=="JNE")   file2<<"101";
    else if(part3=="JLE")   file2<<"110";
    else if(part3=="JMP")   file2<<"111";
    else file2<<"000";
}
// check_type_1 checks " dest = comp ; jump " this type of instructions and call functions
//to generate binary for destination , jump and computation accordingly
void check_type_1(string line){
    string part1,part2,part3;
    part1 = line.substr(0,line.find('='));
    part2 = line.substr(line.find('=')+1,line.find(';')-2);
    part3 = line.substr(line.find(';')+1,line.find("\n")-1);
    //cout<<part1<<"\n"<<part2<<"\n"<<part3<<"\n";
    if(a_check(part2))
        file2<<1;
    else
        file2<<0;
    c_check(part2);
    d_check(part1);
    j_check(part3);
}
//check_type_2 checks this type of instruction : "destination = computation"
//and calls the other function to generate binary according to it
void check_type_2(string line){
    string part1,part2,part3;
    part1 = line.substr(0,line.find('='));
    part2 = line.substr(line.find('=')+1,line.find("\n")-1);
    part3 = {0};
    //cout<<part1<<"\n"<<part2<<"\n"<<part3<<"\n";
    if(a_check(part2))
        file2<<1;
    else
        file2<<0;
    c_check(part2);
    d_check(part1);
    j_check(part3);
}
// check_type_3 checks this type of instructions: "computation ; jump "
//and calls functions to generate its binary according to it and stores the binary in the output file
void check_type_3(string line){
    string part1,part2,part3;
    part2 = line.substr(0,line.find(';'));
    part3 = line.substr(line.find(';')+1,line.find("\n")-1);
    part1 = {0};
    //cout<<part1<<"\n"<<part2<<"\n"<<part3<<"\n";
    if(a_check(part2))
        file2<<1;
    else
        file2<<0;
    c_check(part2);
    d_check(part1);
    j_check(part3);
}
//this function checks the type of instruction and transfers the flow to required function
//to perform further operations according to it
// this function is called only if the instruction is not an A instruction i.e. it does not contain the address (like @20)
void operation_call(string line){
    char character1 = '=';
    char character2 = ';';
    line = remove_comment(line);
    line = removeSpaces(line);
    int i,j;
    for(i=0;i<line.size();i++){
        if(line[i]=='='||line[i]=='\0')
            break;
    }
    for(j=0;j<line.size();j++){
        if(line[j]==';'||line[j]=='\0')
            break;
    }
    if(line[i]!='\0' && line[j]!='\0'){
        check_type_1(line);
    }
    else if(line[i]!='\0' && line[j]=='\0'){
        check_type_2(line);
    }
    else if(line[i]=='\0' && line[j]!='\0'){
        check_type_3(line);
    }
    file2<<"\n";
}
//this function contains the instructions to read the lines of the file one by one 
//and calls remove space and remove comments function to make it easy to convert
//then it checks if the line contains '@' symbol i.e. an A instruction, if yes then converts 
//the integer part to binary and stores it in file
void operations(){
	int flag;
	string line;
	while(getline(file1,line)){
        line = remove_comment(line);
        line = removeSpaces(line);
        if(line=="\0")
            continue;
        for(int i=0;i<line.length();i++){
            if(line[i]=='@'){
                flag = 1;
                file2<<0;
                line = line.substr(line.find("@")+1);
                stringstream geek(line);
                int value=0;
                geek>>value;
                decToBinary(value);
                break;

            }
            else
                flag = 0;
        }
        if(flag==0){
            file2<<111;
            operation_call(line);
        }
    }
}
//main function just contains the instructions to open and close the files and to call the function containing all the operations
int main(){
    file1.open("file.asm");
    file2.open("file.hack");
    operations();
    file1.close();
    file2.close();
    return 0;
}
