using System.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Strategy
{
    public class StrategySort
    {
        [Fact]
        public void Strategy_Select_Sort_WithoutDesign()
        {
            List<int> studentNumbers = new List<int> { 123, 678, 543, 189 };

            var objectToSort = ObjectToSort.CountyResidents;
            
            //Smell 
            var result = AlgoHelper.GetAlgo(objectToSort);

            Assert.Equal("Quick Sort", result);
        }

       [Fact]
        public void Strategy_Sort_With_Design(){
            
            //Arrange
            List<string> countyResidents = new List<string> { "ad", "ac", "ax", "zw" };
            var sortingStrategy = GetSortingOption(ObjectToSort.CountyResidents);

            //Act
            var result = sortingStrategy.Sort(countyResidents);

            //Assert
            Assert.Equal("Quick Sort", result);
            var first = countyResidents.First();
            Assert.Equal("ac",first);
        }

//poor choice
    internal class AlgoHelper
    {
        internal static string GetAlgo(ObjectToSort objectToSort)
        {
            switch (objectToSort)
            {
                case ObjectToSort.StudentNumber:
                    //Merge sort Algo
                    return "Merge Sort";
                case ObjectToSort.RailwayPassengers:
                    //HeapSort Algo
                    return "Heap Sort";
                case ObjectToSort.CountyResidents:
                    //QuickSort Algo
                    return "Quick Sort";
                default:
                    break;
            }

            return "No sorting Algo";
        }
    }

    private static ISortingStrategy GetSortingOption(ObjectToSort objectToSort)
    {
        ISortingStrategy sortingStrategy = null;

        switch (objectToSort)
        {
            case ObjectToSort.StudentNumber:
                sortingStrategy = new MergeSort();
                break;
            case ObjectToSort.RailwayPassengers:
                sortingStrategy = new HeapSort();
                break;
            case ObjectToSort.CountyResidents:
                sortingStrategy = new QuickSort();
                break;
            default:
                break;
        }
        return sortingStrategy;
    }
}

public enum ObjectToSort
{
    StudentNumber,
    RailwayPassengers,
    CountyResidents
}

public interface ISortingStrategy
{
    string Sort<T>(List<T> dataToBeSorted);
}

public class QuickSort : ISortingStrategy
{
    public string Sort<T>(List<T> dataToBeSorted)
    {
        //Logic for quick sort
        dataToBeSorted.Sort();
        return "Quick Sort";
    }
}

public class MergeSort : ISortingStrategy
{
    public string Sort<T>(List<T> dataToBeSorted)
    {
        //Logic for Merge sort
         dataToBeSorted.Sort();
        return "Merge Sort";
    }
}

public class HeapSort : ISortingStrategy
{
    public string Sort<T>(List<T> dataToBeSorted)
    {
        //Logic for Heap sort
        dataToBeSorted.Sort();
        
        return "Heap Sort";
    }
}
}
