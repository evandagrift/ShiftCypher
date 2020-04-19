using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCypher
{
    /*Elijah Vandagrift
     * 4/18/2020
     * L0058894
     * Lab 1 Q 
     *Shift Cypher Final Version
     */
    class Program
    {
        static void Main(string[] args)
        {
            //Loop it forever
            while (true)
            {
                int codeNum = 0;

                Console.Write("Hello enter the word you'd like to encode:");
                string userInput = Console.ReadLine();

                Console.Write("shift by how many?");
                string userIntput = Console.ReadLine();
                //makes sure if they didn't enter an int things don't go bad
                try
                {
                    codeNum = Int32.Parse(userIntput);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"sorry that's not an int");
                }
                //sends user input to be encrypted then prints it back
                string outputString = Cypher(userInput, codeNum);
                Console.WriteLine(outputString);





            }

            //makes base char[] and sends it off to be encrypted
            //encrypted char[] is returned and made into a string
            static string Cypher(string str, int i)
            {
                char[] cArray = str.ToCharArray(0, str.Length);
                char[] completeArray = Unicoder(cArray, i);
                string returnString = new string(completeArray);
                return returnString;
            }


            //take char[] and shift by int and returns shifted char[]
            static char[] Unicoder(char[] charArray, int s)
            {
                //creates the arrays for the ASCII values and the return Char
                int[] iArray = new int[charArray.Length];
                char[] returnArray = new char[iArray.Length];

                //populates Int[]
                for (int j = 0; j < iArray.Length; j++)
                { iArray[j] = (int)charArray[j]; }

                //runs each ASCII and Fixes overspill according to character type
                //loops through all of iArray
                for (int i = 0; i < iArray.Length;i++) 
                {
                    //sets character and a new one to be changed
                    int crntChar = iArray[i];
                    int newChar = crntChar;

                    //is Caps
                    if (crntChar >= 65 && crntChar <= 90)
                    {
                        //change the char
                        newChar = crntChar + s;
                        Console.WriteLine("a" + newChar);
                        //loop round
                        if (newChar < 65) { newChar += 26; }
                        else if (newChar > 90) { newChar -= 26; }
                    }
                    //is lower case
                    if (crntChar >= 97 && crntChar <= 122)
                    {
                        //shifts the new char
                        newChar = crntChar + s;
                        //checks if it needs to be looped back into place
                        //if so it does
                        if (newChar < 97) { newChar += 26; }
                        else if (newChar > 122) { newChar -= 26; }

                    }
                    //numbers
                    if(crntChar >= 48 && crntChar <= 57)
                    {
                        //more of the same as above
                        newChar = crntChar + s;
                        Console.WriteLine("c" + newChar);
                        if (newChar < 48) { newChar += 10; }
                        else if (newChar > 57) { newChar -= 10; }
                    }
                    //replaces the old chars
                    charArray[i] = (char)newChar;
                }

                //puts it in new char[] to be sent back
                for (int k = 0; k < iArray.Length; k++)
                { returnArray[k] = (char)charArray[k]; }


                return returnArray;

            }





        }
    }
}
