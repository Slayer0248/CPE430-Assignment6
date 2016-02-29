using ConsoleApplication1;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testNumC()
        {
            numC n1 = new numC(5);
            Assert.AreEqual(n1.number, 5);

            Assert.AreEqual(Program.interp(n1).toString(), "5");

        }
        [TestMethod]
        public void testNumV()
        {
            numV v1 = new numV(6);
            Assert.AreEqual(v1.number, 6);
        }

        [TestMethod]
        public void interpNumber()
        {
            numC n1 = new numC(5);
            numC n2 = new numC(4);
            Assert.AreEqual(Program.interp(n1).toString(), "5");
            Assert.AreEqual(Program.interp(n2).toString(), "4");
        }

        [TestMethod]
        public void testBinopC()
        {
            binopC abinop = new binopC("+", (new numC(5)), (new numC(6)));
            Assert.AreEqual(abinop.op, "+");
            numC left = abinop.left as numC;
            numC right = abinop.right as numC;
            Assert.AreEqual(left.number, 5);
            Assert.AreEqual(right.number, 6);
        }
        [TestMethod]
        public void interpBinop()
        {
            binopC abinop = new binopC("+", (new numC(5)), (new numC(6)));
            Value rvalue = Program.interp(abinop);
            Assert.AreEqual(rvalue.toString(), "11");
        }

        [TestMethod]
        public void interpIfC()
        {
            boolC b1 = new boolC(true);
            numC n1 = new numC(5);
            numC n2 = new numC(6);
            ifC anifc = new ifC(b1, n1, n2);
            Value rvalue = Program.interp(anifc);
            Assert.AreEqual(rvalue.toString(), "5");
        }
    }
}
