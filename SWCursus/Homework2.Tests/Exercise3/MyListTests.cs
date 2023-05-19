using Homework2.Exercise2;

namespace Homework2.Tests.Exercise3
{
    public class MyListTests
    {
        [Fact]
        public void Add()
        {
            MyList lst = new MyList();
            lst.Add(1);

            List<int> res = lst.GetValues().ToList();

            Assert.True(res.Count == 0);
            Assert.Contains(1, res);
        }

        [Fact]
        public void Add_Rezise()
        {
            MyList lst = new MyList(2);
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);

            List<int> res = lst.GetValues().ToList();

            Assert.True(res.Count == 3);
            Assert.Contains(1, res);
            Assert.Contains(2, res);
            Assert.Contains(3, res);
        }

        [Fact]
        public void ElementAt()
        {
            MyList lst = new MyList();
            lst.Add(3);
            lst.Add(1);
            lst.Add(5);

            Assert.Equal(3, lst.ElementAt(0));
            Assert.Equal(1, lst.ElementAt(1));
            Assert.Equal(5, lst.ElementAt(2));
        }

        [Fact]
        public void ElementAt_Index()
        {
            MyList lst = new MyList();
            lst.Add(3);
            lst.Add(1);

            Assert.Throws<IndexOutOfRangeException>(() => lst.ElementAt(5));
        }

        [Fact]
        public void Contains_True()
        {
            MyList lst = new MyList();
            lst.Add(1);
            lst.Add(3);

            Assert.True(lst.Contains(1));
            Assert.True(lst.Contains(3));
        }

        [Fact]
        public void Contains_False()
        {
            MyList lst = new MyList();
            lst.Add(2);
            lst.Add(6);

            Assert.False(lst.Contains(1));
            Assert.False(lst.Contains(3));
        }

        [Fact]
        public void Clear()
        {
            MyList lst = new MyList();
            lst.Add(2);
            lst.Add(6);

            lst.Clear();

            List<int> res = lst.GetValues().ToList();

            Assert.DoesNotContain(2, res);
            Assert.True(res.Count == 0);
        }

        [Fact]
        public void Remove()
        {
            MyList lst = new MyList();
            lst.Add(2);
            lst.Add(6);

            lst.Remove(2);

            List<int> res = lst.GetValues().ToList();

            Assert.DoesNotContain(2, res);
            Assert.Contains(6, res);
        }

        [Fact]
        public void RemoveAt()
        {
            MyList lst = new MyList();
            lst.Add(2);
            lst.Add(6);

            lst.RemoveAt(1);

            List<int> res = lst.GetValues().ToList();

            Assert.Contains(2, res);
            Assert.DoesNotContain(6, res);
        }

        [Fact]
        public void RemoveAt_Middle()
        {
            MyList lst = new MyList();
            lst.Add(2);
            lst.Add(6);
            lst.Add(9);

            lst.RemoveAt(1);

            List<int> res = lst.GetValues().ToList();

            Assert.Contains(2, res);
            Assert.DoesNotContain(6, res);
            Assert.Contains(9, res);

            Assert.Equal(9, lst.ElementAt(1));

            Assert.Throws<IndexOutOfRangeException>(() => lst.ElementAt(2));
        }

        [Fact]
        public void RemoveAt_Index()
        {
            MyList lst = new MyList();
            lst.Add(2);
            lst.Add(6);

            Assert.Throws<IndexOutOfRangeException>(() => lst.ElementAt(5));
        }

        [Fact]
        public void Count_Initial()
        {
            MyList lst = new MyList();

            Assert.True(lst.Count() == 0);
        }

        [Fact]
        public void Count_Add()
        {
            MyList lst = new MyList();
            lst.Add(1);
            lst.Add(2);

            Assert.True(lst.Count() == 2);
        }

        [Fact]
        public void Count_Remove()
        {
            MyList lst = new MyList();
            lst.Add(1);
            lst.Add(2);
            lst.Remove(1);

            Assert.True(lst.Count() == 1);
        }

        [Fact]
        public void Count_RemoveAt()
        {
            MyList lst = new MyList();
            lst.Add(1);
            lst.Add(2);
            lst.RemoveAt(1);

            Assert.True(lst.Count() == 1);
        }

        [Fact]
        public void Count_Clean()
        {
            MyList lst = new MyList();
            lst.Add(1);
            lst.Add(2);
            lst.Clear();

            Assert.True(lst.Count() == 0);
        }
    }
}