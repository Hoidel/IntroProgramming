namespace Homework2.Exercise1
{
    public class MyList
    {
        private int[] _items;
        private int _capacity;
        private int _size;

        /*
         * This is the constructor of your List, in this constructor you intialize all class variables.
         * 
         */
        public MyList(int initialCapacity = 8)
        {
            _items = new int[initialCapacity];
            _capacity = initialCapacity;
            _size = 0;
        }

        /*
         * Add the value to the list.
         * 
         * Tips:
         * Don't forget to resize the array if it's already full.
         * And don't forget to increase the size.
         * Duplicate values are allowed and do not need to be handled. 
         * 
         * Resizing an array can be a difficult endeavor, 
         * but you're allowed to do it simply by creating a new array with a larger size and moving all values from the old array to the new one. 
         */
        public void Add(int val)
        {


            throw new NotImplementedException();
        }

        /*
         * return the value at a certain index.
         * 
         * Tips:
         * If there is no value at that index we expect an IndexOutOfRangeException.
         * There might be a default value in the array without there being a value at the index. Consider the Size. 
         */
        public int ElementAt(int index)
        {
            throw new NotImplementedException();
        }

        /*
         * Return true if the list contains the given value. 
         */
        public bool Contains(int val)
        {
            throw new NotImplementedException();
        }

        /*
         * Remove all elements from the list.
         * 
         * Tips:
         * This can be done in many ways, try to think outside of the box here. 
         * But don't make it too complex, the solution should be simple. 
         * And don't forget to think about the class variables. 
         */
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /*
         * Remove the value at an index in the list. 
         * If there is no value at that index we expect an IndexOutOfRangeException.
         * 
         * Tips:
         * What happens to all numbers after the given index?
         * 
         * If you're keeping track of indexes here you're allowed to use the Normal List implementation
         */
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /*
         * Remove all occurrances of a value in the list.
         * 
         * Tips:
         * You shouldn't edit a list while looping trough it. 
         * Try to find a way to keep track of the indexes where a number should be removed and remove them later.
         * Don't forget about the size of the array.
         * Don't bother with resizing the array after removing elements, that's uneccecary. 
         * 
         * You might want to use the remove At method 
         */
        public void Remove(int val)
        {
            throw new NotImplementedException();
        }

        /*
         * Return the amount of items in the list.
         * 
         * Tips:
         * You already have a global variable to keep trackof this.
         */
        public int Count()
        {
            throw new NotImplementedException();
        }


        /*
         * Ignore this it's used for testing.
         */
        public IEnumerable<int> GetValues()
        {
            foreach(int val in _items.SkipLast(_capacity-_size))
            { yield return val; }
        }
    }
}