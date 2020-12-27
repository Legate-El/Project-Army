using System;
using System.Collections.Generic;


namespace examenoefeningwachtwoord
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string smalltab = "1";
            /* personel 0 = Personnel number
             * personel 1 = name
             * personel 2 = first name
             * personel 4 = rank
             * personel 5 = alias
             * personel 6 = password*/
            List<string> personnel_0 = new List<string>();
            List<string> personnel_1 = new List<string>();
            List<string> personnel_2 = new List<string>();
            List<string> personnel_4 = new List<string>();
            List<string> personnel_5 = new List<string>();
            List<string> personnel_6 = new List<string>();
            List<int> searchresults = new List<int>();


            short StopProgram = 0;
            string Choice;
            string quit;
            
            //start new employee variables
            string NewName;
            string NewFirstName;
            string NewRanks;
            int NewRank;
            string NewRankName;
            string NewPassWord;
            string NewPersonelnumber;
            string NewAlias;
            //end new employee variables

            //start edit employee variables
            string EditPersonnel;
            int indexEdPe;
            short StopEdit = 0;
            string secondChoice;
            string EdName;
            string EdFirstName;
            string EdAlias;
            string EdPassword;
            string quitEdit;
            //end edit employee variables
            do
            {
                wl("(1) Add new employee");
                wl("(2) View all employees");
                wl("(3) Edit an employee");
                wl("(4) Search an employee");
                wl("(5) Remove an employee");
                wl("(6) View all ranks with the numbers");
                wl("(0) Quit");
                Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                        if (smalltab == "1")
                        {
                            Console.WriteLine("Give the last name of the new employee.");
                            NewName = Console.ReadLine();
                            Console.WriteLine("Give the first name of the new employee.");
                            NewFirstName = Console.ReadLine();
                            do
                            {
                                Console.WriteLine("Give the rank of the new employee. [1-23]");
                                NewRanks = Console.ReadLine();
                                NewRank = Convert.ToInt32(NewRanks);
                                if (NewRank == 13)
                                {
                                    bool IsthereSMOTA = personnel_4.Contains("Sergeant Major of the Army");
                                    if (IsthereSMOTA == true)
                                    {
                                        Console.WriteLine("There can only be one Sergeant Major of the Army at a time, please check the ranks in the menu to find the right rank,");
                                        Console.WriteLine("or change the rank of the current soldier who occupies this rank.");
                                        NewRank = -1;
                                    }
                                }
                            } while (NewRank > 23 | NewRank < 0);
                            Console.WriteLine("Give this persons alias.");
                            NewAlias = Console.ReadLine();
                            Console.WriteLine("please have patience.....");
                            wait(2000);
                            NewPersonelnumber = NewPersonelNumber(NewRank, personnel_0);
                            NewPassWord = NewPassword(NewName, NewFirstName, NewRank);
                            NewRankName = NewRankname(NewRank);
                            personnel_0.Add(NewPersonelnumber);
                            personnel_1.Add(NewName);
                            personnel_2.Add(NewFirstName);
                            personnel_4.Add(NewRankName);
                            personnel_5.Add(NewAlias);
                            personnel_6.Add(NewPassWord);
                            Console.WriteLine("Employee number: " + NewPersonelnumber + " " + NewRankName + " " + NewFirstName + " " + NewName + ", with the following alias : " + NewAlias);
                            Console.WriteLine(NewRankName + " " + NewName + " has gotten the following password: " + NewPassWord + ".");
                            break;
                        }
                        break;
                    case "2":
                        int index = personnel_0.Count;
                        for (int i = 0; i < index; i++)
                        {
                            Console.Write("Employee number: " + personnel_0[i]);
                            Console.Write("   " + personnel_4[i]);
                            Console.Write(" " + personnel_2[i]);
                            Console.Write(" " + personnel_1[i]);
                            Console.Write("   Alias: " + personnel_5[i]);
                            Console.WriteLine("   Password: " + personnel_6[i]);

                        }
                        Console.ReadLine();
                        break;
                    case "3":
                        if(smalltab == "1")
                        {
                            Console.WriteLine("Give The personnel number of the employee that you wish to edit.");
                            EditPersonnel = Console.ReadLine();
                            indexEdPe = personnel_0.IndexOf(EditPersonnel);
                            StopEdit = 0;
                            Console.WriteLine("Employee number: " + personnel_0[indexEdPe]);
                            Console.Write("   " + personnel_4[indexEdPe]);
                            Console.Write(" " + personnel_2[indexEdPe]);
                            Console.Write(" " + personnel_1[indexEdPe]);
                            Console.Write("   Alias: " + personnel_5[indexEdPe]);
                            Console.Write("   Password: " + personnel_6[indexEdPe]);
                            do
                            {
                                Console.WriteLine("What do you wish to change?");
                                Console.WriteLine("- Name");
                                Console.WriteLine("- First name");
                                Console.WriteLine("- Rank");
                                Console.WriteLine("- Alias");
                                Console.WriteLine("- Password");
                                Console.WriteLine("- Quit");
                                secondChoice = Console.ReadLine();

                                switch (secondChoice)
                                {
                                    case "Name":
                                        Console.WriteLine("What do you want instead of the current name?");
                                        EdName = Console.ReadLine();
                                        personnel_1.RemoveAt(indexEdPe);
                                        personnel_1.Insert(indexEdPe, EdName);
                                        break;
                                    case "First name":
                                        Console.WriteLine("What do you want instead of the current first name?");
                                        EdFirstName = Console.ReadLine();
                                        personnel_2.RemoveAt(indexEdPe);
                                        personnel_2.Insert(indexEdPe, EdFirstName);
                                        break;
                                    case "Rank":
                                        do
                                        {
                                            Console.WriteLine("What is this employees new rank? [1-23]");
                                            NewRanks = Console.ReadLine();
                                            NewRank = Convert.ToInt32(NewRanks);
                                            if (NewRank == 13)
                                            {
                                                bool IsthereSMOTA = personnel_4.Contains("Sergeant Major of the Army");
                                                if (IsthereSMOTA == true)
                                                {
                                                    Console.WriteLine("There can only be one Sergeant Major of the Army at a time, please check the ranks in the menu to find the right rank,");
                                                    Console.WriteLine("or change the rank of the current soldier who occupies this rank.");
                                                    NewRank = -1;
                                                }
                                            }
                                        } while (NewRank > 23 | NewRank < 0);
                                        personnel_4.RemoveAt(indexEdPe);
                                        personnel_4.Insert(indexEdPe, NewRankname(NewRank));
                                        personnel_0.RemoveAt(indexEdPe);
                                        NewPersonelnumber = NewPersonelNumber(NewRank, personnel_0);
                                        personnel_0.Insert(indexEdPe, NewPersonelnumber);
                                        break;
                                    case "Alias":
                                        Console.WriteLine("What do you want to change the alias in?");
                                        EdAlias = Console.ReadLine();
                                        personnel_5.RemoveAt(indexEdPe);
                                        personnel_5.Insert(indexEdPe, EdAlias);
                                        break;
                                    case "Password":
                                        Console.WriteLine("What do you want as new password?");
                                        EdPassword = Console.ReadLine();
                                        personnel_6.RemoveAt(indexEdPe);
                                        personnel_6.Insert(indexEdPe, EdPassword);
                                        break;
                                    case "Quit":
                                        Console.WriteLine("Are you sure that you wish to quit this editing menu?[Choose 'yes' or 'no']");
                                        quitEdit = Console.ReadLine();
                                        if (quitEdit == "yes")
                                        {
                                            StopEdit = 1;
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("Please give a valid option.");
                                        break;

                                }


                            } while (StopEdit == 0);
                        }
                        break;
                    case "4":
                        if (smalltab == "1")
                        {
                            Console.WriteLine("Give in a search term.");
                            EditPersonnel = Console.ReadLine();
                            
                            
                             int index2 = personnel_0.Count;
                             for (int i = 0; i < index2; i++)
                             {
                                 if (personnel_0[i] == EditPersonnel)
                                 {
                                     searchresults.Add(i);
                                 }
                                if (personnel_1[i] == EditPersonnel)
                                {
                                    searchresults.Add(i);
                                }
                                if (personnel_2[i] == EditPersonnel)
                                {
                                    searchresults.Add(i);
                                }
                                if (personnel_4[i] == EditPersonnel)
                                {
                                    searchresults.Add(i);
                                }
                                if (personnel_5[i] == EditPersonnel)
                                {
                                    searchresults.Add(i);
                                }
                            }

                            int index3 = searchresults.Count;
                            for(int ii = 0; ii < index3; ii++)
                            {
                                Console.Write("Employee number: " + personnel_0[searchresults[ii]]);
                                Console.Write("   " + personnel_4[searchresults[ii]]);
                                Console.Write(" " + personnel_2[searchresults[ii]]);
                                Console.Write(" " + personnel_1[searchresults[ii]]);
                                Console.Write("   Alias: " + personnel_5[searchresults[ii]]);
                                Console.WriteLine("   Password: " + personnel_6[searchresults[ii]]);
                            }
                            searchresults.Clear();

                        }
                        break;
                    case "5":
                        if (smalltab == "1")
                        {
                            Console.WriteLine("Give The personnel number of the employee that you wish to delete out of the database.");
                            EditPersonnel = Console.ReadLine();
                            indexEdPe = personnel_0.IndexOf(EditPersonnel);
                            Console.Write("Employee number: " + personnel_0[indexEdPe]);
                            Console.Write("   " + personnel_4[indexEdPe]);
                            Console.Write(" " + personnel_2[indexEdPe]);
                            Console.Write(" " + personnel_1[indexEdPe]);
                            Console.Write("   Alias: " + personnel_5[indexEdPe]);
                            Console.WriteLine("   Password: " + personnel_6[indexEdPe]);
                            Console.WriteLine("Are you sure you want to delete this employee from the database?[answer 'yes' or 'no']");
                            string answer = Console.ReadLine();
                            if (answer == "yes")
                            {
                                personnel_0.RemoveAt(indexEdPe);
                                personnel_1.RemoveAt(indexEdPe);
                                personnel_2.RemoveAt(indexEdPe);
                                personnel_4.RemoveAt(indexEdPe);
                                personnel_5.RemoveAt(indexEdPe);
                                personnel_6.RemoveAt(indexEdPe);
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case "6":
                        if (smalltab == "1")
                        {
                            wl("1 = Private");
                            wl("2 = Private 2nd Class");
                            wl("3 = Private first Class");
                            wl("4 = Specialist");
                            wl("5 = Corporal");
                            wl("6 = Sergeant");
                            wl("7 = Staff Sergeant");
                            wl("8 = Sergeant First Class");
                            wl("9 = Master Sergeant");
                            wl("10 = First Sergeant");
                            wl("11 = Sergeant Major");
                            wl("12 = Command Sergeant Major");
                            wl("13 = Sergeant Major of the Army");
                            wl("14 = Second Lieutenant");
                            wl("15 = First Lieutenant");
                            wl("16 = Captain");
                            wl("17 = Major");
                            wl("18 = Lieutenant Colonel");
                            wl("19 = Colonel");
                            wl("20 = Brigadier General");
                            wl("21 = Major General");
                            wl("22 = Lieutenant General");
                            wl("23 = General");
                            Console.ReadLine();
                        }
                        break;
                    case "0":
                        if (smalltab == "1")
                        {
                            Console.WriteLine("Do you wish to quit?[answer with 'yes' or 'no']");
                            quit = Console.ReadLine();
                            if (quit == "yes")
                            {
                                StopProgram = 1;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Please give a valid respons.");
                        break;
                }
                
            } while (StopProgram < 1);
            

        }
        static string NewPassword(string NewName, string NewFirstName, int NewRank)
        {
            /* int PoCo5
             * PassRank
             * PassFirstName
             * PassName*/
            string NewPass = "";
            string NewPasss;
            int PassRank = NewRank + 48;
            char PassRankc = (char)PassRank;
            string PassRanks = Convert.ToString(PassRankc);
            int LengthFirstName = NewFirstName.Length;
            string PassFirstName = NewFirstName.Substring(LengthFirstName - 2, 2);
            int LengthName = NewName.Length;
            string PassName = NewName.Substring(LengthName - 2, 2);
            NewPasss = PassRanks + PassFirstName + PassName;
            NewPass = NewPasss.Replace(" ","");
            return NewPass;
        }
        static string NewPersonelNumber(int NewRank, List<string> personnel_0)
        {
            string PersonelNumber = "";
            string RankString = Convert.ToString(NewRank);
            List<string> CurrentRanks = new List<string>();
            foreach (string value in personnel_0)
            {
                if (value.StartsWith(RankString))
                {
                    CurrentRanks.Add(value);
                }
            }
            int lastperson = CurrentRanks.Count + 1;
            string NewSecondPersonelValue = Convert.ToString(lastperson);
            PersonelNumber = RankString + NewSecondPersonelValue;
            return PersonelNumber;
        }
        static string NewRankname(int NewRank)
        {
            string NewRanks = Convert.ToString(NewRank);
            string NewRankname = "";
            switch (NewRanks)
            {
                case "0":
                    NewRankname = "Civilian";
                    break;
                case "1":
                    NewRankname = "Private";
                    break;
                case "2":
                    NewRankname = "Private 2nd Class";
                    break;
                case "3":
                    NewRankname = "Private First Class";
                    break;
                case "4":
                    NewRankname = "Specialist";
                    break;
                case "5":
                    NewRankname = "Corporal";
                    break;
                case "6":
                    NewRankname = "Sergeant";
                    break;
                case "7":
                    NewRankname = "Staff Sergeant";
                    break;
                case "8":
                    NewRankname = "Sergeant First Class";
                    break;
                case "9":
                    NewRankname = "Master Sergeant";
                    break;
                case "10":
                    NewRankname = "First Sergeant";
                    break;
                case "11":
                    NewRankname = "Sergeant Major";
                    break;
                case "12":
                    NewRankname = "Command Sergeant Major";
                    break;
                case "13":
                    NewRankname = "Sergeant Major of the Army";//unique only one enlisted member at a time
                    break;
                case "14":
                    NewRankname = "Second Lieutenant";
                    break;
                case "15":
                    NewRankname = "First Lieutenant";
                    break;
                case "16":
                    NewRankname = "Captain";
                    break;
                case "17":
                    NewRankname = "Major";
                    break;
                case "18":
                    NewRankname = "Lieutenant Colonel";
                    break;
                case "19":
                    NewRankname = "Colonel";
                    break;
                case "20":
                    NewRankname = "Brigadier General";
                    break;
                case "21":
                    NewRankname = "Major General";
                    break;
                case "22":
                    NewRankname = "Lieutenant General";
                    break;
                case "23":
                    NewRankname = "General";
                    break;
            }
            return NewRankname;
        }
        private static void wait(int v)
        {
            System.Threading.Thread.Sleep(v);
        }
        private static void wl(string write)
        {
            System.Console.WriteLine(write);
        }
        

    

    }
}
