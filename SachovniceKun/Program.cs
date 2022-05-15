while (true)
{
	Console.WriteLine("Rozměry šachovnice:");
	var dimensions = Console.ReadLine();
	var dimensionsParts = dimensions.Split('x');
	if (dimensionsParts.Length != 2)
	{
		throw new InvalidOperationException("Špatně zadané rozměry!");
	}
	var chessboardWidth = int.Parse(dimensionsParts[0]);
	var chessboardHeight = int.Parse(dimensionsParts[1]);

	Console.WriteLine("Počáteční pozice:");
	var start = Console.ReadLine();
	var startParts = start.Split(',');
	if (startParts.Length != 2)
	{
		throw new InvalidOperationException("Špatně zadaná pozice!");
	}
	var startX = int.Parse(startParts[0]) - 1;
	var startY = int.Parse(startParts[1]) - 1;

	Console.WriteLine("Koncová pozice:");
	var end = Console.ReadLine();
	var endParts = end.Split(',');
	if (endParts.Length != 2)
	{
		throw new InvalidOperationException("Špatně zadaná pozice!");
	}
	var endX = int.Parse(endParts[0]) - 1;
	var endY = int.Parse(endParts[1]) - 1;

	var chessboard = new Chessboard(chessboardWidth, chessboardHeight);
	int output = chessboard.GetDistance(startX, startY, endX, endY);
	Console.WriteLine("Vzdálenost: {0}", output);
}

public class Chessboard
{
	private int width;
	private int height;

	public Chessboard(int width, int height)
	{
		this.width = width;
		this.height = height;
	}

	public int GetDistance(int startX, int startY, int endX, int endY)
	{
		if (!IsInside(startX, startY) || !IsInside(endX, endY))
		{
			throw new InvalidOperationException("Pozice mimo šachovnici.");
		}

		var distances = new int[width, height];
		var queue = new Queue<Tuple<int, int>>();
		queue.Enqueue(new(startX, startY));

		while (queue.TryDequeue(out var currentPosition))
		{
			var currentDistance = distances[currentPosition.Item1, currentPosition.Item2];

			if ((currentPosition.Item1 == endX) && (currentPosition.Item2 == endY))
			{
				return currentDistance;
			}

			EnqueueIfNotVisited(currentPosition.Item1 - 2, currentPosition.Item2 + 1);
			EnqueueIfNotVisited(currentPosition.Item1 - 2, currentPosition.Item2 - 1);
			EnqueueIfNotVisited(currentPosition.Item1 + 2, currentPosition.Item2 + 1);
			EnqueueIfNotVisited(currentPosition.Item1 + 2, currentPosition.Item2 - 1);
			EnqueueIfNotVisited(currentPosition.Item1 - 1, currentPosition.Item2 + 2);
			EnqueueIfNotVisited(currentPosition.Item1 - 1, currentPosition.Item2 - 2);
			EnqueueIfNotVisited(currentPosition.Item1 + 1, currentPosition.Item2 + 2);
			EnqueueIfNotVisited(currentPosition.Item1 + 1, currentPosition.Item2 - 2);

			void EnqueueIfNotVisited(int x, int y)
			{
				if (IsInside(x, y) && (distances[x, y] == 0))
				{
					distances[x, y] = currentDistance + 1;
					queue.Enqueue(new(x, y));
				}
			}
		}

		// diagnostický výpis vzdáleností
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				Console.Write(distances[i, j] + " ");
			}
			Console.WriteLine();
		}
		throw new InvalidOperationException("Nenalezena cesta.");
	}

	private bool IsInside(int x, int y)
	{
		if ((x < 0) || (x >= width) || (y < 0) || (y >= height))
		{
			return false;
		}
		return true;
	}
}