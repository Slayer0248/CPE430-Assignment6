using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
//using System.Windows.Forms;

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



class Hello
{
   static void testException() {
      throw new CustomException("exception success");
   }

   static void Main() {
      
      try
      {
         testException();
         Console.WriteLine("hello, world");
      }
      catch (CustomException ex)
      {
          System.Console.WriteLine(ex.ToString());
          System.Console.WriteLine(ex.getMessage());
      } 
      //DialogResult result = MessageBox.Show("Some text", "Some title", 
      //       MessageBoxButtons.OK, MessageBoxIcon.Error);
      
   }
   
   
}
