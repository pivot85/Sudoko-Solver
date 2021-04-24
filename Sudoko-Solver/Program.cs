using System;
class SudokoSolver
{

	//size of the grid
	static int Size = 9;
	static bool solveTheGame(int[,] Sudoko, int row,int col)
	{

		// when we reach the row (8) and column (9) we return true to stop backtracking.
		if (row == Size - 1 && col == Size)
			return true;

		// moving to the next row when column value reach (9) after that column start from (0).
		if (col == Size)
		{
			row++;
			col = 0;
		}

		//check if the cell not empty so we move to next column
		if (Sudoko[row, col] != 0)
			return solveTheGame(Sudoko, row, col + 1);

		//filling up empty cells.
		for (int num = 1; num < 10; num++)
		{
			if (isCorrect(Sudoko, row, col, num))
			{
				//assigning value to the current position that we already checked is correct.
				//fill the position with number from (1-9).
				//then move to next column and check.

				Sudoko[row, col] = num;

				if (solveTheGame(Sudoko, row, col + 1))
					return true;
			}
			//removing the (number) and assign it to (0) because we got the wrong choice and try again with different number.
			Sudoko[row, col] = 0;
		}
		return false;
	}


	static void print(int[,] Sudoko)
	{
		for (int i = 0; i < Size; i++)
		{
			for (int j = 0; j < Size; j++)
				Console.Write(Sudoko[i, j] + " ");
				Console.WriteLine();
		}
	}

	//checking if the assigned num is correct to be place in cell or not.
	static bool isCorrect(int[,] Sudoko, int row, int col,int number)
	{

		//check if we have same number in row then return false
		for (int i = 0; i <= 8; i++)
			if (Sudoko[row, i] == number)
				return false;

		//check if we have same number in column then return false
		for (int i = 0; i <= 8; i++)
			if (Sudoko[i, col] == number)
				return false;

		//check if we have same number in the given Section of[3x3].

		if (row < 3) { row = 0; }     // start from index 0 ----> 2 [0,1,2]
		else if (row < 6) { row = 3; }// start from index 3 ----> 5 [3,4,5] ------> Rows
		else { row = 6; }             // start from index 6 ----> 8 [6,7,8]

		if (col < 3) { col = 0; }     // start from index 0 ----> 2 [0,1,2]
		else if (col < 6) { col = 3; }// start from index 3 ----> 5 [3,4,5] ------> Column
		else { col = 6; }             // start from index 6 ----> 8 [6,7,8]

		for (int i = row; i < row + 3; i++)
		{
			for (int j = col; j < col + 3; j++)
			{
				if (Sudoko[i, j] == number)
				{
					return false;
				}
			}
		}

		return true;
	}

	public static int insertNumber(int[,] Sudoko)
	{

		Console.WriteLine("please enter the row and column of the cell you want to fill ");
		Console.WriteLine("row : ");
		try
		{
			int row = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("col : ");
			int col = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("please enter a value between (1-9) ");

			int newValue = Convert.ToInt32(Console.ReadLine());
			if (newValue < 10 && newValue > 0)
				return Sudoko[row, col] = newValue;
			else
				Console.WriteLine("Please enter a valid number");
			return 0;
		}
		catch { Console.WriteLine("!!Error Message : [Row,Column] must have a valid input!! *PLEASE ENTER NUMBER BETWEEN (0) AND (8)* "); }
		return 0;
	}
	

	public static void Main(string []args)
	{

		//sample to test
		/*int[,] Sudoko={ { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				  { 0, 2, 0, 2, 0, 0, 0, 0, 0 },
				  { 0, 0, 0, 2, 0, 0, 0, 3, 1 },
				  { 0, 0, 3, 2, 1, 0, 0, 8, 0 },
				  { 1, 0, 0, 8, 6, 3, 0, 0, 5 },
				  { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
				  { 0, 3, 3, 0, 0, 0, 2, 5, 0 },
				  { 1, 0, 0, 0, 0, 0, 0, 7, 4 },
				  { 1, 0, 5, 2, 0, 6, 3, 0, 0 } }; */
		int[,] Sudoko = new int[9, 9];

		Console.WriteLine("-----------------");
		print(Sudoko);
		Console.WriteLine("-----------------");

		for (int i = 0; i < 1;)
		{
			insertNumber(Sudoko);
			Console.WriteLine("-----------------");
			print(Sudoko);
			Console.WriteLine("-----------------");
			Console.WriteLine("add another value? (type y to continue || press ENTER to get result)");
			if (Console.ReadLine() == "y".ToLower()) { i = 0; }
			else { break; }

		}
		if (solveTheGame(Sudoko, 0, 0))
			print(Sudoko);
		else
			Console.WriteLine("There is no solution");
	}
}

