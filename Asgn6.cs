using System;
using System.Collections;

struct OWWQ3{
   public int numBinopHandle(String op, int num1, int num2) {
      if (op.Equals("+", StringComparison.Ordinal)) {
         return num1 + num2;
      }
      else if (op.Equals("-", StringComparison.Ordinal)) {
         return num1 - num2;
      }
      else if (op.Equals("*", StringComparison.Ordinal)) {
         return num1 * num2;
      }
      else if (op.Equals("/", StringComparison.Ordinal)) {
         if (num2 == 0) {
         
         }
         else {
            return num1 / num2;
         }
         
      }
      else {
      
      }
   }
   
   public boolean booleanBinopHandle(String op, int num1, int num2) {
}


class OWWQ3Runner
{
   

   static void Main(string[] args) {
      

      Console.WriteLine("hello, world");
   }
}
