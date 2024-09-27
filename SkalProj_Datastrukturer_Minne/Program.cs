using System;
using System.Collections;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        /// 

        static void Main()
        {
            List<string> theList = new List<string>();
            Queue<string> queue = new Queue<string>();
            Stack<string> stack = new Stack<string>();
            
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Recursion"
                    + "\n0. Exit the application"
                    + "\nEnter your choice:");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList(theList);
                        break;
                    case '2':
                        ExamineQueue(queue);
                        break;
                    case '3':
                        ExamineStack(stack);
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        RecursionAndIteration();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

       

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList(List<string> theList)
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            bool isActive = true;

            while (isActive)
            {
                Console.WriteLine("Examine List\n(+):Add\n(-):Remove\n(0):Exit");
                Console.WriteLine("Enter the character to add or remove in the list:");
                string input = Console.ReadLine();
                validateInput(input);
                char nav = input[0];
                string value = input.Substring(1);

                switch(nav)
                {
                    case '+':
                        addItem(theList, value);
                        break;
                    case '-':
                        removeItem(theList, value);
                        break;
                    case '0':
                        isActive = false;
                        Console.WriteLine("Exiting..");
                        break;
                    default :
                        Console.WriteLine("Enter only special chars (+ or -) to add or remove names");
                        break;   
                }
            }
        }

        private static void validateInput(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("enter the valid input value");
            }
        }

        //Answers:
        /*2&3. The list capacity dynamically allocates 4 slots and it increases power of 2 like (4,8,12...) 
        when the elements are added to the list and then capacity increases accordingly.*/
        /*4. It helps to reduce the resizing opreations because every time when you add a new element make resize operation 
        and it copies all the elements to the list.It is very time consuming process.But when the list using this 
        growth strategy it increases the performance too.  */
        //5.No, the capacity will not change dynamically. but we can reduce the unused slots manually by using TrimExcess() Method.
        //6.Yes, it is advantageous because arrays don't need to increase capacity, allocate extra memory, and process much faster than lists.

        private static void addItem(List<string> theList, string value)
        {
            theList.Add(value);
            Console.WriteLine("Total count of the list:"+theList.Count+ "List the capcity:"+theList.Capacity);
            DisplayTheList(theList);
        }
        private static void removeItem(List<string> theList, string value)
        {
            theList.Remove(value);
            Console.WriteLine("Total count of the list:"+theList.Count+ "List the capcity:"+theList.Capacity);
            DisplayTheList(theList);
        }

        private static void DisplayTheList(List<string> theList)
        {
            if(theList.Count == 0)
            {
                Console.WriteLine("The list is empty");
            }
            else
            {
                foreach(string list in theList)
                {
                    Console.WriteLine(list);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue(Queue<string> queue)
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            
            bool isActive = true;
            while (isActive)
            {
                Console.WriteLine("Examine Queue\n(E):Add the tem\n(D):Remove an item\n(Q):Quit");
                Console.WriteLine("Enter the value to add or remove  in the queue:");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "E": 
                        AddItemInQueue(queue); 
                        break;
                    case "D":
                        RemoveItemInQueue(queue);
                        break;
                    case "Q":
                        isActive = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Type the valid input on the screen");
                        break;
                }
            }
        }

        private static void AddItemInQueue(Queue<string> queue)
        {
            Console.WriteLine("ENTER THE VALUE:");
            string value = Console.ReadLine();
            validateInput(value);
            queue.Enqueue(value);
            Console.WriteLine($"{value} add to the queue");
            DisplayTheQueue(queue);
        }

        private static void RemoveItemInQueue(Queue<string> queue)
        {
            if (queue.Count > 0){
                var removedItem = queue.Dequeue();
                Console.WriteLine($"{removedItem} removed in the queue\n");
            }
            else{
                Console.WriteLine("Queue is empty");
            }
            DisplayTheQueue(queue);
        }

        private static void DisplayTheQueue(Queue<string> queue)
        {
            Console.WriteLine("Members in the queue:");
            if (queue.Count == 0) { Console.WriteLine("Queue is empty"); }
            foreach(string item in queue)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack(Stack<string> stack)
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        
            bool isActive = true;
            var choice = 0;
            while (isActive)
            {
                Console.WriteLine("Examine Stack\n(1):Add or push the item\n(2):Remove or pop an item\n(3):Reverse Text\n(0):Back to main menu");
                Console.WriteLine("Enter the value to add or remove  in the stack:");
                string input = Console.ReadLine();
                validateInput(input);
                int.TryParse(input, out choice);
                switch(choice)
                {
                    case 1: 
                        AddItemInStack(stack); 
                        break;
                    case 2:
                        RemoveItemInStack(stack); 
                        break;
                    case 3:
                        ReverseText(stack);
                        break;
                    case 0:
                        isActive = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Choose the valid input (1, 2 or 0) on the screen");
                        break;
                }
            }
        }

        //Answers: Stack is following different approach for various things like pile the books or cups.
        //So we can't use or compare this approach to the queue. Its really unfair to serve when the member comes last and serves first.
        private static void RemoveItemInStack(Stack<string> stack)
        {
            if (stack.Count > 0){
                var removedItem = stack.Pop();
                Console.WriteLine($"{removedItem} removed in the stack\n");
            }
            DisplayTheStack(stack);
        }

        private static void AddItemInStack(Stack<string> stack)
        {
            Console.WriteLine("ENTER THE NAME:");
            string InputValue = Console.ReadLine();
            validateInput(InputValue);
            stack.Push(InputValue);
            Console.WriteLine($"{InputValue} add to the stack");
            DisplayTheStack(stack);
        }

        private static void DisplayTheStack(Stack<string> stack)
        {
            Console.WriteLine("Members in the stack:");
            if (stack.Count == 0) { Console.WriteLine("Stack is empty"); }
            foreach(string item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }


        static void ReverseText(Stack<string> stack)
        {
            if (stack.Count > 0)
            {
                Console.WriteLine("Memebers name in reverse order:");
                foreach (string item in stack)
                {
                    Stack<char> charStack = new Stack<char>(item);
                    while (charStack.Count > 0)
                    {
                        Console.Write(charStack.Pop());
                    }
                    Console.WriteLine();
                }
            }
            else{
                Console.WriteLine("Stack is empty, can't reverse the names");
            }
            
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("ENTER THE TEXT:");
            string inputString = Console.ReadLine();
            validateInput(inputString);
            Stack<char> checkParan = new Stack<char>();
            bool validString = ValidateParantheses(checkParan, inputString);
            if (!validString)
            {
                Console.WriteLine("Parantheses are not matched");
            }
            else
            {
                Console.WriteLine("Parantheses are matched and Well-formed string is presented");
            }
            Console.WriteLine();
        }

        private static bool ValidateParantheses(Stack<char> checkParan, string inputString)
        {
            foreach(char c in inputString.ToCharArray())
            {
                //check opening parantheses and push to stack
                if ( c == '(' || c == '{' || c == '[')
                {
                    checkParan.Push(c); 
                }
                //Check closing parantheses and pop out if required condition matches
                else if ( c == ')' || c == '}' || c == ']')
                {
                    if (checkParan.Count == 0)
                    {
                        return false;
                    }
                    char popItem = checkParan.Pop(); // top item will be removed and returned value will be stored in popItem variable 
                    if (popItem != '(' && c == ')' || popItem != '[' && c == ']' || popItem != '{' && c == '}')
                    {
                        return false; // if mismatch occured
                    }
                }
            }
            return checkParan.Count == 0;  // if the count is 0 then parantheses are matched 
        }

        private static void RecursionAndIteration()
        {

            bool isActive = true;
            var inputChoice = 0;
            while (isActive){
                Console.WriteLine("Examine Recursion\n1:Recursion for odd numbers\n2:Recursion for even numbers\n3:Fabinocci series\n0:Back to main menu");
                Console.WriteLine("Enter the value:");
                string inputValue = Console.ReadLine();
                validateInput(inputValue);
                int.TryParse(inputValue, out inputChoice);
                switch(inputChoice)
                {
                    case 1: 
                        RecursiveOddNumber(); 
                        break;
                    case 2:
                        RecursiveEvenNumber();
                        break;
                    case 3:
                        FabanocciSeries();
                        break;
                    case 0:
                        isActive = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Type the valid input on the screen");
                        break;
                }
            }
        }


        private static void RecursiveOddNumber()
        {
            Console.WriteLine("Enter the odd number:");
            int n = Convert.ToInt32(Console.ReadLine());
            int result = RecursiveOdd(n);
            if (result == 0){
                Console.WriteLine("Invalid input number are given");
            }
            else{
                Console.WriteLine($"Result of {n} : {result}");
            }
            
        }

        private static int RecursiveOdd(int n)
        {
            Console.WriteLine($"Fact({n})");
            if (n == 1){
                return 1;
            }
            else if ((n % 2) == 1)
            {
                return n * RecursiveOdd(n-2);
            }
            else{
                return 0;
            }
        }

        private static void RecursiveEvenNumber()
        {
            Console.WriteLine("Enter the even number:");
            int n = Convert.ToInt32(Console.ReadLine());
            int result = RecursiveEven(n);
            if (result == 0){
                Console.WriteLine("Invalid input number are given");
            }
            else{
                Console.WriteLine($"Result of {n} : {result}");
            }
        }

        private static int RecursiveEven(int n)
        {
            Console.WriteLine($"Fact({n})");
            if (n == 2){
                return 2;
            }
            else if ((n % 2) == 0)
            {
                return n * RecursiveEven(n-2);
            }
            else{
                return 0;
            }
        }


        private static void FabanocciSeries()
        {
            throw new NotImplementedException();
        }

        
    }

    

}

