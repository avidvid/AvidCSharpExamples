using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    //nuget xunit
    public class StringManipulatorTest
    {
        [Theory]
        [InlineData("", "a", "")]
        [InlineData("a", "a", "<b>a</b>")]
        [InlineData("aaaaaaaa", "a", "<b>a</b><b>a</b><b>a</b><b>a</b><b>a</b><b>a</b><b>a</b><b>a</b>")]
        [InlineData("world world", "llo", "world world")]
        [InlineData("Hello world", "llo", "He<b>llo</b> world")]
        [InlineData("Hello Hello world", "llo", "He<b>llo</b> He<b>llo</b> world")]
        [InlineData("Hellollo world", "llo", "He<b>llo</b><b>llo</b> world")]
        [InlineData("Hellollol world", "llol", "He<b>llollol</b> world")]
        [InlineData("banana", "ana", "b<b>anana</b>")]
        [InlineData("ananana", "ana", "<b>ananana</b>")]
        public void BoldString_Theory(string input, string target, string bold)
        {
            //Act
            var result = AvidTest.StringManipulator.BoldString(input, target);
            //Assert
            Assert.Matches(bold, result);
        }

        [Theory]
        [InlineData("", "", "target")]
        [InlineData("abcs", "", "target")]
        public void BoldStringException_Theory(string input, string target, string param)
        {
            //Assert
            Assert.Throws<ArgumentException> (param, ()=> AvidTest.StringManipulator.BoldString(input, target));
        }

        [Theory]
        [InlineData("Hello World!!", "H2o W3d!!")]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("  ,.,  ", "  ,.,  ")]
        [InlineData("   h  ", "   h0h  ")]
        [InlineData("h3o", "h0h3o0o")]
        [InlineData("h3 o", "h0h3 o0o")]
        [InlineData("h", "h0h")]
        [InlineData("hh", "h0h")]
        [InlineData("hhh", "h1h")]
        [InlineData("hhhh", "h1h")]
        [InlineData("hello", "h2o")]
        [InlineData("hello hello hello hello", "h2o h2o h2o h2o")]
        [InlineData("helLo", "h3o")]
        [InlineData("aa    qq", "a0a    q0q")]
        [InlineData("a    q", "a0a    q0q")]
        [InlineData("/   2", "/   2")]
        [InlineData("\\  n", @"\  n0n")]
        [InlineData("Automotive parts", "A6e p3s")]
        [InlineData("Automotive   . parts    a", "A6e   . p3s    a0a")]
        [InlineData(" NOOOOOOOOOOOOOOOOOOOOOOOOOOOOO YEEEES", " N1O Y1S")]
        [InlineData(" NOOOooooooooOOOOOOOOOOO YEEEES", " N2O Y1S")]
        [InlineData("ComMunicate", "C9e")]
        [InlineData("3. Any non-alphabetic character in the input string should appear in the output string in its original relative location.",
            "3. A1y n1n-a8c c6r i0n t1e i3t s4g s4d a3r i0n t1e o3t s4g i0n i1s o5l r6e l5n.")]
        [InlineData("Our hiring team wants executable code, with test cases.Please do not submit a file with a single method.",
            "O1r h3g t2m w3s e8e c2e, w2h t2t c3s.P4e d0o n1t s4t a0a f2e w2h a0a s4e m4d.")]
        [InlineData("2. A \"word\" is defined as a sequence of alphabetic characters,",
            "2. A0A \"w2d\" i0s d4d a0s a0a s5e o0f a8c c6s,")]
        [InlineData("[xUnit.net 00:00:00.63]   Starting:    vAutoInterviewSetTest", "[x3t.n1t 00:00:00.63]   S5g:    v14t")]
        [InlineData("[9/26/2019 4:50:13 PM Informational]", "[9/26/2019 4:50:13 P0M I8l]")]
        [InlineData("Remember - Details… Details… Details…", "R3r - D5s… D5s… D5s…")]
        [InlineData("  Our final interview is half a day (3-4 hours). ", "  O1r f3l i6w i0s h2f a0a d1y (3-4 h3s). ")]

        private void SentenceTest(string sentence, string result)
        {
            var calculateResult = AvidTest.StringManipulator.MidWordCntCoder(sentence);
            Assert.Equal(calculateResult, result);
        }

    }
}