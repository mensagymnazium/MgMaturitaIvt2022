while (true)
{
	Console.WriteLine("Zadejte zlomek:");
	string input = Console.ReadLine();

	var parts = input.Split('/');
	if (parts.Length != 2)
	{
		throw new InvalidOperationException("Neplatný vstup");
	}

	if (int.TryParse(parts[0].Trim(), out var num1) && int.TryParse(parts[1].Trim(), out var num2))
	{
		if (num2 == 0)
		{
			throw new InvalidOperationException("Nelze dělit nulou");
		}
		var output = FractionToPeriodicDecimal(num1, num2);
		Console.WriteLine(output);
	}
	else
	{
		throw new InvalidOperationException("Neplatný vstup");
	}
}

string FractionToPeriodicDecimal(int num1, int num2)
{
	int wholePart = num1 / num2;
	int remainder = num1 % num2;
	List<Tuple<int, int>> decimalsWithRemainders = new List<Tuple<int, int>>();
	decimalsWithRemainders.Add(new Tuple<int, int>(wholePart, remainder));
	while (remainder > 0)
	{
		remainder *= 10;
		wholePart = remainder / num2;
		remainder = remainder % num2;

		var periodStart = decimalsWithRemainders.FindIndex(i => i.Item2 == remainder);
		if (periodStart != -1)
		{
			// periodická část nalezena
			var nonperiodicPart = string.Join(String.Empty, decimalsWithRemainders.GetRange(1, periodStart).Select(i => i.Item1));
			var periodicPart = string.Join(String.Empty, decimalsWithRemainders.GetRange(periodStart + 1, decimalsWithRemainders.Count - periodStart - 1).Select(i => i.Item1));
			periodicPart = periodicPart + wholePart.ToString();
			return $"{decimalsWithRemainders[0].Item1}.{nonperiodicPart}({periodicPart})";
		}
		decimalsWithRemainders.Add(new Tuple<int, int>(wholePart, remainder));
	}
	
	// neperiodický výsledek (může být i celé číslo)
	return $"{decimalsWithRemainders[0].Item1}.{string.Join(String.Empty, decimalsWithRemainders.Skip(1).Select(i => i.Item1))}"
		.Trim('.');

}