
using MyMonkeyApp;

internal class Program
{
	private static readonly string[] AsciiArts = new[]
	{
		@"  (o o)\//",
		@" ( . .)  (o o)",
		@"  (o.o)  ('.')",
		@"  (o_O)  (O_o)",
		@"  ( : )  ( : )",
		@"  ("""") ("""")",
		@"  (='.'=) (='.'=)"
	};

	public static async Task Main(string[] args)
	{
		await MonkeyHelper.LoadMonkeysAsync();
		bool exit = false;
		var random = new Random();
		while (!exit)
		{
			Console.Clear();
			// 랜덤 ASCII 아트 출력
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(AsciiArts[random.Next(AsciiArts.Length)]);
			Console.ResetColor();
			Console.WriteLine("\n==== Monkey App ====");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.Write("Select an option: ");
			var input = Console.ReadLine();
			Console.WriteLine();
			switch (input)
			{
				case "1":
					ListAllMonkeys();
					break;
				case "2":
					GetMonkeyByName();
					break;
				case "3":
					GetRandomMonkey();
					break;
				case "4":
					exit = true;
					break;
				default:
					Console.WriteLine("Invalid option. Try again.");
					break;
			}
			if (!exit)
			{
				Console.WriteLine("\nPress any key to return to menu...");
				Console.ReadKey();
			}
		}
	}

	private static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		if (monkeys.Count == 0)
		{
			Console.WriteLine("No monkeys found.");
			return;
		}
		Console.WriteLine($"{nameof(Monkey.Name),-20} {nameof(Monkey.Location),-25} {nameof(Monkey.Population),-10}");
		Console.WriteLine(new string('-', 60));
		foreach (var m in monkeys)
		{
			Console.WriteLine($"{m.Name,-20} {m.Location,-25} {m.Population,10}");
		}
	}

	private static void GetMonkeyByName()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		var monkey = MonkeyHelper.GetMonkeyByName(name ?? string.Empty);
		if (monkey == null)
		{
			Console.WriteLine("Monkey not found.");
			return;
		}
		Console.WriteLine($"Name: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}");
		if (!string.IsNullOrWhiteSpace(monkey.Image))
			Console.WriteLine($"Image: {monkey.Image}");
	}

	private static void GetRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		if (monkey == null)
		{
			Console.WriteLine("No monkeys available.");
			return;
		}
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine($"Random Monkey: {monkey.Name}");
		Console.ResetColor();
		Console.WriteLine($"Location: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}");
		if (!string.IsNullOrWhiteSpace(monkey.Image))
			Console.WriteLine($"Image: {monkey.Image}");
		Console.WriteLine($"(Random pick count: {MonkeyHelper.GetRandomPickCount()})");
	}
}
