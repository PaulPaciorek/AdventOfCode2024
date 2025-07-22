/******************************************************************************

                            Online C# Compiler.
                Code, Compile, Run and Debug C# program online.
Write your code in this editor and press "Run" button to execute it.

*******************************************************************************/

using System;
using System.IO;

class HelloWorld {
    
  public static int[,] fileToArrays(StreamReader locFile) {
      int[,] twoLists = new int[2, 1000];
      for (int i=0; i<1000; i++) {
          string line = locFile.ReadLine();
          int ind=0, num1=0, num2=0;
          char c = line[0];
          while (c != ' ') {
              num1 = (num1 * 10) + ((int)c - 48); 
              ind++;
              c = line[ind];
          }
          twoLists[0, i] = num1;
          while (c == ' ') {
              ind++;
              c = line[ind];
          }
          while (ind < line.Length) {
              c = line[ind];
              num2 = (num2 * 10) + ((int)c - 48);
              ind++;
          }
          twoLists[1, i] = num2;
      }
      return twoLists;
  }
  
  public static int findNextDistance(int[,] doubleList) {
      int indOne=0, indTwo=0;
      while (doubleList[0, indOne] == -1) {
          indOne++;
      }
      while (doubleList[1, indTwo] == -1) {
          indTwo++;
      }
      int minOne=doubleList[0, indOne], minTwo=doubleList[1, indTwo];
      for (int i=indOne; i<1000; i++) {
          int numOne = doubleList[0, i];
          if ((numOne < minOne) && (numOne != -1)) {
              indOne = i;
              minOne = numOne;
          }
      }
      doubleList[0, indOne] = -1;
      for (int j=indTwo; j<1000; j++) {
          int numTwo = doubleList[1, j];
          if ((numTwo < minTwo) && (numTwo != -1)) {
              indTwo = j;
              minTwo = numTwo;
          }
      }
      doubleList[1, indTwo] = -1;
      if (minOne >= minTwo) {
          return (minOne - minTwo);
      } else {
          return (minTwo - minOne);
      }
  }
  
  public static int findTotalDistance(int[,] doubleList) {
      int distSum=0;
      for (int i=0; i<1000; i++) {
        distSum += findNextDistance(doubleList);
      }
      return distSum;
  }
    
  static void Main() {
    StreamReader locationFile = new StreamReader("LocationList.txt");
    int[,] locations = fileToArrays(locationFile);
    Console.Write(findTotalDistance(locations));
  }
}
