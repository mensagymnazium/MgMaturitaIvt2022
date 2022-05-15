var calculator = new RomanNumeralsCalculator();
while (true)
{
	Console.WriteLine("Zadej příklad:");
	var input = Console.ReadLine();

	var parts = input.Split('+');
	if (parts.Length != 2)
	{
		throw new InvalidOperationException("Příklad musí být ve tvaru a+b");
	}
	var sum = calculator.Add(parts[0].Trim(), parts[1].Trim());
	Console.WriteLine(sum);
}

public class RomanNumeralsCalculator
{
	private Dictionary<string, int> knownValues;

	public RomanNumeralsCalculator()
	{
		knownValues = new Dictionary<string, int>();
		knownValues.Add("I", 1);
		knownValues.Add("IV", 4);
		knownValues.Add("V", 5);
		knownValues.Add("IX", 9);
		knownValues.Add("X", 10);
		knownValues.Add("XL", 40);
		knownValues.Add("L", 50);
		knownValues.Add("XC", 90);
		knownValues.Add("C", 100);
		knownValues.Add("CD", 400);
		knownValues.Add("D", 500);
		knownValues.Add("CM", 900);
		knownValues.Add("M", 1000);
	}

	public string Add(string number1, string number2)
	{
		var sum = RomanToArabic(number1) + RomanToArabic(number2);
		return ArabicToRoman(sum);
	}

	private string ArabicToRoman(int arabic)
	{
		string roman = String.Empty;
		while (arabic > 0)
		{
			var numeral = knownValues.OrderByDescending(kv => kv.Value).First(kv => kv.Value <= arabic);
			roman += numeral.Key;
			arabic = arabic - numeral.Value;
		}
		return roman;
	}

	private int RomanToArabic(string roman)
	{
		if (roman.Length == 0) return 0;
		roman = roman.ToUpper();

		int total = 0;
		int lastValue = 0;
		for (int i = roman.Length - 1; i >= 0; i--)
		{
			if (knownValues.TryGetValue(roman[i].ToString(), out var new_value))
			{
				if (new_value < lastValue)
				{
					total -= new_value;
				}
				else
				{
					total += new_value;
					lastValue = new_value;
				}
			}
			else
			{
				throw new InvalidOperationException("Neznámá římská číslice.");
			}
		}

		return total;
	}
}