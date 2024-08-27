Console.WriteLine("Plan Your Heist!");

List<TeamMember> teamMembers = new List<TeamMember>();

int bankDifficulty = 100;

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
        SkillLevel = GetValidIntegerInput("Enter team member's skill level (1 - 20): "),
        Courage = GetValidDecimalInput("Enter team member's courage factor (0.0 - 2.0): ")
    };

    teamMembers.Add(teamMember); 
    Console.WriteLine($"✅ Success! You have {teamMembers.Count} team member(s).");
}

int skillSum = teamMembers.Sum(member => member.SkillLevel);

if (skillSum >= bankDifficulty)
{
    Console.WriteLine("✅ Success! Your team's skill level is sufficient to handle the bank's difficulty.");
}
else if (teamMembers.Count == 0)
{
    Console.WriteLine("⛔ No team members entered. You will fail the heist.");
}
else
{
    Console.WriteLine("⛔ Failure. Your team's skill level is not strong enough to handle the bank's difficulty.");
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

int GetValidIntegerInput(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        try
        {
            int input = int.Parse(Console.ReadLine());
            if (input >= 1 && input <= 20)
            {
                return input;
            }
            else
            {
                Console.WriteLine("⛔ Skill Level needs to be a number between 1 - 20");
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