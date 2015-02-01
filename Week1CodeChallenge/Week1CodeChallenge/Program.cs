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
            //calling FizzBuzz 0-20
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }
            //add a line break in the console window for readability
            Console.WriteLine();

            //calling FizzBuzz 92-79
            for (int i = 92; i >= 79; i--)
            {
                Console.WriteLine(FizzBuzz(i));
            }
            Console.WriteLine();

            //calling Yodaizer with 3 words to test *extra credit*
            Console.WriteLine(Yodaizer("I like code a whole hell of a lot"));
            Console.WriteLine(Yodaizer("I like code"));
            Console.WriteLine();

            //Call TextStats function
            TextStats("This function shows some stats of this text.  It counts the number of characters, words, vowels, consonants, and special characters!  And for some superextraduper extra credit, it'll even display the longest word, second longest word, and shortest word.");
            Console.WriteLine();



            //keep console open
            Console.ReadKey();
        }

        /// <summary>
        /// Function used for testing what numbers are divisable by 3, 5, and both 3 and 5.
        /// </summary>
        /// <param name="number">number to test</param>
        /// <returns>test result, Buzz for 3, Fizz for 5, FizzBuzz for 3 and 5, input number otherwise</returns>
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
        /// <returns>string, words reversed</returns>
        public static string Yodaizer(string text)
        {
            //string to hold reversed words
            string reverseText = string.Empty;
            //create new list object, used to reverse words
            List<string> stringWords = new List<string>();
            //split text string into words and put into List array
            stringWords = text.Split(' ').ToList();
            
            //if input string contains only 3 words, returns as "2, 0 + 1"
            if (stringWords.Count == 3)
            {
                return (stringWords[2] + ", " + stringWords[0] + " " + stringWords[1]);
            }else
            //otherwise reverse words and concatenate back into a string
            stringWords.Reverse();
            for (int i = 0; i < stringWords.Count; i++)
            {
                reverseText += stringWords[i] + " ";
            }
            //return orginal text now reversed w/ empty space at end of string removed
            return reverseText.Trim();
        }

        /// <summary>
        /// Runs several differnt stats on input text string
        /// </summary>
        /// <param name="input">string of text</param>
        public static void TextStats(string input)
        {
            //First output the original string
            Console.WriteLine(input);



            //Output number of characters
            Console.WriteLine("Number of characters: " + input.Length);



            //Output number of words
            //First split string into an array
            string[] wordCount = input.Split(' ');
            //Turn string array into a List
            List<string> wordCountList = wordCount.ToList();
            //Remove any empty indexes that came from a double space between sentences in original text  *******
            for (int i = 0; i < wordCountList.Count; i++)
            {
                wordCountList.Remove("");
            }
            Console.WriteLine("Number of words: " + wordCountList.Count);



            //Count number of vowels
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



            //Count number of consonants
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



            //Count number of special characters
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



            //Begin process to disply longest word, second longest, and shortest
            //create array of special character that might be attached to the end of words
            string[] specialCharacters = {",", ".", "!", "?"};
            //remember that wordCountList is original input string convertered to a List, as done above
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
            //need to add 1 empty index for loop to run
            wordLengthOrder.Add("");
            //Loop through original List, if its current word length is longer than first word in wordLength order then insert it, if not then check next index in wordLengthOrder.  When spot is found then exit j loop.  
            //****saw the .OrderBy method but could not figure out****
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
        }



        public static bool IsPrime(int number)
        {
            if (number > 0)
            {
                if (number == 1 || number == 2)
                {
                    return true;
                }
                if (number > 2)
                {
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
                return false;
            }
            
        }



        public static string DashInsert(int number)
        {
            return string.Empty;
        }
    }
}
