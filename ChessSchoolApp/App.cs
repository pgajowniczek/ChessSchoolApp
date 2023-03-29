using ChessSchoolApp.Entities;
using ChessSchoolApp.Repositories;

public class App : IApp
{
    private readonly IRepository<Student> _studentRepository;
    private readonly IRepository<Trainer> _trainerRepository;
    private readonly IRankingProvider _rankingProvider;

    public App(
        IRepository<Student> studentRepository, 
        IRepository<Trainer> trainerRepository,
        IRankingProvider rankingProvider)
    {
        _studentRepository = studentRepository;
        _trainerRepository = trainerRepository;
        _rankingProvider = rankingProvider;
    }

    const string LogFileName = "logs.txt";





    public void Run()
    {
        AppOppened();
        _studentRepository.ItemAdded += UserRepositoryOnItemAdded;
        _trainerRepository.ItemAdded += UserRepositoryOnItemAdded;
        _studentRepository.ItemRemoved += UserRepositoryOnItemRemoved;
        _trainerRepository.ItemRemoved += UserRepositoryOnItemRemoved;
        bool isWorking = true;
        while (isWorking)
        {
            ClearConsole();
            var userInput = GetValueFromUser("1. Add user\n2. Show specific user\n3. Show all users\n4. Remove specific user\n X - Close the program");
            var stayInCurrentView = true;
            switch (userInput)
            {
                case "1":
                    while (stayInCurrentView)
                    {
                        ClearConsole();
                        string name;
                        string surname;
                        userInput = GetValueFromUser("What user you want to add\n1. Student\n2. Trainer\n3. Go back to previous view\nX - Close the program");
                        switch (userInput)
                        {
                            case "1":
                                ClearConsole();
                                name = GetValueFromUser("Name: ");
                                surname = GetValueFromUser("Surname: ");
                                _studentRepository.Add(new Student { FirstName = name, LastName = surname });
                                Console.WriteLine("User added!\npress any key to continue");
                                Console.ReadKey();
                                stayInCurrentView = false;
                                break;
                            case "2":
                                ClearConsole();
                                name = GetValueFromUser("Name: ");
                                surname = GetValueFromUser("Surname: ");
                                _trainerRepository.Add(new Trainer { FirstName = name, LastName = surname });
                                Console.WriteLine("User added!\npress any key to continue");
                                Console.ReadKey();
                                stayInCurrentView = false;
                                break;
                            case "3":
                                stayInCurrentView = false;
                                break;
                            case "x":
                            case "X":
                                stayInCurrentView = false;
                                isWorking = false;
                                AppClosed();
                                break;
                            default:
                                Console.WriteLine("Invalid value. Please try again when this text will disapear");
                                Thread.Sleep(1500);
                                break;
                        }

                    }

                    break;
                case "2":
                    ClearConsole();
                    userInput = GetValueFromUser("1. Student\n2. Trainer");
                    int providedID;
                    switch (userInput)
                    {
                        case "1":
                            providedID = int.Parse(GetValueFromUser("Please provide ID of the Student you want to display: "));
                            Console.WriteLine(_studentRepository.GetById(providedID));
                            Console.ReadKey();
                            break;
                        case "2":
                            providedID = int.Parse(GetValueFromUser("Please provide ID of the Trainer you want to display: "));
                            Console.WriteLine(_trainerRepository.GetById(providedID));
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Invalid value. Please try again when this text will disapear");
                            Thread.Sleep(1500);
                            break;
                    }
                    break;
                case "3":
                    userInput = GetValueFromUser("1. Students\n2. Trainers");
                    switch (userInput)
                    {
                        case "1":
                            var allStudents = _studentRepository.GetAll();
                            ClearConsole();
                            foreach (var student in allStudents)
                            {
                                Console.WriteLine(student);
                            }
                            Console.ReadKey();
                            break;
                        case "2":
                            var allTrainers = _trainerRepository.GetAll();
                            ClearConsole();
                            foreach (var trainer in allTrainers)
                            {
                                Console.WriteLine(trainer);
                            }
                            Console.ReadKey();
                            break;
                        default:
                            break;
                    }
                    break;
                case "4":
                    ClearConsole();
                    userInput = GetValueFromUser("1. Student\n2. Trainer");
                    switch (userInput)
                    {
                        case "1":
                            providedID = int.Parse(GetValueFromUser("Please provide ID of the Student you want to delete: "));
                            _studentRepository.Remove(_studentRepository.GetById(providedID));
                            Console.WriteLine("User deleted. Press any key to continue");
                            Console.ReadKey();
                            break;
                        case "2":
                            providedID = int.Parse(GetValueFromUser("Please provide ID of the Trainer you want to delete: "));
                            _trainerRepository.Remove(_trainerRepository.GetById(providedID));
                            Console.WriteLine("User deleted. Press any key to continue");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Invalid value. Please try again when this text will disapear");
                            Thread.Sleep(1500);
                            break;
                    }
                    break;
                case "x":
                case "X":
                    isWorking = false;
                    AppClosed();
                    break;
                default:
                    break;
            }
        }
    }

    static string GetValueFromUser(string text)
    {
        Console.WriteLine(text);
        string userInput = Console.ReadLine();
        return userInput;
    }

    static void ClearConsole()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        var logo = "   ______  __                             ______          __                     __         _                        \r\n .' ___  |[  |                          .' ____ \\        [  |                   [  |       / \\                       \r\n/ .'   \\_| | |--.  .---.  .--.   .--.   | (___ \\_| .---.  | |--.   .--.    .--.  | |      / _ \\    _ .--.   _ .--.   \r\n| |        | .-. |/ /__\\\\( (`\\] ( (`\\]   _.____`. / /'`\\] | .-. |/ .'`\\ \\/ .'`\\ \\| |     / ___ \\  [ '/'`\\ \\[ '/'`\\ \\ \r\n\\ `.___.'\\ | | | || \\__., `'.'.  `'.'.  | \\____) || \\__.  | | | || \\__. || \\__. || |   _/ /   \\ \\_ | \\__/ | | \\__/ | \r\n `.____ .'[___]|__]'.__.'[\\__) )[\\__) )  \\______.''.___.'[___]|__]'.__.'  '.__.'[___] |____| |____|| ;.__/  | ;.__/  \r\n                                                                                                  [__|     [__|  ";
        Console.Clear();
        Console.WriteLine(logo);
        Console.ResetColor();
    }

    static void AppOppened()
    {
        using (var writer = File.AppendText(LogFileName))
        {
            writer.WriteLine($"{DateTime.Now} - Application oppened ===================================================");
        }
    }
    static void AppClosed()
    {
        using (var writer = File.AppendText(LogFileName))
        {
            writer.WriteLine($"{DateTime.Now} - Application closed  ===================================================");
        }
    }

    void UserRepositoryOnItemAdded<T>(object? sender, T e) where T : class, INameable
    {
        var text = $"   {DateTime.Now} {typeof(T).Name} added => Name: {e.FirstName} Surname: {e.LastName} from {sender?.GetType().Name}";
        using (var writer = File.AppendText(LogFileName))
        {
            writer.WriteLine(text);
        }
    }

    void UserRepositoryOnItemRemoved<T>(object? sender, T e) where T : class, INameable
    {
        var text = $"       {DateTime.Now} {typeof(T).Name} REMOVED => Name: {e.FirstName} Surname: {e.LastName} from {sender?.GetType().Name}";
        using (var writer = File.AppendText(LogFileName))
        {
            writer.WriteLine(text);
        }
    }
}
