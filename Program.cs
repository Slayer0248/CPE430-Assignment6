﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
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

        public interface ExprC
        {

        }

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

        public class numC : ExprC
        {
            public double number;

            public numC(double number)
            {
                this.number = number;
            }
        }

        public static Value interp(ExprC exp)
        {
            if(exp.GetType() == typeof(numC))
            {
                var n = exp as numC;
                return (new numV (n.number));
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

            return new numC(3);
        }
        

        static void Main(string[] args)
        {
            numC anum = new numC(5);
            Console.WriteLine(interp(anum).toString());
            
            Console.WriteLine("hello world");

            string[] aNum = {"3.2"};
            Console.WriteLine(interp(parse(aNum)).toString());
        }
    }
}
