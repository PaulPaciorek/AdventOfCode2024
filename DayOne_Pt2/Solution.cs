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
  
  public static int findNextSimScore(int ind, int[,] doubleList) {
      int simCount=0, targ=doubleList[0, ind];
      for (int i=0; i<1000; i++) {
          if (targ == doubleList[1, i]) simCount++;
      }
      return (simCount*targ);
  }
  
  public static int findTotalSimScore(int[,] doubleList) {
      int simScoreSum=0;
      for (int i=0; i<1000; i++) {
         simScoreSum += findNextSimScore(i, doubleList);
      }
      return simScoreSum;
  }
    
  static void Main() {
    StreamReader locationFile = new StreamReader("LocationList.txt");
    int[,] locations = fileToArrays(locationFile);
    Console.Write(findTotalSimScore(locations));
  }
