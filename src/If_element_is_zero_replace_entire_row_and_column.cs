void Main()
{
	var arr = new int[,] {
				{ 1, 2, 3, 4, 5, 6, 7, 9, 8 },
				{ 1, 2, 0, 4, 5, 6, 7, 9, 8 },
				{ 1, 2, 3, 4, 5, 6, 7, 9, 8 },
				{ 1, 2, 3, 4, 2, 6, 7, 9, 8 },
				{ 1, 2, 3, 4, 5, 1, 7, 9, 8 },
				{ 1, 2, 3, 4, 5, 6, 7, 9, 8 },
				{ 1, 2, 3, 4, 5, 6, 0, 9, 8 }
			};

	arr.Dump();

	ReplaceRowAndColumns(arr, findNum: 0, replaceWithNum: 0);
	
	/*
	 * Algorithm: it can be done in two steps,
	 * 1: Collect rows and columns which have `findNum` in two boolean arrays
	 * 2: Iterate over the matrix, for each cell, check if current row or column has `findNum`
	 *    using the bool arrays created in step 1. If so, then replace the value with `replaceWithNum`
	 *
	 * C# syntax for accessing multidimentional arrays is bit different, be sure to familiarize the syntax
	 * Ref: https://msdn.microsoft.com/en-us/library/2yd9wwz4.aspx
	*/
}

private void ReplaceRowAndColumns(int[,] matrix, int findNum, int replaceWithNum)
{
	int rowCount = matrix.GetLength(0);
	int colCount = matrix.GetLength(1);

	bool[] row = new bool[rowCount];
	bool[] col = new bool[colCount];

	//collect rows and columns having `findNum`
	for (int i = 0; i < rowCount; i++)
	{
		for (int j = 0; j < colCount; j++)
		{
			if (matrix[i, j] == findNum)
			{
				row[i] = col[j] = true;
			}
		}
	}
	
	//iterate and replace each row and column
	for (int i = 0; i < rowCount; i++)
	{
		for (int j = 0; j < colCount; j++)
		{
			if (row[i] || col[j])
			{
				matrix[i, j] = replaceWithNum;
			}
		}
	}

	matrix.Dump();
}