Console.WriteLine("Plan Your Heist!");

int bankDifficulty = GetValidIntegerInput("Enter the bank's difficulty level (max 100): ", 1, 100);

List<TeamMember> teamMembers = new List<TeamMember>();

while (true)
{
    string name = GetValidStringInput("Enter team member's name (or press Enter to finish): ");
    if (string.IsNullOrEmpty(name))
    {
        break;
    }
   
    TeamMember teamMember = new TeamMember
    {
        Name = name,
        SkillLevel = GetValidIntegerInput("Enter team member's skill level (1 - 20): ", 1, 20),
        Courage = GetValidDecimalInput("Enter team member's courage factor (0.0 - 2.0): ")
    };

    teamMembers.Add(teamMember); 
    Console.WriteLine($"✅ Success! You have {teamMembers.Count} team member(s).");
}

if (teamMembers.Count > 0)
{
    int trialRuns = GetValidIntegerInput("Enter the number of trial runs: ", 1, 50);
    int successfulRuns = 0;
    int failedRuns = 0;

    for (int i = 0; i <trialRuns; i++)
    {
        Random random = new Random();
        int luckValue = random.Next(-10, 11);
        int currentBankDifficulty = bankDifficulty + luckValue;

        int skillSum = teamMembers.Sum(member => member.SkillLevel);

        Console.WriteLine(@$"Trial Run {i + 1}:
Your team's combined Skill Level: {skillSum}
Bank difficulty level: {currentBankDifficulty}");

        if (skillSum >= currentBankDifficulty)
        {
            Console.WriteLine("✅ Success! Your team's skill level is sufficient to handle the bank's difficulty.");
            successfulRuns++;
        }
        else
        {
            Console.WriteLine("⛔ Failure. Your team's skill level is not strong enough to handle the bank's difficulty.");
            failedRuns++;
        }
    }
    Console.WriteLine($@"Simulation Complete:
- Successful Runs: {successfulRuns}
- Failed Runs: {failedRuns}");
}
else
{
    Console.WriteLine("⛔ No team members entered. You will fail the heist.");
}

string GetValidStringInput(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();
        if (input?.Length < 30)
        {
            return input;
        }
        Console.WriteLine("⛔ Invalid input. Ensure it's not empty or longer than 30 characters.");
    }
}

int GetValidIntegerInput(string prompt, int min, int max)
{
    while (true)
    {
        Console.WriteLine(prompt);
        try
        {
            int input = int.Parse(Console.ReadLine());
            if (input >= min && input <= max)
            {
                return input;
            }
            else
            {
                Console.WriteLine($"⛔ Input needs to be a number between {min} - {max}");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("⛔ Enter a valid number"); 
        }
    }
}

decimal GetValidDecimalInput(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        try
        {
            decimal input = decimal.Parse(Console.ReadLine());
            if (input >= 0.0M && input <= 2.0M)
            {
                return input;
            }
            else
            {
                Console.WriteLine("⛔ Courage Factor needs to be a decimal number between 0.0 - 2.0");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("⛔ Enter a valid decimal number"); 
        }
    }
}