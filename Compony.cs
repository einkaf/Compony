using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Managment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // managment usernaem and password are *admin*, as a manager, you can add or delete or edit employers name, task, username, password.
            string managementUsername = "admin",
                managementPassword = "admin";

            // guest username and password are *guest*, iin term that you forget your user | password, you can sign in as guest to see employer task.
            string guestUsername = "guest",
                guestPassword = "guest";

            // employers can change their password and see theit tasks.
            //string employerUsername,
            //    employerPassword;

            string[] employers = new string[0];
            bool mainMenu = false;


            while (mainMenu == false)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.Write("\n\n\t\tEnter your USERNAME : ");
                string username = Console.ReadLine();

                Console.Clear();
                Console.Write("\n\n\t\tEnter your PASSWORD : ");
                string password = Console.ReadLine();
                bool doesNotExist = true;

                if (username == managementUsername && password == managementPassword)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();

                    WellcomeMessage("\n\n\n\t\tHello dear boss :0 , press any key to continue... ");
                    //bool managementmenu means you enter the while as long as is true
                    bool managementmenu = true;
                    doesNotExist = false;

                    while (managementmenu == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Clear();

                        Console.WriteLine("\n\t\t- Management Menu -");
                        Console.WriteLine(new string('_', 100));

                        Console.WriteLine("\n\tA) ADD a new employer.");
                        Console.WriteLine("\n\tE) EDIT employers information.");
                        Console.WriteLine("\n\tD) DELET employer information.");
                        Console.WriteLine("\n\tP) PRINT  all information of employers.");
                        Console.WriteLine("\n\tT) PRINT and EDIT employer Task.");
                        Console.WriteLine("\n\tBackspace) BACK to sign in menu.");


                        ConsoleKeyInfo cki = Console.ReadKey(true);
                        switch (cki.Key)
                        {
                            case ConsoleKey.A:
                                TitleMenu("\n\t\t- ADD Menu -");
                                AddEmployer(ref employers);
                                break;

                            case ConsoleKey.E:
                                TitleMenu("\n\t\t- EDIT Menu -");
                                Console.Write("\n\tWhich employer want you to edit? write his|her last name, i will find it, if it exist\n\tand you can chage the information : ");
                                string search = Console.ReadLine();
                                int index = Find(employers, search);
                                if (index > -1)
                                {
                                    Console.Clear();
                                    Console.Write("\n\tPefect, i've found it, now...\n\tInsert new first name of the employer: ");
                                    string employerFirstname = Console.ReadLine();

                                    Console.Write("\n\tso, add her/his new last name : ");
                                    string employerLastname = Console.ReadLine();

                                    Console.Write($"\n\tnow, define a new username for \"{employerFirstname}\" : ");
                                    string employerUsername = Console.ReadLine();

                                    Console.Write($"\n\tnow, define a new password for  \"{employerFirstname}\" : ");
                                    string employerPassword = Console.ReadLine();

                                    Console.Write("\n\tPerfect, What is he|she responsible for? Expailn his|her new Task here ;) :  ");
                                    string employerTask = Console.ReadLine();



                                    string completedEmployer = employerFirstname + '#' + employerLastname + '#' + employerUsername + '#' + employerPassword + '#' + employerTask + "#1";

                                    employers[index] = completedEmployer;

                                    BackToBossMenuMessage();
                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\n\tSorry dear BOSS, the \"{search}\" has not been hired yet ;))))))) ....");
                                    Console.ReadKey();
                                }
                                break;



                            case ConsoleKey.D:
                                TitleMenu("\n\t\t- DELET Menu -");
                                Console.Write("\n\t\tWhich employer want you to DELETE? write his|her last name, i will find it,\n\t\tif it exist and you can DELET the information : ");
                                string searchDelete = Console.ReadLine();
                                int indexDelete = Find(employers, searchDelete);
                                if (indexDelete > -1)
                                {
                                    string[] delete = employers[indexDelete].Split('#');
                                    employers[indexDelete] = delete[0] + '#' + delete[1] + '#' + delete[2] + '#' + delete[3] + '#' + delete[4] + "#0";
                                    Console.WriteLine($"\n\t\t\"{searchDelete}\" was successfully deleted!");
                                    BackToBossMenuMessage();
                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\n\tSorry dear BOSS, the \"{searchDelete}\" has not been hired yet ;))))))) ....");
                                    Console.ReadKey();

                                }

                                break;

                            case ConsoleKey.P:
                                TitleMenu("\n\t\t- PRINT Menu -");
                                PrintEmployersInformation(employers);
                                break;

                            case ConsoleKey.T:
                                TitleMenu("\n\t\t- PRINT & Edit Tasks -\n");
                                Console.Write("\n\tWrite your employers last name, and i will tell you his|her task : ");
                                string searchTask = Console.ReadLine();
                                Console.Clear();

                                int indexTask = Find(employers, searchTask);
                                if (indexTask > -1)
                                {
                                    string[] tasks = employers[indexTask].Split('#');
                                    Console.WriteLine("\n\t\tlast name of the employer : " + tasks[1] + "\n\t\tTask : " + tasks[4]);
                                    Console.WriteLine("\n\n\t\tDo you want to change it?\n\t\tPress \"ENTER\" to CHAGE or \"BACKSPACE\" to back to main menu...");

                                    ConsoleKeyInfo yesOrNo = Console.ReadKey(true);
                                    Console.Clear();
                                    switch (yesOrNo.Key)
                                    {
                                        case ConsoleKey.Enter:
                                            Console.Write($"\n\n\t\tnew task for \"{tasks[1]}\" : ");
                                            tasks[4] = Console.ReadLine();
                                            employers[indexTask] = tasks[0] + '#' + tasks[1] + '#' + tasks[2] + '#' + tasks[3] + '#' + tasks[4] + '#' + "1";
                                            Console.Clear();
                                            Console.WriteLine("\n\n\tChanges was successfully saved!");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;

                                        case ConsoleKey.Backspace:
                                            break;

                                    }
                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\n\tSorry dear BOSS, the \"{searchTask}\" has not been hired yet ;))))))) ....");
                                    Console.ReadKey();
                                }
                                break;

                            case ConsoleKey.Backspace:
                                TitleMenu("\n\n\n\t\t\tSee you soon BOSS! ;)\n\n");
                                Console.ReadKey();
                                managementmenu = false;
                                break;


                            default:
                                DefaultEror("BOSS");
                                break;
                        }
                    }
                }

                if (username == guestUsername && password == guestPassword)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear(); 

                    doesNotExist = false;
                    bool guestMenu = true;
                    while (guestMenu == true)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t\t- Guest Menu -");
                        Console.WriteLine(new string('_', 100));
                        Console.WriteLine("\n\tP) PRINT  all information of employers");
                        Console.WriteLine("\n\tT) PRINT employer Task");
                        Console.WriteLine("\n\tBackspace) BACK to sign in menu.");

                        ConsoleKeyInfo cki = Console.ReadKey(true);
                        switch (cki.Key)
                        {
                            case ConsoleKey.P:
                                TitleMenu("\n\t\t- PRINT Menu -");
                                PrintEmployersInformationForGuest(employers);
                                break;

                            case ConsoleKey.T:
                                TitleMenu("\n\t\t- PRINT & Edit Tasks -");
                                Console.Write("\n\tWrite your employers last name, and i will tell you his|her task : ");
                                string searchTask = Console.ReadLine();
                                Console.Clear();

                                int indexTask = Find(employers, searchTask);
                                if (indexTask > -1)
                                {
                                    string[] tasks = employers[indexTask].Split('#');
                                    Console.WriteLine("\n\tlast name of the employer : " + tasks[1] + "\n\tTask : " + tasks[4]);
                                    Console.WriteLine("\n\t\tPress any key to back to guest menu");
                                    Console.ReadKey();
                                    Console.Clear();

                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\t\t\n\nSorry dear GUEST, the {searchTask} does not existed ;))))))) ....");

                                    BackToGuestMenuMessage();
                                }
                                break;

                            case ConsoleKey.Backspace:
                                TitleMenu("\n\n\t\tSee you soon dear GUEST! ;)\n\n");
                                Console.ReadKey();
                                guestMenu = false;
                                break;


                            default:
                                DefaultEror("GUEST");
                                break;
                        }


                    }

                    ///*guestMenu*/();
                }

                for (int i = 0; i < employers.Length; i++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();

                    doesNotExist = false;
                    string[] epmloyerUserAndPassword = employers[i].Split('#');
                    if (epmloyerUserAndPassword[2] == username && epmloyerUserAndPassword[3] == password)
                    {
                       Console.Clear() ;
                       Console.Write($"\n\n\twellcome to your account dear {epmloyerUserAndPassword[0]} ...(press any key to continue) ");
                       Console.ReadKey(true);

                        bool employerMenu = true;
                        while (employerMenu == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.Clear();
                            Console.WriteLine("\n\t\t- Employer Menu -");
                            Console.WriteLine(new string('_', 100));
                            Console.WriteLine("\n\tS) Show task");
                            Console.WriteLine("\n\tU) Change Username and Password");
                            Console.WriteLine("\n\tBackspaceB) BACK to sign in menu.");

                            ConsoleKeyInfo cki = Console.ReadKey(true);
                            switch (cki.Key)
                            {
                                case ConsoleKey.S:
                                    TitleMenu("\n\t\t- Show Task -");
                                    Console.Write($"\n\tyour task is \" {epmloyerUserAndPassword[4]}\" dear {epmloyerUserAndPassword[0]} ...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;


                                case ConsoleKey.U:
                                    TitleMenu("\n\t\t- Change Username and Password -");
                                    Console.Write("\n\tInsert your Username : ");
                                    string lastUsername = Console.ReadLine();
                                    Console.Clear();
                                    if (lastUsername == epmloyerUserAndPassword[2])
                                    {
                                        Console.Write("\n\tInsert your new Username : ");
                                        string newUsename = Console.ReadLine();
                                        epmloyerUserAndPassword[2] = newUsename;
                                        employers[i] = epmloyerUserAndPassword[0] + '#' + epmloyerUserAndPassword[1] + '#' + epmloyerUserAndPassword[2] + '#' + epmloyerUserAndPassword[3] + '#' + epmloyerUserAndPassword[4] + '#' + "1";

                                        Console.Clear();

                                        bool exitEnterPassword = true;

                                        while (exitEnterPassword == true)
                                        {
                                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Clear();


                                            Console.Write("\n\tYour Username was successfully changed...");
                                            Console.Write("\tdo you want to change your password too?\n\t\tY) Yes\n\t\tN) No");
                                            ConsoleKeyInfo change = Console.ReadKey(true);

                                            switch (change.Key)
                                            {



                                                case ConsoleKey.Y:
                                                    Console.Clear() ;
                                                    Console.WriteLine("\n\tInsert your Password : ");
                                                    string lastPassword = Console.ReadLine();
                                                    if (lastPassword == epmloyerUserAndPassword[3])
                                                    {

                                                        Console.Clear();
                                                        Console.WriteLine("\n\tInsert your new Password : ");
                                                        string newPassword = Console.ReadLine();
                                                        Console.Clear();
                                                        epmloyerUserAndPassword[3] = newPassword;
                                                        Console.WriteLine("\n\tYour Password was successfully changed...");
                                                        Console.Write("\tPress any key to back to employer menu.");
                                                        employers[i] = epmloyerUserAndPassword[0] + '#' + epmloyerUserAndPassword[1] + '#' + epmloyerUserAndPassword[2] + '#' + epmloyerUserAndPassword[3] + '#' + epmloyerUserAndPassword[4] + '#' + "1";
                                                        exitEnterPassword = false;
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                    }

                                                    else
                                                    {
                                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.Clear();
                                                        Console.WriteLine("\n\tyour Password is false, try again... ");
                                                        Console.ReadKey();

                                                    }
                                                    Console.Clear();

                                                    break;
                                                case ConsoleKey.N:
                                                    exitEnterPassword = false;
                                                    break;
                                                default:
                                                    DefaultEror($"{epmloyerUserAndPassword[0]}");
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Clear();
                                        Console.Clear();
                                        Console.WriteLine("\n\n\tUsername is false!");
                                        Console.ReadKey();
                                    }
                                    break;


                                case ConsoleKey.Backspace:
                                    TitleMenu($"\n\n\tSee you soon dear {epmloyerUserAndPassword[0]}! ;)\n\n");
                                    Console.ReadKey();
                                    employerMenu = false;
                                    break;


                                default:
                                    DefaultEror($"{epmloyerUserAndPassword[0]}");
                                    break;
                            }
                        }
                    }
                }

                if (doesNotExist == true)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                   
                    Console.Clear ();
                    Console.Write("\n\n\t\tUser does not found!  ");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
        static void WellcomeMessage(string wellcome)
        {
            Console.Clear();
            Console.Write(wellcome);
            Console.ReadKey();
            Console.Clear();
        }
        static void DefaultEror(string name)
        {
            Console.Clear();
            Console.WriteLine($"\n\n\n\tDear {name}, your input is not defined, please pay attention to menu guid, and insert correctly ^_^ ... ");
            Console.ReadKey();
            Console.Clear();
        }
        static void TitleMenu(string name)
        {
            Console.Clear();
            Console.WriteLine(name);
            Console.WriteLine(new string('_', 100));
        }
        static void AddEmployer(ref string[]test)
        {
            Console.Clear();
            Console.Write("\n\tInsert first name of the new employer: ");
            string employerFirstname = Console.ReadLine();

            Console.Write("\n\tso, add her/his last name : ");
            string employerLastname = Console.ReadLine();

            Console.Write($"\n\tnow, define a username for \"{employerFirstname}\"  : ");
            string employerUsername = Console.ReadLine();

            Console.Write($"\n\tthen, define a password for \"{employerFirstname}\"  : ");
            string employerPassword = Console.ReadLine();

            Console.Write("\n\tPerfect, What is he|she responsible for? Expailn his|her  Task here ;) : ");
            string employerTask = Console.ReadLine();



            string completedEmployer = employerFirstname + '#' + employerLastname + '#' + employerUsername + '#' + employerPassword + '#' + employerTask + "#1";

            Array.Resize<string>(ref test, test.Length + 1);

            test[test.Length - 1] = completedEmployer;

            BackToBossMenuMessage();
        }
        static void PrintEmployersInformation(string[]test)
        {
            for (int i = 0; i < test.Length; i++)
            {
                string[] information = test[i].Split('#');
                if (information[5] == "1")
                {
                    Console.WriteLine("\n\tFirst name : " + information[0] + "\t\tLast name : " + information[1] + "\n\n\tEmployer username : " + information[2] + "\t\tEmployer password : " + information[3] + "\n\n\tEmployer Task : " + information[4] );
                    Console.WriteLine();
                    Console.WriteLine(new string('_', 70));

                }
            }
            BackToBossMenuMessage();
        }
        static void PrintEmployersInformationForGuest(string[] test)
        {
            for (int i = 0; i < test.Length; i++)
            {
                string[] information = test[i].Split('#');
                if (information[5] == "1")
                {
                    Console.WriteLine("\n\tFirst name : " + information[0] + "\t\tLast name : " + information[1] + "\n\n\tEmployer Task : " + information[4]);
                    Console.WriteLine();
                    Console.WriteLine(new string('_', 70));

                }
            }
            BackToGuestMenuMessage();
        }
        static void BackToBossMenuMessage()
        {
            Console.WriteLine();
            Console.WriteLine(new string('_', 100));
            Console.WriteLine("\n\n\tIt's over, press any key to back to Management Menu, BOSS <'_'> ... ");
            Console.ReadKey(true);
        }
        static void BackToGuestMenuMessage()
        {
            Console.WriteLine(new string('_', 100));
            Console.WriteLine("It's over, press any key to back to Management Menu, Guest < _ > ... ");
            Console.ReadKey(true);
        }
        static int Find(string[] testFind, string lastname)
        {
            int index = -1;

            for (int i = 0; i < testFind.Length; i++)
            {
                string[] info = testFind[i].Split('#');
                if (info[1] == lastname)
                {
                    index = i;
                }
            }
            return index;
        }
    }

}
