using System;
using System.Collections;

struct OWWQ3{
   
   
   
}

class LangException : Exception
{
    private String eMessage;

    public LangException(string message)
    {
       eMessage = message;
    }
    
    public String getMessage() {
       return eMessage;
    }

}


class OWWQ3Runner
{
   public double numBinopHandle(String op, double num1, double num2) {
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
            LangException ex = new LangException("Divide by zero exception");
            throw ex;
         }
         else {
            return num1 / num2;
         }
         
      }
      else {
         LangException ex = new LangException("Bad num binop");
         throw ex;
      }
   }
   
   public bool booleanBinopHandle(String op, Object prim1, Object prim2) {
      Type prim1Type = prim1.GetType();
      Type prim2Type = prim2.GetType();
      if (op.Equals("<=", StringComparison.Ordinal)) {
         if (prim1Type.Equals(typeof(double)) && prim2Type.Equals(typeof(double))) {
            double num1 = (double)prim1;
            double num2 = (double)prim2;
            if (num1 <= num2) { 
               return true;
            }
            else {
               return false;
            }
         }
         else {
            LangException ex = new LangException("Both types for <= must be doubles");
            throw ex;
         }
      }
      else if (op.Equals("eq?", StringComparison.Ordinal)) {
         if (!prim1Type.Equals(prim2Type)) {
            return false;
         }
         else if (prim1Type.Equals(typeof(double))) {
            double num1 = (double)prim1;
            double num2 = (double)prim2;
            
            if (num1 == num2) {
               return true;
            }
            else {
               return false;
            }
         }
         else {
            bool bool1 = (bool)prim1;
            bool bool2 = (bool)prim2;
            
            if (bool1 == bool2) {
               return true;
            }
            else {
               return false;
            }
         }
         
      }
      else {
         LangException ex = new LangException("Bad boolean binop");
         throw ex;
      }
   }

   static void Main(string[] args) {
      

      Console.WriteLine("hello, world");
   }
}
