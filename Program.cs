Console.WriteLine("Plan Your Heist!");

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
        SkillLevel = GetValidIntegerInput("Enter team member's skill level (1 - 10): "),
        Courage = GetValidDecimalInput("Enter team member's courage factor (0.0 - 2.0): ")
    };

    teamMembers.Add(teamMember); 
    Console.WriteLine($"✅ Success! You have {teamMembers.Count} team member(s).");
}

if (teamMembers.Count > 0)
{
    Console.Clear();
    Console.WriteLine("Your Team Members:");
    foreach (TeamMember member in teamMembers)
    {
        Console.WriteLine(@$"• {member.Name} | Skill Level: {member.SkillLevel} | Courage Factor: {member.Courage:F1}");
    }
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
            if (input >= 1 && input <= 10)
            {
                return input;
            }
            else
            {
                Console.WriteLine("⛔ Skill Level needs to be a number between 1 - 10");
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