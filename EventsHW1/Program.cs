using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventsHW1.StudentList;

namespace EventsHW1
{
   
    public delegate void LongThen10();
    public delegate void LuckyNumber();
    public class Program
    {
        public static void PrintWrong()
        {
            Console.WriteLine("The name is longer then 10 char");
        }
        public static void PrintOK()
        {
            Console.WriteLine("The name is CORRECT");
        }

        public static void  GetNumber(int num)
        {
            Console.WriteLine("Enter number...");
            num = int.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            #region q1
            Person person = new Person("khjkjkk");
            if (person.Name.Length > 10)
            {
                WrongName();
            }
            else
            {
                CorrectName();
            }
            #endregion

            #region q2

            Console.WriteLine("Enter number...");
            int num = int.Parse(Console.ReadLine());

            while (num != 999)
            {
                Console.WriteLine("Enter number...");
                num = int.Parse(Console.ReadLine());
            }
            luckyNumOK();

            #endregion

            #region  q3
            StudentList sl = new StudentList();
            Student s1 = new Student();
            Student s2 = new Student();
            Student s3 = new Student();
            Student s4 = new Student();
            Student s5 = new Student();
            DiscountsManage dm = new DiscountsManage();

            sl.FivePrcDiscount += dm.GetFivePrcntDiscount;

            sl.AddStudent(s1);
            sl.AddStudent(s5);
            sl.AddStudent(s4);
            sl.AddStudent(s3);
            sl.AddStudent(s2);
            #endregion

            #region q5
            Bank b = new Bank();
            User u = new User();
            b.SuccessLogin += u.OnTryLogin;
            b.UnsuccessLogin += u.OnTryLogin;

            b.Login("123", "123");
            User unSuccessLoginUser = b.Login("33", "123");
            User loggedUser = b.Login("33", "acdsc");

            b.BalanceChanged += u.Account.WhenDeposit;
            b.Deposit(unSuccessLoginUser, 41231);
            b.Deposit(loggedUser, 1231);

#endregion


        }
        public static event LongThen10 CorrectName = PrintOK;
        public static event LongThen10 WrongName = PrintWrong;

        public static void PrintLuckyNumIsOK() { Console.WriteLine("Lucky Number was entered"); }
        public static event LuckyNumber luckyNumOK = PrintLuckyNumIsOK;
        
    }
    

    
}
