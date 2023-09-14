using System;

public class MyArray {
    public static int[] Clone (int[] inputArray) {
        int[] clonedArray = new int[inputArray.Length];
        for (int i = 0; i < clonedArray.Length; i++)
        {
            clonedArray[i] = inputArray[i];
        }
        return clonedArray;
    }

    public static int[] ReadIntArray(string label, int length) {
        // Creating the array
        int[] array = new int[length];
        // Reading values for each index of the array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{label}[{i}] = ");
            array[i] = Convert.ToInt32(Console.ReadLine());
        }
        // Returnin the array
        return array;
    }
}