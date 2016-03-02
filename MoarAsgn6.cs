using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{

    public interface ExprC{}

    public interface Value
    {
        string toString();
    }

    public class numV : Value
    {
        public double number;

        public numV(double number)
        {
            this.number = number;
        }

        public String toString()
        {
            return number.ToString();
        }
    }

    public class boolV : Value
    {
        public Boolean b;

        public boolV(Boolean b)
        {
            this.b = b;
        }

        public String toString()
        {
            return b.ToString();
        }
    }

    public class stringV : Value
    {
        public String s;

        public stringV(String s)
        {
            this.s = s;
        }

        public String toString()
        {
            return s.ToString();
        }
    }

    public class numC : ExprC
    {
        public double number;

        public numC(double number)
        {
            this.number = number;
        }
    }

    public class binopC : ExprC
    {
        public String op;
        public ExprC left;
        public ExprC right;

        public binopC(String op, ExprC left, ExprC right)
        {
            this.op = op;
            this.left = left;
            this.right = right;
        }
    }
    
    public class boolC : ExprC
    {
        public boolean b;
        
        public boolC(boolean c)
        {
            this.b = b;
        }
    }
    
    public class ifC : ExprC
    {
        public ExprC conditional;
        public ExprC then;
        public ExprC els;
        
        public ifC(ExprC conditional, ExprC then, ExprC els)
        {
            this.conditional = conditional;
            this.then = then;
            this.els = els;
        }
    }
    
    
    public class Program
    {

        class LangException : Exception
        {
            private String eMessage;

            public LangException(string message)
            {
                eMessage = message;
            }

            public String getMessage()
            {
                return eMessage;
            }
        }

        public double numBinopHandle(String op, double num1, double num2)
        {
            if (op.Equals("+", StringComparison.Ordinal))
            {
                return num1 + num2;
            }
            else if (op.Equals("-", StringComparison.Ordinal))
            {
                return num1 - num2;
            }
            else if (op.Equals("*", StringComparison.Ordinal))
            {
                return num1 * num2;
            }
            else if (op.Equals("/", StringComparison.Ordinal))
            {
                if (num2 == 0)
                {
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

      
        public static Value interp(ExprC exp)
        {
            if(exp.GetType() == typeof(numC))
            {
                var n = exp as numC;
                return (new numV (n.number));
            }
            else if(exp.GetType() == typeof(binopC))
            {
                var b = exp as binopC;
                
                var lVal = interp(b.left);
                var rVal = interp(b.right);
                var lNum = lVal as numV;
                var rNum = rVal as numV;
                    
                if(b.op == op.Equals("eq?", StringComparison.Ordinal) || b.op == op.Equals("<=", StringComparison.Ordinal) ){           
                    return booleanBinopHandle(b.op, lNum.number, rNum.number);
                }
                else if{
                    return numBinopHandle(b.op, lNum.number, rNum.number);  
                }                     
            }
            else if(exp.GetType() == typeof(boolC))
            {
                boolC bC = exp as boolC;
                return boolV(bC.b);
            }
            else if(exp.GetType() == typeof(ifC))
            {
                ifC i = exp as ifC;
                Value v = interp(i.conditional);
                if(v.GetType() == typeof(boolV))
                {
                    boolV bV = v as boolV;
                    if(bV.b == true)
                        return interp(i.then);
                    else
                        return interp(i.els);
                }
                else
                    stringV("interp: error, not a boolV value");
            }
            else
            {
                LangException ex = new LangException("Not a valid exprC");
                throw ex;
            }
            
        }

        public static ExprC parse(string[] arr){
            if(arr.Length == 1){
                double n;
                if(double.TryParse(arr[0], out n)){
                    return new numC(n);
                }
            }

            throw new LangException("Not valid OWWQ");
        }

    public bool booleanBinopHandle(String op, Object prim1, Object prim2) {
      Type prim1Type = prim1.GetType();
      Type prim2Type = prim2.GetType();
      if (op.Equals("<=", StringComparison.Ordinal)) {
         if (prim1Type.Equals(typeof(double)) && prim2Type.Equals(typeof(double))) {
            double num1 = (double)prim1;
            double num2 = (double)prim2;
            
            return num1 <= num2;
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
            
            return num1 == num2;
         }
         else {
            bool bool1 = (bool)prim1;
            bool bool2 = (bool)prim2;
            
            return bool1 == bool2;
         }
         
      }
      else {
         LangException ex = new LangException("Bad boolean binop");
         throw ex;
      }
   }        

        static void Main(string[] args)
        {
            numC anum = new numC(5);
            Console.WriteLine(interp(anum).toString());
            binopC abinop = new binopC("plus", (new numC(5)), (new numC(6)));
            Console.WriteLine("hello world");
        }
    }
}