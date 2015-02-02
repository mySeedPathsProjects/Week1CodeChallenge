using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //call FizzBuzz for 0-20
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }
            //add a line break in the console window for readability
            Console.WriteLine();


            //call FizzBuzz for 92-79
            for (int i = 92; i >= 79; i--)
            {
                Console.WriteLine(FizzBuzz(i));
            }
            Console.WriteLine();


            //call Yodaizer, test *extra credit*
            Console.WriteLine(Yodaizer("I like code"));
            Console.WriteLine();


            //Call TextStats function, includes *extra credit* modification
            TextStats("This function shows some stats of this text.  It counts the number of characters, words, vowels, consonants, and special characters!  And for some superextraduper extra credit, it'll even display the longest word, second longest word, and shortest word.");
            Console.WriteLine();


            //Call IsPrime function only on odd numbers
            for (int i = 1; i <= 25; i++)
            {
                //check for odd numbers
                if (i % 2 != 0)
                {
                    //check to see if current number in loop is prime
                    bool prime = IsPrime(i);
                    //if it is prime (true)
                    if (prime)
                    {
                        Console.WriteLine(i + " is a prime number");
                    }
                    else
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            Console.WriteLine();


            //Call DashInsert
            Console.WriteLine(DashInsert(454793));
            Console.WriteLine(DashInsert(8675309));


            //keep console open
            Console.ReadKey();
        }

        /// <summary>
        /// Function used for testing what numbers are divisable by 3, 5, and both 3 and 5.
        /// </summary>
        /// <param name="number">number to test</param>
        /// <returns>return Buzz for 3, Fizz for 5, FizzBuzz for 3 and 5, return input number otherwise</returns>
        public static string FizzBuzz(int number)
        {
            if ((number % 3 == 0) && (number % 5 == 0))
            {
                return "FizzBuzz";
            }
            else if (number % 3 == 0)
            {
                return "Buzz";
            }
            else if (number % 5 == 0)
            {
                return "Fizz";
            }else
            return number.ToString();
        }

        /// <summary>
        /// Takes a string input and return words in reverse order.
        /// If 3 words are given, then "last word, first word + second word" returned
        /// </summary>
        /// <param name="text">string of text</param>
        /// <returns>words reversed</returns>
        public static string Yodaizer(string text)
        {
            //empty string to hold reversed words
            string reverseText = string.Empty;
            //split up input string and convert to a List of words
            List<string> stringWords = text.Split(' ').ToList();
            
            //if input string contains only 3 words, returns as "2, 0 + 1"
            if (stringWords.Count == 3)
            {
                return (stringWords[2] + ", " + stringWords[0] + " " + stringWords[1]);
            }else
            //otherwise reverse word order and...
            stringWords.Reverse();
            //loop through reversed List array and turn back into a string
            for (int i = 0; i < stringWords.Count; i++)
            {
                reverseText += stringWords[i] + " ";
            }
            //return orginal text now reversed (w/ empty space at end of string removed by Trim)
            return reverseText.Trim();
        }

        /// <summary>
        /// Runs several differnt stats on input text string:
        /// Number of characters
        /// Number of words
        /// Number of vowels
        /// Number of consonants
        /// Number of special characters
        /// Longest word
        /// Second longest word
        /// Shortest word
        /// </summary>
        /// <param name="input">stats</param>
        public static void TextStats(string input)
        {
            //***First output the original string
            Console.WriteLine(input);

            //***Output number of characters
            Console.WriteLine("Number of characters: " + input.Length);

            //***Output number of words
            //split up input string and convert to a List of words
            List<string> wordCountList = input.Split(' ').ToList();
            //Remove any empty indexes in List that came from a double space (from between sentences in original text)  *******
            for (int i = 0; i < wordCountList.Count; i++)
            {
                wordCountList.Remove("");
            }
            Console.WriteLine("Number of words: " + wordCountList.Count);

            //***Output number of vowels
            int vowelCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                //checks to see if current index (a character) is a vowel, if so add 1 to vowelCounter
                if ("aeiou".Contains(input[i].ToString().ToLower()))
                {
                    vowelCounter++;
                }
            }
            Console.WriteLine("Number of vowels: " + vowelCounter);

            //***Output number of consonants
            int consonantCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                //checks to see if current index (a character) is a consonant, if so add 1 to consonantCounter
                if ("bcdfghjklmnpqrstvwxyz".Contains(input[i].ToString().ToLower()))
                {
                    consonantCounter++;
                }
            }
            Console.WriteLine("Number of consonants: " + consonantCounter);

            //***Output number of special characters
            int specialCharacterCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                //checks to see if current index (a character) is a special character, if so add 1 to specialCharacterCounter
                if (" .,?!'".Contains(input[i].ToString().ToLower()))
                {
                    specialCharacterCounter++;
                }
            }
            Console.WriteLine("Number of special characters: " + specialCharacterCounter);


            //***Begin process to disply longest word, second longest, and shortest
            //create array of special characters that might be attached to the end of words, for removing
            string[] specialCharacters = {",", ".", "!", "?"};
            //remember that wordCountList is original input string convertered to a List, done above
            //Remove any special characters from each word which would effect its true length (being extra nerdy here)
            for (int i = 0; i < wordCountList.Count; i++)
			{
                for (int j = 0; j < specialCharacters.Length; j++)
			    {
                    wordCountList[i] = wordCountList[i].Replace(specialCharacters[j], string.Empty);
			    }
			}
            //Create a new List to hold words as they are rearranged by word length
            List<string> wordLengthOrder = new List<string>();
            //need to add 1 empty index for loop to run (need to run one index past final word), removed after loop
            wordLengthOrder.Add(string.Empty);
            //Loop through original wordCountList, if its current word length is longer than first word in wordLength order then insert it, if not then check next index in wordLengthOrder.  When spot is found then exit j loop.  
            //****saw the List.OrderBy method but could not figure it out****
            for (int i = 0; i < wordCountList.Count; i++)
            {
                for (int j = 0; j <wordLengthOrder.Count; j++)
			    {
                    if (wordCountList[i].Length > wordLengthOrder[j].Length)
                    {
                        wordLengthOrder.Insert(j, wordCountList[i]);
                        break;
                    }
			    }             
            }
            //remove empty index added above, which should the last index in the List at this point
            wordLengthOrder.RemoveAt(wordLengthOrder.Count - 1);
            //Print words to console
            Console.WriteLine("The longest word is: " + wordLengthOrder[0]);
            Console.WriteLine("The second longest word is: " + wordLengthOrder[1]);
            Console.WriteLine("The shortest word is: " + wordLengthOrder[wordLengthOrder.Count - 1]);

            /*  //******* NOW USING "ORDER BY DESCENDING" ****************

            //Create a new List to hold words as they are rearranged by word length
            List<string> wordLengthOrder = new List<string>();
            //order words from original "wordCountList" by length and put into "var orderedWords"
            var orderedWords = wordCountList.OrderByDescending(c => c.Length);
            //add each word (now in order by length) into the wordLengthOrder List we created
            foreach (var item in orderedWords)
            {
                wordLengthOrder.Add(item);
            }
            //print to screen the longest, second longest, and shortest
            Console.WriteLine("The longest word is: " + wordLengthOrder[0]);
            Console.WriteLine("The second longest word is: " + wordLengthOrder[1]);
            Console.WriteLine("The shortest word is: " + wordLengthOrder[wordLengthOrder.Count - 1]);
            */
        }

        /// <summary>
        /// Check to see if a positive number is prime, if so return true
        /// </summary>
        /// <param name="number">any integer greater than 0</param>
        /// <returns>true if prime</returns>
        public static bool IsPrime(int number)
        {
            //check if number is greater than zero
            if (number > 0)
            {
                //1 and 2 are both prime, loop only useful for numbers greater than 2
                if (number == 1 || number == 2)
                {
                    return true;
                }
                if (number > 2)
                {
                    //check to see if number is divisible by any number between 2 and (number-1)
                    for (int i = 2; i < number; i++)
                    {
                        if (number % i == 0)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                //if number not greater than 0
                return false;
            }
            
        }

        /// <summary>
        /// Insert a dash ('-') between each pair of odd numbers
        /// </summary>
        /// <param name="number">number to process</param>
        /// <returns>original number with dashes between odd numbers</returns>
        public static string DashInsert(int number)
        {
            //convert input number to a string for looping through
            string numString = number.ToString();
            //creat empty string for inputing new values with dashes
            string dashNumString = string.Empty;
            
            for (int i = 0; i < numString.Length; i++)
            {
                //add number at current index to new string
                dashNumString += numString[i].ToString();
                //do not process code on final index of original string
                if (i < numString.Length - 1)
                {
                    //if current index is odd and...
                    if ((int.Parse(numString[i].ToString()) % 2) != 0)
                    {
                        //...if number at next index is also odd then...
                        if ((int.Parse(numString[i + 1].ToString()) % 2) != 0)
                        {
                            //...add a dash to the new string
                            dashNumString += "-";
                        }
                    }
                }
            }
            //return new string with dashes inserted
            return dashNumString;
        }


    }
}
