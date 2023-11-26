using System;
using System.Linq;
using System.Net;
using System.Reflection;
using OurCompany;

/*
 * 23. Implement a routine to move all zeros of an integer array to the left side.
       Can you do it in-place?
 */
public class ArrayQuestion23
{
    public static void Main(string[] args)
    {
        int[] array1 = {0, 1, 2, 0, 0, 3, 0, 0, 4, 5, 0, 0, 0, 7, 0, 0};
        int[] array2 = {1, 2, 3, 0, 0, 0, 0, 4, 5, 0, 0, 0, 7, 0, 8, 0, 0, 0, 0};
        int[] array3 = {1, 2, 3, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6};
        int[] array4 = {1, 2, 3, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 7, 8};

       MyArray.Print(array1);
//       MoveZersLeft(array1);
       MoveZeroesLeftInPlace(array1);
       MyArray.Print(array1);

       MyArray.Print(array2);
//       MoveZersLeft(array2);
       MoveZeroesLeftInPlace(array2);
       MyArray.Print(array2);

        MyArray.Print(array3);
//        MoveZersLeft(array3);
        MoveZeroesLeftInPlace(array3);
        MyArray.Print(array3);

        MyArray.Print(array4);
//        MoveZersLeft(array4);
        MoveZeroesLeftInPlace(array4);
        MyArray.Print(array4);
    }

    private static void MoveZersLeft(int[] array)
    {
        int[] aux = new int[array.Length];
        int iAux = aux.Length - 1;
        for (int i = array.Length - 1; i >= 0; i--) {
            if (array[i] != 0) {
                aux[iAux] = array[i];
                iAux--;
            }
        }
        Array.Copy(aux, 0, array, 0, array.Length);
    }

    private static void MoveZeroesLeftInPlace(int[] array) {
        int zero = array.Length - 1; // Index looking for Zero
        int nonZero = zero; // Index looking for non zero
        while (zero >= 0 && nonZero >= 0) {
            // Swap a zero with a non zero element
            if (array[zero] == 0 && array[nonZero] != 0) {
                MyArray.swap(array, zero, nonZero);
            }
            if (array[zero] != 0) {
                zero--;
            }
            if (array[nonZero] == 0) {
                nonZero--;
            }
            // Make sure the nonZero index is always at the left size of the zero index
            if (nonZero > zero) {
                nonZero = zero - 1;
            }
        }
    }
}