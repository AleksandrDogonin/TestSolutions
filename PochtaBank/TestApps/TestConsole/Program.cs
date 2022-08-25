// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// 6, -1, 13, 3, 5, -2, 7, 9, 0, 14
// 5

//Dictionary 

var data = new int[]
{
    6, -1, 13, 3, 5, -2, 7, 9, 0, 14
};

var comparisonValue = 8;

var dataDictionary = new Dictionary<int, int>(data.Length);

foreach (var item in data)
{
    dataDictionary.Add(item, item);
}

GetResult(dataDictionary, comparisonValue);



void GetResult(Dictionary<int, int> input, int comporisonValue)
{
    var result = new Dictionary<int, int>(input.Count);

    foreach (var item in input)
    {
        if(result.ContainsKey(item.Key))
            continue;
 
        var searchValue = comporisonValue - item.Key;

        if (input.ContainsKey(searchValue))
        {
            result.Add(searchValue, item.Key);

            Console.WriteLine($"first: {searchValue}, second: {item.Key}");
        }
    }
}