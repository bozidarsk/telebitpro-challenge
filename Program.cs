// bin/Release/net9.0/telebitpro-challenge  0.66s user 0.02s system 23% cpu 2.870 total

List<int> input;

do 
{
	input = ParseLine("Line 1: ");

	if (input.Count != 2)
		Console.WriteLine("First line must contain 2 integers.");
} while (input.Count != 2);

int sheepCount = input[0], tripCount = input[1];

do 
{
	input = ParseLine("Line 2: ");

	if (input.Count != sheepCount)
		Console.WriteLine($"Second line must contain {sheepCount} integers.");
} while (input.Count != sheepCount);

List<int> weights = input;
int minCapacity;

for (minCapacity = weights.Max(); CalculateTripCount(new(weights), minCapacity) != tripCount; minCapacity++);

Console.WriteLine(minCapacity);

static int CalculateTripCount(List<int> weights, int capacity) 
{
	int tripCount = 1, total = 0;

	while (weights.Count > 0) 
	{
		var query = weights.Where(x => total + x <= capacity);

		if (!query.Any()) 
		{
			tripCount++;
			total = 0;
			continue;
		}

		int current = query.Max();

		if (current > capacity)
			return -1; // there is a sheep heavier than the maximum capacity

		weights.Remove(current);
		total += current;
	}

	return tripCount;
}

static List<int> ParseLine(string? message = null) 
{
	start:

	if (message != null)
		Console.Write(message);

	string[]? source = Console.ReadLine()?.Split(' ');

	if (source == null || source.Length == 0) 
	{
		Console.WriteLine("Stdin must not be null or empty.");
		goto start;
	}

	Span<int> destination = stackalloc int[source.Length];
	int di = 0;

	for (int si = 0; si < source.Length; si++) 
	{
		if (string.IsNullOrWhiteSpace(source[si]))
			continue;

		if (!int.TryParse(source[si], out int value)) 
		{
			Console.WriteLine($"Value '{source[si]}' is not an integer. Please input the line correctly.");
			goto start;
		}

		destination[di++] = value;
	}

	var data = new List<int>(di);

	for (int i = 0; i < di; i++)
		data.Add(destination[i]);

	return data;
}
