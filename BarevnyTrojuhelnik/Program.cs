while (true)
{
	Console.WriteLine("Zadejte přvní řádek:");
	var input = Console.ReadLine();

	if (String.IsNullOrEmpty(input))
	{
		throw new InvalidOperationException("Řádek nesmí být prázdný.");
	}

	var output = Redukuj(input.ToUpper());
	Console.WriteLine(output);
}

string Redukuj(string input)
{
	if (input.Length == 1)
	{
		if ((input == "R") || (input == "G") || (input == "B"))
		{
			return input;
		}
		throw new InvalidOperationException("Neplatný vstup");
	}
	var redukce = String.Empty;
	for (int i = 0; i < input.Length - 1; i++)
	{
		if ((input[i] == input[i + 1])
			&& ((input[i] == 'R') || (input[i] == 'G') || (input[i] == 'B')))
		{
			redukce += input[i];
		}
		else if ((input[i] == 'R') && (input[i + 1] == 'G')
				|| (input[i] == 'G') && (input[i + 1] == 'R'))
		{
			redukce += 'B';
		}
		else if ((input[i] == 'R') && (input[i + 1] == 'B')
			|| (input[i] == 'B') && (input[i + 1] == 'R'))
		{
			redukce += 'G';
		}
		else if ((input[i] == 'G') && (input[i + 1] == 'B')
			|| (input[i] == 'B') && (input[i + 1] == 'G'))
		{
			redukce += 'R';
		}
		else
		{
			throw new InvalidOperationException("Neplatný vstup.");
		}
	}
	return Redukuj(redukce);
}