/*Name: Sansayan Pratheepan
 * Date: 5/3/2024
 * Title: A7 Input Output Sansayan Pratheepan
 *Purpose: read values from a file in the debug, inport those values into arrays, and allow the user to manipulate those values
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A7InputOutputSansayanP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] strNamesandAge; //state all our variables
            string strNamesandAgesInput;
            string strName;
            string strAge;
            int intNameArrayLength = 0; //counter

            //get all values in the first txt file


            StreamReader Na = File.OpenText("names.txt"); //this code uses the counter to see how many elements are in the text file named "names.txt"
            string nameInput = null;//the user can enter as many values as they want in that file. 
            while ((nameInput = Na.ReadLine()) != null)
            {
                intNameArrayLength++;
            }
            Na.Close();


            strNamesandAge = new string[intNameArrayLength];//in this array, you copy down everything from the names.txt file, but that has both the name and the ages
            string[] Names = new string[intNameArrayLength];//create two seperate arrays for names and ages
            int[] Ages = new int[intNameArrayLength];//set the size of each array to the last value of the counter, which indicates how many items there are in the txt file. 

            Na = File.OpenText("names.txt");

            for (int i = 0; i < strNamesandAge.Length; i++) //the code bellow seperates the names and ages in strNamesandAge into 2 seperate arrays, names, and ages. 
            {
                strNamesandAgesInput = Na.ReadLine(); // Read from the file, not from console input

                Names[i] = strNamesandAgesInput.Substring(0, strNamesandAgesInput.IndexOf(",")); //this is done using the index of function to find where something is, then the subtring to pull it out of the string. 

                int commaIndex = strNamesandAgesInput.IndexOf(",");
                strAge = strNamesandAgesInput.Substring(commaIndex + 1, strNamesandAgesInput.Length - commaIndex - 1);
                Ages[i] = Int32.Parse(strAge);
                strNamesandAge[i] = strNamesandAgesInput;
            }




            //Get all the values in the grade txt file
            int[] intGrades;
            int intGradeArrayLength = 0;
            int Grade;
            StreamReader Gr = File.OpenText("grades.txt"); //here we look at the next file, the grades.txt file, and we read the file
            string gradeInput = null;
            while ((gradeInput = Gr.ReadLine()) != null) //we go to see how many items are in the file
            {
                intGradeArrayLength++;
            }
            Gr.Close();
            intGrades = new int[intGradeArrayLength]; //create an array about grades, that is the same length as the counter above. 
            Gr = File.OpenText("grades.txt");

            for (int i = 0; i < intGrades.Length; i++) //might have to convert to integer. 
            {

                Grade = Int32.Parse(Gr.ReadLine()); //put all the values in the grade array, and make sure to parse them because they are technically strings. 
                intGrades[i] = Grade;
            }
            int[] intGradesORG = new int[intNameArrayLength]; //create orignial strings, that doesn't change when ever something is added to deleted (important for case 1)
            string[] NamesORG = new string[intNameArrayLength];
            int[] AgeORG = new int[intNameArrayLength];
            int NameArrayLengthORG = 0;

            for (int i = 0; i < Names.Length; i++)
            {
                intGradesORG[i] = intGrades[i]; // copy down all the values in each array to the "orignial array"
                NamesORG[i] = Names[i];
                AgeORG[i] = Ages[i];
                NameArrayLengthORG = intNameArrayLength;

            }


            while (true)
            {
                Console.WriteLine("1. Show Name, Grade, Age List from File (Unsorted)"); //show the user the menu, and the index they need to choose inorder to enter that part of the application. 
                Console.WriteLine("2. Show Sorted List by Grade (Along with Name and Age) (Highest to Lowest)");
                Console.WriteLine("3. Show Sorted List by Name (Along with Grades and Age) (A-Z)");
                Console.WriteLine("4. Show Sorted List by Highest Grade and Student Name and corresponding age");
                Console.WriteLine("5. Show Sorted List by Lowest Grade and Student Name and corresponding age  ");
                Console.WriteLine("6. Average Grade");
                Console.WriteLine("7. Median Grade");
                Console.WriteLine("8. Average Age");
                Console.WriteLine("9. Add a new Student with a Grade and Age");
                Console.WriteLine("10. Save to a New File");
                Console.WriteLine("11. Exit");
                int Choice = 0;
                try
                {
                    Choice = Int32.Parse(Console.ReadLine()); //convert what the user said into a number, then go look at cases. 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);//exception handling tells the user that something is wrong with what they entered. 
                }

                switch (Choice)
                {
                    case 1://show values(unsorted)

                        //unsorted List
                        Console.Clear(); //makes everything clutter free
                        Console.WriteLine("Original Unsorted List:");
                        Console.WriteLine("ID  | Name      | Grade   | Age");
                        try
                        {
                            for (int i = 0; i < NameArrayLengthORG; i++)
                            {
                                Console.WriteLine(String.Format("{0,-4}| {1,-10}| {2,-8}| {3}", i + 1, NamesORG[i], intGradesORG[i], AgeORG[i])); //format everything in the form of a chart then show the user what they orignially entered.
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message); //if anything goes wrong, the exception message is thrown at the user saying something is wrong. 
                        }
                        break;
                    case 2:
                        try
                        {
                            //Sorted By Grade
                            Console.Clear();
                            for (int i = 0; i < intGrades.Length; i++)
                            {
                                for (int j = 0; j < intGrades.Length - 1; j++)
                                {
                                    if (intGrades[j] < intGrades[j + 1])
                                    {
                                        int tempGrade = intGrades[j];
                                        intGrades[j] = intGrades[j + 1];
                                        intGrades[j + 1] = tempGrade;
                                        //swaps the grades first based on highest to lowest

                                        string TempName = Names[j];
                                        Names[j] = Names[j + 1];
                                        Names[j + 1] = TempName;
                                        //changes the names aswell

                                        int TempAge = Ages[j];
                                        Ages[j] = Ages[j + 1];
                                        Ages[j + 1] = TempAge;
                                        //changes the Ages aswell. 
                                    }
                                }
                            }
                            Console.WriteLine("ID  | Name      | Grade   | Age"); //displays the sorted value in the form of a chart, so the user can read easily. 
                            for (int i = 0; i < intNameArrayLength; i++)
                            {
                                Console.WriteLine(String.Format("{0,-4}| {1,-10}| {2,-8}| {3}", i + 1, Names[i], intGrades[i], Ages[i]));
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message); //if anything goes wrong in the sorting an error message will pop up instead of crashing the code. 
                        }
                        break;
                    case 3:
                        try
                        {
                            //sort by name
                            Console.Clear();
                            for (int i = 0; i < Names.Length; i++) //this code sorts everything based on names (a-z), then changes the other arrays in accordance to it, so no value gets jumbled
                            {
                                for (int j = 0; j < Names.Length - 1; j++)
                                {
                                    if (Names[j].CompareTo(Names[j + 1]) > 0)
                                    {
                                        string TempNames = Names[j];
                                        Names[j] = Names[j + 1];
                                        Names[j + 1] = TempNames;
                                        //Swaps the names

                                        int tempGrade = intGrades[j];
                                        intGrades[j] = intGrades[j + 1];
                                        intGrades[j + 1] = tempGrade;

                                        int TempAge = Ages[j];
                                        Ages[j] = Ages[j + 1];
                                        Ages[j + 1] = TempAge;
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        { //if anything goes wrong in the sorting this message appears. preventing it from crashing
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine("ID  | Name      | Grade   | Age");
                        for (int i = 0; i < intNameArrayLength; i++)
                        {
                            Console.WriteLine(String.Format("{0,-4}| {1,-10}| {2,-8}| {3}", i + 1, Names[i], intGrades[i], Ages[i])); //displays the sorted values. 
                        }
                        break;

                    case 4://shows the highest grade
                        Console.Clear();//unclutters the console.
                        int highestGrade = intGrades[0];
                        try
                        {
                            Console.WriteLine("The Student With The Highest Grade:");
                            for (int i = 1; i < intGradeArrayLength; i++)
                            {
                                if (intGrades[i] > highestGrade)//goes through all the values in the array to find the highest grade. 
                                {
                                    highestGrade = intGrades[i];
                                }
                            }
                        }
                        catch (Exception f)
                        {
                            Console.WriteLine(f.Message);
                        }
                        try
                        {
                            // Print students with the highest grade
                            for (int i = 0; i < intGradeArrayLength; i++)
                            {
                                if (intGrades[i] == highestGrade)
                                {
                                    Console.WriteLine($"Name: {Names[i]}, Grade: {intGrades[i]}, Age: {Ages[i]}"); //then displays the students with the highest grade, as well as their age 
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message); //if anything goes wrong in the printing process (unlikely) this error message comes up, preventing a crash. 
                        }
                        break;
                    case 5://shows lowest grade. 

                        Console.Clear();
                        Console.WriteLine("The Student With The Lowest Grade:");
                        int intLowest = intGrades[0];

                        try
                        {
                            for (int i = 1; i < intGradeArrayLength; i++)
                            {
                                if (intGrades[i] < intLowest) //goes through all the values in the array to find the lowest grade. 
                                {
                                    intLowest = intGrades[i];
                                }
                            }
                        }
                        catch (Exception e)
                        {//when it is searching if anything goes wrong this error message pops up preventing a crash. 
                            Console.WriteLine(e.Message);
                        }


                        // Print students with the highest grade
                        try
                        {
                            for (int i = 0; i < intGradeArrayLength; i++)
                            {
                                if (intGrades[i] == intLowest)
                                {
                                    Console.WriteLine($"Name: {Names[i]}, Grade: {intGrades[i]}, Age: {Ages[i]}"); //displays the lowest grade, as well as the students name and age. 
                                }
                            }
                        }
                        catch (Exception f)
                        {
                            Console.WriteLine(f.Message);
                        }

                        break;

                    case 6:

                        //Average grades
                        Console.Clear();
                        Console.WriteLine("The Average for the class is: ");
                        double dblTotal = 0;
                        try
                        {
                            for (int i = 0; i < intGradeArrayLength; i++)
                            { //adds all the values in the grade array. 
                                dblTotal += intGrades[i];
                            }
                            double Average = dblTotal / intGradeArrayLength; //divide the total value by the total number of values in the array to find the average, then round to 2 decimal places. 
                            Average = Math.Round(Average, 2);
                            Console.WriteLine($"The Average Grade is: {Average}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 7: //median
                        Console.Clear();
                        //Median Grade
                        for (int i = 0; i < intGrades.Length; i++)
                        {
                            for (int j = 0; j < intGrades.Length - 1; j++) //first sorts everything from highest to lowest(grades), as well as swap the names and age so nothing gets jumbled. 
                            {
                                if (intGrades[j] < intGrades[j + 1])
                                {
                                    int tempGrade = intGrades[j];
                                    intGrades[j] = intGrades[j + 1];
                                    intGrades[j + 1] = tempGrade;
                                    //swaps the grades first based on highest to lowest

                                    string TempName = Names[j];
                                    Names[j] = Names[j + 1];
                                    Names[j + 1] = TempName;
                                    //changes the names aswell

                                    int TempAge = Ages[j];
                                    Ages[j] = Ages[j + 1];
                                    Ages[j + 1] = TempAge;
                                    //changes the Ages aswell. 
                                }
                            }
                        }
                        try
                        {
                            if (intGradeArrayLength % 2 == 0) //then if there are even number of items in the array, it finds the middle index, then the one under it
                            {
                                int MiddleIndex1 = (intGradeArrayLength / 2) - 1;//then finds the average of the 2 medians. 
                                int MiddleIndex2 = (intGradeArrayLength / 2);

                                double dblMiddleIndex = Convert.ToDouble(intGrades[MiddleIndex1] + intGrades[MiddleIndex2]);
                                dblMiddleIndex = dblMiddleIndex / 2;
                                Console.WriteLine($"The Median Grade is: {dblMiddleIndex}");
                            }
                            else
                            {//if not it finds the middle index by dividing by 2, and displaying that index
                                int MiddleIndex = intGradeArrayLength / 2;
                                Console.WriteLine($"The Median Grade is: {intGrades[MiddleIndex]}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }


                        break;
                    case 8:
                        //Average Age
                        Console.Clear();

                        double AgeSum = 0;


                        for (int i = 0; i < Ages.Length; i++)
                        { //adds all the values in the age array. 
                            AgeSum += Ages[i];
                        }
                        double dblAgeAverage = 0;
                        try
                        {
                            dblAgeAverage = Math.Round((AgeSum / Ages.Length), 2); //then divides that sum by the total number of elements in the array, to get the average, as well as round to 2 decimal places. 
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        Console.WriteLine($"The Average Age is {dblAgeAverage}"); //show the user the average age. 

                        break;
                    case 9://add a student
                        Console.Clear();
                        string[] newNames = new string[intNameArrayLength + 1]; //creates 3 new arrays that are 1 element bigger than the orignial ones. so that you can add another element on to it
                        int[] newAges = new int[intNameArrayLength + 1];
                        int[] newGrades = new int[intGradeArrayLength + 1];

                        for (int i = 0; i < intNameArrayLength; i++)
                        {
                            newNames[i] = Names[i]; //copy down all the values into the 3 new arrays. 
                            newAges[i] = Ages[i];
                            newGrades[i] = intGrades[i];
                        }
                        try
                        {
                            Console.WriteLine($"Student Name:"); //ask the user for the new name, age, and grade, and store those into the array. 
                            newNames[intGradeArrayLength] = Console.ReadLine();
                            Console.WriteLine($"Student Grade:");
                            newGrades[intGradeArrayLength] = Int32.Parse(Console.ReadLine());
                            Console.WriteLine($"Student Age:");
                            newAges[intGradeArrayLength] = Int32.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Names = newNames; //reassign all the values so the orignial array is what we still use for other parts of the code. 
                        Ages = newAges;
                        intGrades = newGrades;
                        intGradeArrayLength++;
                        intNameArrayLength++;
                        break;

                    case 10: //save everything to a new file. 
                        Console.Clear();

                        Console.WriteLine("Please Enter The Name Of The File");//ask the user the name of the new file. 
                        string strFileName = Console.ReadLine();

                        try
                        {
                            FileInfo Mas = new FileInfo($"{strFileName}.txt"); //create a new text file with the name the user said. 
                            StreamWriter MasterChart = Mas.CreateText();
                            for (int i = 0; i < intNameArrayLength; i++)
                            {
                                MasterChart.WriteLine($"{Names[i]}, {intGrades[i]}, {Ages[i]}"); //write down all our array elements, starting with names, grade, and age. 
                            }
                            MasterChart.Close();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        Console.WriteLine($"Everything Has Been Uploaded to the {strFileName} Textfile."); //tell the user everything has been uploaded if its successful. 

                        break;
                    case 11:
                        Console.Clear(); //exit
                        Console.WriteLine("Thank you for coming");//if they enter 11, tell them thank you for coming, let them read it, then exit the program. 
                        Console.ReadKey();
                        return;
                }


            }




        }
    }
}


